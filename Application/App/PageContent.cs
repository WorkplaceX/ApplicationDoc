namespace Application.Doc
{
    using Database.Doc;
    using Framework.Json;
    using System.Threading.Tasks;

    public class PageContent : Page
    {
        public PageContent(ComponentJson owner, Content contentRow) : base(owner) 
        {
            // Content
            new Html(this) { TextHtml = contentRow.TextHtml, IsNoSanatize = true, IsNoSanatizeScript = "if (typeof Prism != 'undefined') { Prism.highlightAll(); }" }; // IsNoSanatize because of html id for named anchor.
            
            // Title, Description
            this.ComponentOwner<AppJson>().Title = contentRow.TitleLong;
            this.ComponentOwner<AppJson>().Description = contentRow.Description;
            NavigatePath = contentRow.NavigatePath;
        }

        public string NavigatePath;

        public override async Task InitAsync()
        {
            await new PageFeedback(this, NavigatePath).InitAsync();
        }
    }
}
