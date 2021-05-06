--Get All Offers
CREATE PROCEDURE usp_Offer_GetList
AS
BEGIN
	SELECT TOP(2000) o.OfferId, o.[Days], o.[Price], o.[Description]
	FROM Offer AS o
END
GO
--Get one Offer
CREATE PROCEDURE usp_Offer_Get
@id INT
AS
BEGIN 
	SELECT TOP(1) o.OfferId, o.[Days], o.[Price], o.[Description]
	FROM Offer AS o
	WHERE o.OfferId = @id
END
GO
--Create
CREATE PROCEDURE usp_Offer_Create
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

--Update
CREATE PROCEDURE usp_Offer_Update
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
-- Delete
CREATE PROCEDURE usp_Offer_Delete
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