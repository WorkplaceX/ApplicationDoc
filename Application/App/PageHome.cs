namespace Application.Doc
{
    using Framework.Json;

    public class PageHome : Page
    {
        public PageHome(ComponentJson owner) : base(owner) 
        {
            new Html(this) { TextHtml = "<h1 class='title'>Web Application Framework</h1>" };
        }
    }
}
