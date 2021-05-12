using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataAccess
{
    public class DatabaseConn
    {
        //public static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();

        public static string conString = "Server=AS;Database=MyLibrary;Trusted_Connection=True;MultipleActiveResultSets=true";
        //public static string conString = "Server=DESKTOP-A57SPHC;Database=MyLibrary;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
    }
}
