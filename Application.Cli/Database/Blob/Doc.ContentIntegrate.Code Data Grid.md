# From Database to Data Grid
This example shows how to bring an sql table or view directly to the browser including filtering, sorting, paging and Excel export.
![](/assets/db-to-data-grid.png)

## Create SQL Table
First let's create a new database table.
```sql
CREATE TABLE HelloWorld
(
    Id INT PRIMARY KEY IDENTITY,
    Text NVARCHAR(256),
    Number FLOAT
)
```
## Generate C# Code
Next we need C# code for this table. Run command line:
```cmd
wpx generate
```

This generates the following code for us:

```csharp
// File: Application.Database/Database/Database.cs

namespace Database.dbo
{
    using Framework.DataAccessLayer;
    using System;

    [SqlTable("dbo", "HelloWorld")]
    public class HelloWorld : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Text", FrameworkTypeEnum.Nvarcahr)]
        public string Text { get; set; }

        [SqlField("Number", FrameworkTypeEnum.Float)]
        public double? Number { get; set; }
    }
}
```

## Show Data in App
In order to load the data grid write:
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
    }
}
```
Start the program. It looks like this, sorting and filtering already included and working:
![](/assets/data-grid.png)