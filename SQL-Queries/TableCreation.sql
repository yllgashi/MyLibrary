--CREATE DATABASE MyLibrary

USE MyLibrary

CREATE TABLE [User]
(
	UserId INT NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(40) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,

	CONSTRAINT Pk_User_UserId PRIMARY KEY(UserId),
)

GO

CREATE TABLE Book
(
	BookId INT NOT NULL IDENTITY(1,1),
	Title VARCHAR(50) NOT NULL,
	Summary VARCHAR(300) NOT NULL,
	PublishedYear SMALLINT NOT NULL,
	Publisher VARCHAR(60) NOT NULL DEFAULT('No information'),
	ISBN VARCHAR(15) NOT NULL,
	Pages SMALLINT NOT NULL,
	UnitPrice MONEY NOT NULL,

	CONSTRAINT Pk_Book_BookId PRIMARY KEY(BookId),
)

GO

CREATE TABLE Client
(
	ClientId INT NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	BirthDate DATE NOT NULL,

	CONSTRAINT Pk_Client_ClientId PRIMARY KEY(ClientId),
)

GO

CREATE TABLE BookRent
(
		BookRentId INT NOT NULL IDENTITY(1,1),
		BookId INT NOT NULL,
		ClientId INT NOT NULL,
		RentDate DATETIME NOT NULL,

		CONSTRAINT Pk_BookRent_BookRentId PRIMARY KEY(BookRentId),
		CONSTRAINT Fk_BookRent_Book_BookId FOREIGN KEY(BookId)
			REFERENCES Book(BookId),
		CONSTRAINT Fk_BookRent_Client_ClientId FOREIGN KEY(ClientId)
			REFERENCES Client(ClientId)
)

GO

CREATE TABLE Author
(
	AuthorId INT NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	BirthDate DATE NULL,

	CONSTRAINT Pk_Author_AuthorId PRIMARY KEY(AuthorId),
)

GO

CREATE TABLE BookAuthor
(
	BookAuthorId INT NOT NULL IDENTITY(1,1),
	BookId INT NOT NULL,
	AuthorId INT NOT NULL,

	CONSTRAINT Pk_BookAuthor_BookAuthorId PRIMARY KEY(BookAuthorId),
	CONSTRAINT Fk_BookAuthor_BookId FOREIGN KEY(BookId)
		REFERENCES Book(BookId),
	CONSTRAINT Fk_BookAuthor_AuthorId FOREIGN KEY(AuthorId)
		REFERENCES Author(AuthorId)
)

GO

CREATE TABLE Category
(
	CategoryId INT NOT NULL IDENTITY(1,1),
	[Description] VARCHAR(100) NOT NULL,

	CONSTRAINT Pk_Category_CategoryId PRIMARY KEY(CategoryId),
)

GO

CREATE TABLE BookCategory
(
	BookCategoryId INT NOT NULL IDENTITY(1,1),
	BookId INT NOT NULL,
	CategoryId INT NOT NULL,

	CONSTRAINT Pk_BookCategory_BookCategoryId PRIMARY KEY(BookCategoryId),
	CONSTRAINT Fk_BookCategory_Book_BookId FOREIGN KEY (BookId)
		REFERENCES Book(BookId),
	CONSTRAINT Fk_BookCategory_Category_CategoryId FOREIGN KEY (CategoryId)
		REFERENCES Category(CategoryId),
)

GO

CREATE TABLE Offer
(
	OfferId INT NOT NULL IDENTITY(1,1),
	[Days] INT NOT NULL,
	Price MONEY NOT NULL,
	[Description] VARCHAR(100) NOT NULL,

	CONSTRAINT Pk_Offer_OfferId PRIMARY KEY(OfferId),
)

GO

CREATE TABLE ClientOffer
(
	ClientOfferId INT NOT NULL IDENTITY(1,1),
	ClientId INT NOT NULL,
	OfferId INT NOT NULL,
	AgreementDate DATE NOT NULL,

	CONSTRAINT Pk_ClientOffer_ClientOfferId PRIMARY KEY(ClientOfferId),
	CONSTRAINT Fk_ClientOffer_Client_ClientId FOREIGN KEY (ClientId)
		REFERENCES Client(ClientId),
	CONSTRAINT Fk_ClientOffer_Offer_OfferId FOREIGN KEY (OfferId)
		REFERENCES Offer(OfferId),
)

--CREATE TABLE BookOrder
--(
--	BookOrderId INT NOT NULL IDENTITY(1,1),
--	OrderDate DATETIME NOT NULL

--	CONSTRAINT Pk_BookOrder_BookOrderId PRIMARY KEY(BookOrderId),
--)

--CREATE TABLE BookOrderDetails
--(
--	BookOrderDetailsId INT NOT NULL IDENTITY(1,1),
--	BookId INT NOT NULL,
--	Price MONEY NOT NULL,
--	Quantity INT NOT NULL,
--	Discount TINYINT NOT NULL

--	CONSTRAINT Pk_BookOrderDetails_BookOrderDetailsId PRIMARY KEY(BookOrderDetailsId),
--)