﻿CREATE TABLE [dbo].[UserVotes]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [EntryID] NVARCHAR(128) NOT NULL, 
    [VoterID] NVARCHAR(128) NOT NULL, 
    [Score] INT NOT NULL
)
