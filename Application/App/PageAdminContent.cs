namespace Application.Doc
{
    using Database.Doc;
    using Framework;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PageAdminContent : Page
    {
        public PageAdminContent(ComponentJson owner) : base(owner)
        {
            new Html(this) { TextHtml = "<h1 class='title'>Content</h1>" };
            GridContent = new GridContent(this);
            GridContentMd = new GridContentMd(this);
            ButtonPublish = new Button(this) { TextHtml = "Publish", CssClass = "button is-primary" };
            var content = new Div(this) { CssClass = "content" };
            Html = new Html(content);
        }

        public Button ButtonPublish;
        
        public GridContent GridContent;
        
        public GridContentMd GridContentMd;

        public Html Html;

        public override async Task InitAsync()
        {
            await GridContent.LoadAsync();
        }

        protected override async Task ProcessAsync()
        {
            if (ButtonPublish.IsClick)
            {
                await Util.ContentPublish();

                // Refresh navigation
                await this.ComponentOwner<PageMain>().GridNavigate.LoadAsync();
            }
        }
    }

    public class GridContent : Grid<Content>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GridContent(ComponentJson owner)
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = Data.Query<Content>().OrderBy(item => item.NavigatePath);
        }

        protected override async Task RowSelectAsync()
        {
            await this.ComponentOwner<PageAdminContent>().GridContentMd.LoadAsync();
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            await Data.UpdateAsync(args.Row);
            result.IsHandled = true;
        }

        protected override async Task InsertAsync(InsertArgs args, InsertResult result)
        {
            await Data.InsertAsync(args.Row);
            result.IsHandled = true;
        }
    }

    public class GridContentMd : Grid<Content>
    {
        public GridContentMd(ComponentJson owner) 
            : base(owner)
        {

        }

        public PageAdminContent PageAdminContent => this.ComponentOwner<PageAdminContent>();

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.ConfigName = "Md";
        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            var list = new List<Content>();
            list.Add(PageAdminContent.GridContent.RowSelect);
            result.Query = list.AsQueryable();

            PageAdminContent.Html.TextHtml = PageAdminContent.GridContent.RowSelect.TextHtml;
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            result.Row.TextHtml = UtilFramework.TextMdToHtml(args.Row.TextMd);
            result.Row.SitemapDate = DateTime.UtcNow;
            await Data.UpdateAsync(result.Row);
            Data.RowCopy(result.Row, PageAdminContent.GridContent.RowSelect);
            PageAdminContent.Html.TextHtml = result.Row.TextHtml;
            result.IsHandled = true;
        }
    }
}