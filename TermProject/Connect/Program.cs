using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace Connect
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "parlinrtest.database.windows.net";
                builder.UserID = "testadmin";
                builder.Password = "Whatthehell1";
                builder.InitialCatalog = "test";
                List<Passer> passers = new List<Passer>();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();
                    
                    string sb = "";
                    sb += ("SELECT * FROM dbo.NFLOffensePassing");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Passer p = new Passer();
                                p.LastName = reader["playerLastName"].ToString();
                                p.FirstName = reader["playerFirstName"].ToString();
                                p.TeamNameLong = reader["teamNameLong"].ToString();
                                p.TeamNameShort = reader["teamNameShort"].ToString();
                                p.Yards = Convert.ToInt32(reader["yards"]);
                                p.Interceptions = Convert.ToInt32(reader["interceptionsThrown"]);
                                p.Touchdowns = Convert.ToInt32(reader["touchdownPasses"]);
                                passers.Add(p);
                            }
                        }
                    }
                    
                }
                StreamWriter sWriter = new StreamWriter(DataSettings.passerFilePath);
                //generate json string from list of ski runs
                string jsonText = JsonConvert.SerializeObject(passers, Formatting.Indented);

                using (sWriter)
                {
                    sWriter.Write(jsonText);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
