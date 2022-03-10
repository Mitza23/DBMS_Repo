using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            /*string connectionString =
            "Server=DESKTOP-DUP68MN\\MSSQLSERVER02;Database=Laborator_1;"
            + "User ID=mitza;Password=test;";

            string queryString =
            "SELECT name, gender "
            + "from dbo.Athletes ;";


            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter daAthletes = new SqlDataAdapter("select * from Athletes", connection);
                SqlDataAdapter daParticipations = new SqlDataAdapter("select * from Participations", connection);

                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();*/
        }
    }
}