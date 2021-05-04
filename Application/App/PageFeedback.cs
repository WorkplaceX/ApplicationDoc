namespace Application.Doc
{
    using Database.Doc;
    using Framework;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PageFeedback : Page
    {
        public PageFeedback(ComponentJson owner, string navigatePath)
            : base(owner) 
        {
            this.NavigatePath = navigatePath;
        }

        /// <summary>
        /// Gets or sets NavigatePath. This is the path of the current content page.
        /// </summary>
        public string NavigatePath;

        public override async Task InitAsync()
        {
            new Html(this) { TextHtml = "<h1 class='title'>Feedback <i class='far fa-comment'></i></h1><p>Provide feedback to this page if you have any question regarding content or something should get updated.</p>" };

            await new GridFeedback(this).LoadAsync();

            Button = new Button(this) { TextHtml = "Send", CssClass = "button is-primary" };
        }

        public Button Button;

        protected override Task ProcessAsync()
        {
            if (Button.IsClick)
            {
                new Alert(this, "Feedback has been sent.", AlertEnum.Info);
            }
            return base.ProcessAsync();
        }
    }

    public class GridFeedback : Grid<Feedback>
    {
        public GridFeedback(ComponentJson owner) 
            : base(owner)
        {
            FeedbackList = new List<Feedback>();
            FeedbackList.Add(new Feedback());
        }

        public List<Feedback> FeedbackList;

        protected override void CellAnnotation(AnnotationArgs args, AnnotationResult result)
        {
            if (args.FieldName == nameof(Feedback.AttachmentFileName))
            {
                result.IsFileUpload = true;
            }
        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = FeedbackList.AsQueryable();
        }

        protected override void QueryConfig(QueryConfigArgs args, QueryConfigResult result)
        {
            result.GridMode = GridMode.Stack;
        }

        protected override async Task UpdateAsync(UpdateArgs args, UpdateResult result)
        {
            args.Row.Time = DateTime.UtcNow;

            if (args.Row.Name == null)
            {
                // Insert
                args.Row.Name = Guid.NewGuid();
                args.Row.NavigatePath = this.ComponentOwner<PageFeedback>().NavigatePath;
                args.Row.IpAddress = UtilFramework.ClientIpAddress;
                args.Row.UserAgent = UtilFramework.ClientUserAgent;
                await Data.InsertAsync(args.Row);
            }
            else
            {
                // Update
                var attachmentData = (await Data.Query<Feedback>().Where(item => item.Id == args.Row.Id).QueryExecuteAsync()).Single().AttachmentData;
                args.Row.AttachmentData = attachmentData;
                await Data.UpdateAsync(args.Row);
            }

            // Attachment
            if (args.FileUpload.Data != null)
            {
                // Write attachment data
                args.Row.AttachmentData = args.FileUpload.Data;
                args.Row.AttachmentFileName = args.FileUpload.FileName;
                await Data.UpdateAsync(args.Row);
            }

            args.Row.AttachmentData = null; // Remove data from session
            result.IsHandled = true;
        }
    }
}
