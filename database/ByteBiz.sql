USE [master]
GO
/****** Object:  Database [ByteBiz]    Script Date: 10/17/2024 4:47:50 PM ******/
CREATE DATABASE [ByteBiz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ByteBiz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ByteBiz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ByteBiz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ByteBiz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ByteBiz] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ByteBiz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ByteBiz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ByteBiz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ByteBiz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ByteBiz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ByteBiz] SET ARITHABORT OFF 
GO
ALTER DATABASE [ByteBiz] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ByteBiz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ByteBiz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ByteBiz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ByteBiz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ByteBiz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ByteBiz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ByteBiz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ByteBiz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ByteBiz] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ByteBiz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ByteBiz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ByteBiz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ByteBiz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ByteBiz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ByteBiz] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ByteBiz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ByteBiz] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ByteBiz] SET  MULTI_USER 
GO
ALTER DATABASE [ByteBiz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ByteBiz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ByteBiz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ByteBiz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ByteBiz] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ByteBiz] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ByteBiz] SET QUERY_STORE = ON
GO
ALTER DATABASE [ByteBiz] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ByteBiz]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountUpgrades]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountUpgrades](
	[AccountUpgradeId] [uniqueidentifier] NOT NULL,
	[AccountUpgradeName] [nvarchar](20) NOT NULL,
	[AccountUpgradeType] [nvarchar](10) NOT NULL,
	[AccountUpgradeDescription] [nvarchar](max) NOT NULL,
	[Month] [int] NOT NULL,
	[Money] [decimal](18, 2) NOT NULL,
	[Discount] [real] NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AccountUpgrades] PRIMARY KEY CLUSTERED 
(
	[AccountUpgradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUserProfiles]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserProfiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](30) NOT NULL,
	[Skype] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Avatar] [nvarchar](200) NOT NULL,
	[IdentifierName] [nvarchar](30) NOT NULL,
	[IdentifierId] [nvarchar](20) NOT NULL,
	[Dob] [datetime] NOT NULL,
	[FacebookLink] [nvarchar](max) NOT NULL,
	[OtherLink] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ApplicationUserProfiles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[LoginCount] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentAndRates]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentAndRates](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[FreelancerId] [uniqueidentifier] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Rate] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CommentAndRates] PRIMARY KEY CLUSTERED 
(
	[FreelancerId] ASC,
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[FieldId] [uniqueidentifier] NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationId] [uniqueidentifier] NOT NULL,
	[ReceiverId] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Content] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[PaymentDetails] [nvarchar](max) NOT NULL,
	[Money] [decimal](18, 2) NOT NULL,
	[TransactionId] [nvarchar](100) NOT NULL,
	[PaymentStatus] [nvarchar](200) NOT NULL,
	[AccountUpgradeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectBiddings]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectBiddings](
	[ProjectId] [uniqueidentifier] NOT NULL,
	[BidderId] [uniqueidentifier] NOT NULL,
	[DateBidding] [datetime2](7) NOT NULL,
	[MoneyBidding] [int] NOT NULL,
 CONSTRAINT [PK_ProjectBiddings] PRIMARY KEY CLUSTERED 
(
	[BidderId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[BudgetFrom] [int] NOT NULL,
	[BudgetTo] [int] NOT NULL,
	[FormOfWork] [nvarchar](20) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
	[PosterId] [uniqueidentifier] NOT NULL,
	[ReceiverId] [uniqueidentifier] NULL,
	[FieldId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UpgradeHistories]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpgradeHistories](
	[UserId] [uniqueidentifier] NOT NULL,
	[AccountUpgradeId] [uniqueidentifier] NOT NULL,
	[DateBuy] [datetime2](7) NOT NULL,
	[DateEnd] [datetime2](7) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_UpgradeHistories] PRIMARY KEY CLUSTERED 
(
	[AccountUpgradeId] ASC,
	[UserId] ASC,
	[DateBuy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCVs]    Script Date: 10/17/2024 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCVs](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserCVImg] [nvarchar](100) NOT NULL,
	[ProfessionalTitle] [nvarchar](200) NOT NULL,
	[Introdution] [nvarchar](200) NOT NULL,
	[WebsiteUrl] [nvarchar](100) NOT NULL,
	[FieldId] [uniqueidentifier] NOT NULL,
	[Level] [nvarchar](30) NOT NULL,
	[Skill] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserCVs] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241003074205_ver1', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007164912_ver2', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241010102507_ver3', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241011050134_ver4', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241014154850_ver5', N'8.0.8')
GO
INSERT [dbo].[ApplicationUserProfiles] ([UserId], [FullName], [Skype], [Address], [Avatar], [IdentifierName], [IdentifierId], [Dob], [FacebookLink], [OtherLink]) VALUES (N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', N'Trần Trung Học', N'hoctran', N'Ha Hoi', N'~/avatar/5e1de1b6-ba22-40aa-2f8c-08dce6dea536_Screenshot (7).png', N'Trần Trung Học', N'123456789012', CAST(N'2002-12-31T00:00:00.000' AS DateTime), N'https://www.facebook.com/hoc.tran.73345048', N'')
INSERT [dbo].[ApplicationUserProfiles] ([UserId], [FullName], [Skype], [Address], [Avatar], [IdentifierName], [IdentifierId], [Dob], [FacebookLink], [OtherLink]) VALUES (N'456c5e83-3a27-4117-3471-08dcebad8dc2', N'Trần Trung Học', N'studytran', N'Ha Hoi', N'~/avatar/456c5e83-3a27-4117-3471-08dcebad8dc2_Bytebiz.png', N'Trần Trung Học', N'123456789012', CAST(N'2003-06-04T00:00:00.000' AS DateTime), N'https://www.facebook.com/hoc.tran.73345048', N'')
INSERT [dbo].[ApplicationUserProfiles] ([UserId], [FullName], [Skype], [Address], [Avatar], [IdentifierName], [IdentifierId], [Dob], [FacebookLink], [OtherLink]) VALUES (N'0dde672c-7b13-4c65-06aa-08dceccace1d', N'Bùi Ngọc Đức', N'ducngu', N'Ha Hoi', N'~/avatar/0dde672c-7b13-4c65-06aa-08dceccace1d_Bytebiz.png', N'Trần Trung Học', N'123456789012', CAST(N'2003-02-15T00:00:00.000' AS DateTime), N'https://www.facebook.com/hoc.tran.73345048', N'')
INSERT [dbo].[ApplicationUserProfiles] ([UserId], [FullName], [Skype], [Address], [Avatar], [IdentifierName], [IdentifierId], [Dob], [FacebookLink], [OtherLink]) VALUES (N'02ddbf84-812d-4f34-7d42-08dced91c4cc', N'Trần Trung Học', N'', N'Ha Hoi', N'~/avatar/02ddbf84-812d-4f34-7d42-08dced91c4cc_0-ky-hieu-thong-dung-tu-vung-tieng-han.jpg', N'Trần Trung Học', N'123456789012', CAST(N'2006-01-16T00:00:00.000' AS DateTime), N'https://www.facebook.com/hoc.tran.73345048', N'')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6aff6f8e-22b3-4c83-9c68-03050e363a1a', N'Freelancer', N'Freelancer', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'070cc236-4090-4921-8bf2-3789ab07e330', N'Customer', N'Customer', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'44c578d4-35ab-4e88-a2fb-94c48b9c32fa', N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'001f7121-d739-4d9e-66f9-08dce567338c', N'6aff6f8e-22b3-4c83-9c68-03050e363a1a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a7e16b1a-763f-4f05-16dc-08dce5dc2ae3', N'6aff6f8e-22b3-4c83-9c68-03050e363a1a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', N'6aff6f8e-22b3-4c83-9c68-03050e363a1a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02ddbf84-812d-4f34-7d42-08dced91c4cc', N'6aff6f8e-22b3-4c83-9c68-03050e363a1a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe1d0cf4-e1b3-4d8e-3294-08dce5db2121', N'070cc236-4090-4921-8bf2-3789ab07e330')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'456c5e83-3a27-4117-3471-08dcebad8dc2', N'070cc236-4090-4921-8bf2-3789ab07e330')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0dde672c-7b13-4c65-06aa-08dceccace1d', N'070cc236-4090-4921-8bf2-3789ab07e330')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bd9f8f93-ab56-4101-7d43-08dced91c4cc', N'070cc236-4090-4921-8bf2-3789ab07e330')
GO
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'001f7121-d739-4d9e-66f9-08dce567338c', 0, NULL, N'hoctthe170098', N'HOCTTHE170098', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAENzbB98LhGaw6vTD79g0LEeabjQOSh75RGDHvQBn0Gm2R3pBAydaNyIW/UwEdp38ug==', N'WZGZG6OFNVK367USAMK2KN6LTFJJTXXN', N'33bd6984-c746-4442-9e5c-9aaf9af162f2', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fe1d0cf4-e1b3-4d8e-3294-08dce5db2121', 0, NULL, N'hoctthe170097', N'HOCTTHE170097', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEFINzonc8UNryDpmDD7YSTUqBecsodNQPN8hDxG2R+cP/53DA/Y0aPb0Az96QutX2A==', N'GTD3QYL7YCUPCTPQY6HIXNI6TJG3M5O5', N'3ea4aabe-8ea3-436a-a43c-64e4fa5c50d1', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a7e16b1a-763f-4f05-16dc-08dce5dc2ae3', 0, NULL, N'hoc0406', N'HOC0406', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEDMqD3IPJkmUW+28dGTOSXF56R5aQlrd6glwukELRB0F87Vze3y2E2ZMCspBd+X52g==', N'WR4YHP6XYSZXAHLJWV23BZNS7ED3IOVX', N'2810d971-7498-4930-aa76-41b1a74cc0a3', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a2c8fd0f-5bf8-4018-8821-08dce66e34d5', 0, NULL, N'studytran081530', N'STUDYTRAN081530', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEAFevz96FXvGNc9jSKpNwPaG14OvNFhGJMgAIlg7IG5oP/9/hTfhFvj3lVQ848UU0Q==', N'PC72KB2ZZ3SQSPKBM7IGXWJMAKVFLR3D', N'02011c2c-8107-4dfc-aadf-3b8af6c11cd7', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', 0, NULL, N'hoctran', N'HOCTRAN', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEAkoomrdL2i/wch38JjaMRBLMNV+DN04Cajfbd0RCUrP/5AWZLcLnUpsUADELscI7g==', N'UWLNX75YS77JCSANS66XCVD466MRTPFZ', N'becb5ef5-4c71-49ff-a5c7-8bf49a9d5a52', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'456c5e83-3a27-4117-3471-08dcebad8dc2', 0, NULL, N'hoccustomer', N'HOCCUSTOMER', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAENO8NB3Nysfj+mOq7LaSVHsmySChxGyk5sCG15pSWqyTJJKsxTVrkh39XaIHmfBssw==', N'TEBK3VF2TJDXSFCK5N7DRVEQG2DTQKYV', N'35473c2a-1a43-4dca-9183-229f475c7b8e', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0dde672c-7b13-4c65-06aa-08dceccace1d', 0, NULL, N'hoccustomer1', N'HOCCUSTOMER1', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEIP2LO+v3X7Ke5plwWKi6tAEp5KQliJKrsU8U6Iii1h1ye5lLhmeFmHhM/BqxLobYw==', N'NPZYHRGHMFGEOV3KW5BSS6CCUG7J6R3I', N'b365e8b5-0317-4947-a597-0dbf812c0838', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'02ddbf84-812d-4f34-7d42-08dced91c4cc', 0, NULL, N'hoctthe20081530', N'HOCTTHE20081530', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEL2rIln/1O9Xfw7YNQU3lToRlhSvjQBV0GtVj0AGkiyhskEpZoAK9leEvxS2GdUICg==', N'RGFE2A5LF5QFGK3LJBK3KK7VYDHWSEYZ', N'7fab96f9-173c-4107-93e9-4676f5f85932', N'0948102469', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [LoginCount], [LastLoginTime], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bd9f8f93-ab56-4101-7d43-08dced91c4cc', 0, NULL, N'hoccustomer2', N'HOCCUSTOMER2', N'hoctthe170098@fpt.edu.vn', N'HOCTTHE170098@FPT.EDU.VN', 0, N'AQAAAAIAAYagAAAAEON3cmWdqyt0T7D+x+B5Zm6n18bMiHBQELp0AGH5e0XR01ctMLW0YLyr7T21X1Xcyw==', N'MJX2XYLK7LT2GX2K6LMQFWTHPKK4RLUH', N'b67cb503-0fb1-4fbd-8f91-a8dfdb306930', N'0948102469', 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'48608f13-826e-45c8-b479-1b1fc2a6ab98', N'Trí tuệ nhân tạo')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'00ac120c-aa3a-44b4-a8ff-33daeec9e4b8', N'Kỹ thuật mạng')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'5960c6e0-4eb4-4c0e-97c5-6b98cd5e4ca5', N'Big data')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'9a7ffa2a-d819-4bf1-b021-74788a9105fd', N'Phát triển phần mềm')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'76d77cdc-8ab5-4b66-b5ef-8aadb493c873', N'Sáng tác nội dung')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'c7f67615-b284-4991-a0a8-a2130fbe68f4', N'Thiết kế đồ hoạ')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'07993995-43eb-4d2a-9505-b00bf581dd07', N'Edit ảnh và video')
INSERT [dbo].[Fields] ([FieldId], [FieldName]) VALUES (N'5b817203-1705-4f02-9c19-c69830370d76', N'Tài chính và Blockchain')
GO
INSERT [dbo].[ProjectBiddings] ([ProjectId], [BidderId], [DateBidding], [MoneyBidding]) VALUES (N'fc1d1242-8c94-459f-79cf-08dcecc9121f', N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', CAST(N'2024-10-16T16:09:01.5682691' AS DateTime2), 3)
INSERT [dbo].[ProjectBiddings] ([ProjectId], [BidderId], [DateBidding], [MoneyBidding]) VALUES (N'4acd774f-d60a-4a09-06de-08dcee4345f2', N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', CAST(N'2024-10-17T09:35:05.7486379' AS DateTime2), 8)
INSERT [dbo].[ProjectBiddings] ([ProjectId], [BidderId], [DateBidding], [MoneyBidding]) VALUES (N'fc1d1242-8c94-459f-79cf-08dcecc9121f', N'02ddbf84-812d-4f34-7d42-08dced91c4cc', CAST(N'2024-10-16T16:04:36.4488866' AS DateTime2), 4)
GO
INSERT [dbo].[Projects] ([ProjectId], [CreatedDate], [EndDate], [Address], [BudgetFrom], [BudgetTo], [FormOfWork], [Status], [PosterId], [ReceiverId], [FieldId], [Description], [Title]) VALUES (N'fc1d1242-8c94-459f-79cf-08dcecc9121f', CAST(N'2024-10-15T10:25:51.6259139' AS DateTime2), CAST(N'2024-10-16T00:00:00.0000000' AS DateTime2), N'Hà Nội', 1, 5, N'Offline', N'Done', N'456c5e83-3a27-4117-3471-08dcebad8dc2', N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', N'9a7ffa2a-d819-4bf1-b021-74788a9105fd', N'Thiết kế trang web giáo dục bao gồm việc tạo ra một nền tảng trực tuyến thân thiện và dễ sử dụng cho người học. Công việc này yêu cầu phát triển giao diện hấp dẫn, tổ chức nội dung một cách logic, và tích hợp các tính năng như bài giảng trực tuyến, diễn đàn thảo luận, và bài kiểm tra tương tác. Ngoài ra, cần đảm bảo trang web hoạt động tốt trên nhiều thiết bị và trình duyệt khác nhau để phục vụ tốt nhất cho nhu cầu học tập của người dùng.', N'Thiết kế trang web giáo dục')
INSERT [dbo].[Projects] ([ProjectId], [CreatedDate], [EndDate], [Address], [BudgetFrom], [BudgetTo], [FormOfWork], [Status], [PosterId], [ReceiverId], [FieldId], [Description], [Title]) VALUES (N'4acd774f-d60a-4a09-06de-08dcee4345f2', CAST(N'2024-10-17T07:33:08.3342057' AS DateTime2), CAST(N'2024-10-20T00:00:00.0000000' AS DateTime2), N'', 5, 10, N'Online', N'Hiring', N'456c5e83-3a27-4117-3471-08dcebad8dc2', NULL, N'9a7ffa2a-d819-4bf1-b021-74788a9105fd', N'- Thiết kế trang web giáo dục bao gồm việc tạo ra một nền tảng trực tuyến thân thiện và dễ sử dụng cho người học. Công việc này yêu cầu phát triển giao diện hấp dẫn, tổ chức nội dung một cách logic, và tích hợp các tính năng như bài giảng trực tuyến, diễn đàn thảo luận, và bài kiểm tra tương tác. Ngoài ra, cần đảm bảo trang web hoạt động tốt trên nhiều thiết bị và trình duyệt khác nhau để phục vụ tốt nhất cho nhu cầu học tập của người dùng.
- Yêu cầu kinh nghiệm lâu năm
- Yêu cầu .......', N'Thiết kế trang web')
GO
INSERT [dbo].[UserCVs] ([UserId], [UserCVImg], [ProfessionalTitle], [Introdution], [WebsiteUrl], [FieldId], [Level], [Skill]) VALUES (N'5e1de1b6-ba22-40aa-2f8c-08dce6dea536', N'~/cv/5e1de1b6-ba22-40aa-2f8c-08dce6dea536_CV_MaiMinhKhoi.pdf', N'Sinh viên', N'- học kỹ thuật phần mềm tại đại học FPT
- phát triển các ứng dụng
- phát triển web
- tạo app', N'', N'00ac120c-aa3a-44b4-a8ff-33daeec9e4b8', N'Đại học', N'HTML, C#, java')
INSERT [dbo].[UserCVs] ([UserId], [UserCVImg], [ProfessionalTitle], [Introdution], [WebsiteUrl], [FieldId], [Level], [Skill]) VALUES (N'02ddbf84-812d-4f34-7d42-08dced91c4cc', N'~/cv/02ddbf84-812d-4f34-7d42-08dced91c4cc_Đơn thực tập _ Học.pdf', N'Intern', N'- Chuyên ngành kỹ thuật phần mềm tại FPTU
- thực tập tại VNPt', N'', N'9a7ffa2a-d819-4bf1-b021-74788a9105fd', N'Mới đi làm', N'HTML, C#, java')
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommentAndRates_CustomerId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_CommentAndRates_CustomerId] ON [dbo].[CommentAndRates]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notifications_ReceiverId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Notifications_ReceiverId] ON [dbo].[Notifications]
(
	[ReceiverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_AccountUpgradeId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_AccountUpgradeId] ON [dbo].[Payments]
(
	[AccountUpgradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_UserId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_UserId] ON [dbo].[Payments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectBiddings_ProjectId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectBiddings_ProjectId] ON [dbo].[ProjectBiddings]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_FieldId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Projects_FieldId] ON [dbo].[Projects]
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_PosterId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Projects_PosterId] ON [dbo].[Projects]
(
	[PosterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_ReceiverId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_Projects_ReceiverId] ON [dbo].[Projects]
(
	[ReceiverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UpgradeHistories_UserId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_UpgradeHistories_UserId] ON [dbo].[UpgradeHistories]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserCVs_FieldId]    Script Date: 10/17/2024 4:47:51 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserCVs_FieldId] ON [dbo].[UserCVs]
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApplicationUserProfiles] ADD  DEFAULT (N'') FOR [FacebookLink]
GO
ALTER TABLE [dbo].[ApplicationUserProfiles] ADD  DEFAULT (N'') FOR [OtherLink]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[ApplicationUserProfiles]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserProfiles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserProfiles] CHECK CONSTRAINT [FK_ApplicationUserProfiles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CommentAndRates]  WITH CHECK ADD  CONSTRAINT [FK_CommentAndRates_AspNetUsers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CommentAndRates] CHECK CONSTRAINT [FK_CommentAndRates_AspNetUsers_CustomerId]
GO
ALTER TABLE [dbo].[CommentAndRates]  WITH CHECK ADD  CONSTRAINT [FK_CommentAndRates_AspNetUsers_FreelancerId] FOREIGN KEY([FreelancerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[CommentAndRates] CHECK CONSTRAINT [FK_CommentAndRates_AspNetUsers_FreelancerId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_AspNetUsers_ReceiverId] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_AspNetUsers_ReceiverId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_AccountUpgrades_AccountUpgradeId] FOREIGN KEY([AccountUpgradeId])
REFERENCES [dbo].[AccountUpgrades] ([AccountUpgradeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_AccountUpgrades_AccountUpgradeId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ProjectBiddings]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBiddings_AspNetUsers_BidderId] FOREIGN KEY([BidderId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ProjectBiddings] CHECK CONSTRAINT [FK_ProjectBiddings_AspNetUsers_BidderId]
GO
ALTER TABLE [dbo].[ProjectBiddings]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBiddings_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectBiddings] CHECK CONSTRAINT [FK_ProjectBiddings_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_AspNetUsers_PosterId] FOREIGN KEY([PosterId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_AspNetUsers_PosterId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_AspNetUsers_ReceiverId] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_AspNetUsers_ReceiverId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Fields_FieldId] FOREIGN KEY([FieldId])
REFERENCES [dbo].[Fields] ([FieldId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Fields_FieldId]
GO
ALTER TABLE [dbo].[UpgradeHistories]  WITH CHECK ADD  CONSTRAINT [FK_UpgradeHistories_AccountUpgrades_AccountUpgradeId] FOREIGN KEY([AccountUpgradeId])
REFERENCES [dbo].[AccountUpgrades] ([AccountUpgradeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UpgradeHistories] CHECK CONSTRAINT [FK_UpgradeHistories_AccountUpgrades_AccountUpgradeId]
GO
ALTER TABLE [dbo].[UpgradeHistories]  WITH CHECK ADD  CONSTRAINT [FK_UpgradeHistories_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UpgradeHistories] CHECK CONSTRAINT [FK_UpgradeHistories_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserCVs]  WITH CHECK ADD  CONSTRAINT [FK_UserCVs_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCVs] CHECK CONSTRAINT [FK_UserCVs_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserCVs]  WITH CHECK ADD  CONSTRAINT [FK_UserCVs_Fields_FieldId] FOREIGN KEY([FieldId])
REFERENCES [dbo].[Fields] ([FieldId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCVs] CHECK CONSTRAINT [FK_UserCVs_Fields_FieldId]
GO
USE [master]
GO
ALTER DATABASE [ByteBiz] SET  READ_WRITE 
GO
