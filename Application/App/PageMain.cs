namespace Application.Doc
{
    using Database.dbo;
    using Database.Doc;
    using DatabaseIntegrate.Doc;
    using Framework.Json;
    using Framework.Json.Bulma;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PageMain : Page
    {
        public PageMain(ComponentJson owner) 
            : base(owner) 
        {
            BulmaNavbar = new BulmaNavbar(this) { BrandTextHtml = "<b>WorkplaceX</b>.org" };

            // Hero
            new Custom01(this);

            // Columns
            var columns = new DivContainer(this) { CssClass = "columns" };
            var column0 = new Div(columns) { CssClass = "column is-one-fifth has-background-white-ter" };
            var column1 = new Div(columns) { CssClass = "column" };
            var column2 = new Div(columns) { CssClass = "column is-one-fifth" };

            // Container
            // var container = new DivContainer(column1) { CssClass = "container" };
            Content = new Div(column1) { CssClass = "content content-bulma-framework" };
            // Content = column1;

            GridNavigate = new GridNavigate(this) { IsHide = true };
            GridLanguage = new GridLanguage(this) { IsHide = true };

            // Footer
            Footer = new Custom02(this);

            BulmaNavbar.GridAdd(GridLanguage, isNavbarEnd: true, isSelectMode: true);
            BulmaNavbar.GridAdd(GridNavigate);

            new BulmaNavbarMenu(column0) { Grid = GridNavigate };

            // Preserve login user
            if (this.ComponentOwner<AppMain>().IsNavigateReload<AppMain>(out var appJsonPrevious))
            {
                LoginUserRoleAppList = appJsonPrevious.PageMain.LoginUserRoleAppList;
            }
        }

        protected override Task ProcessAsync()
        {
            Footer.TextHtml= Util.Version; // Displays service heartbeat

            return base.ProcessAsync();
        }

        public override async Task InitAsync()
        {
            await GridLanguage.LoadAsync();
            await GridNavigate.LoadAsync(); // Navigate depends on language selection for translate
        }

        public Custom02 Footer;

        public Div Content;

        /// <summary>
        /// Gets LoginUserRoleApp. Currently singed in user with its roles.
        /// </summary>
        public List<LoginUserRoleApp> LoginUserRoleAppList = new List<LoginUserRoleApp>();

        /// <summary>
        /// Gets LoginUserName. Currently signed in user. Returns null 
        /// </summary>
        public string LoginUserName
        {
            get
            {
                string result = LoginUserRoleAppList.FirstOrDefault()?.LoginUserName;
                
                // Assert
                foreach (var item in LoginUserRoleAppList)
                {
                    Util.Assert(item.LoginUserName == result);
                }

                return result;
            }
        }

        /// <summary>
        /// Gets GridNavigate. Loaded once on login.
        /// </summary>
        public GridNavigate GridNavigate;

        /// <summary>
        /// Gets GridLanguage. Currently selected language. Loaded once on login.
        /// </summary>
        public GridLanguage GridLanguage;

        public BulmaNavbar BulmaNavbar;
    }

    public class GridNavigate : Grid<NavigateDisplay>
    {
        public GridNavigate(ComponentJson owner) 
            : base(owner)
        {

        }

        protected override Task RowSelectAsync()
        {
            string navigatePath = RowSelect.NavigatePath;
            this.ComponentOwner<AppJson>().Navigate(navigatePath);
            return Task.FromResult(0);
        }

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.ConfigGrid = new FrameworkConfigGridIntegrate { RowCountMax = 100 };
            base.QueryConfig(args, result);
        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            // IdName
            var loginUserName = this.ComponentOwner<PageMain>().LoginUserName;
            if (loginUserName == null)
            {
                // IdName of Guest User
                loginUserName = LoginUserIntegrateApp.IdEnum.Guest.IdName();
            }

            result.RowSelect = null;
            result.Query = args.Query.Where(item => item.LoginUserName == loginUserName);
        }
    }

    public class GridLanguage : Grid<Language>
    {
        public GridLanguage(ComponentJson owner) 
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            // English by default
            result.RowSelect = (rowList) => rowList.Where(item => item.Name == LanguageIntegrateApp.IdName(LanguageIntegrateApp.IdEnum.English)).Single();

            // Preserve language from previous session on browser refresh
            if (this.ComponentOwner<AppMain>().IsNavigateReload<AppMain>(out var appPrevious))
            {
                result.RowSelect = (rowList) => rowList.SingleOrDefault(item => item.LanguageId == appPrevious.PageMain.GridLanguage.RowSelect.LanguageId);
            }
        }
    }
}
