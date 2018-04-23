CREATE TABLE [dbo].[Competition]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [CompoLength] DATETIME NOT NULL, 
    [VoteLength] DATETIME NOT NULL, 
    [CompoStartDate] DATETIME NOT NULL, 
    [CurrentPhase] INT NOT NULL, 
    [HostUserID] NVARCHAR(128) NULL,
    [Created] DATETIME NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [Title] NVARCHAR(MAX) NULL, 
    [CompoType] INT NOT NULL, 
    CONSTRAINT [FK_HostUserID] FOREIGN KEY (HostUserID) REFERENCES [dbo].[User]([Id])
)
