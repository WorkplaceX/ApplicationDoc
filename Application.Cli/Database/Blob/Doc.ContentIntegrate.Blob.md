# Blob (Feature)
The Blob feature is part of the **[Integrate](/feature-integrate/)**. By default the **Integrate** feature writes all data into C# code. For binary data such as images one might prefer to store such data into a file.

(Note)
Storing large text sql data in external files (for cli command generate) can also help to better track text changes with git DIFF before comiting to the repo.
(Note)

Following code example shows how to store data of sql column TextMd in external files. See AddBlob. This sql to C# Code data goes during cli command generate into the folder:

Application.Cli/Database/Blob/
```csharp
// File: Application.Cli/App/AppCliMain.cs

namespace Application.Cli.Doc
{
    using Application.Doc;
    using Database.Doc;
    using DatabaseIntegrate.Doc;
    using Framework.Cli;
    using Framework.DataAccessLayer;
    using System.Linq;

    public class AppCliMain : AppCli
    {
        public AppCliMain() :
            base(
                typeof(Content).Assembly, // Register Application.Database dll
                typeof(AppMain).Assembly) // Register Application dll
        {

        }

        /// <summary>
        /// Cli command generate.
        /// </summary>
        /// <param name="result"></param>
        protected override void CommandGenerateIntegrate(GenerateIntegrateResult result)
        {
            // Content
            result.Add(Data.Query<ContentIntegrate>().OrderBy(item => item.IdName));
            result.AddKey<Content>(nameof(Content.Name));
            result.AddBlob<ContentIntegrate>(nameof(Content.TextMd), (row) => row.IdName + ".md"); // Store field TextMd in an external file.
        }

        /// <summary>
        /// Cli command deployDb.
        /// </summary>
        protected override void CommandDeployDbIntegrate(DeployDbIntegrateResult result)
        {
            // Content
            result.Add(ContentIntegrateAppCli.RowList);
        }
    }
}
```