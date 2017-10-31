CREATE TABLE [dbo].[LogEntry]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Level] NCHAR(1) NULL, 
    [Message] NCHAR(300) NULL,
    [CreatedOn] DATETIME NULL
)
