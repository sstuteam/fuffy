USE [FuffyDB]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 27.12.2015 16:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Album] [nvarchar](30) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[AlbumID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 27.12.2015 16:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Comment] [text] NULL,
	[Likes] [int] NOT NULL,
	[CommentID] [uniqueidentifier] NOT NULL,
	[PhotoId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Connection]    Script Date: 27.12.2015 16:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connection](
	[UserID] [uniqueidentifier] NOT NULL,
	[CommentId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Photo]    Script Date: 27.12.2015 16:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Photo](
	[Photo] [binary](50) NOT NULL,
	[Likes] [int] NOT NULL,
	[PhotoId] [uniqueidentifier] NOT NULL,
	[AlbumId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 27.12.2015 16:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profile](
	[Login] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Avatar] [binary](50) NULL,
	[Status] [int] NULL,
	[UserID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Login] FOREIGN KEY([ID])
REFERENCES [dbo].[Profile] ([UserID])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Login]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Photo] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photo] ([PhotoId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Photo]
GO
ALTER TABLE [dbo].[Connection]  WITH CHECK ADD  CONSTRAINT [FK_Connection_Comments] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comments] ([CommentID])
GO
ALTER TABLE [dbo].[Connection] CHECK CONSTRAINT [FK_Connection_Comments]
GO
ALTER TABLE [dbo].[Connection]  WITH CHECK ADD  CONSTRAINT [FK_Connection_Login] FOREIGN KEY([UserID])
REFERENCES [dbo].[Profile] ([UserID])
GO
ALTER TABLE [dbo].[Connection] CHECK CONSTRAINT [FK_Connection_Login]
GO
ALTER TABLE [dbo].[Photo]  WITH CHECK ADD  CONSTRAINT [FK_Photo_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumID])
GO
ALTER TABLE [dbo].[Photo] CHECK CONSTRAINT [FK_Photo_Album]
GO
