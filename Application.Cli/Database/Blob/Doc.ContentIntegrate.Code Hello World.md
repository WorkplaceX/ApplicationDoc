# Hello World Example
Following example shows how to display a simple text.

The namespace Framework.Json contains all semantic components to build a logical tree. It contains components like button, navbar or data grid. This logical tree is different from the html tree. The logical tree contains only relevant data to build an html tree. Only the logical tree is serialized and stored on the server at the end of a request.

(Note)
**AppJson** is the root component of any application. On an incoming request the framework looks in the file ConfigServer.json to decide which root component to take.
(Note)


```csharp
namespace Application
{
    using Framework.Json;

    public class AppMain : AppJson
    {
        public AppMain()
        {
            new Html(this) { TextHtml = "Hello World" };
        }
    }
}
```

Output looks like this:
![](/assets/hello-world.png)