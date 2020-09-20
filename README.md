# DDD project
crqs, repository, dependency injection, clean, solid.

#Database Sql Server EntityFramework Commands

dotnet ef dbcontext scaffold "Server=localhost;Database=GameManager;Uid=sa;Pwd=Insecure!12345" Microsoft.EntityFrameworkCore.SqlServer

#Sql Create Script 

USE [master]
GO
/****** Object:  Database [GameManager]    Script Date: 9/20/2020 10:52:50 AM ******/
CREATE DATABASE [GameManager]
GO
ALTER DATABASE [GameManager] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GameManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GameManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GameManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GameManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GameManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GameManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [GameManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GameManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GameManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GameManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GameManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GameManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GameManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GameManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GameManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GameManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GameManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GameManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GameManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GameManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GameManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GameManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GameManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GameManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GameManager] SET  MULTI_USER 
GO
ALTER DATABASE [GameManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GameManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GameManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GameManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GameManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GameManager] SET QUERY_STORE = OFF
GO
USE [GameManager]
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 9/20/2020 10:52:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 9/20/2020 10:52:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GameBorrowed]    Script Date: 9/20/2020 10:52:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameBorrowed](
	[GameId] [uniqueidentifier] NOT NULL,
	[FriendId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GameBorrowed] PRIMARY KEY CLUSTERED 
(
	[GameId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GameBorrowed]  WITH CHECK ADD  CONSTRAINT [FK_GameBorrowed_Friend] FOREIGN KEY([FriendId])
REFERENCES [dbo].[Friend] ([Id])
GO
ALTER TABLE [dbo].[GameBorrowed] CHECK CONSTRAINT [FK_GameBorrowed_Friend]
GO
ALTER TABLE [dbo].[GameBorrowed]  WITH CHECK ADD  CONSTRAINT [FK_GameBorrowed_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[Game] ([Id])
GO
ALTER TABLE [dbo].[GameBorrowed] CHECK CONSTRAINT [FK_GameBorrowed_Game]
GO
USE [master]
GO
ALTER DATABASE [GameManager] SET  READ_WRITE 
GO
