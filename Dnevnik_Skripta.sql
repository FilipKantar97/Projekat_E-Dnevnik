USE [master]
GO
/****** Object:  Database [Dnevnik]    Script Date: 17.3.2017. 15.29.23 ******/
CREATE DATABASE [Dnevnik]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dnevnik', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Dnevnik.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dnevnik_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Dnevnik_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dnevnik] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dnevnik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dnevnik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dnevnik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dnevnik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dnevnik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dnevnik] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dnevnik] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dnevnik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dnevnik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dnevnik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dnevnik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dnevnik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dnevnik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dnevnik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dnevnik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dnevnik] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dnevnik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dnevnik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dnevnik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dnevnik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dnevnik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dnevnik] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dnevnik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dnevnik] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dnevnik] SET  MULTI_USER 
GO
ALTER DATABASE [Dnevnik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dnevnik] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dnevnik] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dnevnik] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dnevnik] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Dnevnik]
GO
/****** Object:  Table [dbo].[Adresa]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adresa](
	[Adresa] [nvarchar](50) NOT NULL,
	[Postanski_Broj] [nvarchar](10) NOT NULL,
	[Grad] [nvarchar](25) NOT NULL,
	[IDOsobe] [int] NOT NULL,
	[IDOznakeAdresa] [int] NOT NULL,
 CONSTRAINT [PK_Adresa] PRIMARY KEY CLUSTERED 
(
	[IDOsobe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email_Adresa]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email_Adresa](
	[Adresa] [nvarchar](50) NOT NULL,
	[IDOsobe] [int] NOT NULL,
	[IDOznakeMail] [int] NULL,
 CONSTRAINT [PK_Email_Adresa] PRIMARY KEY CLUSTERED 
(
	[IDOsobe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kontakt]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kontakt](
	[Broj_Telefona] [varchar](50) NOT NULL,
	[Lokal] [varchar](10) NULL,
	[IDOsobe] [int] NOT NULL,
	[IDOznake] [int] NOT NULL,
 CONSTRAINT [PK_Kontakt] PRIMARY KEY CLUSTERED 
(
	[IDOsobe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ocene]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ocene](
	[IDOsoba] [int] IDENTITY(1,1) NOT NULL,
	[Srpski] [nvarchar](25) NULL,
	[Matematika] [nvarchar](25) NULL,
	[Istorija] [nvarchar](25) NULL,
	[Geografija] [nvarchar](25) NULL,
	[Informatika] [nvarchar](25) NULL,
	[Fizicko] [nvarchar](25) NULL,
	[Vladanje] [nvarchar](25) NULL,
 CONSTRAINT [PK_Ocene] PRIMARY KEY CLUSTERED 
(
	[IDOsoba] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ucenik]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ucenik](
	[IDOsobe] [int] IDENTITY(4,1) NOT NULL,
	[Ime] [varchar](25) NOT NULL,
	[Prezime] [varchar](25) NOT NULL,
	[Ime_Roditelja] [varchar](25) NOT NULL,
	[JMBG] [varchar](13) NOT NULL,
	[Datum_Rodjenja] [date] NOT NULL,
	[Mesto_Rodjenja] [varchar](25) NOT NULL,
	[Opstina_Rodjenja] [varchar](25) NOT NULL,
	[Pol] [varchar](10) NOT NULL,
	[Broj_Licne_Karte] [varchar](9) NOT NULL,
	[Fotografija] [image] NULL,
	[Beleska] [varchar](50) NULL,
	[Pin] [int] NOT NULL,
 CONSTRAINT [PK_Ucenik] PRIMARY KEY CLUSTERED 
(
	[IDOsobe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vrsta_Adresa]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vrsta_Adresa](
	[IDOznakeAdresa] [int] NOT NULL,
	[Ime_OznakeAdresa] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Vrsta_Adresa] PRIMARY KEY CLUSTERED 
(
	[IDOznakeAdresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vrsta_Email]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vrsta_Email](
	[IDOznakeMail] [int] NOT NULL,
	[Ime_OznakeMail] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[IDOznakeMail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vrsta_Kontakta]    Script Date: 17.3.2017. 15.29.23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vrsta_Kontakta](
	[IDOznake] [int] NOT NULL,
	[Ime_Oznake] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vrsta_Kontakta] PRIMARY KEY CLUSTERED 
(
	[IDOznake] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Adresa] ([Adresa], [Postanski_Broj], [Grad], [IDOsobe], [IDOznakeAdresa]) VALUES (N'Humska 1', N'11000', N'Beograd', 1, 1)
INSERT [dbo].[Adresa] ([Adresa], [Postanski_Broj], [Grad], [IDOsobe], [IDOznakeAdresa]) VALUES (N'Beogradska 35', N'25410', N'Novi Sad', 2, 1)
INSERT [dbo].[Adresa] ([Adresa], [Postanski_Broj], [Grad], [IDOsobe], [IDOznakeAdresa]) VALUES (N'Zemunska 62', N'55741', N'Svilajnac', 3, 2)
INSERT [dbo].[Email_Adresa] ([Adresa], [IDOsobe], [IDOznakeMail]) VALUES (N'milos@gmail.com', 1, 1)
INSERT [dbo].[Email_Adresa] ([Adresa], [IDOsobe], [IDOznakeMail]) VALUES (N'jovan@yahoo.com', 2, 2)
INSERT [dbo].[Email_Adresa] ([Adresa], [IDOsobe], [IDOznakeMail]) VALUES (N'jovana@hotmail.com', 3, 2)
INSERT [dbo].[Kontakt] ([Broj_Telefona], [Lokal], [IDOsobe], [IDOznake]) VALUES (N'0641587456', NULL, 1, 1)
INSERT [dbo].[Kontakt] ([Broj_Telefona], [Lokal], [IDOsobe], [IDOznake]) VALUES (N'2234816', N'011', 2, 2)
INSERT [dbo].[Kontakt] ([Broj_Telefona], [Lokal], [IDOsobe], [IDOznake]) VALUES (N'0631154784', NULL, 3, 3)
SET IDENTITY_INSERT [dbo].[Ocene] ON 

INSERT [dbo].[Ocene] ([IDOsoba], [Srpski], [Matematika], [Istorija], [Geografija], [Informatika], [Fizicko], [Vladanje]) VALUES (1, N'4,5,3', N'2,3', N'3,4,3', N'4,3', N'4,3,4', N'5,4,3', N'5')
INSERT [dbo].[Ocene] ([IDOsoba], [Srpski], [Matematika], [Istorija], [Geografija], [Informatika], [Fizicko], [Vladanje]) VALUES (2, N'4,3', N'4,4', N'5,4', N'4,4', N'5,4,4', N'5,4,5', N'5')
INSERT [dbo].[Ocene] ([IDOsoba], [Srpski], [Matematika], [Istorija], [Geografija], [Informatika], [Fizicko], [Vladanje]) VALUES (3, N'5,3', N'4,3', N'5,4', N'4,4', N'4,5', N'5,4,5', N'5')
INSERT [dbo].[Ocene] ([IDOsoba], [Srpski], [Matematika], [Istorija], [Geografija], [Informatika], [Fizicko], [Vladanje]) VALUES (4, N'4,4', N'4.3', N'5,2', N'5,4', N'4,2,4', N'4,5', N'4')
SET IDENTITY_INSERT [dbo].[Ocene] OFF
SET IDENTITY_INSERT [dbo].[Ucenik] ON 

INSERT [dbo].[Ucenik] ([IDOsobe], [Ime], [Prezime], [Ime_Roditelja], [JMBG], [Datum_Rodjenja], [Mesto_Rodjenja], [Opstina_Rodjenja], [Pol], [Broj_Licne_Karte], [Fotografija], [Beleska], [Pin]) VALUES (1, N'Milos', N'Maric', N'Dragan', N'0203998415234', CAST(N'1998-03-02' AS Date), N'Beograd', N'Savski Venac', N'Muski', N'004977241', NULL, NULL, 2145)
INSERT [dbo].[Ucenik] ([IDOsobe], [Ime], [Prezime], [Ime_Roditelja], [JMBG], [Datum_Rodjenja], [Mesto_Rodjenja], [Opstina_Rodjenja], [Pol], [Broj_Licne_Karte], [Fotografija], [Beleska], [Pin]) VALUES (2, N'Jovan', N'Ristic', N'Marko', N'1704997710541', CAST(N'1997-04-17' AS Date), N'Beograd', N'Rakovica', N'Muski', N'004781245', NULL, NULL, 4418)
INSERT [dbo].[Ucenik] ([IDOsobe], [Ime], [Prezime], [Ime_Roditelja], [JMBG], [Datum_Rodjenja], [Mesto_Rodjenja], [Opstina_Rodjenja], [Pol], [Broj_Licne_Karte], [Fotografija], [Beleska], [Pin]) VALUES (3, N'Jovana', N'Dragic', N'Stefan', N'180899810452', CAST(N'1998-08-18' AS Date), N'Beograd', N'Novi Beograd', N'Zenski', N'004251784', NULL, NULL, 1836)
INSERT [dbo].[Ucenik] ([IDOsobe], [Ime], [Prezime], [Ime_Roditelja], [JMBG], [Datum_Rodjenja], [Mesto_Rodjenja], [Opstina_Rodjenja], [Pol], [Broj_Licne_Karte], [Fotografija], [Beleska], [Pin]) VALUES (4, N'Filip', N'Kantar', N'Stefi', N'0102997710166', CAST(N'1197-01-02' AS Date), N'dddsffds', N'sddsfds', N'dfggff', N'224515', NULL, NULL, 2144)
SET IDENTITY_INSERT [dbo].[Ucenik] OFF
INSERT [dbo].[Vrsta_Adresa] ([IDOznakeAdresa], [Ime_OznakeAdresa]) VALUES (1, N'Kuca')
INSERT [dbo].[Vrsta_Adresa] ([IDOznakeAdresa], [Ime_OznakeAdresa]) VALUES (2, N'Posao')
INSERT [dbo].[Vrsta_Email] ([IDOznakeMail], [Ime_OznakeMail]) VALUES (1, N'Posao')
INSERT [dbo].[Vrsta_Email] ([IDOznakeMail], [Ime_OznakeMail]) VALUES (2, N'Privatna')
INSERT [dbo].[Vrsta_Kontakta] ([IDOznake], [Ime_Oznake]) VALUES (1, N'Mobilni')
INSERT [dbo].[Vrsta_Kontakta] ([IDOznake], [Ime_Oznake]) VALUES (2, N'Fiksni')
INSERT [dbo].[Vrsta_Kontakta] ([IDOznake], [Ime_Oznake]) VALUES (3, N'Sluzbeni')
INSERT [dbo].[Vrsta_Kontakta] ([IDOznake], [Ime_Oznake]) VALUES (4, N'Posao')
ALTER TABLE [dbo].[Adresa]  WITH CHECK ADD  CONSTRAINT [FK_Adresa_Ucenik] FOREIGN KEY([IDOsobe])
REFERENCES [dbo].[Ucenik] ([IDOsobe])
GO
ALTER TABLE [dbo].[Adresa] CHECK CONSTRAINT [FK_Adresa_Ucenik]
GO
ALTER TABLE [dbo].[Adresa]  WITH CHECK ADD  CONSTRAINT [FK_Adresa_Vrsta_Adresa] FOREIGN KEY([IDOznakeAdresa])
REFERENCES [dbo].[Vrsta_Adresa] ([IDOznakeAdresa])
GO
ALTER TABLE [dbo].[Adresa] CHECK CONSTRAINT [FK_Adresa_Vrsta_Adresa]
GO
ALTER TABLE [dbo].[Email_Adresa]  WITH CHECK ADD  CONSTRAINT [FK_Email_Adresa_Ucenik] FOREIGN KEY([IDOsobe])
REFERENCES [dbo].[Ucenik] ([IDOsobe])
GO
ALTER TABLE [dbo].[Email_Adresa] CHECK CONSTRAINT [FK_Email_Adresa_Ucenik]
GO
ALTER TABLE [dbo].[Email_Adresa]  WITH CHECK ADD  CONSTRAINT [FK_Email_Adresa_Vrsta_Email] FOREIGN KEY([IDOznakeMail])
REFERENCES [dbo].[Vrsta_Email] ([IDOznakeMail])
GO
ALTER TABLE [dbo].[Email_Adresa] CHECK CONSTRAINT [FK_Email_Adresa_Vrsta_Email]
GO
ALTER TABLE [dbo].[Kontakt]  WITH CHECK ADD  CONSTRAINT [FK_Kontakt_Ucenik] FOREIGN KEY([IDOsobe])
REFERENCES [dbo].[Ucenik] ([IDOsobe])
GO
ALTER TABLE [dbo].[Kontakt] CHECK CONSTRAINT [FK_Kontakt_Ucenik]
GO
ALTER TABLE [dbo].[Kontakt]  WITH CHECK ADD  CONSTRAINT [FK_Kontakt_Vrsta_Kontakta] FOREIGN KEY([IDOznake])
REFERENCES [dbo].[Vrsta_Kontakta] ([IDOznake])
GO
ALTER TABLE [dbo].[Kontakt] CHECK CONSTRAINT [FK_Kontakt_Vrsta_Kontakta]
GO
ALTER TABLE [dbo].[Ocene]  WITH CHECK ADD  CONSTRAINT [FK_Ocene_Ucenik] FOREIGN KEY([IDOsoba])
REFERENCES [dbo].[Ucenik] ([IDOsobe])
GO
ALTER TABLE [dbo].[Ocene] CHECK CONSTRAINT [FK_Ocene_Ucenik]
GO
USE [master]
GO
ALTER DATABASE [Dnevnik] SET  READ_WRITE 
GO
