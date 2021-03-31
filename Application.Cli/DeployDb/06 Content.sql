GO
CREATE TABLE Doc.Content
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL UNIQUE,
    TextMd NVARCHAR(MAX),
    IsIntegrate BIT NOT NULL, -- Built into CSharp code with IdNameEnum and deployed with cli deployDb command
    IsDelete BIT NOT NULL,
)

GO
CREATE VIEW Doc.ContentIntegrate AS
SELECT
    Content.*,
    Content.Name AS IdName
FROM
    Doc.Content Content
