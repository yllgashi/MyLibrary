--Get All Users
CREATE PROCEDURE usp_User_GetList
AS
BEGIN
	SELECT TOP(2000) u.UserId, u.FirstName, u.LastName, u.Email, u.[Password]
	FROM [User] AS u
END
GO
--Get one User
CREATE PROCEDURE usp_User_Get
@id INT
AS
BEGIN
	SELECT TOP(1) u.UserId, u.FirstName, u.LastName, u.Email, u.[Password]
	FROM [User] AS u
	WHERE u.UserId = @id
END
GO
--Create 
CREATE PROCEDURE usp_User_Create
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
--Update
CREATE PROCEDURE usp_User_Update
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
--Delete
CREATE PROCEDURE usp_User_Delete
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