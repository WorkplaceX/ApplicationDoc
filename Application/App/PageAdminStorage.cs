namespace Application.Doc
{
    using Database.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Linq;
    using System.Threading.Tasks;

    public class PageAdminStorage : Page
    {
        public PageAdminStorage(ComponentJson owner) : base(owner)
        {
            var content = new Div(this) { CssClass = "content" };
            new Html(content) { TextHtml = "<h1>Storage</h1>" };
        }

        public override async Task InitAsync()
        {
            await new GridStorage(this).LoadAsync();
        }
    }

    public class GridStorage : Grid<StorageFileDisplay>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GridStorage(ComponentJson owner)
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = Data.Query<StorageFileDisplay>();
        }

        protected override void CellAnnotation(AnnotationArgs args, AnnotationResult result)
        {
            if (args.FieldName == nameof(StorageFileDisplay.FileName))
            {
                result.IsFileUpload = true;
                if (args.Row.IsData != null)
                {
                    result.HtmlRight = $"<a href=\"" + "/assets/" + args.Row.FileName + "\">" + "Open" + "</a>";
                }
            }
        }

        protected override void CellAnnotationFilterNew(AnnotationFilterNewArgs args, AnnotationResult result)
        {
            if (args.IsNew && args.FieldName == nameof(StorageFileDisplay.FileName))
            {
                result.IsFileUpload = true;
            }
        }

        protected override async Task InsertAsync(InsertArgs args, InsertResult result)
        {
            var row = new StorageFile();
            Data.RowCopy(args.Row, row);
            if (args.FileUpload != null)
            {
                row.Data = args.FileUpload.Data;
                row.FileName = args.FileUpload.FileName;
                result.Row.FileName = row.FileName;
                result.Row.IsData = true;
            }
            row.IsIntegrate = true;
            await Data.InsertAsync(row);
            result.Row.Id = row.Id;
            result.IsHandled = true;
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            var row = new StorageFile();
            Data.RowCopy(args.Row, row);
            if (args.FileUpload != null)
            {
                row.Data = args.FileUpload.Data;
            }
            else
            { 
                row.Data = (await Data.Query<StorageFile>().Where(item => item.Id == row.Id).QueryExecuteAsync()).Single().Data;
            }
            row.IsIntegrate = true;
            await Data.UpdateAsync(row);
            result.IsHandled = true;
        }
    }
}