using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace FaceRecognize_StudentSystem
{
    class Admin
    {
        public int ID
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public byte[] Picture
        {
            get; set;
        }

        private static String myConn = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public const String InsertQuery = "Insert Into admins(Name,Picture) Values(@Name,@Picture)";
        public bool InsertCustomer(Admin admin)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@Name", admin.Name);
                    com.Parameters.AddWithValue("@Picture", admin.Picture);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public const String SelectQuery = "select * from admins";

        public DataTable GetCustomer()
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(SelectQuery, con))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }
}
