USE [master]
GO
/****** Object:  Database [PhotographySiteDb]    Script Date: 12/1/2013 2:56:09 PM ******/
--CREATE DATABASE [PhotographySiteDb]
 --CONTAINMENT = NONE
 --ON  PRIMARY 
--( NAME = N'PhotographySiteDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PhotographySiteDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 --LOG ON 
--( NAME = N'PhotographySiteDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PhotographySiteDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PhotographySiteDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotographySiteDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotographySiteDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PhotographySiteDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotographySiteDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotographySiteDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotographySiteDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotographySiteDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PhotographySiteDb] SET  MULTI_USER 
GO
ALTER DATABASE [PhotographySiteDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotographySiteDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotographySiteDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhotographySiteDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PhotographySiteDb]
GO
/****** Object:  User [photographyUser]    Script Date: 12/1/2013 2:56:09 PM ******/
CREATE USER [photographyUser] FOR LOGIN [photographyUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [photographyUser]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[AlbumCoverId] [int] NULL,
	[CategoryId] [int] NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AlbumTag]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumTag](
	[AlbumId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_AlbumTag_1] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Photo]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Source] [nvarchar](500) NOT NULL,
	[ThumbnailSource] [nvarchar](500) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhotoAlbum]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoAlbum](
	[AlbumId] [int] NOT NULL,
	[PhotoId] [int] NOT NULL,
 CONSTRAINT [PK_PhotoAlbum_1] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC,
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhotoTag]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoTag](
	[PhotoId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_PhotoTag] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResetPasswordRequest]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResetPasswordRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UsedOn] [datetime] NULL,
 CONSTRAINT [PK_ResetPasswordRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Session]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionKey] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tag]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[Password] [binary](32) NOT NULL,
	[Salt] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAlbum]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAlbum](
	[UserId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
 CONSTRAINT [PK_UserAlbum_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 12/1/2013 2:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_ResetPasswordRequest]    Script Date: 12/1/2013 2:56:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ResetPasswordRequest] ON [dbo].[ResetPasswordRequest]
(
	[UserId] ASC,
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Category]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Photo] FOREIGN KEY([AlbumCoverId])
REFERENCES [dbo].[Photo] ([Id])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Photo]
GO
ALTER TABLE [dbo].[AlbumTag]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTag_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[AlbumTag] CHECK CONSTRAINT [FK_AlbumTag_Album]
GO
ALTER TABLE [dbo].[AlbumTag]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[AlbumTag] CHECK CONSTRAINT [FK_AlbumTag_Tag]
GO
ALTER TABLE [dbo].[PhotoAlbum]  WITH CHECK ADD  CONSTRAINT [FK_PhotoAlbum_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[PhotoAlbum] CHECK CONSTRAINT [FK_PhotoAlbum_Album]
GO
ALTER TABLE [dbo].[PhotoAlbum]  WITH CHECK ADD  CONSTRAINT [FK_PhotoAlbum_Photo] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photo] ([Id])
GO
ALTER TABLE [dbo].[PhotoAlbum] CHECK CONSTRAINT [FK_PhotoAlbum_Photo]
GO
ALTER TABLE [dbo].[PhotoTag]  WITH CHECK ADD  CONSTRAINT [FK_PhotoTag_Photo] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photo] ([Id])
GO
ALTER TABLE [dbo].[PhotoTag] CHECK CONSTRAINT [FK_PhotoTag_Photo]
GO
ALTER TABLE [dbo].[PhotoTag]  WITH CHECK ADD  CONSTRAINT [FK_PhotoTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[PhotoTag] CHECK CONSTRAINT [FK_PhotoTag_Tag]
GO
ALTER TABLE [dbo].[ResetPasswordRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ResetPasswordRequest_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ResetPasswordRequest] CHECK CONSTRAINT [FK_ResetPasswordRequest_User]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_User]
GO
ALTER TABLE [dbo].[UserAlbum]  WITH CHECK ADD  CONSTRAINT [FK_UserAlbum_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([Id])
GO
ALTER TABLE [dbo].[UserAlbum] CHECK CONSTRAINT [FK_UserAlbum_Album]
GO
ALTER TABLE [dbo].[UserAlbum]  WITH CHECK ADD  CONSTRAINT [FK_UserAlbum_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserAlbum] CHECK CONSTRAINT [FK_UserAlbum_User]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
USE [master]
GO
ALTER DATABASE [PhotographySiteDb] SET  READ_WRITE 
GO
