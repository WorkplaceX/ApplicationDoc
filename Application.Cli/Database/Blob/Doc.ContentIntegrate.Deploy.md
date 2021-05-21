# Deploy (Feature)
Deploy a new version of the application to a local IIS server or to Azure App Service. The following configuration contains two entries:
* Deploy to local path. (C:/Temp/Publish/). Typically a local IIS server folder.
* Deploy to Azure App Service (azurewebsites.net)
```json
// File ConfigCli.json

{
  "EnvironmentName": "DEV",
  "EnvironmentList": [
    {
      "EnvironmentName": "DEV",
      "IsUseDeveloperExceptionPage": true,
      "IsRedirectHttps": false,
      "IsRedirectWww": false,
      "ConnectionStringFramework": "Data Source=localhost; Initial Catalog=ApplicationDoc; Integrated Security=True;",
      "ConnectionStringApplication": "Data Source=localhost; Initial Catalog=ApplicationDoc; Integrated Security=True;",
      "DeployAzureGitUrl": "https://User:Password@my.scm.azurewebsites.net:443/my.git",
      "DeployLocalFolderName": "C:/Temp/Publish/"
    },
...
```
Start deployment of application with the following command:

```cmd
npx deploy --azure
```

In order to deploy to a local IIS server use the option **--local**.

## Azure Configuration
It might be necessary to set the node version (for Angular server side rendering SSR) on the Azure portal. It is found here: 

"Configuration / Application settings / Name (**WEBSITE_NODE_DEFAULT_VERSION**) / Value (12.18.0)"

The git url is the git repository to deploy to in order to update a website. It can be found under "properties / Git Url"

## Angular Server Side Rendering Status
Server side rendering module turns a json object into html. It does never access any data on database or on ASP.NET Core. It's status can be tested by opening the following url:

* http://localhost:4001/ (Application running in Visual Studio)
* https://www.workplacex.org/Framework/Application.Website/Website01/server/main.js (Application running on IIS)

(Image Src="/assets/continuous-integration.jpg" Href="/continues-integration/" Title="Continues Integration" Description="Update application with continues integration (CI)")
(Image Src="/assets/architecture.jpg" Href="/architecture/" Title="Architecture" Description="Article explains difference between CLI and Web application and how they work together")
