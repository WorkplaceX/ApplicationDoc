GO
CREATE TABLE Doc.Content
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL UNIQUE,
    NavigateTree NVARCHAR(256), -- Insted of ParentId
    NavigatePath NVARCHAR(256), -- Can be null for group
    TitleHtml NVARCHAR(256),
    TitleLong NVARCHAR(256),
    TextMd NVARCHAR(MAX),
    TextHtml NVARCHAR(MAX),
    Description NVARCHAR(MAX), -- Html meta description
    Sort FLOAT,
    SitemapDate DATETIME2
)
GO
CREATE VIEW Doc.ContentIntegrate AS
SELECT
    Content.*,
    Content.Name AS IdName
FROM
    Doc.Content Content
