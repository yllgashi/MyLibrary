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
CREATE PROCEDURE usp_Category_Update
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