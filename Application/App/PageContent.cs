namespace Application.Doc
{
    using Database.Doc;
    using Framework.Json;
    using System.Threading.Tasks;

    public class PageContent : Page
    {
        public PageContent(ComponentJson owner, Content content) : base(owner) 
        {
            Content = new Div(this) { CssClass = "content" };
            new Html(Content) { TextHtml = content.TextHtml, IsNoSanatize = true, IsNoSanatizeScript = "Prism.highlightAll();" }; // IsNoSanatize because of html id for named anchor.
            this.ComponentOwner<AppJson>().Title = content.TitleLong;
            NavigatePath = content.NavigatePath;
        }

        public Div Content;

        public string NavigatePath;

        public override async Task InitAsync()
        {
            await new PageFeedback(Content, NavigatePath).InitAsync();
        }
    }
}
