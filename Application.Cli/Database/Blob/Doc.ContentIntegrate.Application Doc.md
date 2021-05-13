# Application Doc (CMS)
An open source document management platform developed and released by WorkplaceX. Any company and organization can use this product to manage it's web content.

## Page Navigation and Content

Pages, navigation and content is highly structured and organized in a spread sheet like manner.

(Image Src="/assets/application-doc-cms-page-preview.jpg" Href="/assets/application-doc-cms-page.png")

## Customers
Application Doc (CMS) is used for the web site:
* https://www.workplacex.org

## Download
The application can be downloaded from: https://github.com/WorkplaceX/ApplicationDoc

## Backup Content
All content changes like adding new pages, images or modifying text is stored in SQL database. Content data is stored nowhere else. A backup of the database is suffice.

Additionally WorkplaceX allows to read data back from database and put it into C# code. From there you can close the cycle, and push content changes back to your git repository. Now the application can be deployed und updated to any other database. This suits most development processes.

Following video shows how to read content changes back from DEV database. Push changes to git. And update a TEST database with the new content.

(Image Src="/assets/application-doc-cms.jpg" Href="https://youtu.be/8Pk2ZXOwknU")
