CREATE TABLE [Login] (
	Login nvarchar(50) NOT NULL,
	ID uniqueidentifier NOT NULL,
	Password nvarchar(max) NOT NULL,
  CONSTRAINT [PK_LOGIN] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Name] (
	Name nvarchar(50) NOT NULL,
	Surname nvarchar(50) NOT NULL,
	Birthday datetime NOT NULL,
	ID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_NAME] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Connection] (
	ID uniqueidentifier NOT NULL,
	LikeID uniqueidentifier NOT NULL,
	PhotoID uniqueidentifier NOT NULL,
	AlbumID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_CONNECTION] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Connection2] (
	ID uniqueidentifier NOT NULL,
	CommentID uniqueidentifier NOT NULL,
	PhotoID uniqueidentifier NOT NULL,
	AlbumID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_CONNECTION2] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Photo] (
	Photo nvarchar NOT NULL,
	PhotoID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_PHOTO] PRIMARY KEY CLUSTERED
  (
  [PhotoID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Likes] (
	"Like" int NOT NULL,
	LikeID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_LIKES] PRIMARY KEY CLUSTERED
  (
  [LikeID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Comments] (
	Comment text NOT NULL,
	CommentID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_COMMENTS] PRIMARY KEY CLUSTERED
  (
  [CommentID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Album] (
	Album nvarchar(50) NOT NULL,
	AlbumID uniqueidentifier NOT NULL,
  CONSTRAINT [PK_ALBUM] PRIMARY KEY CLUSTERED
  (
  [AlbumID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [Name] WITH CHECK ADD CONSTRAINT [Name_fk0] FOREIGN KEY ([ID]) REFERENCES [Login]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Name] CHECK CONSTRAINT [Name_fk0]
GO

ALTER TABLE [Connection] WITH CHECK ADD CONSTRAINT [Connection_fk3] FOREIGN KEY ([AlbumID]) REFERENCES [Album]([AlbumID])
ON UPDATE CASCADE
GO
ALTER TABLE [Connection] CHECK CONSTRAINT [Connection_fk3]
GO

ALTER TABLE [Connection2] WITH CHECK ADD CONSTRAINT [Connection2_fk3] FOREIGN KEY ([AlbumID]) REFERENCES [Album]([AlbumID])
ON UPDATE CASCADE
GO
ALTER TABLE [Connection2] CHECK CONSTRAINT [Connection2_fk3]
GO

