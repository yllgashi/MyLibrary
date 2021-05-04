using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibrary.Models;

namespace MyLibrary.DataAccess
{
    public class Db
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author()
            {
                AuthorId = 1,
                FirstName = "Gjergj",
                LastName = "Fishta",
                BirthDate = DateTime.Now
            },
            new Author()
            {
                AuthorId = 2,
                FirstName = "Ernest",
                LastName = "Hemingway",
                BirthDate = DateTime.Now
            },
            new Author()
            {
                AuthorId = 3,
                FirstName = "Franc",
                LastName = "Kafka",
                BirthDate = DateTime.Now
            }
        };

        public static List<Book> Books = new List<Book>
        {
            new Book()
            {
                BookId = 1,
                Title = "Test",
                Summary = "Test",
                ISBN = "123456789123456",
                Pages = 120,
                PublishedYear = 2021,
                Publisher = "Buzuku",
                UnitPrice = 7.50
            },
            new Book()
            {
                BookId = 2,
                Title = "Test2",
                Summary = "Test2",
                ISBN = "123456789123456",
                Pages = 50,
                PublishedYear = 2020,
                Publisher = "Buzuku",
                UnitPrice = 5
            }
        };

        public static List<BookAuthor> BookAuthors = new List<BookAuthor>()
        {
            new BookAuthor()
            {
                BookAuthorId = 1,
                AuthorId = 1,
                BookId = 1
            },
            new BookAuthor()
            {
                BookAuthorId = 2,
                AuthorId = 2,
                BookId = 2
            }
        };

        public static List<BookCategory> BookCategories = new List<BookCategory>()
        {
            new BookCategory()
            {
                BookCategoryId = 1,
                BookId = 1,
                CategoryId = 1
            },
            new BookCategory()
            {
                BookCategoryId = 2,
                BookId = 2,
                CategoryId = 2
            }
        };

        public static List<BookRentAccess> BookRents = new List<BookRentAccess>()
        {
            new BookRentAccess()
            {
                BookRentId = 1,
                BookId = 1,
                ClientId = 1,
                RentDate = DateTime.Now
            },
            new BookRentAccess()
            {
                BookRentId = 2,
                BookId = 2,
                ClientId = 2,
                RentDate = DateTime.Now
            }
        };

        public static List<Category> Categories = new List<Category>()
        {
             new Category()
             {
                 CategoryId = 1,
                 Description = "Aksion"
             },
             new Category()
             {
                 CategoryId = 2,
                 Description = "Drame"
             }
        };

        public static List<Client> Clients = new List<Client>()
        {
            new Client()
            {
                ClientId = 1,
                FirstName = "Testim",
                LastName = "Testeri",
                BirthDate = DateTime.Now
            },
            new Client()
            {
                ClientId = 2,
                FirstName = "Filan",
                LastName = "Fisteku",
                BirthDate = DateTime.Now
            }
        };

        public static List<ClientOffer> ClientOffers = new List<ClientOffer>()
        {
            new ClientOffer()
            {
                ClientOfferId = 1,
                ClientId = 1,
                OfferId = 1,
                AgreementDate = DateTime.Now
            },
            new ClientOffer()
            {
                ClientOfferId = 2,
                ClientId = 2,
                OfferId = 2,
                AgreementDate = DateTime.Now
            }
        };

        public static List<Offer> Offers = new List<Offer>()
        {
            new Offer()
            {
                OfferId = 1,
                Days = 365,
                Description = "One year offer",
                Price = 10
            },
            new Offer()
            {
                OfferId = 2,
                Days = 30,
                Description = "One month offer",
                Price = 2
            }
        };

        public static List<User> Users = new List<User>()
        {
            new User()
            {
                UserId = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                Password = "123456789"
            },
            new User()
            {
                UserId = 2,
                FirstName = "Testim",
                LastName = "Testeri",
                Email = "testim@testeri.com",
                Password = "123456789"
            }
        };
    }
}
