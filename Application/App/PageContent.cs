namespace Application.Doc
{
    using Framework.Json;

    public class PageContent : Page
    {
        public PageContent(ComponentJson owner, string textHtml) : base(owner) 
        {
            var content = new Div(this) { CssClass = "content" };
            new Html(content) { TextHtml = textHtml };
        }
    }
}
