namespace Application.Doc
{
    using Framework.Json;

    public class PageNotFound : Page
    {
        public PageNotFound(ComponentJson owner) : base(owner) 
        {
            var content = new Div(this) { CssClass = "content" };
            new Html(content) { TextHtml = "<h1>Page not Found</h1>" };
            string text = "<article class=\"message is-warning\"><div class=\"message-body\">The requested URL was not found on this server.</div></article>";
            new Html(content) { TextHtml = text };
        }
    }
}
