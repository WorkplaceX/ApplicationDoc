CREATE TABLE Doc.Language
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(256) NOT NULL UNIQUE,
	TextHtml NVARCHAR(256),
	LanguageId INT NOT NULL, -- See field FrameworkTranslate.Language01
)

GO
CREATE VIEW Doc.LanguageIntegrate AS
SELECT
    *,
	Name AS IdName
FROM
	Doc.Language
