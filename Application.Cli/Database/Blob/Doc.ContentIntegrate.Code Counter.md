# Hello World Counter
Following example shows how to add a button and count on every click.
(Note)
**AppMain** is basically a json object. The variables Html and Button are references which are stored accordingly at the end of every request.
(Note)

```csharp
// File: Application/App/AppMain.cs

namespace Application
{
    using Framework.Json;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        public AppMain()
        {
            Html = new Html(this) { TextHtml = "Hello World" };
            Button = new Button(this) { TextHtml = "Click" };
        }

        public Html Html;

        public Button Button;

        public int Count;

        protected override Task ProcessAsync()
        {
            if (Button.IsClick)
            {
                Count += 1;
                Html.TextHtml = Count.ToString();
            }
            return base.ProcessAsync();
        }
    }
}
```

Counts on every click:
![](/assets/counter.png)
