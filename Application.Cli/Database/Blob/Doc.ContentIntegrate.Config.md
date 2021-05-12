# Configuration Environment (Feature)
All configuration values are stored in the file **ConfigCli.json**. It contains for example different configurations for DEV, TEST and PROD environment.

* File **ConfigCli.json** contains DEV, TEST and PROD configuration values
* File **ConfigServer.json** is deployed and contains **only** runtime (webserver) relevant values of **one** (currently selected) environment. Do not change the values in this file!

To switch for example to PROD environment configuration call:

```cmd
wpx env name=PROD
```
(Note)
Webserver relevant configuration values are copied on every wpx command from file **ConfigCli.json** to file **ConfigServer.json**.
(Note)

## Configuration Example
Following example contains a configuration for DEV and one for PROD environment.
```json
// File: ConfigCli.json

{
  "EnvironmentName": "DEV",
  "EnvironmentList": [
    {
      "EnvironmentName": "DEV",
      "IsUseDeveloperExceptionPage": false,
      "IsRedirectHttps": false,
      "IsRedirectWww": false,
      "ConnectionStringFramework": "Data Source=localhost; Initial Catalog=ApplicationDemo; Integrated Security=True;",
      "ConnectionStringApplication": "Data Source=localhost; Initial Catalog=ApplicationDemo; Integrated Security=True;",
      "DeployAzureGitUrl": null
    },
    {
      "EnvironmentName": "PROD",
      "IsUseDeveloperExceptionPage": false,
      "IsRedirectHttps": true,
      "IsRedirectWww": true,
      "ConnectionStringFramework": "Data Source=localhost; Initial Catalog=ApplicationDemo; Integrated Security=True;",
      "ConnectionStringApplication": "Data Source=localhost; Initial Catalog=ApplicationDemo; Integrated Security=True;",
      "DeployAzureGitUrl": null
    }
  ],
  "WebsiteList": [
    {
      "FolderNameAngular": "Application.Website/",
      "DomainNameList": [
        {
          "EnvironmentName": "DEV",
          "DomainName": "localhost",
          "AppTypeName": "Application.Demo.AppMain, Application",
          "IsRedirectHttps": false,
          "BingMapKey": null,
          "GoogleAnalyticsId": null
        },
        {
          "EnvironmentName": "PROD",
          "DomainName": "demo.workplacex.org",
          "AppTypeName": "Application.Demo.AppMain, Application",
          "IsRedirectHttps": false,
          "BingMapKey": null,
          "GoogleAnalyticsId": null
        }
      ]
    }
  ],
  "ExternalGitList": []
}
```

## Default Configuration
It's possible to define programmatically a default **ConfigCli.json** configuration. If there is no **ConfigCli.json** file it is created on any wpx command.

```csharp
// File: Application.Cli/App/AppCliMain.cs

namespace Application.Cli.Doc
{
    using Application.Doc;
    using Framework.Cli;
    using Framework.Cli.Config;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Command line interface application.
    /// </summary>
    public class AppCliMain : AppCli
    {
...
        /// <summary>
        /// Set default values if file ConfigCli.json does not exist.
        /// </summary>
        protected override void InitConfigCli(ConfigCli configCli)
        {
            string appTypeName = UtilCli.AppTypeName(typeof(AppMain));
            configCli.WebsiteList.Add(new ConfigCliWebsite()
            {
                DomainNameList = new List<ConfigCliWebsiteDomain>(new ConfigCliWebsiteDomain[] { new ConfigCliWebsiteDomain { EnvironmentName = "DEV", DomainName = "localhost", AppTypeName = appTypeName } }),
                FolderNameAngular = "Application.Website/",
            });

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Default ConnectionString (Windows)
                configCli.EnvironmentGet().ConnectionStringApplication = "Data Source=localhost; Initial Catalog=ApplicationDoc; Integrated Security=True;";
                configCli.EnvironmentGet().ConnectionStringFramework = "Data Source=localhost; Initial Catalog=ApplicationDoc; Integrated Security=True;";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Default ConnectionString (Linux)
                configCli.EnvironmentGet().ConnectionStringApplication = "Data Source=localhost; Initial Catalog=ApplicationDoc; User Id=SA; Password=MyPassword;";
                configCli.EnvironmentGet().ConnectionStringFramework = "Data Source=localhost; Initial Catalog=ApplicationDoc; User Id=SA; Password=MyPassword;";
            }
        }
...
    }
}
```