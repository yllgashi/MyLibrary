CREATE TABLE Book(
	BookId INT NOT NULL IDENTITY(1,1),
	Title VARCHAR(50) NOT NULL,
	Summary VARCHAR(300) NOT NULL,
	PublishedYear SMALLINT NOT NULL DEFAULT(-1),
	Publisher VARCHAR(60) NOT NULL DEFAULT('No information'),
	ISBN VARCHAR(15) NOT NULL,
	Pages SMALLINT NOT NULL,

	CONSTRAINT pk_Book_BookId PRIMARY KEY(BookId)
);

GO

CREATE TABLE Author(
	AuthorId INT NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Birthyear SMALLINT NOT NULL DEFAULT(-1),
	AddressId INT NOT NULL,

	CONSTRAINT pk_Author_AuthorId PRIMARY KEY(AuthorId),
	CONSTRAINT fk_Author_Address_AddressId FOREIGN KEY(AddressId)
		REFERENCES Address(AddressId)
);

GO

CREATE TABLE BookAuthor(
	BookAuthorId INT NOT NULL IDENTITY(1,1),
	BookId INT NOT NULL,
	AuthorId INT NOT NULL,

	CONSTRAINT pk_BookAuthor_BookAuthorId PRIMARY KEY(BookAuthorId),
	CONSTRAINT fk_BookAuthor_Book_BookId FOREIGN KEY(BookId)
		REFERENCES Book(BookId),
	CONSTRAINT fk_BookAuthor_Author_AuthorId FOREIGN KEY(AuthorId)
		REFERENCES Author(AuthorId)
);

GO

CREATE TABLE Category(
	CategoryId INT NOT NULL IDENTITY(1,1),
	CategoryName VARCHAR(30) NOT NULL,

	CONSTRAINT pk_Category_CategoryId PRIMARY KEY(CategoryId)
);

GO

CREATE TABLE BookCategory(
	BookCategoryId INT NOT NULL IDENTITY(1,1),
	BookId INT NOT NULL,
	CategoryId INT NOT NULL,

	CONSTRAINT pk_BookCategory_BookCategoryId PRIMARY KEY(BookCategoryId),
	CONSTRAINT fk_BookCategory_Book_BookId FOREIGN KEY(BookId)
		REFERENCES Book(BookId),
	CONSTRAINT fk_BookCategory_Category_CategoryId FOREIGN KEY(CategoryId)
		REFERENCES Category(CategoryId)
);

GO

CREATE TABLE Address(
	AddressId INT NOT NULL IDENTITY(1,1),
	CountryId INT NULL,
	CityId INT NULL,

	CONSTRAINT pk_Address_AddressId PRIMARY KEY(AddressId),
	CONSTRAINT fk_Address_Country_CountryId FOREIGN KEY(CountryId)
		REFERENCES Country(CountryId),
	CONSTRAINT fk_Address_City_CityId FOREIGN KEY(CityId)
		REFERENCES City(CityId),
);

GO

CREATE TABLE Country(
	CountryId INT NOT NULL IDENTITY(1,1),
	CountryName VARCHAR(74) NOT NULL,

	CONSTRAINT pk_Country_CountryId PRIMARY KEY(CountryId)
);

GO

CREATE TABLE City(
	CityId INT NOT NULL IDENTITY(1,1),
	CityName VARCHAR(70) NOT NULL,

	CONSTRAINT pk_City_CityId PRIMARY KEY(CityId)
);