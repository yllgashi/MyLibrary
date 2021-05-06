--Get all Categories
CREATE PROCEDURE usp_Category_GetList
AS
BEGIN
	SELECT TOP(2000) c.CategoryId, c.[Description]
	FROM Category AS c
END
GO

--Get One Category
CREATE PROCEDURE usp_Category_Get
@id INT
AS
BEGIN 
	SELECT TOP(1) c.CategoryId, c.[Description]
	FROM Category AS c
	WHERE c.CategoryId = @id
END
GO

--Create
CREATE PROCEDURE usp_Category_Create
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

--Update
CREATE PROCEDURE usp_Category_Update
@id INT,
@categoryId INT,
@description VARCHAR(50)
AS
BEGIN
	BEGIN TRY
		UPDATE c
		SET 
			c.CategoryId = @categoryId,
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
--Delete
CREATE PROCEDURE usp_Category_Delete
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

CREATE PROCEDURE usp_Get_Books_By_Category
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