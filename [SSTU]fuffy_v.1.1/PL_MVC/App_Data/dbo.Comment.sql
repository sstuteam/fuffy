CREATE TABLE [dbo].[Comment] (
    [Comment]   TEXT             NULL,
    [Likes]     INT              NOT NULL,
    [CommentID] UNIQUEIDENTIFIER NOT NULL,
    [PhotoId]   UNIQUEIDENTIFIER NOT NULL,
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([CommentID] ASC),
    CONSTRAINT [FK_Comment_Photo] FOREIGN KEY ([PhotoId]) REFERENCES [dbo].[Photo] ([PhotoId]),
    CONSTRAINT [FK_Comment_Login] FOREIGN KEY ([ID]) REFERENCES [dbo].[Login] ([ID])
);

