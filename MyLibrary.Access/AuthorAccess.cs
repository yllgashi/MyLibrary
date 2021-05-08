using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataAccess
{
    public class AuthorAccess
    {
        public List<Author> GetList()
        {
            List<Author> authors = new List<Author>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Author_GetList", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        authors.Add(GetAuthorFromDb(reader));
                    }

                    return authors;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public Author Get(int id)
        {
            // usp_Author_Get
            // usp_Author_Books_Get
            Author author = new Author();
            // get author
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Author_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        author = GetAuthorFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // get author books
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Author_Books_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                author.Books = new List<Book>();
                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        author.Books.Add(GetAuthorBooksFromDb(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return author;
        }

        public bool Create(Author author)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Author_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@firstName", author.FirstName);
                DatabaseConn.cmd.Parameters.AddWithValue("@lastName", author.LastName);
                DatabaseConn.cmd.Parameters.AddWithValue("@birthDate", author.BirthDate);

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

        public bool Update(int id, Author author)
        {
            DatabaseConn.cmd = new SqlCommand("usp_Author_Update", DatabaseConn.conn);
            DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
            DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
            DatabaseConn.cmd.Parameters.AddWithValue("@firstName", author.FirstName);
            DatabaseConn.cmd.Parameters.AddWithValue("@lastName", author.LastName);
            DatabaseConn.cmd.Parameters.AddWithValue("@birthDate", author.BirthDate);

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

        public bool Delete(int id)
        {
            DatabaseConn.cmd = new SqlCommand("usp_Author_Delete", DatabaseConn.conn);
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

        private Book GetAuthorBooksFromDb(SqlDataReader reader)
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

    }
}
