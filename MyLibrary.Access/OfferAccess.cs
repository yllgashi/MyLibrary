using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyLibrary.Access
{
    public class OfferAccess
    {
        public List<Offer> GetList()
        {
            List<Offer> offers = new List<Offer>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Offer_GetList", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        offers.Add(GetOfferFromDb(reader));
                    }

                    return offers;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Offer Get(int id)
        {
            Offer offer = new Offer();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Offer_Get", DatabaseConn.conn);
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
                        offer = GetOfferFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return offer;
        }

        public bool Create(Offer offer)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Offer_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@days", offer.Days);
                DatabaseConn.cmd.Parameters.AddWithValue("@price", offer.Price);
                DatabaseConn.cmd.Parameters.AddWithValue("@description", offer.Description);

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

        public bool Update(int id, Offer offer)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Offer_Update", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
                DatabaseConn.cmd.Parameters.AddWithValue("@days", offer.Days);
                DatabaseConn.cmd.Parameters.AddWithValue("@price", offer.Price);
                DatabaseConn.cmd.Parameters.AddWithValue("@description", offer.Description);

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
                DatabaseConn.cmd = new SqlCommand("usp_Offer_Delete", DatabaseConn.conn);
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

        private Offer GetOfferFromDb(SqlDataReader reader)
        {
            Offer offer = new Offer()
            {
                OfferId = int.Parse(reader["OfferId"].ToString()),
                Days = int.Parse(reader["Days"].ToString()),
                Price = double.Parse(reader["Price"].ToString()),
                Description = reader["Description"].ToString(),
            };
            return offer;
        }
    }
}
