CREATE TABLE [dbo].[CompoPack]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [CompetitionID] NVARCHAR(128) NULL, 
    [Instructions] NVARCHAR(MAX) NULL, 
    [CompoPackLink] NVARCHAR(MAX) NULL,
	[isReleased] BIT NULL, 
    [Created] DATETIME NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    CONSTRAINT [FK_CompetitionID] FOREIGN KEY ([CompetitionID]) REFERENCES [dbo].[Competition]([Id])
)
