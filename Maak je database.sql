USE [master]
GO
/****** Object:  Database [B2D4 Casus Ziekenhuis]    Script Date: 29-6-2020 15:03:56 ******/
CREATE DATABASE [B2D4 Casus Ziekenhuis]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'B2D4 Casus Ziekenhuis', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\B2D4 Casus Ziekenhuis.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'B2D4 Casus Ziekenhuis_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\B2D4 Casus Ziekenhuis_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [B2D4 Casus Ziekenhuis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET ARITHABORT OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET RECOVERY FULL 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET  MULTI_USER 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET DB_CHAINING OFF 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'B2D4 Casus Ziekenhuis', N'ON'
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET QUERY_STORE = OFF
GO
USE [B2D4 Casus Ziekenhuis]
GO
/****** Object:  Table [dbo].[Afdeling]    Script Date: 29-6-2020 15:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Afdeling](
	[Afdeling_ID] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NULL,
	[Max_Patiënt] [int] NULL,
 CONSTRAINT [PK_Afdeling] PRIMARY KEY CLUSTERED 
(
	[Afdeling_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eten]    Script Date: 29-6-2020 15:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eten](
	[Eten_ID] [int] IDENTITY(1,1) NOT NULL,
	[NaamEten] [nvarchar](50) NULL,
	[ImageEten] [image] NULL,
 CONSTRAINT [PK_Eten] PRIMARY KEY CLUSTERED 
(
	[Eten_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kamer]    Script Date: 29-6-2020 15:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kamer](
	[Kamer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Kamernaam] [varchar](30) NOT NULL,
	[Afdeling_ID] [int] NOT NULL,
 CONSTRAINT [PK_Kamer] PRIMARY KEY CLUSTERED 
(
	[Kamer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicatie]    Script Date: 29-6-2020 15:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicatie](
	[Medicatie_ID] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [varchar](50) NOT NULL,
	[Merk] [varchar](50) NOT NULL,
	[Dosis] [varchar](10) NOT NULL,
	[Patient_ID] [int] NULL,
 CONSTRAINT [PK_Medicatie] PRIMARY KEY CLUSTERED 
(
	[Medicatie_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 29-6-2020 15:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Patiënt_ID] [int] IDENTITY(1,1) NOT NULL,
	[Voornaam] [varchar](50) NOT NULL,
	[Achternaam] [varchar](50) NOT NULL,
	[Adres] [varchar](70) NOT NULL,
	[Geboortedatum] [date] NOT NULL,
	[Telefoonnummer] [varchar](20) NOT NULL,
	[Afdeling_ID] [int] NULL,
	[Kamer_ID] [int] NULL,
	[Gearchiveerd] [bit] NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Patiënt_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zorgverlener]    Script Date: 29-6-2020 15:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zorgverlener](
	[Zorgverlener_ID] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](50) NULL,
	[Functie] [nvarchar](50) NULL,
 CONSTRAINT [PK_Zorgverlener] PRIMARY KEY CLUSTERED 
(
	[Zorgverlener_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Afdeling] ON 

INSERT [dbo].[Afdeling] ([Afdeling_ID], [Naam], [Max_Patiënt]) VALUES (1, N'Brandwonden', 20)
SET IDENTITY_INSERT [dbo].[Afdeling] OFF
SET IDENTITY_INSERT [dbo].[Kamer] ON 

INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (1, N'Zeezicht', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (2, N'Meerzicht', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (3, N'Rivierzicht', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (4, N'TiolettenRuimte', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (5, N'Heaven', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (6, N'OpslagRuimte', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (8, N'Hell', 1)
INSERT [dbo].[Kamer] ([Kamer_ID], [Kamernaam], [Afdeling_ID]) VALUES (9, N'ZorgverlenerOffice', 1)
SET IDENTITY_INSERT [dbo].[Kamer] OFF
SET IDENTITY_INSERT [dbo].[Medicatie] ON 

INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (1, N'Paracetamol', N'TEVA', N'500mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (2, N'Paracetamol', N'TEVA', N'1000mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (3, N'Pantoprazol', N'AUROBINDO', N'20mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (4, N'Pantoprazol', N'AUROBINDO', N'40mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (5, N'Simvastatine', N'SANDOZ', N'20mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (6, N'Simvastatine', N'SANDOZ', N'40mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (7, N'Naproxen', N'ACCORD', N'500mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (8, N'TRAMADOL HCL', N'AUROBINDO', N'50mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (9, N'Sotalol', N'SANDOZ', N'80mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (10, N'Diazepam', N'TEVA', N'10mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (11, N'Clonazepam', N'SANDOZ', N'2mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (12, N'Atorvastatine', N'SANDOZ', N'40mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (13, N'Macogol en Elektrolyten', N'TEVA', N'13,7mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (14, N'Alprazolam', N'MYLAN', N'0,25mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (15, N'Alprazolam', N'PFIZER', N'0,5mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (16, N'Ezetimibe', N'Apotex', N'10mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (17, N'Antagel', N'SANDOZ', N'300ml', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (18, N'Acetylsalicylzuur', N'AUROBINDO', N'80mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (19, N'Bromazepam', N'SANDOZ', N'3mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (20, N'Bromazepam', N'TEVA', N'6mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (22, N'Valsartan', N'SANDOZ', N'80mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (23, N'Valsartan', N'SANDOZ', N'160mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (28, N'Oxazepam', N'TEVA', N'10mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (29, N'Oxazepam', N'ACCORD', N'50mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (31, N'Methylfenidaat HCl', N'MYLAN', N'10mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (32, N'Nebivolol', N'ACTAVIS', N'5mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (33, N'ASCAL', N'CARDIO', N'100mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (34, N'Chlooramfenicol', N'TEVA', N'10mg', NULL)
INSERT [dbo].[Medicatie] ([Medicatie_ID], [Naam], [Merk], [Dosis], [Patient_ID]) VALUES (35, N'Loperamide', N'MYLAN', N'2mg', NULL)
SET IDENTITY_INSERT [dbo].[Medicatie] OFF
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([Patiënt_ID], [Voornaam], [Achternaam], [Adres], [Geboortedatum], [Telefoonnummer], [Afdeling_ID], [Kamer_ID], [Gearchiveerd]) VALUES (1, N'Justin', N'Theunissens', N'Beijlkensweg 112 Oirsbeek', CAST(N'1999-06-30' AS Date), N'0683191303', 1, 1, NULL)
INSERT [dbo].[Patient] ([Patiënt_ID], [Voornaam], [Achternaam], [Adres], [Geboortedatum], [Telefoonnummer], [Afdeling_ID], [Kamer_ID], [Gearchiveerd]) VALUES (3, N'test', N'test2', N'adres', CAST(N'2020-06-18' AS Date), N'0612380673', 1, 1, NULL)
INSERT [dbo].[Patient] ([Patiënt_ID], [Voornaam], [Achternaam], [Adres], [Geboortedatum], [Telefoonnummer], [Afdeling_ID], [Kamer_ID], [Gearchiveerd]) VALUES (4, N'test2', N'test4', N'adrest', CAST(N'2020-06-17' AS Date), N'0612380673', 1, 1, NULL)
INSERT [dbo].[Patient] ([Patiënt_ID], [Voornaam], [Achternaam], [Adres], [Geboortedatum], [Telefoonnummer], [Afdeling_ID], [Kamer_ID], [Gearchiveerd]) VALUES (5, N'Antwan', N'Horbach', N'adres', CAST(N'1999-08-14' AS Date), N'0637386140', 1, 2, NULL)
INSERT [dbo].[Patient] ([Patiënt_ID], [Voornaam], [Achternaam], [Adres], [Geboortedatum], [Telefoonnummer], [Afdeling_ID], [Kamer_ID], [Gearchiveerd]) VALUES (7, N'Tony', N'Kuster', N'adres', CAST(N'1998-10-18' AS Date), N'0641556354', 1, 5, NULL)
SET IDENTITY_INSERT [dbo].[Patient] OFF
ALTER TABLE [dbo].[Kamer]  WITH CHECK ADD  CONSTRAINT [FK_Kamer_Afdeling] FOREIGN KEY([Afdeling_ID])
REFERENCES [dbo].[Afdeling] ([Afdeling_ID])
GO
ALTER TABLE [dbo].[Kamer] CHECK CONSTRAINT [FK_Kamer_Afdeling]
GO
ALTER TABLE [dbo].[Medicatie]  WITH CHECK ADD  CONSTRAINT [FK_Medicatie_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patient] ([Patiënt_ID])
GO
ALTER TABLE [dbo].[Medicatie] CHECK CONSTRAINT [FK_Medicatie_Patient]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Afdeling] FOREIGN KEY([Afdeling_ID])
REFERENCES [dbo].[Afdeling] ([Afdeling_ID])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Afdeling]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Kamer] FOREIGN KEY([Kamer_ID])
REFERENCES [dbo].[Kamer] ([Kamer_ID])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Kamer]
GO
USE [master]
GO
ALTER DATABASE [B2D4 Casus Ziekenhuis] SET  READ_WRITE 
GO
