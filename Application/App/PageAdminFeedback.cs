namespace Application.Doc
{
    using Database.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Threading.Tasks;

    public class PageAdminFeedback : Page
    {
        public PageAdminFeedback(ComponentJson owner) : base(owner)
        {
            var content = new Div(this) { CssClass = "content" };
            new Html(content) { TextHtml = "<h1>Feedback</h1>" };
        }

        public override async Task InitAsync()
        {
            await new GridAdminFeedback(this).LoadAsync();
        }
    }

    public class GridAdminFeedback : Grid<Feedback>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GridAdminFeedback(ComponentJson owner)
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = Data.Query<Feedback>();
        }

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.ConfigName = "Admin";
            base.QueryConfig(args, result);
        }

        protected override void CellAnnotation(AnnotationArgs args, AnnotationResult result)
        {
            if (args.FieldName == nameof(Feedback.AttachmentFileName) && args.Row.AttachmentData != null)
            {
                result.Html = $"<a href='/feedback/{ args.Row.Name }'>{ args.Row.AttachmentFileName }</a>";
            }
        }

        protected override void Truncate(TruncateArgs args)
        {
            if (args.Row.AttachmentData != null)
            {
                args.Row.AttachmentData = new byte[0];
            }
        }
    }
}