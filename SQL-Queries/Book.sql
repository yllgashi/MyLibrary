-- Get all books
CREATE PROCEDURE usp_Book_Get_List
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

-- Get single book
CREATE PROCEDURE usp_Book_Get
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

-- Create book
CREATE PROCEDURE usp_Book_Create
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

-- Update book
CREATE PROCEDURE usp_Book_Update
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
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END

GO

-- Delete book
CREATE PROCEDURE usp_Book_Delete
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

-- Get book categories
CREATE PROCEDURE usp_Book_Get_Category
@id INT
AS
BEGIN
	BEGIN TRY
		SELECT b.BookId, b.Title, b.Summary, b.PublishedYear, b.Publisher, b.ISBN, b.Pages, b.UnitPrice
		FROM BookCategory AS bc
			INNER JOIN Book AS b ON b.BookId = bc.BookId
	WHERE bc.BookId = @id
	END TRY
	BEGIN CATCH
		RETURN -1;
	END CATCH
END