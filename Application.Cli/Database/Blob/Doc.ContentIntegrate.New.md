# Create a New Application (Feature)
To create a new WorkplaceX application go into an empty folder. Then run the following command:
```cmd
npx workplacex-cli new
```
It runs the npm package from https://www.npmjs.com/package/workplacex-cli

To create a new application you'll be asked:
## Copy folder Framework? - (Otherwise git submodule is used) [y/n]
Choose **yes** for full control. Updating the framework has to be done manually by updating the folder Framework/

Choose **no** for easy update. Every time you want to update the WorkplaceX framework go to folder Framework/ and run git pull. It's linked via git submodule.
## Copy folder Application.Website? - (otherwise framework website is used) [y/n]
Choose **yes** for full control and website customization without limits. Updating the framework has to be done manually by coping new files from folder Framework/Framework.Cli/Template/Application.Website/.

Cohoose **no** for easy update. Every time you update the framework, Application.Website is also up to date. Only default customization of the website is possible.

## Deploy the Database
Create a new MS-SQL database called "Application". By default the new application creates a file **ConfigCli.json** which uses the connection string: "Data Source=localhost; Initial Catalog=Application; Integrated Security=True;". This default is defined in the file: Application.Cli/App/AppCliMain.cs and can be changed.

You can also change the connection string in the file **ConfigCli.json** be running the following command:
```cmd
wpx config connectionString="Data Source=localhost; Initial Catalog=ApplicationDoc; Integrated Security=True;"
```
Once the connection string is set correctly and the database is created run:
```cmd
wpx deployDb
```
This command executes all sql scripts in the folder Application.Cli/DeployDb/

If you want to revert and delete the database tables and views run:
```cmd
wpx deployDb --drop
```
This runs all sql scripts in the folder Application.Cli/DeployDb/ ending with **Drop.sql**

(Note)
You can run the command wpx deployDb multiple times. The framework keeps track of the executed sql scripts in the sql table "dbo.FrameworkDeployDb". Like this it is possible to define proper update paths when deploying new application version to several sql servers.
(Note)

## Build and Start
The build command will compile the Angular application and the start command will launch the application at http://localhost:5000/
```cmd
wpx build
wpx start
```