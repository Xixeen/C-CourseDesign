using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Project
{
    class course
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String CreditHours { get; set; }
        public String Semester { get; set; }
        public String Department { get; set; }

        private static String myConn = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public const String InsertQuery = "INSERT INTO course(Name, CreditHours, Semester, Department) VALUES(@Name, @CreditHours, @Semester, @Department)";
        public bool AddCourse(course course)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@Name", course.Name);
                    com.Parameters.AddWithValue("@CreditHours", course.CreditHours);
                    com.Parameters.AddWithValue("@Semester", course.Semester);
                    com.Parameters.AddWithValue("@Department", course.Department);

                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public const String SelectQuery = "SELECT * FROM course WHERE Semester=@Semester AND Department=@Department";
        public DataTable SearchCourse(course course)
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(SelectQuery, con))
                {
                    com.Parameters.AddWithValue("@Semester", course.Semester);
                    com.Parameters.AddWithValue("@Department", course.Department);
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
