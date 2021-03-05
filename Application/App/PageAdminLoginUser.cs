namespace Application.Doc
{
    using Database.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;

    public class PageAdminLoginUser : Page
    {
        public PageAdminLoginUser(ComponentJson owner) : base(owner)
        {
            new Html(this) { TextHtml = "<h1 class='title'>User</h1>" };
            GridLoginUser = new GridAdminLoginUser(this);
            new Html(this) { TextHtml = "<h2 class='title'>Role</h1>" };
            GridLoginUserRole = new GridAdminLoginUserRole(this);
        }

        public override async Task InitAsync()
        {
            await GridLoginUser.LoadAsync();
        }

        public GridAdminLoginUser GridLoginUser;

        public GridAdminLoginUserRole GridLoginUserRole;
    }

    public class GridAdminLoginUser : Grid<LoginUser>
    {
        public GridAdminLoginUser(ComponentJson owner)
            : base(owner)
        {

        }

        protected override async Task RowSelectAsync()
        {
            await this.ComponentOwner<PageAdminLoginUser>().GridLoginUserRole.LoadAsync();
        }
    }

    public class GridAdminLoginUserRole : Grid<LoginUserRoleDisplay>
    {
        public GridAdminLoginUserRole(ComponentJson owner)
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            var navigateId = this.ComponentOwner<PageAdminLoginUser>().GridLoginUser.RowSelect.Id;
            result.Query = args.Query.Where(item => item.LoginUserId == navigateId);
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            var navigateLoginRole = new LoginUserRole { LoginUserId = args.Row.LoginUserId, LoginRoleId = args.Row.LoginRoleId, IsActive = args.Row.IsActive };
            if (args.Row.LoginUserRoleId != null)
            {
                navigateLoginRole.Id = args.Row.LoginUserRoleId.Value;
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
