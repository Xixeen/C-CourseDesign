using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Project
{
    class Result
    {
        public String SID { get; set; }
        public String gOne { get; set; }
        public String gTwo { get; set; }
        public String gThree { get; set; }
        public String gFour { get; set; }
        public String gFive { get; set; }
        public String gSix { get; set; }
        public String chOne { get; set; }
        public String chTwo { get; set; }
        public String chThree { get; set; }
        public String chFour { get; set; }
        public String chFive { get; set; }
        public String chSix { get; set; }
        public String cnOne { get; set; }
        public String cnTwo { get; set; }
        public String cnThree { get; set; }
        public String cnFour { get; set; }
        public String cnFive { get; set; }
        public String cnSix { get; set; }
        public String gpa { get; set; }
        public String rID { get; set; }
        private static String myConn = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public const String InsertQuery = "INSERT INTO result(SID, gOne, gTwo, gThree, gFour, gFive, gSix, chOne, chTwo, chThree, chFour, chFive, chSix, cnOne, cnTwo, cnThree, cnFour, cnFive, cnSix, gpa) VALUES(@SID, @gOne, @gTwo, @gThree, @gFour, @gFive, @gSix, @chOne, @chTwo, @chThree, @chFour, @chFive, @chSix, @cnOne, @cnTwo, @cnThree, @cnFour, @cnFive, @cnSix, @gpa)";
        public const String resultDisplay = "SELECT * FROM result WHERE SID=@SID ORDER BY rID DESC";

        public bool InsertResult(Result result)
        {
            int rows;
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@SID", result.SID);
                    com.Parameters.AddWithValue("@gOne", result.gOne);
                    com.Parameters.AddWithValue("@gTwo", result.gTwo);
                    com.Parameters.AddWithValue("@gThree", result.gThree);
                    com.Parameters.AddWithValue("@gFour", result.gFour);
                    com.Parameters.AddWithValue("@gFive", result.gFive);
                    com.Parameters.AddWithValue("@gSix", result.gSix);
                    com.Parameters.AddWithValue("@chOne", result.chOne);
                    com.Parameters.AddWithValue("@chTwo", result.chTwo);
                    com.Parameters.AddWithValue("@chThree", result.chThree);
                    com.Parameters.AddWithValue("@chFour", result.chFour);
                    com.Parameters.AddWithValue("@chFive", result.chFive);
                    com.Parameters.AddWithValue("@chSix", result.chSix);
                    com.Parameters.AddWithValue("@cnOne", result.cnOne);
                    com.Parameters.AddWithValue("@cnTwo", result.cnTwo);
                    com.Parameters.AddWithValue("@cnThree", result.cnThree);
                    com.Parameters.AddWithValue("@cnFour", result.cnFour);
                    com.Parameters.AddWithValue("@cnFive", result.cnFive);
                    com.Parameters.AddWithValue("@cnSix", result.cnSix);
                    com.Parameters.AddWithValue("@gpa", result.gpa);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0);
        }

        public DataTable Display(Result result)
        {
            var datatable = new DataTable();
            using (MySqlConnection con = new MySqlConnection(myConn))
            {
                con.Open();
                using (MySqlCommand com = new MySqlCommand(resultDisplay, con))
                {
                    com.Parameters.AddWithValue("@SID", result.SID);
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
