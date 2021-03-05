namespace Application.Doc
{
    using Database.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;

    public class PageAdminNavigate : Page
    {
        public PageAdminNavigate(ComponentJson owner) : base(owner) 
        {
            new Html(this) { TextHtml = "<h1 class='title'>Navigate</h1>" };
            GridNavigate = new GridAdminNavigate(this);
            new Html(this) { TextHtml = "<h2 class='title'>Role</h1>" };
            GridNavigateRole = new GridAdminNavigateRole(this);
        }

        public override async Task InitAsync()
        {
            await GridNavigate.LoadAsync();
        }

        public GridAdminNavigate GridNavigate;

        public GridAdminNavigateRole GridNavigateRole;
    }

    public class GridAdminNavigate : Grid<Navigate>
    {
        public GridAdminNavigate(ComponentJson owner) 
            : base(owner)
        {

        }

        protected override async Task RowSelectAsync()
        {
            await this.ComponentOwner<PageAdminNavigate>().GridNavigateRole.LoadAsync();
        }
    }

    public class GridAdminNavigateRole : Grid<NavigateRoleDisplay>
    {
        public GridAdminNavigateRole(ComponentJson owner) 
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            var navigateId = this.ComponentOwner<PageAdminNavigate>().GridNavigate.RowSelect.Id;
            result.Query = args.Query.Where(item => item.NavigateId == navigateId);
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            var navigateLoginRole = new NavigateRole { NavigateId = args.Row.NavigateId, LoginRoleId = args.Row.LoginRoleId, IsActive = args.Row.IsActive };
            if (args.Row.NavigateRoleId != null)
            {
                navigateLoginRole.Id = args.Row.NavigateRoleId.Value;
                await Data.UpdateAsync(navigateLoginRole);
            }
            else
            {
                await Data.InsertAsync(navigateLoginRole);
            }
            result.IsHandled = true;
        }
    }
}
