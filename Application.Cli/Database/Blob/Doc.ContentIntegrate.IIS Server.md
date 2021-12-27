# Local IIS Server <i class="fas fa-server"></i>
WorkplaceX web application runs on local IIS server on Windows 10.

In order to run .NET applications on local IIS server install:

* [.NET Hosting Bundle](https://dotnet.microsoft.com/download/dotnet) (ASP.NET Core. Click **Hosting Bundle**, not x86 or x64!)
* [Node for IIS](https://github.com/Azure/iisnode/releases) (Click file: **iisnode-full.msi**)

For SSL see: [SSL Installation](https://github.com/WorkplaceX/Util/tree/master/SSL)

After successful installation Windows "add remove programs" should look like this:
![](/assets/iis.png)

## IIS Server Log (Exceptions)
If for example an empty page is shown enable log in web.config like this:
![](/assets/iislog.png)

## Local IIS Server and ConnectionString
If Integrated Security is used in the ConnectionString ensure local IIS server uses "your" user in the application pool.
![](/assets/iisuser.png)

## See also:
(Image Src="/assets/continuous-integration.jpg" Href="/continuous-integration/" Title="Continues Integration" Description="Update application with continues integration (CI)")
(Image Src="/assets/architecture.jpg" Href="/architecture/" Title="Architecture" Description="Article explains difference between CLI and Web application and how they work together")
