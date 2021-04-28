# Feature Integrate
This feature allows to read sql data and store it in C# code. It is part of the cli command **generate**. Such data can be embedded in:
* Application
* Cli

Later the data can be deployed for example to an other database with the cli command **deploydb**. This process works for specially structured data.

## Example Language
By default an application might support English, German and French. However a client might add an additional language and translate the application. Let's say into Italian. The manufacturer decides later to add Italian and the translation to his application by default. The **Integrate** feature allows now to read and store the Italian language and it's translation into the main C# repository. And make it part of the deployment process.

# SQL Data to C# Code and Back
* Cli command **generate** (Sql Data to C# Code)
* Cli command **deploydb** (C# Code to Sql Data)
![](/assets/feature-integrate.png)