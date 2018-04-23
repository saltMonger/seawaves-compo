CREATE TABLE [dbo].[Entry]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [CompetitionID] NVARCHAR(128) NULL, 
    [AuthorUserID] NVARCHAR(128) NULL, 
    [TempURL] NVARCHAR(128) NULL, 
    [PermanentURL] NVARCHAR(128) NULL, 
    [Rank] INT NULL, 
    [IsAnonymous] BIT NULL,
	[Created] DATETIME NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [Score] INT NULL, 
    [Title] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_BoundCompetitionID] FOREIGN KEY ([CompetitionID]) REFERENCES [dbo].[Competition]([Id]),
	CONSTRAINT [FK_AuthorUserID] FOREIGN KEY ([AuthorUserID]) REFERENCES [dbo].[User]([Id])
)
