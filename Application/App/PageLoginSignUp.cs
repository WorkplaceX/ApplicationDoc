namespace Application.Doc
{
    using Database.Doc;
    using Database.Doc.Calculated;
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
            new Html(this) { TextHtml = "<h1>User Sign Up</h1>", CssClass = "title" };
            new Html(this) { TextHtml = "<p>After sign up you'll receive an email with confirmation link to click and finish registration.</p>" };
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
                var userCalculated = Grid.RowList.Single();
                var user = new LoginUser { IsDelete = false };
                user.Name = userCalculated.Name;
                user.Password = userCalculated.Password;
                await Data.InsertAsync(user);
                Alert = new Alert(this.ComponentOwner<AppJson>(), "An email has been sent!", AlertEnum.Success);
                this.ComponentOwner<AppMain>().IsScrollToTop = true;

                // InsertUserRole (assign customer role)
                int loginRoleid = await LoginRoleIntegrateApp.IdEnum.Customer.Id();
                LoginUserRole userRole = new LoginUserRole { LoginUserId = user.Id, LoginRoleId = loginRoleid, IsActive = true };
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
    public class GridLoginUserSignUp : Grid<LoginUserSignUp>
    {
        public GridLoginUserSignUp(ComponentJson owner) 
            : base(owner)
        {
            LoginUserList.Add(new LoginUserSignUp());
        }

        public List<LoginUserSignUp> LoginUserList = new List<LoginUserSignUp>();
     
        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = LoginUserList.AsQueryable();
        }

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.GridMode = GridMode.Stack;
        }

        protected override Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            LoginUserList[0] = args.Row;
            result.IsHandled = true;
            return base.UpdateAsync(args, result);
        }
    }
}

namespace Database.Doc.Calculated
{
    using Framework.DataAccessLayer;

    public class LoginUserSignUp : Row
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}