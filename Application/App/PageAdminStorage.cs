namespace Application.Doc
{
    using Database.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Threading.Tasks;

    public class PageAdminStorage : Page
    {
        public PageAdminStorage(ComponentJson owner) : base(owner)
        {
            new Html(this) { TextHtml = "<h1 class='title'>Storage</h1>" };
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
    }
}