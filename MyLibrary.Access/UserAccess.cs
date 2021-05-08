using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyLibrary.Access
{
    public class UserAccess
    {
        public List<User> GetList()
        {
            List<User> users = new List<User>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_User_GetList", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(GetUserFromDb(reader));
                    }

                    return users;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public User Get(int id)
        {
            User user = new User();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_User_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = GetUserFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return user;
        }

        public bool Create(User user)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_User_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                DatabaseConn.cmd.Parameters.AddWithValue("@lastName", user.LastName);
                DatabaseConn.cmd.Parameters.AddWithValue("@email", user.Email);
                DatabaseConn.cmd.Parameters.AddWithValue("@password", user.Password);

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

            return true;
        }

        public bool Update(int id, User user)
        {
            DatabaseConn.cmd = new SqlCommand("usp_User_Update", DatabaseConn.conn);
            DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
            DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
            DatabaseConn.cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            DatabaseConn.cmd.Parameters.AddWithValue("@lastName", user.LastName);
            DatabaseConn.cmd.Parameters.AddWithValue("@email", user.Email);
            DatabaseConn.cmd.Parameters.AddWithValue("@password", user.Password);

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
            DatabaseConn.cmd = new SqlCommand("usp_User_Delete", DatabaseConn.conn);
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

        private User GetUserFromDb(SqlDataReader reader)
        {
            User user = new User()
            {
                UserId = int.Parse(reader["UserId"].ToString()),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
            };

            return user;
        }
    }
}
