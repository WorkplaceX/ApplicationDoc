# Application Doc (CMS)
An open source document management platform developed and released by WorkplaceX. Any company and organization can use this product to manage it's web content.

## Customers
Application Doc (CMS) is used for the web site:
* https://www.workplacex.org

## Download
The application can be downloaded from
* https://github.com/WorkplaceX/ApplicationDoc

## Backup Content
All content changes like adding new pages, images or modifying text is stored in the SQL database. Instead of creating a backup of the database, WorkplaceX allows to read data back from database and put it into C# code. From there you can close the cycle, and push content changes back into your git repository.

![](/assets/application-doc-cms.jpg)