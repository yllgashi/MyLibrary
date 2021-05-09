USE [master]
GO
/****** Object:  Database [MyLibrary]    Script Date: 5/9/2021 7:26:21 PM ******/
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
/****** Object:  Table [dbo].[Author]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[Book]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[BookCategory]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[BookRent]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[Client]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[ClientOffer]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[Offer]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Author_Books_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Author_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Author_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Author_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Author_Get]
@id INT
AS
BEGIN
	SELECT TOP(1) a.AuthorId, a.FirstName, a.LastName, a.BirthDate
	FROM Author AS a
	WHERE a.AuthorId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Author_GetList]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Author_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Book_Add_Author]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Book_Add_Author]
@bookId INT,
@authorId INT
AS
BEGIN
	INSERT INTO BookAuthor
	(
		AuthorId,
		BookId
	)
	VALUES
	(
		@authorId,
		@bookId
	)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create book
CREATE PROCEDURE [dbo].[usp_Book_Create]
@title VARCHAR(50),
@summary VARCHAR(300),
@publishedYear SMALLINT,
@publisher VARCHAR(60),
@isbn VARCHAR(15),
@pages SMALLINT,
@unitPrice MONEY
AS
BEGIN
	BEGIN TRY
		INSERT INTO dbo.Book
		(
			Title,
			Summary,
			PublishedYear,
			Publisher,
			ISBN,
			Pages,
			UnitPrice
		)
		VALUES
		(
			@title,
			@summary,
			@publishedYear,
			@publisher,
			@isbn,
			@pages,
			@unitPrice
		)

		RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete book
CREATE PROCEDURE [dbo].[usp_Book_Delete]
@id INT
AS
BEGIN
	BEGIN TRY
		DELETE b
		FROM Book AS b
		WHERE b.BookId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get single book
CREATE PROCEDURE [dbo].[usp_Book_Get]
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT TOP(1) b.BookId, b.Title, b.Summary, b.PublishedYear, b.Publisher, b.ISBN, b.Pages, b.UnitPrice
		FROM Book AS b
		WHERE b.BookId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Get_Authors]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Book_Get_Authors]
@id INT
AS
BEGIN
	SELECT TOP(100) a.AuthorId, a.FirstName, a.LastName, a.BirthDate
	FROM Author AS a
		INNER JOIN BookAuthor AS ba ON ba.BookId = @id
	WHERE ba.BookId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Get_Category]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Book_Get_Category]
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT c.CategoryId, c.Description
		FROM BookCategory AS bc
			INNER JOIN Category AS c ON c.CategoryId = bc.CategoryId
	WHERE bc.BookId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Get_List]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get all books
CREATE PROCEDURE [dbo].[usp_Book_Get_List]
AS
BEGIN
	BEGIN TRY
		SELECT TOP(2000) b.BookId, b.Title, b.Summary, b.PublishedYear, b.Publisher, b.ISBN, b.Pages, b.UnitPrice
		FROM Book AS b
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Book_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Book_Update]
@id INT,
@title VARCHAR(50),
@summary VARCHAR(300),
@publishedYear SMALLINT,
@publisher VARCHAR(60),
@isbn VARCHAR(15),
@pages SMALLINT,
@unitPrice MONEY
AS
BEGIN
	BEGIN TRY
		UPDATE b
		SET
			b.Title = @title,
			b.Summary = @summary,
			b.PublishedYear = @publishedYear,
			b.Publisher = @publisher,
			b.ISBN = @isbn,
			b.Pages = @pages,
			b.UnitPrice = @unitPrice
		FROM Book AS b
		Where b.BookId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_BookRent_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create 
CREATE PROCEDURE [dbo].[usp_BookRent_Create]
@bookId int,
@clientId int,
@rentDate DATE 
AS
BEGIN
	BEGIN TRY
		INSERT INTO BookRent
		(
			BookId,
			ClientId,
			RentDate
		)
		VALUES
		(
		@bookId,
		@clientId,
		@rentDate
		)
		RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BookRent_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Delete
CREATE PROCEDURE [dbo].[usp_BookRent_Delete]
@id INT
AS
BEGIN
	BEGIN TRY
		DELETE b
		FROM BookRent AS b
		WHERE b.BookRentId = @id
		RETURN @id;
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BookRent_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get one BookRent
CREATE PROCEDURE [dbo].[usp_BookRent_Get]
@id INT
AS
BEGIN 
	SELECT TOP(1) b.BookId, b.ClientId, b.RentDate
	FROM BookRent AS b
	WHERE b.BookRentId = @id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_BookRent_Get_By_Client]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_BookRent_Get_By_Client]
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT TOP(5000) b.BookId, b.Title, b.Summary, b.PublishedYear, b.Publisher, b.ISBN, b.Pages, b.UnitPrice
		FROM BookRent AS br
			INNER JOIN Book AS b ON b.BookId = br.BookId
		WHERE br.ClientId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BookRent_GetList]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get All BookRent
CREATE PROCEDURE [dbo].[usp_BookRent_GetList]
AS
BEGIN 
	SELECT TOP(2000) b.BookId, b.ClientId, b.RentDate
	FROM BookRent AS b
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BookRent_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[usp_BookRent_Update]
@id INT,
@bookId INT,
@clientId INT,
@rentDate DATE
AS 
BEGIN
	BEGIN TRY 
		UPDATE b
		SET
			b.BookId = @bookId,
			b.ClientId = @clientId,
			b.RentDate = @rentDate
		FROM BookRent AS b
		WHERE b.BookRentId = @id

		RETURN @id
	END TRY
	BEGIN CATCH 
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_Add_Book_Category]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Category_Add_Book_Category]
@categoryId INT,
@bookId INT
AS
BEGIN
		INSERT INTO dbo.BookCategory
		(
			BookId,
			CategoryId
		)
		VALUES
		(
			SCOPE_IDENTITY(),
			@categoryId
		)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create
CREATE PROCEDURE [dbo].[usp_Category_Create]
@categoryId int,
@description VARCHAR(50)
AS
BEGIN
	BEGIN TRY
	INSERT INTO Category
	(
		CategoryId,
		[Description]
	)
	VALUES
	(
	@categoryId,
	@description
	)
	RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Delete
CREATE PROCEDURE [dbo].[usp_Category_Delete]
@id INT
AS
BEGIN 
	BEGIN TRY
		DELETE c
		FROM Category AS c
		WHERE c.CategoryId = @id
		RETURN @id;
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Category_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Get One Category
CREATE PROCEDURE [dbo].[usp_Category_Get]
@id INT
AS
BEGIN 
	SELECT TOP(1) c.CategoryId, c.[Description]
	FROM Category AS c
	WHERE c.CategoryId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_Get_Books_By_Category]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Category_Get_Books_By_Category]
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT TOP(2000) b.BookId, b.Title, b.Summary, b.PublishedYear, b.Publisher, b.ISBN, b.Pages, b.UnitPrice
		FROM BookCategory AS bc
			INNER JOIN Book AS b ON b.BookId = bc.BookId
		WHERE bc.BookCategoryId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_GetList]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get all Categories
CREATE PROCEDURE [dbo].[usp_Category_GetList]
AS
BEGIN
	SELECT TOP(2000) c.CategoryId, c.[Description]
	FROM Category AS c
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Category_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Category_Update]
@id INT,
@categoryId INT,
@description VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		UPDATE c
		SET 
			c.[Description] = @description
		FROM Category AS c
		WHERE c.CategoryId = @id

		RETURN @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Client_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create client
CREATE PROCEDURE [dbo].[usp_Client_Create]
@firstName VARCHAR(50),
@lastName VARCHAR(50),
@birthDate DATE
AS
BEGIN
	BEGIN TRY
		INSERT INTO Client
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
/****** Object:  StoredProcedure [dbo].[usp_Client_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete client
CREATE PROCEDURE [dbo].[usp_Client_Delete]
@id INT
AS
BEGIN
	BEGIN TRY
		DELETE c
		FROM Client AS c
		WHERE c.ClientId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Client_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Get single client
CREATE PROCEDURE [dbo].[usp_Client_Get]
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT TOP(1) c.ClientId, c.FirstName, c.LastName, c.BirthDate 
		FROM Client AS c
		WHERE c.ClientId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Client_Get_All]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Get all clients
CREATE PROCEDURE [dbo].[usp_Client_Get_All]
AS
BEGIN
	BEGIN TRY
		SELECT TOP(5000) c.ClientId, c.FirstName, c.LastName, c.BirthDate 
		FROM Client AS c
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Client_Get_Offers]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create client offer
CREATE PROCEDURE [dbo].[usp_Client_Get_Offers]
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT TOP(2000) o.OfferId, o.[Days], o.Price, o.[Description], co.AgreementDate
		FROM ClientOffer AS co
			INNER JOIN Client AS c ON c.ClientId = co.ClientId
			INNER JOIN Offer AS o ON o.OfferId = co.OfferId
		WHERE co.ClientId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[usp_Client_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Client_Update]
@id INT,
@firstName VARCHAR(50),
@lastName VARCHAR(50),
@birthDate DATE
AS
BEGIN
	BEGIN TRY
		UPDATE c
		SET
			c.FirstName = @firstName,
			c.LastName = @lastName,
			c.BirthDate = @birthDate
		FROM Client AS c
		WHERE c.ClientId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Offer_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create
CREATE PROCEDURE [dbo].[usp_Offer_Create]
@days INT,
@price MONEY,
@description VARCHAR(100)
AS
BEGIN
	BEGIN TRY
		INSERT INTO Offer
		(
		[Days],
		[Price],
		[Description]
		)
		VALUES
		(
		@days,
		@price,
		@description
		)
		RETURN SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END 
GO
/****** Object:  StoredProcedure [dbo].[usp_Offer_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete
CREATE PROCEDURE [dbo].[usp_Offer_Delete]
@id INT
AS
BEGIN
    BEGIN TRY
        DELETE o
        FROM Offer AS o
        WHERE o.OfferId = @id
        RETURN @id;
    END TRY
    BEGIN CATCH
        RETURN -1;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Offer_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get one Offer
CREATE PROCEDURE [dbo].[usp_Offer_Get]
@id INT
AS
BEGIN 
	SELECT TOP(1) o.OfferId, o.[Days], o.[Price], o.[Description]
	FROM Offer AS o
	WHERE o.OfferId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Offer_GetList]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get All Offers
CREATE PROCEDURE [dbo].[usp_Offer_GetList]
AS
BEGIN
	SELECT TOP(2000) o.OfferId, o.[Days], o.[Price], o.[Description]
	FROM Offer AS o
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Offer_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Update
CREATE PROCEDURE [dbo].[usp_Offer_Update]
@id INT,
@days INT,
@price MONEY,
@description VARCHAR(100)
AS
BEGIN
	BEGIN TRY
		UPDATE o
		SET 
			o.[Days] = @days,
			o.[Price] = @price,
			o.[Description] = @description
		FROM Offer AS o
		WHERE o.OfferId = @id

		RETURN @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Create]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create 
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
/****** Object:  StoredProcedure [dbo].[usp_User_Delete]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Delete
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
/****** Object:  StoredProcedure [dbo].[usp_User_Get]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get one User
CREATE PROCEDURE [dbo].[usp_User_Get]
@id INT
AS
BEGIN
	SELECT TOP(1) u.UserId, u.FirstName, u.LastName, u.Email, u.[Password]
	FROM [User] AS u
	WHERE u.UserId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_GetList]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Get All Users
CREATE PROCEDURE [dbo].[usp_User_GetList]
AS
BEGIN
	SELECT TOP(2000) u.UserId, u.FirstName, u.LastName, u.Email, u.[Password]
	FROM [User] AS u
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 5/9/2021 7:26:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Update
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
