# Install and Getting Started
The following components need to be installed on the machine as prerequisite:
* [Node.js](https://nodejs.org/en/) (LTS Version)
* [.NET Core](https://dotnet.microsoft.com/download) (Version 5.0)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Free Express Edition)

Web [Application Demo](https://github.com/WorkplaceX/ApplicationDemo) is a comprehensive example to get started with:

(Image Src="/assets/data-grid-tile.jpg" Href="https://www.youtube.com/watch?v=ORDp3uNPrSY")

## Install
```cmd
### Git clone (parameter recursive clones also required submodule Framework):
git clone https://github.com/WorkplaceX/ApplicationDemo.git --recursive

cd ApplicationDemo

### On first launch it will ask to register wpx command in environment path:
./wpx.cmd # For Windows
./wpx.sh # For Linux

### From now on just use:
wpx

### Build
wpx build # Builds client (Angular) and server (.NET)

### Set ConnectionString
wpx config connectionString="Data Source=localhost; Initial Catalog=ApplicationDemo; Integrated Security=True;" # Example Windows
wpx config connectionString="Data Source=localhost; Initial Catalog=ApplicationDemo; User Id=SA; Password=MyPassword;" # Example Linux

### Deploy Database
wpx deployDb

### Start
wpx start # http://localhost:5000/

### Stop
killall -g -SIGKILL -r Application.S # Example Linux. Close group (regular expression for Application.Server)
sudo netstat -ltp # Show all program listening to port # Example Linux```

## Command Line Interface (CLI)
The framework provides a command line interface (CLI) with all necessary functions like build, deploy and so on. In the root folder type cli.
```cmd
cd ApplicationDemo
wpx
```
All available framework CLI commands are listed like this:
![](/assets/cli.png)