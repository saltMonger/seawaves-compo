CREATE TABLE [dbo].[User] (
    [Id]           NVARCHAR(128)  NOT NULL,
    [ProfileText]  VARCHAR (MAX) NULL,
    [VaporAmount]  INT           NULL,
    [AetherAmount] INT           NULL,
    [Avatar]       VARCHAR (MAX) NULL,
    [UserHandle] VARCHAR(32) NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [Created] DATETIME NOT NULL, 
    [LastHere] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_User_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers]([Id])
);

