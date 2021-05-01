# ExternalGit (Feature)
This feature allows to bundle multiple WorkplaceX applications stored on different repositories into one main application during cli command **build** process. Like this all applications are built into one ASP.NET Core application. All run on the same framework version. And all run on the same database and need not to be deployed individually. This requires all applications to have a distinct C# code namespace. And all applications need a distinct sql schema.

## Consolidate C# Code and SQL Scripts
The following folders are consolidated on the main application during cli command build process:
* ExternalGit/ (Into this folder all external repos are cloned into during build process)
* Application/App/ExternalGit/ (Into this folder all external AppMain C# code is consolidated)
* Application.Database/Database/ExternalGit/
* Application.Cli/App/ExternalGit/ (Into this folder all external AppCliMain C# code is consolidated)
* Application.Cli/DeployDb/ExternalGit/ (Into this folder all external SQL scripts are consolidated)
* Application.Cli/Database/ExternalGit/

## Configuration
Following example shows how to pack two external applications on top of the main application. One is in a public repo (ApplicationDemo). And one is in a private repo (ApplicationMy) and accessed with a personal token.
```json
// File: ConfigCli.json

...
  "ExternalGitList": [
    {
      "ExternalGit": "https://github.com/WorkplaceX/ApplicationDemo.git",
      "ExternalProjectName": "ApplicationDemo"
    },
    {
      "ExternalGit": "https://workplacex:myTokenABCDEF@github.com/WorkplaceX/ApplicationMy.git",
      "ExternalProjectName": "ApplicationMy"
    }
  ],
...
```

## SQL Table Filter
Since multiple applications run on the same database each application needs to know which sql tables belong to it. This can be achieved by overriding the method CommandGenerateFilter(); like this:
```csharp
// File: Application.Cli/App/AppCliMain.cs

namespace Application.Cli.Doc
{
    using Application.Doc;
    using Database.Doc;
    using Framework.Cli;
    using System.Linq;

    /// <summary>
    /// Command line interface application.
    /// </summary>
    public class AppCliMain : AppCli
    {
        public AppCliMain() :
            base(
                typeof(Language).Assembly, // Register Application.Database dll
                typeof(AppMain).Assembly) // Register Application dll
        {

        }

        /// <summary>
        /// Command cli generate.
        /// </summary>
        protected override void CommandGenerateFilter(GenerateFilterArgs args, GenerateFilterResult result)
        {
            result.FieldSqlList = args.FieldSqlList.Where(item => item.SchemaName == "Doc").ToList();
            result.TypeRowCalculatedList = args.TypeRowCalculatedList.Where(item => item.Namespace == "Database.Doc.Calculated").ToList();
        }
    }
}
```