using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyLibrary.Access
{
    public class BookRentAccess
    {
        public List<BookRent> GetList()
        {
            List<BookRent> bookRents = new List<BookRent>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_BookRent_GetList", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bookRents.Add(GetBookRentFromDb(reader));
                    }

                    return bookRents;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public BookRent Get(int id)
        {
            BookRent bookRent = new BookRent();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_BookRent_Get", DatabaseConn.conn);
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
                        bookRent = GetBookRentFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Client_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", bookRent.ClientId);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bookRent.Client = GetClientFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Book_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", bookRent.BookId);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bookRent.Book = GetBookFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return bookRent;
        }

        public bool Create(BookRent bookRent)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_BookRent_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@bookId", bookRent.BookId);
                DatabaseConn.cmd.Parameters.AddWithValue("@clientId", bookRent.ClientId);
                DatabaseConn.cmd.Parameters.AddWithValue("@rentDate", bookRent.RentDate);

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

        public bool Update(int id, BookRent bookRent)
        {
            DatabaseConn.cmd = new SqlCommand("usp_BookRent_Update", DatabaseConn.conn);
            DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
            DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
            DatabaseConn.cmd.Parameters.AddWithValue("@bookId", bookRent.BookId);
            DatabaseConn.cmd.Parameters.AddWithValue("@clientId", bookRent.ClientId);
            DatabaseConn.cmd.Parameters.AddWithValue("@rentDate", bookRent.RentDate);

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
            DatabaseConn.cmd = new SqlCommand("usp_BookRent_Delete", DatabaseConn.conn);
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

        private BookRent GetBookRentFromDb(SqlDataReader reader)
        {
            BookRent bookRent = new BookRent()
            {
                BookRentId = int.Parse(reader["BookRentId"].ToString()),
                BookId = int.Parse(reader["BookId"].ToString()),
                ClientId = int.Parse(reader["ClientId"].ToString()),
                RentDate = DateTime.Parse(reader["RentDate"].ToString()),
            };

            return bookRent;
        }


        private Client GetClientFromDb(SqlDataReader reader)
        {
            Client client = new Client()
            {
                ClientId = int.Parse(reader["ClientId"].ToString()),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                BookRents = new List<BookRent>(),
                ClientOffers = new List<ClientOffer>()
            };

            return client;
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
    }
}
