GO
CREATE TABLE Doc.Feedback
(
    Id INT PRIMARY KEY IDENTITY,
    Name UNIQUEIDENTIFIER UNIQUE,
    Email NVARCHAR(256),
    Message NVARCHAR(MAX),
    AttachmentFileName NVARCHAR(256),
	AttachmentData VARBINARY(MAX),
    Time DateTime,
    NavigatePath NVARCHAR(256),
    IpAddress NVARCHAR(256),
    UserAgent NVARCHAR(256),
    IsDone BIT
)
GO
CREATE VIEW Doc.FeedbackIntegrate AS
SELECT
    *,
    Name AS IdName
FROM
    Doc.Feedback