-- Get all authors
CREATE PROCEDURE usp_Author_GetList
AS
BEGIN
    SELECT TOP(2000) a.AuthorId, a.FirstName, a.LastName, a.BirthDate
    FROM Author AS a
END
GO
-- Get one author
CREATE PROCEDURE usp_Author_Get
@id INT
AS
BEGIN
    SELECT TOP(1) a.AuthorId, a.FirstName, a.LastName, a.BirthDate
    FROM Author AS a
    WHERE a.AuthorId = @id
END
GO
-- Get author books
CREATE PROCEDURE usp_Author_Books_Get
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
-- Create
CREATE PROCEDURE usp_Author_Create
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
-- Update
CREATE PROCEDURE usp_Author_Update
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
-- Delete
CREATE PROCEDURE usp_Author_Delete
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