using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyLibrary.Access
{
    public class BookAccess
    {
        public List<Book> GetList()
        {
            List<Book> books = new List<Book>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Get_List", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        books.Add(GetBookFromDb(reader));
                    }

                    return books;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Book Get(int id)
        {
            //usp_Book_Get
            //usp_Book_Get_Category
            //usp_Book_Get_Authors
            Book book = new Book();

            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    if (!reader.HasRows) throw new Exception();

                    while (reader.Read())
                    {
                        book = GetBookFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Get_Category", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                book.Categories = new List<Category>();
                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        book.Categories.Add(GetCategoryFromDb(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Get_Authors", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                book.Authors = new List<Author>();
                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        book.Authors.Add(GetAuthorFromDb(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return book;
        }

        public bool Create(Book book)
        {
            // usp_Book_Create
            //usp_Category_Add_Book_Category
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@title", book.Title);
                DatabaseConn.cmd.Parameters.AddWithValue("@summary", book.Summary);
                DatabaseConn.cmd.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
                DatabaseConn.cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                DatabaseConn.cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                DatabaseConn.cmd.Parameters.AddWithValue("@pages", book.Pages);
                DatabaseConn.cmd.Parameters.AddWithValue("@birthDate", book.UnitPrice);

                try
                {
                    DatabaseConn.conn.Open();
                    DatabaseConn.cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            CreateBookCategories(book.Categories, book.BookId);
            return true;
        }

        public bool Update(int id, Book book)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Update", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
                DatabaseConn.cmd.Parameters.AddWithValue("@title", book.Title);
                DatabaseConn.cmd.Parameters.AddWithValue("@summary", book.Summary);
                DatabaseConn.cmd.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
                DatabaseConn.cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                DatabaseConn.cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                DatabaseConn.cmd.Parameters.AddWithValue("@pages", book.Pages);
                DatabaseConn.cmd.Parameters.AddWithValue("@birthDate", book.UnitPrice);

                try
                {
                    DatabaseConn.conn.Open();
                    DatabaseConn.cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Delete(int id)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Delete", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    DatabaseConn.conn.Open();
                    DatabaseConn.cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool CreateBookCategories(List<Category> categories, int bookId)
        {
            foreach (Category item in categories)
            {
                {
                    DatabaseConn.cmd = new SqlCommand("usp_Category_Add_Book_Category", DatabaseConn.conn);
                    DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                    DatabaseConn.cmd.Parameters.AddWithValue("@categoryId", item.CategoryId);
                    DatabaseConn.cmd.Parameters.AddWithValue("@bookId", bookId);

                    try
                    {
                        DatabaseConn.conn.Open();
                        DatabaseConn.cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return true;
        }

        private Book GetBookFromDb(SqlDataReader reader)
        {
            Book book = new Book()
            {
                BookId = int.Parse(reader["BookId"].ToString()),
                Title = reader["Title"].ToString(),
                Summary = reader["Summary"].ToString(),
                PublishedYear = short.Parse(reader["PublishedYear"].ToString()),
                Publisher = reader["Publisher"].ToString(),
                ISBN = reader["ISBN"].ToString(),
                Pages = int.Parse(reader["Pages"].ToString()),
                UnitPrice = double.Parse(reader["UnitPrice"].ToString())
            };

            return book;
        }

        private Author GetAuthorFromDb(SqlDataReader reader)
        {
            Author author = new Author()
            {
                AuthorId = int.Parse(reader["AuthorId"].ToString()),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = DateTime.Parse(reader["BirthDate"].ToString())
            };

            return author;
        }

        private Category GetCategoryFromDb(SqlDataReader reader)
        {
            Category category = new Category()
            {
                CategoryId = int.Parse(reader["CategoryId"].ToString()),
                Description = reader["Description"].ToString(),
            };

            return category;
        }
    }
}
