namespace Application.Doc
{
    using Database.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Threading.Tasks;

    public class PageAdminContent : Page
    {
        public PageAdminContent(ComponentJson owner) : base(owner)
        {
            new Html(this) { TextHtml = "<h1 class='title'>Content</h1>" };
            GridContent = new GridContent(this);
            ButtonPublish = new Button(this) { TextHtml = "Publish", CssClass = "button is-primary" };
        }

        public GridContent GridContent;

        public Button ButtonPublish;

        public override async Task InitAsync()
        {
            await GridContent.LoadAsync();
        }

        protected override async Task ProcessAsync()
        {
            if (ButtonPublish.IsClick)
            {
                string textMd = GridContent.RowSelect.TextMd;
                await Util.ContentPublish(textMd);
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
            result.Query = Data.Query<Content>();
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            await Data.UpdateAsync(args.Row);
            result.IsHandled = true;
        }
    }
}