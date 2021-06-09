using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyLibrary.Access
{
    public class ClientAccess
    {
        public List<Client> GetList()
        {
            List<Client> clients = new List<Client>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Client_GetList", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        clients.Add(GetClientFromDb(reader));
                    }

                    return clients;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Client Get(int id)
        {
            Client client = new Client();
            // usp_Client_Get
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Client_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    if (!reader.HasRows) throw new Exception();

                    while (reader.Read())
                    {
                        client = GetClientFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // usp_Client_Get_Offers
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Client_Get_Offers", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                client.ClientOffers = new List<ClientOffer>();
                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client.ClientOffers.Add(GetClientOfferFromDb(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // usp_BookRent_Get_By_Client
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_BookRent_Get_By_Client", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                client.BookRents = new List<BookRent>();
                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client.BookRents.Add(GetBookRentFromDb(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // usp_

            return client;
        }

        public bool Create(Client client)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Client_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@firstName", client.FirstName);
                DatabaseConn.cmd.Parameters.AddWithValue("@lastName", client.LastName);
                DatabaseConn.cmd.Parameters.AddWithValue("@birthDate", client.BirthDate);

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

        public bool Update(int id, Client client)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Client_Update", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
                DatabaseConn.cmd.Parameters.AddWithValue("@firstName", client.FirstName);
                DatabaseConn.cmd.Parameters.AddWithValue("@lastName", client.LastName);
                DatabaseConn.cmd.Parameters.AddWithValue("@birthDate", client.BirthDate);

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
                DatabaseConn.cmd = new SqlCommand("usp_Client_Delete", DatabaseConn.conn);
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

        private ClientOffer GetClientOfferFromDb(SqlDataReader reader)
        {
            ClientOffer clientOffer = new ClientOffer()
            {
                Offer = new Offer()
                {
                    OfferId = int.Parse(reader["OfferId"].ToString()),
                    Days = int.Parse(reader["Days"].ToString()),
                    Price = double.Parse(reader["Price"].ToString()),
                    Description = reader["Description"].ToString(),
                },
                AgreementDate = DateTime.Parse(reader["AgreementDate"].ToString()),
            };
            return clientOffer;
        }

        private BookRent GetBookRentFromDb(SqlDataReader reader)
        {
            BookRent bookRent = new BookRent()
            {
                BookRentId = int.Parse(reader["BookRentId"].ToString()),
                BookId = int.Parse(reader["BookId"].ToString()),
                ClientId = int.Parse(reader["ClientId"].ToString()),
                RentDate = DateTime.Parse(reader["RentDate"].ToString()),
                Book = new Book()
                {
                    BookId = int.Parse(reader["BookId"].ToString()),
                    Title = reader["Title"].ToString(),
                    Summary = reader["Summary"].ToString(),
                    PublishedYear = short.Parse(reader["PublishedYear"].ToString()),
                    Publisher = reader["Publisher"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    Pages = int.Parse(reader["Pages"].ToString()),
                    UnitPrice = double.Parse(reader["UnitPrice"].ToString())
                }
            };

            return bookRent;
        }
    }
}
