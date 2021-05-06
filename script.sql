USE [master]
GO
/****** Object:  Database [MyLibrary]    Script Date: 5/7/2021 1:31:58 AM ******/
CREATE DATABASE [MyLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyLibrary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyLibrary_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyLibrary] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyLibrary] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyLibrary] SET RECOVERY FULL 
GO
ALTER DATABASE [MyLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [MyLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyLibrary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyLibrary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyLibrary', N'ON'
GO
ALTER DATABASE [MyLibrary] SET QUERY_STORE = OFF
GO
USE [MyLibrary]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [Pk_Author_AuthorId] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Summary] [varchar](300) NOT NULL,
	[PublishedYear] [smallint] NOT NULL,
	[Publisher] [varchar](60) NOT NULL,
	[ISBN] [varchar](15) NOT NULL,
	[Pages] [smallint] NOT NULL,
	[UnitPrice] [money] NOT NULL,
 CONSTRAINT [Pk_Book_BookId] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[BookAuthorId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [Pk_BookAuthor_BookAuthorId] PRIMARY KEY CLUSTERED 
(
	[BookAuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[BookCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [Pk_BookCategory_BookCategoryId] PRIMARY KEY CLUSTERED 
(
	[BookCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRent]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRent](
	[BookRentId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[RentDate] [datetime] NOT NULL,
 CONSTRAINT [Pk_BookRent_BookRentId] PRIMARY KEY CLUSTERED 
(
	[BookRentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [Pk_Category_CategoryId] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
 CONSTRAINT [Pk_Client_ClientId] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientOffer]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOffer](
	[ClientOfferId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[OfferId] [int] NOT NULL,
	[AgreementDate] [date] NOT NULL,
 CONSTRAINT [Pk_ClientOffer_ClientOfferId] PRIMARY KEY CLUSTERED 
(
	[ClientOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offer]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[OfferId] [int] IDENTITY(1,1) NOT NULL,
	[Days] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [Pk_Offer_OfferId] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](40) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [Pk_User_UserId] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Filan', N'Fisteku', CAST(N'2021-02-02' AS Date))
INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Haruki', N'Murakami', CAST(N'1998-01-01' AS Date))
INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Victor', N'Hugo', CAST(N'1802-01-01' AS Date))
INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Nicholas', N'Sparks', CAST(N'1960-01-01' AS Date))
INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (5, N'William', N'Shakespear', CAST(N'1700-01-01' AS Date))
INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (6, N'J.K', N'Rowling', CAST(N'1980-01-01' AS Date))
INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (7, N'Franz', N'Kafka', CAST(N'1883-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (1, N'Wutherin Heigh', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (3, N'Norvegian Wood', N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum..', 1855, N'Cautley Newby', N'1050261110 ', 232, 23.0000)
INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (4, N'Kafka on the shore', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1866, N'Thomas Cautley', N'1853260010 ', 272, 21.0000)
INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (5, N'Lord of the Flies ', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (6, N'Great Expectations ', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (7, N'Lolita ', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[BookAuthor] ON 

INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (1, 1, 2)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (2, 1, 1)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (4, 3, 1)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (5, 3, 2)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (7, 1, 2)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (8, 1, 3)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (9, 1, 4)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (10, 3, 4)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (11, 3, 5)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (12, 1, 5)
INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (13, 4, 5)
SET IDENTITY_INSERT [dbo].[BookAuthor] OFF
GO
SET IDENTITY_INSERT [dbo].[BookCategory] ON 

INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (1, 1, 1)
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (4, 3, 1)
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (5, 3, 1)
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (6, 4, 1)
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (7, 1, 3)
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (8, 1, 3)
SET IDENTITY_INSERT [dbo].[BookCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[BookRent] ON 

INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (2, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (3, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (4, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (5, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (6, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BookRent] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (1, N'Drama')
INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (2, N'Romance')
INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (3, N'Thriller')
INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (4, N'Fiction')
INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (5, N'Science')
INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (6, N'Action')
INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (7, N'Kids')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (1, N'ARbonita', N'Sylejmani', CAST(N'1998-01-01' AS Date))
INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Blendon', N'Luta', CAST(N'2012-01-01' AS Date))
INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Yll', N'Gashi', CAST(N'2000-01-01' AS Date))
INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Albiona', N'Ahmeti', CAST(N'2000-01-01' AS Date))
INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Artiola', N'Sylejmani', CAST(N'2000-01-01' AS Date))
INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (6, N'Altina', N'Sylejmani', CAST(N'2002-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientOffer] ON 

INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (4, 5, 2, CAST(N'2020-01-01' AS Date))
INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (5, 2, 2, CAST(N'2020-01-01' AS Date))
INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (6, 3, 5, CAST(N'2020-01-01' AS Date))
INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (7, 4, 3, CAST(N'2020-01-01' AS Date))
INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (8, 2, 2, CAST(N'2020-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[ClientOffer] OFF
GO
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (2, 20, 23.0000, N'Oferte e papare')
INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (3, 10, 24.0000, N'Oferte e papare')
INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (4, 4, 21.0000, N'Oferte e papare')
INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (5, 5, 12.0000, N'Oferte e papare')
INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (6, 13, 10.0000, N'Oferte e papare')
INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (7, 8, 5.0000, N'Oferte e papare')
SET IDENTITY_INSERT [dbo].[Offer] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'ARbonita', N'Sylejmani', N'arbonitasy@gmail.com', N'1998')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Blendon', N'Luta', N'blendonluta@gmail.com', N'2012')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Yll', N'Gashi', N'yllgashi@gmail.com', N'2000')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (4, N'Albiona', N'Ahmeti', N'albionaahmeti@gmail.com', N'2000')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (5, N'Artiola', N'Sylejmani', N'artiolasy@gmail.com', N'2000')
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (6, N'Altina', N'Sylejmani', N'altinasy@gmail.com', N'2002')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT ('No information') FOR [Publisher]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [Fk_BookAuthor_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [Fk_BookAuthor_AuthorId]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [Fk_BookAuthor_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [Fk_BookAuthor_BookId]
GO
ALTER TABLE [dbo].[BookCategory]  WITH CHECK ADD  CONSTRAINT [Fk_BookCategory_Book_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookCategory] CHECK CONSTRAINT [Fk_BookCategory_Book_BookId]
GO
ALTER TABLE [dbo].[BookCategory]  WITH CHECK ADD  CONSTRAINT [Fk_BookCategory_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[BookCategory] CHECK CONSTRAINT [Fk_BookCategory_Category_CategoryId]
GO
ALTER TABLE [dbo].[BookRent]  WITH CHECK ADD  CONSTRAINT [Fk_BookRent_Book_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookRent] CHECK CONSTRAINT [Fk_BookRent_Book_BookId]
GO
ALTER TABLE [dbo].[BookRent]  WITH CHECK ADD  CONSTRAINT [Fk_BookRent_Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[BookRent] CHECK CONSTRAINT [Fk_BookRent_Client_ClientId]
GO
ALTER TABLE [dbo].[ClientOffer]  WITH CHECK ADD  CONSTRAINT [Fk_ClientOffer_Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[ClientOffer] CHECK CONSTRAINT [Fk_ClientOffer_Client_ClientId]
GO
ALTER TABLE [dbo].[ClientOffer]  WITH CHECK ADD  CONSTRAINT [Fk_ClientOffer_Offer_OfferId] FOREIGN KEY([OfferId])
REFERENCES [dbo].[Offer] ([OfferId])
GO
ALTER TABLE [dbo].[ClientOffer] CHECK CONSTRAINT [Fk_ClientOffer_Offer_OfferId]
GO
/****** Object:  StoredProcedure [dbo].[usp_Author_Books_Get]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get author books
CREATE PROCEDURE [dbo].[usp_Author_Books_Get]
@id INT
AS
BEGIN
	SELECT TOP(2000) b.BookId, b.Title, b.Summary, b.PublishedYear, b.Publisher, b.ISBN, b.Pages, b.UnitPrice
	FROM BookAuthor AS ba
		INNER JOIN Book AS b ON b.BookId = ba.BookId
		INNER JOIN Author AS a ON a.AuthorId = ba.AuthorId
	WHERE ba.AuthorId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Author_Create]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create
CREATE PROCEDURE [dbo].[usp_Author_Create]
@firstName VARCHAR(50),
@lastName VARCHAR(50),
@birthDate DATE
AS
BEGIN
	BEGIN TRY
		INSERT INTO Author
		(
			FirstName,
			LastName,
			BirthDate
		)
		VALUES
		(
			@firstName,
			@lastName,
			@birthDate
		)
		RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Author_Delete]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete
CREATE PROCEDURE [dbo].[usp_Author_Delete]
@id INT
AS
BEGIN
	BEGIN TRY
		DELETE a
		FROM Author AS a
		WHERE a.AuthorId = @id
		RETURN @id;
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Author_Get]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get one author
CREATE PROCEDURE [dbo].[usp_Author_Get]
@id INT
AS
BEGIN
	SELECT TOP(1) a.AuthorId, a.FirstName, a.LastName, a.BirthDate
	FROM Author AS a
	WHERE a.AuthorId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Author_GetList]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get all authors
CREATE PROCEDURE [dbo].[usp_Author_GetList]
AS
BEGIN
	SELECT TOP(2000) a.AuthorId, a.FirstName, a.LastName, a.BirthDate
	FROM Author AS a
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Author_Update]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update
CREATE PROCEDURE [dbo].[usp_Author_Update]
@id INT,
@firstName VARCHAR(50),
@lastName VARCHAR(50),
@birthDate DATE
AS
BEGIN
	BEGIN TRY
		UPDATE a
		SET
			a.FirstName = @firstName,
			a.LastName = @lastName,
			a.BirthDate = @birthDate
		FROM Author AS a
		WHERE a.AuthorId = @id

		RETURN @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_User_Create]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_Create]
@firstName VARCHAR(50),
@lastName VARCHAR(50),
@email VARCHAR(50),
@password VARCHAR(30)
AS
BEGIN
	BEGIN TRY
		INSERT INTO [User]
		(
		FirstName,
		LastName,
		Email,
		[Password]
		)
		VALUES
		(
		@firstName,
		@lastName,
		@email,
		@password
		)
		RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Delete]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_Delete]
@id INT
AS
BEGIN
	BEGIN TRY
		DELETE u
		FROM [User] AS u
		WHERE u.UserId = @id
		RETURN @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Get]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_Get]
@id INT
AS
BEGIN
	SELECT TOP(1) u.UserId, u.FirstName, u.LastName, u.Email, u.[Password]
	FROM [User] AS u
	WHERE u.UserId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_GetList]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_GetList]
AS
BEGIN
	SELECT TOP(2000) u.UserId, u.FirstName, u.LastName, u.Email, u.[Password]
	FROM [User] AS u
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 5/7/2021 1:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_Update]
@id INT,
@firstName VARCHAR(50),
@lastName VARCHAR(50),
@email VARCHAR(50),
@password VARCHAR(30)
AS
BEGIN
	BEGIN TRY
		UPDATE u
		SET 
			u.FirstName = @firstName,
			u.LastName = @lastName,
			u.Email = @email,
			u.[Password] = @password
		FROM [User] AS u
		WHERE u.UserId = @id

		RETURN @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [MyLibrary] SET  READ_WRITE 
GO
