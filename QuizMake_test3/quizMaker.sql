USE [master]
GO
/****** Object:  Database [Quizmaker_Test3_CreateQuiz]    Script Date: 2/5/2019 12:39:09 ******/
CREATE DATABASE [Quizmaker_Test3_CreateQuiz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quizmaker_Test3_CreateQuiz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Quizmaker_Test3_CreateQuiz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Quizmaker_Test3_CreateQuiz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Quizmaker_Test3_CreateQuiz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quizmaker_Test3_CreateQuiz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET  MULTI_USER 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET QUERY_STORE = OFF
GO
USE [Quizmaker_Test3_CreateQuiz]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Quizmaker_Test3_CreateQuiz]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 2/5/2019 12:39:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Log_IN] [datetime] NULL,
	[Log_OUT] [datetime] NULL,
	[LogStatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 2/5/2019 12:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionTitle] [nvarchar](max) NOT NULL,
	[Q_A] [nvarchar](200) NOT NULL,
	[Q_B] [nvarchar](200) NOT NULL,
	[Q_C] [nvarchar](200) NOT NULL,
	[Q_D] [nvarchar](200) NULL,
	[Q_CorrectAnswer] [nvarchar](200) NOT NULL,
	[QuizId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizs]    Script Date: 2/5/2019 12:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizs](
	[QuizId] [int] IDENTITY(1,1) NOT NULL,
	[QuizName] [nvarchar](50) NOT NULL,
	[QuizTotalScore] [float] NULL,
	[QuizMaxScore] [int] NOT NULL,
	[User_Id] [int] NULL,
	[OrganiserId] [int] NOT NULL,
	[CreateDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Types]    Script Date: 2/5/2019 12:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Types](
	[UserType_Id] [int] IDENTITY(1,1) NOT NULL,
	[UserType_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/5/2019 12:39:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserFullName] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserType_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Log] ADD  DEFAULT ((0)) FOR [LogStatus]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizs] ([QuizId])
GO
ALTER TABLE [dbo].[Quizs]  WITH CHECK ADD FOREIGN KEY([OrganiserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Quizs]  WITH CHECK ADD FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [const01] FOREIGN KEY([UserType_Id])
REFERENCES [dbo].[User_Types] ([UserType_Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [const01]
GO
USE [master]
GO
ALTER DATABASE [Quizmaker_Test3_CreateQuiz] SET  READ_WRITE 
GO
