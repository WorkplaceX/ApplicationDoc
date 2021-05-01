# Feature Navigate Request

WorkplaceX runs as single page application (SPA). The root component of every website is the classt **AppMain** derived from the class Framework.Json.AppJson. But how does **AppMain** know which data to display? There is two methods to override:

* Method **NavigateAsync();** is used to serve static requests which do not need session data. For example to serve a publicly available (*.pdf) file.
* Method **NavigateSessionAsync();** is used to serve requests which need session data. For example the user navigates to the url path /about/. The program can now prepare to display and serve the /about/ page.

(Note)
In WorkplaceX a **Page** is nothing else than a json component like a **Button** or any other component. The application root json component is **AppMain**. In the method **NavigateSessionAsync();** the json tree is just updated according the incoming url request.
(Note)

## Example Home, About and Page not Found
Following example has three pages:
* Home (localhost:5000/)
* About (localhost:5000/about/)
* Page Not Found (localhost:5000/anyotherurl
```csharp
namespace Application
{
    using Framework.Json;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        protected override Task NavigateAsync(NavigateArgs args, NavigateResult result)
        {
            // Request session deserialize.
            result.IsSession = true;

            return base.NavigateAsync(args, result);
        }

        protected override Task NavigateSessionAsync(NavigateArgs args, NavigateSessionResult result)
        {
            this.ComponentListClear(); // Remove all pages

            if (args.NavigatePath == "/")
            {
                new PageHome(this); 
            }
            else
            {
                if (args.NavigatePath == "/about/")
                {
                    new PageAbout(this);
                }
                else
                {
                    new PageNotFound(this);
                    result.IsPageNotFound = true; // Returns code 404.
                }
            }

            return base.NavigateSessionAsync(args, result);
        }
    }

    public class PageHome : Page
    {
        public PageHome(ComponentJson owner) 
            : base(owner)
        {
            new Html(this) { TextHtml = "Home" };
        }
    }

    public class PageAbout : Page
    {
        public PageAbout(ComponentJson owner)
            : base(owner)
        {
            new Html(this) { TextHtml = "About us" };
        }
    }

    public class PageNotFound : Page
    {
        public PageNotFound(ComponentJson owner)
            : base(owner)
        {
            new Html(this) { TextHtml = "Page not Found!" };
        }
    }
}
```

## Download Public File
Following example shows how to serve a simple public request to download file localhost:5000/my.txt:

```csharp
namespace Application
{
    using Framework.Json;
    using System.Text;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        protected override Task NavigateAsync(NavigateArgs args, NavigateResult result)
        {
            if (args.FileName == "my.txt")
            {
                result.Data = Encoding.Unicode.GetBytes("Hello World!");
            }

            return base.NavigateAsync(args, result);
        }
    }
}

```

## Download Private File
Following example shows how to download a private file (for example a customer bill). It only can be downloaded if the customer logged on (or in this example clicked the login button first):
```csharp
namespace Application
{
    using Framework.Json;
    using System.Text;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        public AppMain()
        {
            ButtonLogin = new Button(this) { TextHtml = "Login" };
        }

        public Button ButtonLogin;

        public bool IsLogin;

        protected override Task ProcessAsync()
        {
            if (ButtonLogin.IsClick)
            {
                IsLogin = true;
            }
            return base.ProcessAsync();
        }

        protected override Task NavigateAsync(NavigateArgs args, NavigateResult result)
        {
            if (args.NavigatePath.StartsWith("/bill/"))
            {
                result.IsSession = true; // Request session data deserialization. IsLogin is always false here because session data is not yet available (performance).
            }

            return base.NavigateAsync(args, result);
        }

        protected override Task NavigateSessionAsync(NavigateArgs args, NavigateSessionResult result)
        {
            if (args.NavigatePath == "/bill/my.txt")
            {
                if (IsLogin)
                {
                    result.Data = Encoding.Unicode.GetBytes("Dear Customer. Here your bill: USD $10.00");
                }
            }

            return base.NavigateSessionAsync(args, result);
        }
    }
}
```

## Trailing Slash
Following example shows how to forward a request to a trailing slash:
* localhost:5000/about
* localhost:5000/about/

```csharp
namespace Application
{
    using Framework.Json;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        protected override Task NavigateAsync(NavigateArgs args, NavigateResult result)
        {
            if (args.NavigatePath == "/about")
            {
                result.RedirectPath = "/about/"; // Sends a (HTTP 302) to the client
            }

            if (args.NavigatePath == "/about/")
            {
                result.IsSession = true; // Request url is ok, continue with deserialized session data
            }

            return base.NavigateAsync(args, result);
        }
    }
}
```