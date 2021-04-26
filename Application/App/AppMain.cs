namespace Application.Doc
{
    using Database.Doc;
    using DatabaseIntegrate.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        public override async Task InitAsync()
        {
            CssFrameworkEnum = CssFrameworkEnum.Bulma;

            // Offset navbar
            HtmlNavbarOffset = new Html(this) { TextHtml = "<div class=\"is-fixed-top-offset\"></div>" };

            PageMain = new PageMain(this);
            await PageMain.InitAsync();
        }

        public Html HtmlNavbarOffset;

        public PageMain PageMain;

        protected override void Setting(SettingArgs args, SettingResult result)
        {
            if (args.Grid != null)
            {
                // IsShowConfig for LoginRole Developer, Admin
                result.GridIsShowConfig = PageMain.LoginUserRoleAppList.Where(item => item.LoginRoleName == LoginRoleIntegrateApp.IdEnum.Developer.IdName() || item.LoginRoleName == LoginRoleIntegrateApp.IdEnum.Admin.IdName()).Any();

                // IsShowConfigDeveloper for LoginRole Developer
                result.GridIsShowConfigDeveloper = PageMain.LoginUserRoleAppList.Where(item => item.LoginRoleName == LoginRoleIntegrateApp.IdEnum.Developer.IdName()).Any();
            }
        }

        protected override async Task NavigateAsync(NavigateArgs args, NavigateResult result)
        {
            // Download robots.txt and sitemap.xml
            if (args.IsFileName("/", out string fileNameRoot))
            {
                if (fileNameRoot == "robots.txt")
                {
                    var robots = string.Format("Sitemap: {0}sitemap.xml", args.RequestUrlHost);
                    result.Data = Encoding.UTF8.GetBytes(robots);
                    return;
                }
                if (fileNameRoot == "sitemap.xml")
                {
                    var sitemap = new StringBuilder();
                    sitemap.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sitemap.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
                    var rowList = (await Data.Query<Navigate>().Where(item => item.IsContent == true).QueryExecuteAsync());
                    foreach (var row in rowList)
                    {
                        if (row.NavigatePath != null) // Not a group
                        {
                            sitemap.Append("<url>");
                            var loc = string.Format("{0}{1}", args.RequestUrlHost, row.NavigatePath?.Substring(1));
                            sitemap.Append("<loc>" + loc + "</loc>");
                            if (row.SitemapDate is DateTime sitemapDate)
                            {
                                var lastmod = sitemapDate.ToString("yyyy-MM-dd");
                                sitemap.Append("<lastmod>");
                                sitemap.Append(lastmod);
                                sitemap.Append("</lastmod>");
                            }
                            sitemap.Append("</url>");
                        }
                    }
                    sitemap.Append("</urlset>");
                    result.Data = Encoding.UTF8.GetBytes(sitemap.ToString());
                    return;
                }
            }

            // Download file
            if (args.IsFileName("/assets/", out string fileName))
            {
                var row = (await Data.Query<StorageFile>().Where(item => item.FileName == fileName).QueryExecuteAsync()).SingleOrDefault();
                if (row != null)
                {
                    result.Data = row.Data;
                    if (args.HttpQuery.ContainsKey("imageThumbnail"))
                    {
                        result.Data = row.DataImageThumbnail;
                    }
                    return;
                }
            }
         
            // Request session deserialize
            result.IsSession = true;
        }

        protected override async Task NavigateSessionAsync(NavigateArgs args, NavigateSessionResult result)
        {
            var row = PageMain.GridNavigate.RowList.SingleOrDefault(item => item.NavigatePath == args.NavigatePath);

            if (row != null)
            {
                if (PageMain.GridNavigate.RowSelect != row)
                {
                    PageMain.GridNavigate.RowSelect = row;
                }
                if (row.IsContent)
                {
                    string name = row.Name;
                    var contentPage = (await Data.Query<Content>().Where(item => item.Name == name).QueryExecuteAsync()).FirstOrDefault();
                    if (contentPage != null)
                    {
                        PageMain.Content.ComponentListClear();
                        new PageContent(PageMain.Content, contentPage.TextHtml, contentPage.TitleLong);
                        return;
                    }
                }
                else
                {
                    var pageType = Type.GetType("Application.Doc." + row.PageTypeName);
                    if (pageType?.IsSubclassOf(typeof(Page)) == true)
                    {
                        if (PageMain.Content.List.FirstOrDefault()?.GetType() != pageType)
                        {
                            PageMain.Content.ComponentListClear();
                            var page = (Page)Activator.CreateInstance(pageType, new object[] { PageMain.Content });
                            await page.InitAsync();
                            return;
                        }
                    }
                }
            }

            // Redirect trailing slash
            if (!args.NavigatePath.EndsWith("/"))
            {
                row = PageMain.GridNavigate.RowList.SingleOrDefault(item => item.NavigatePath == args.NavigatePath + "/");
                if (row != null)
                {
                    result.RedirectPath = args.NavigatePath + "/";
                    return;
                }
            }

            // Page not found
            PageMain.Content.ComponentListClear();
            await new PageNotFound(PageMain.Content).InitAsync();
            result.IsPageNotFound = true;
        }

        public Alert AlertSessionExpired;

        protected override Task ProcessAsync()
        {
            if (IsSessionExpired)
            {
                if (AlertSessionExpired == null)
                {
                    AlertSessionExpired = new Alert(this, "Session expired!", AlertEnum.Warning, HtmlNavbarOffset.ComponentIndex() + 1);
                    IsScrollToTop = true;
                }
            }
            else
            {
                AlertSessionExpired?.ComponentRemove();
            }

            return base.ProcessAsync();
        }
    }
}
