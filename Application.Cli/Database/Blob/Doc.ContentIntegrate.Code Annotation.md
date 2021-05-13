# Data Annotation
Adding visual icons to a data grid can improve readability substantially. Following example shows positive numbers with a green up arrow. And negative numbers with a red down arrow.
![](/assets/data-grid-annotation.png)

## Implementation
This example builds on [Data Grid Example](/data-grid/) and shows how to annotate data grid cells.

```csharp
// File: Application/App/AppMain.cs

namespace Application.Doc
{
    using Database.dbo;
    using Framework.DataAccessLayer;
    using Framework.Json;
    using System.Linq;
    using System.Threading.Tasks;

    public class AppMain : AppJson
    {
        public override async Task InitAsync()
        {
            await new GridHelloWorld(this).LoadAsync();
        }
    }

    public class GridHelloWorld : Grid<HelloWorld>
    {
        public GridHelloWorld(ComponentJson owner) 
            : base(owner)
        {

        }

        protected override void Query(QueryArgs args, QueryResult result)
        {
            result.Query = Data.Query<HelloWorld>().OrderBy(item => item.Text);
        }

        protected override void CellAnnotation(AnnotationArgs args, AnnotationResult result)
        {
            if (args.FieldName == nameof(HelloWorld.Number))
            {
                if (args.Row.Number > 0)
                {
                    result.HtmlLeft = "<i class='fas fa-arrow-up green'></i>";
                }
                if (args.Row.Number < 0)
                {
                    result.HtmlLeft = "<i class='fas fa-arrow-down red'></i>";
                }
                if (args.Row.Number == 0)
                {
                    result.HtmlLeft = "<i class='fas fa-arrow-right'></i>";
                }
            }
        }
    }
}
```

