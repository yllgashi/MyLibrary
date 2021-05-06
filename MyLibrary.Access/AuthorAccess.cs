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
        public List<Author> GetAll()
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

        public Author Get(string id)
        {
            //return authorAccess.Get(id);

            return null;
        }

        public bool Create(Author author)
        {
            return false;
        }

        public bool Update(string id, Author author)
        {
            return false;
        }

        public bool Delete(string id)
        {
            return false;
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

    }
}
