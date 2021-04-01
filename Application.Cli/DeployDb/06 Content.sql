GO
CREATE TABLE Doc.Content
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL UNIQUE,
    NavigatePath NVARCHAR(256),
    TitleHtml NVARCHAR(256),
    TitleLong NVARCHAR(256),
    TextMd NVARCHAR(MAX),
    TextHtml NVARCHAR(MAX),
    Sort FLOAT
)
GO
CREATE VIEW Doc.ContentIntegrate AS
SELECT
    Content.*,
    Content.Name AS IdName
FROM
    Doc.Content Content
