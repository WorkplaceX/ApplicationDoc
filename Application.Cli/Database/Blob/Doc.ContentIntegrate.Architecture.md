# Software Architecture
A WorkplaceX application consists of two applications:
* Command Line Interface (CLI) Application (Launched with the **wpx** command)
* Web Application

The CLI application class name is **AppCliMain** and derives from Framework.Cli.AppCli. The CLI application contains for example the (*.sql) scripts to deploy for a new installation. The CLI application manages everything from configuration to build and compile to deployment.

The web application class name is **AppMain** and derives from Framework.Json.AppJson. Indicating that a WorkplaceX web application is nothing more than a json object.

## Start CLI Application and Web Application
The cli application can be launched from command prompt with
```cmd
wpx
```

The web application can be launched from command prompt with:
```cmd
wpx start
```

Both applications can also be started from Visual Studio:
![](/assets/visual-studio.png)
