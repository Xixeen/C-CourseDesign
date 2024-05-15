using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Project
{
    class Student
    {
        public String ID { get; set; }
        public String Fname { get; set; }
        public String Address { get; set; }
        public String Contact { get; set; }
        public String Gender { get; set; }
        public String FeeStatus { get; set; }
        public String Semester { get; set; }
        public String Department { get; set; }
        public byte[] Picture { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        private static String myConn = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public const String InsertQuery = "INSERT INTO student(Fname,Address,Contact,Gender,FeeStatus,Semester,Department,Picture,Email) VALUES(@Fname,@Address,@Contact,@Gender,@FeeStatus,@Semester,@Department,@Picture,@Email)";
        public const String UpdateQuery = "UPDATE student SET Email=@Email WHERE ID=@ID";
        public const String SelectQ = "SELECT * FROM student ORDER BY ID DESC";
        public const String Check = "SELECT * FROM student WHERE Email=@Email"; // for student login
        public const String PasswordCheck = "UPDATE student SET Password=@Password WHERE Email=@Email";
        public const String selectAll = "SELECT * FROM student";
        public const String update = "UPDATE student SET Fname=@Fname,Address=@Address,Contact=@Contact,FeeStatus=@FeeStatus,Gender=@Gender,Semester=@Semester,Department=@Department WHERE ID=@ID";
        public const String Select = "SELECT * FROM student";
        public const String SelectFromEmail = "SELECT ID,Fname,Semester,Department FROM student WHERE Email=@Email";

        public bool InsertStudent(Student student)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@Fname", student.Fname);
                    com.Parameters.AddWithValue("@Address", student.Address);
                    com.Parameters.AddWithValue("@Contact", student.Contact);
                    com.Parameters.AddWithValue("@Gender", student.Gender);
                    com.Parameters.AddWithValue("@FeeStatus", student.FeeStatus);
                    com.Parameters.AddWithValue("@Semester", student.Semester);
                    com.Parameters.AddWithValue("@Department", student.Department);
                    com.Parameters.AddWithValue("@Picture", student.Picture);
                    com.Parameters.AddWithValue("@Email", student.Email);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public bool UpdateEmail(Student student)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@ID", student.ID);
                    com.Parameters.AddWithValue("@Email", student.ID + "@aack.au.edu.pk");
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public DataTable GetStudent()
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(SelectQ, con))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public DataTable checkEmail(Student student)
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(Check, con))
                {
                    com.Parameters.AddWithValue("@Email", student.Email);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public bool UpdatePassword(Student student)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(PasswordCheck, con))
                {
                    com.Parameters.AddWithValue("@Password", student.Password);
                    com.Parameters.AddWithValue("@Email", student.Email);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public DataTable SearchStudent(Student student, String txt)
        {
            String SearchQuery;

            if (txt == "Address")
                SearchQuery = "SELECT * FROM student WHERE Address=@Address";
            else if (txt == "Gender")
                SearchQuery = "SELECT * FROM student WHERE Gender=@Gender";
            else if (txt == "FeeStatus")
                SearchQuery = "SELECT * FROM student WHERE FeeStatus=@FeeStatus";
            else if (txt == "Semester")
                SearchQuery = "SELECT * FROM student WHERE Semester=@Semester";
            else if (txt == "Department")
                SearchQuery = "SELECT * FROM student WHERE Department=@Department";
            else
                SearchQuery = "SELECT * FROM student WHERE ID=@ID";

            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(SearchQuery, con))
                {
                    if (txt == "ID")
                        com.Parameters.AddWithValue("@ID", student.ID);
                    else if (txt == "Address")
                        com.Parameters.AddWithValue("@Address", student.Address);
                    else if (txt == "Gender")
                        com.Parameters.AddWithValue("@Gender", student.Gender);
                    else if (txt == "FeeStatus")
                        com.Parameters.AddWithValue("@FeeStatus", student.FeeStatus);
                    else if (txt == "Semester")
                        com.Parameters.AddWithValue("@Semester", student.Semester);
                    else
                        com.Parameters.AddWithValue("@Department", student.Department);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public DataTable AllStudent()
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(selectAll, con))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public bool UpdateStudent(Student student)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(update, con))
                {
                    com.Parameters.AddWithValue("@ID", student.ID);
                    com.Parameters.AddWithValue("@Fname", student.Fname);
                    com.Parameters.AddWithValue("@Address", student.Address);
                    com.Parameters.AddWithValue("@Contact", student.Contact);
                    com.Parameters.AddWithValue("@Gender", student.Gender);
                    com.Parameters.AddWithValue("@FeeStatus", student.FeeStatus);
                    com.Parameters.AddWithValue("@Semester", student.Semester);
                    com.Parameters.AddWithValue("@Department", student.Department);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public DataTable GetAllStudent()
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(Select, con))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public DataTable loadData(Student student)
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(SelectFromEmail, con))
                {
                    com.Parameters.AddWithValue("@Email", student.Email);
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
