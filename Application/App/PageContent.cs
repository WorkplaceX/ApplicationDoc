namespace Application.Doc
{
    using Framework.Json;

    public class PageContent : Page
    {
        public PageContent(ComponentJson owner, string textHtml, string titleLong) : base(owner) 
        {
            var content = new Div(this) { CssClass = "content" };
            new Html(content) { TextHtml = textHtml, IsNoSanatize = true, IsNoSanatizeScript = "Prism.highlightAll();" }; // IsNoSanatize because of html id for named anchor.
            this.ComponentOwner<AppJson>().Title = titleLong;
        }
    }
}
