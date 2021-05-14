namespace Application.Doc
{
    using Database.Doc;
    using DatabaseIntegrate.Doc;
    using Framework;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// ApplicationDoc.
    /// </summary>
    public class AppMain : AppJson
    {
        public override async Task InitAsync()
        {
            CssFrameworkEnum = CssFrameworkEnum.Bulma;

            // Offset navbar
            HtmlNavbarOffset = new Html(this) { TextHtml = "<div class=\"is-fixed-top-offset\"></div>" };

            AlertContainer = new Div(this);

            PageMain = new PageMain(this);
            await PageMain.InitAsync();
        }

        public Html HtmlNavbarOffset;

        public PageMain PageMain;

        protected override void Setting(SettingArgs args, SettingResult result)
        {
            if (args.Grid != null)
            {
                // IsShowConfig for LoginRole Admin
                result.GridIsShowConfig = PageMain.LoginUserRoleAppList.Where(item => item.LoginRoleName == LoginRoleIntegrateApp.IdEnum.Admin.IdName()).Any();

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
                    var rowList = (await Data.Query<ContentSitemap>().QueryExecuteAsync());
                    rowList = rowList.OrderBy(item => item.NavigatePath).ThenBy(item => item.FileName).ToList(); // In memory sort
                    var sitemap = new StringBuilder();
                    sitemap.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sitemap.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:image=\"http://www.google.com/schemas/sitemap-image/1.1\">");
                    for (int i = 0; i < rowList.Count; i++)
                    {
                        var row = rowList[i];
                        if (row.NavigatePath != null) // Not a group
                        {
                            sitemap.Append("<url>");
                            var loc = string.Format("{0}{1}", args.RequestUrlHost, row.NavigatePath?.Substring(1));
                            sitemap.Append("<loc>" + loc + "</loc>");
                            var navigatePath = row.NavigatePath;
                            while (i < rowList.Count && (row = rowList[i]).FileName != null && row.NavigatePath == navigatePath)
                            {
                                // See also: https://developers.google.com/search/docs/advanced/sitemaps/image-sitemaps
                                sitemap.Append("<image:image>");
                                sitemap.Append($"<image:loc>{ args.RequestUrlHost + row.FileName.Substring(1) }</image:loc>");
                                sitemap.Append("</image:image>");
                                i += 1;
                            }
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
                if (fileNameRoot == "ads.txt" && args.ConfigCustom is JsonElement jsonElement && jsonElement.TryGetProperty("GoogleAdsTxt", out var googleAdsTxt))
                {
                    result.Data = Encoding.UTF8.GetBytes(googleAdsTxt.GetString());
                    return;
                }
            }

            // Download file (assets)
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

            // Download File (feedback)
            if (args.IsFileName("/feedback/", out var fileNameFeedback))
            {
                if (Guid.TryParse(fileNameFeedback, out var name))
                {
                    var row = (await Data.Query<Feedback>().Where(item => item.Name == name).QueryExecuteAsync()).SingleOrDefault();
                    if (row != null)
                    {
                        result.Data = row.AttachmentData;
                        return;
                    }
                }
            }

            // Request session deserialize
            result.IsSession = true;
        }

        protected override async Task NavigateSessionAsync(NavigateArgs args, NavigateSessionResult result)
        {
            if (args.IsFileName("/", out string fileNameRoot))
            {
                if (fileNameRoot == "log.csv")
                {
                    result.Data = File.ReadAllBytes(UtilFramework.FileNameLog);
                    return;
                }
            }

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
                    var content = (await Data.Query<Content>().Where(item => item.Name == name).QueryExecuteAsync()).FirstOrDefault();
                    if (content != null)
                    {
                        PageMain.Content.ComponentListClear();
                        await new PageContent(PageMain.Content, content).InitAsync();
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
                    AlertSessionExpired = new Alert(this, "Session expired!", AlertEnum.Warning);
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
