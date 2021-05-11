namespace Application.Doc
{
    using Database.Doc;
    using Framework.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PageLoginSignOut : Page
    {
        public PageLoginSignOut(ComponentJson owner) : base(owner) 
        {

        }

        public override async Task InitAsync()
        {
            var pageMain = this.ComponentOwner<PageMain>();
            pageMain.LoginUserRoleAppList = new List<LoginUserRoleApp>();

            new Html(this) { TextHtml = "<h1>User Sign Out</h1>" };
            new Html(this) { TextHtml = "<p>You successfully signed out.</p>" };

            await pageMain.GridNavigate.LoadAsync();
        }
    }
}
