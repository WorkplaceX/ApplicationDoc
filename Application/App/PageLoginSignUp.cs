namespace Application.Doc
{
    using Database.Doc;
    using DatabaseIntegrate.Doc;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PageLoginSignUp : Page
    {
        public PageLoginSignUp(ComponentJson owner) : base(owner)
        {
            new Html(this) { TextHtml = "<h1 class='title'>User Sign Up</h1>" };
            new Html(this) { TextHtml = "<p>After sign up you'll receive an email with confirmation link to click and finish registration.</p><div></div>" };
            Grid = new GridLoginUserSignUp(this);
            Button = new Button(this) { TextHtml = "Sign Up", CssClass = "button is-primary" };
        }

        public override async Task InitAsync()
        {
            await Grid.LoadAsync();
        }

        protected override async Task ProcessAsync()
        {
            Alert.ComponentRemove();
            if (Button.IsClick)
            {
                // Insert LoginUser
                var userLocal = Grid.RowList.Single();
                var user = new LoginUser { IsDelete = false };
                user.Name = userLocal.Name;
                user.PasswordHash = userLocal.PasswordHash;
                user.PasswordSalt = userLocal.PasswordSalt;
                await Data.InsertAsync(user);
                Alert = new Alert(this.ComponentOwner<AppJson>(), "Sign up successfull! Email has been sent for confirmation! Go to <a href='/signin/'>Sign in</a>", AlertEnum.Success, 1);
                this.ComponentOwner<AppMain>().IsScrollToTop = true;

                // InsertUserRole (assign Guest and Customer role)
                int loginRoleid = await LoginRoleIntegrateApp.IdEnum.Guest.Id();
                LoginUserRole userRole = new LoginUserRole { LoginUserId = user.Id, LoginRoleId = loginRoleid, IsActive = true };
                await Data.InsertAsync(userRole);
                loginRoleid = await LoginRoleIntegrateApp.IdEnum.Customer.Id();
                userRole = new LoginUserRole { LoginUserId = user.Id, LoginRoleId = loginRoleid, IsActive = true };
                await Data.InsertAsync(userRole);
            }
        }

        public Alert Alert;

        public GridLoginUserSignUp Grid;

        public Button Button;
        
        public Button ButtonModal;
    }

    /// <summary>
    /// Data grid.
    /// </summary>
    public class GridLoginUserSignUp : Grid<LoginUser>
    {
        public GridLoginUserSignUp(ComponentJson owner) 
            : base(owner)
        {
            LoginUserList.Add(new LoginUser());
        }

        public List<LoginUser> LoginUserList = new List<LoginUser>();
     
        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = LoginUserList.AsQueryable();
        }

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.ConfigName = "SignUp";
            result.GridMode = GridMode.Stack;
        }

        protected override void CellAnnotation(AnnotationArgs args, AnnotationResult result)
        {
            if (args.FieldName == nameof(LoginUser.PasswordHash) || args.FieldName == nameof(LoginUser.PasswordSalt))
            {
                result.IsPassword = true;
            }
        }

        protected override Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            LoginUserList[0] = args.Row;
            result.IsHandled = true;
            return base.UpdateAsync(args, result);
        }
    }
}