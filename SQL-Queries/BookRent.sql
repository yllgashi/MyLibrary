--Get All BookRent
CREATE PROCEDURE usp_BookRent_GetList
AS
BEGIN 
	SELECT TOP(2000) b.BookId, b.ClientId, b.RentDate
	FROM BookRent AS b
END
GO

--Get one BookRent
CREATE PROCEDURE usp_BookRent_Get
@id INT
AS
BEGIN 
	SELECT TOP(1) b.BookId, b.ClientId, b.RentDate
	FROM BookRent AS b
	WHERE b.BookRentId = @id
END

GO
--Create 
CREATE PROCEDURE usp_BookRent_Create
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

--Update
CREATE PROCEDURE usp_BookRent_Update
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

--Delete
CREATE PROCEDURE usp_BookRent_Delete
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