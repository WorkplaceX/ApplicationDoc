namespace Application.Doc
{
    using Framework.Json;

    public class PageContent : Page
    {
        public PageContent(ComponentJson owner) : base(owner) 
        {
            new Html(this) { TextHtml = "<h1 class='title'>Content</h1>" };

        }
    }
}
