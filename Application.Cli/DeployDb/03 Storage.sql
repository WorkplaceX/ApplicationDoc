GO
CREATE TABLE Doc.StorageFile
(
	Id INT PRIMARY KEY IDENTITY,
	FileName NVARCHAR(256) UNIQUE,
	Data VARBINARY(MAX),
    DataImageThumbnail VARBINARY(MAX),
	Description NVARCHAR(MAX),
	SourceUrl NVARCHAR(512),
	IsIntegrate BIT NOT NULL,
	IsDelete BIT NOT NULL
)
GO
CREATE VIEW Doc.StorageFileIntegrate AS
SELECT
    *,
    FileName AS IdName
FROM
    Doc.StorageFile Data

GO
CREATE VIEW Doc.StorageFileDisplay AS
SELECT
    Id,
    FileName,
    CASE WHEN Data IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS IsData,
    CASE WHEN DataImageThumbnail IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS IsDataImageThumbnail,
    Description,
    SourceUrl
FROM
    Doc.StorageFile Data
