CREATE TABLE [dbo].[Products] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (100)   NOT NULL,
    [Price]     FLOAT (53)       NOT NULL,
    [Type]      INT              NOT NULL,
    [CreatedAt] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

