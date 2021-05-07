
--SET IDENTITY_INSERT [dbo].[Author] ON 

--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Filan', N'Fisteku', CAST(N'2021-02-02' AS Date))
--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Haruki', N'Murakami', CAST(N'1998-01-01' AS Date))
--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Victor', N'Hugo', CAST(N'1802-01-01' AS Date))
--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Nicholas', N'Sparks', CAST(N'1960-01-01' AS Date))
--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (5, N'William', N'Shakespear', CAST(N'1700-01-01' AS Date))
--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (6, N'J.K', N'Rowling', CAST(N'1980-01-01' AS Date))
--INSERT [dbo].[Author] ([AuthorId], [FirstName], [LastName], [BirthDate]) VALUES (7, N'Franz', N'Kafka', CAST(N'1883-01-01' AS Date))
--SET IDENTITY_INSERT [dbo].[Author] OFF
GO
--SET IDENTITY_INSERT [dbo].[Book] ON 

--INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (1, N'Wutherin Heigh', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
--INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (3, N'Norvegian Wood', N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum..', 1855, N'Cautley Newby', N'1050261110 ', 232, 23.0000)
--INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (4, N'Kafka on the shore', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1866, N'Thomas Cautley', N'1853260010 ', 272, 21.0000)
--INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (5, N'Lord of the Flies ', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
--INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (6, N'Great Expectations ', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
--INSERT [dbo].[Book] ([BookId], [Title], [Summary], [PublishedYear], [Publisher], [ISBN], [Pages], [UnitPrice]) VALUES (7, N'Lolita ', N'Wuthering Heights is an 1847 novel by Emily Brontë, published under the pseudonym Ellis Bell. It concerns two families of the landed gentry living on the West Yorkshire moors, the Earnshaws and the Lintons.', 1847, N'Thomas Cautley Newby', N'1853260010 ', 272, 21.0000)
--SET IDENTITY_INSERT [dbo].[Book] OFF
--GO
--SET IDENTITY_INSERT [dbo].[BookAuthor] ON 

--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (1, 1, 2)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (2, 1, 1)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (4, 3, 1)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (5, 3, 2)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (7, 1, 2)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (8, 1, 3)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (9, 1, 4)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (10, 3, 4)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (11, 3, 5)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (12, 1, 5)
--INSERT [dbo].[BookAuthor] ([BookAuthorId], [BookId], [AuthorId]) VALUES (13, 4, 5)
--SET IDENTITY_INSERT [dbo].[BookAuthor] OFF

GO
--SET IDENTITY_INSERT [dbo].[Category] ON 

--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (1, N'Drama')
--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (2, N'Romance')
--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (3, N'Thriller')
--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (4, N'Fiction')
--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (5, N'Science')
--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (6, N'Action')
--INSERT [dbo].[Category] ([CategoryId], [Description]) VALUES (7, N'Kids')
--SET IDENTITY_INSERT [dbo].[Category] OFF

GO
--SET IDENTITY_INSERT [dbo].[BookCategory] ON 

--INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (1, 1, 1)
--INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (4, 3, 1)
--INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (5, 3, 1)
--INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (6, 4, 1)
--INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (7, 1, 3)
--INSERT [dbo].[BookCategory] ([BookCategoryId], [BookId], [CategoryId]) VALUES (8, 1, 3)
--SET IDENTITY_INSERT [dbo].[BookCategory] OFF

GO
--SET IDENTITY_INSERT [dbo].[Client] ON 

--INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (1, N'ARbonita', N'Sylejmani', CAST(N'1998-01-01' AS Date))
--INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Blendon', N'Luta', CAST(N'2012-01-01' AS Date))
--INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Yll', N'Gashi', CAST(N'2000-01-01' AS Date))
--INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Albiona', N'Ahmeti', CAST(N'2000-01-01' AS Date))
--INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Artiola', N'Sylejmani', CAST(N'2000-01-01' AS Date))
--INSERT [dbo].[Client] ([ClientId], [FirstName], [LastName], [BirthDate]) VALUES (6, N'Altina', N'Sylejmani', CAST(N'2002-01-01' AS Date))
--SET IDENTITY_INSERT [dbo].[Client] OFF

GO
--SET IDENTITY_INSERT [dbo].[BookRent] ON 

--INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (2, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
--INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (3, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
--INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (4, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
--INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (5, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
--INSERT [dbo].[BookRent] ([BookRentId], [BookId], [ClientId], [RentDate]) VALUES (6, 1, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
--SET IDENTITY_INSERT [dbo].[BookRent] OFF

GO
--SET IDENTITY_INSERT [dbo].[Offer] ON 

--INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (2, 20, 23.0000, N'Oferte e papare')
--INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (3, 10, 24.0000, N'Oferte e papare')
--INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (4, 4, 21.0000, N'Oferte e papare')
--INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (5, 5, 12.0000, N'Oferte e papare')
--INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (6, 13, 10.0000, N'Oferte e papare')
--INSERT [dbo].[Offer] ([OfferId], [Days], [Price], [Description]) VALUES (7, 8, 5.0000, N'Oferte e papare')
--SET IDENTITY_INSERT [dbo].[Offer] OFF

GO
--SET IDENTITY_INSERT [dbo].[ClientOffer] ON 

--INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (4, 5, 2, CAST(N'2020-01-01' AS Date))
--INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (5, 2, 2, CAST(N'2020-01-01' AS Date))
--INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (6, 3, 5, CAST(N'2020-01-01' AS Date))
--INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (7, 4, 3, CAST(N'2020-01-01' AS Date))
--INSERT [dbo].[ClientOffer] ([ClientOfferId], [ClientId], [OfferId], [AgreementDate]) VALUES (8, 2, 2, CAST(N'2020-01-01' AS Date))
--SET IDENTITY_INSERT [dbo].[ClientOffer] OFF
GO
--SET IDENTITY_INSERT [dbo].[User] ON 

--INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'ARbonita', N'Sylejmani', N'arbonitasy@gmail.com', N'1998')
--INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Blendon', N'Luta', N'blendonluta@gmail.com', N'2012')
--INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Yll', N'Gashi', N'yllgashi@gmail.com', N'2000')
--INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (4, N'Albiona', N'Ahmeti', N'albionaahmeti@gmail.com', N'2000')
--INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (5, N'Artiola', N'Sylejmani', N'artiolasy@gmail.com', N'2000')
--INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (6, N'Altina', N'Sylejmani', N'altinasy@gmail.com', N'2002')
--SET IDENTITY_INSERT [dbo].[User] OFF