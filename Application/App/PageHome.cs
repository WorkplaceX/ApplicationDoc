namespace Application.Doc
{
    using Framework.Json;

    public class PageHome : Page
    {
        public PageHome(ComponentJson owner) : base(owner) 
        {
            new Html(this) { TextHtml = "<h1>Web Application Framework</h1>", CssClass="title" };
        }
    }
}
