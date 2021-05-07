-- Get all clients
CREATE PROCEDURE usp_Client_Get_All
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

-- Get single client
CREATE PROCEDURE usp_Client_Get
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

-- Create client
CREATE PROCEDURE usp_Client_Create
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

-- Update client
CREATE PROCEDURE usp_Client_Update
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

-- Delete client
CREATE PROCEDURE usp_Client_Delete
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

-- Create client offer
CREATE PROCEDURE usp_Client_Get_Offers
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

CREATE PROCEDURE usp_BookRent_Get_By_Client
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