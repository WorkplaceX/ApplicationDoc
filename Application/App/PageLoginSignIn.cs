namespace Application.Doc
{
    using Database.Doc;
    using Framework;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PageLoginSignIn : Page
    {
        public PageLoginSignIn(ComponentJson owner)
            : base(owner)
        {
            new Html(this) { TextHtml = "<h1>User Sign In</h1>" };
            Grid = new GridSignIn(this);

            Button = new Button(this) { TextHtml = "Login", CssClass = "button is-primary" };
        }

        public override async Task InitAsync()
        {
            await Grid.LoadAsync();
        }

        public ComponentJson AlertError;

        protected override async Task ProcessAsync()
        {
            AlertError.ComponentRemove();
            if (Button.IsClick)
            {
                var loginUserSession = Grid.RowSelect;

                var loginUserRoleAppList = (await Data.Query<LoginUserRoleApp>().Where(item => item.LoginUserName == loginUserSession.Name && item.LoginUserRoleIsActive == true).QueryExecuteAsync());
                if (!loginUserRoleAppList.Any())
                {
                    // Username does not exist
                    this.AlertError = new Alert(this.ComponentOwner<AppJson>(), "Username or password wrong!", AlertEnum.Error);
                }
                else
                {
                    var pageMain = this.ComponentOwner<PageMain>();
                    string password = loginUserSession.PasswordHash; // User entered password
                    string passwordHash = loginUserRoleAppList.First().LoginUserPasswordHash; // In db stored hash
                    string passwordSalt = loginUserRoleAppList.First().LoginUserPasswordSalt; // In db stored salt
                    if (passwordHash != null && !UtilFramework.PasswordIsValid(password, passwordHash, passwordSalt))
                    {
                        // Password wrong
                        this.AlertError = new Alert(this.ComponentOwner<AppJson>(), "Username or password wrong!", AlertEnum.Error);
                    }
                    else
                    {
                        if (!loginUserRoleAppList.First().LoginUserIsActive)
                        {
                            // User not active
                            this.AlertError = new Alert(this.ComponentOwner<AppJson>(), "User not (yet) active.", AlertEnum.Warning);
                        }
                        else
                        {
                            // Login successful
                            pageMain.LoginUserRoleAppList = loginUserRoleAppList;
                            foreach (var item in pageMain.LoginUserRoleAppList)
                            {
                                item.LoginUserPasswordHash = null; // Remoe from session
                                item.LoginUserPasswordSalt = null; // Remove from session
                            }
                            var loginUserId = pageMain.LoginUserRoleAppList.First().LoginUserId;
                            await pageMain.GridNavigate.LoadAsync();
                            this.ComponentOwner<AppJson>().Navigate("/"); // Navigate to home after login
                        }
                    }
                }

                // Render grid ConfigDeveloper (coffee icon) if user is a developer.
                await Grid.LoadAsync();
            }
        }

        public GridSignIn Grid;

        public Button Button;
    }

    public class GridSignIn : Grid<LoginUser>
    {
        public GridSignIn(ComponentJson owner) : base(owner) 
        {
            LoginUserList.Add(new LoginUser { });
        }

        public List<LoginUser> LoginUserList = new List<LoginUser>();

        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = LoginUserList.AsQueryable();
        }

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.ConfigName = "SignIn"; // Special configuration. Same grid also used in user role mapping.
            result.GridModeEnum = GridModeEnum.Stack;
        }

        protected override void CellAnnotation(AnnotationArgs args, AnnotationResult result)
        {
            if (args.FieldName == nameof(LoginUser.PasswordHash))
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
