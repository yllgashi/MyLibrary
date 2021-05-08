using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyLibrary.Access
{
    public class CategoryAccess
    {
        public List<Category> GetList()
        {
            List<Category> categories = new List<Category>();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Category_GetList", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(GetCategoryFromDb(reader));
                    }

                    return categories;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Category Get(int id)
        {
            Category category = new Category();
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Category_Get", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        category = GetCategoryFromDb(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Get_Books_By_Category", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.da = new SqlDataAdapter(DatabaseConn.cmd);
                DatabaseConn.cmd.Parameters.AddWithValue("@id", id);

                category.Books = new List<Book>();
                try
                {
                    DatabaseConn.conn.Open();
                    var reader = DatabaseConn.cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        category.Books.Add(GetBookFromDb(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return category;
        }

        public bool Create(Category category)
        {
            using (DatabaseConn.conn = new SqlConnection(DatabaseConn.conString))
            {
                DatabaseConn.cmd = new SqlCommand("usp_Category_Create", DatabaseConn.conn);
                DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
                DatabaseConn.cmd.Parameters.AddWithValue("@description", category.Description);

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

        public bool Update(int id, Category category)
        {
            DatabaseConn.cmd = new SqlCommand("usp_Category_Update", DatabaseConn.conn);
            DatabaseConn.cmd.CommandType = CommandType.StoredProcedure;
            DatabaseConn.cmd.Parameters.AddWithValue("@id", id);
            DatabaseConn.cmd.Parameters.AddWithValue("@bookId", category.Description);

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
            DatabaseConn.cmd = new SqlCommand("usp_Category_Delete", DatabaseConn.conn);
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

        private Category GetCategoryFromDb(SqlDataReader reader)
        {
            Category category = new Category()
            {
                CategoryId = int.Parse(reader["CategoryId"].ToString()),
                Description = reader["Description"].ToString(),
            };

            return category;
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
