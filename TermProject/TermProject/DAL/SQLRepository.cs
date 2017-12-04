using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.IO;
using Windows.Storage;
using Newtonsoft.Json;



namespace TermProject
{
    public class SQLRepository
    {
        #region FIELDS
        private List<Passer> _passers = new List<Passer>(); 
        private List<Rusher> _rushers = new List<Rusher>();
        private List<Receiver> _receivers = new List<Receiver>();
        #endregion

        #region PROPERTIES
        public List<Passer> Passers { get; }
        public List<Receiver> Receivers { get; }
        public List<Rusher> Rushers { get; }
        #endregion

        #region CONSTRUCTORS
        //have this take a parameter indicating the table to access
        public SQLRepository(Table table)
        {
            if (table == Table.Passers)
            {
                _passers = ReadAllPassers();
            }
            else if (table == Table.Receivers)
            {
                _receivers = ReadAllReceivers();
            }
            else
            {
                _rushers = ReadAllRushers();
            }
                
        }
        #endregion

        #region METHODS
        public List<Passer> ReadAllPassers()
        {
            //SelectDatabase();
            //AddToDB();
            string parentdir;
            List<Passer> passers = new List<Passer>();
            List<int> nums = new List<int>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteDB.db"))
            {
                db.Open();
                string test = db.DataSource;

                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * FROM NFLOffensePassing", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    throw new NotImplementedException();
                }

                /*
                string command = "SELECT * FROM NFLOffensePassing";
                SqliteCommand selectCommand = new SqliteCommand(command, db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    throw new NotImplementedException();
                }
                */

                db.Close();
            }

                /*
                string connString = GetConnectionString();
                if (connString != null)
                {
                    throw new NotImplementedException();
                }
                string sqlCommandString = "SELECT * FROM dbo.NFLOffensePassing";

                using (SqlConnection sqlConn = new SqlConnection(connString))
                using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn))
                {
                    //TODO: exception handling
                        sqlConn.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    Passer passer = new Passer();
                                    passer.LastName = reader["playerLastName"].ToString();
                                    passer.FirstName = reader["playerFirstName"].ToString();
                                    passer.TeamNameLong = reader["teamNameLong"].ToString();
                                    passer.TeamNameShort = reader["teamNameShort"].ToString();
                                    passer.Yards = Convert.ToInt32(reader["yards"]);
                                    passer.Interceptions = Convert.ToInt32(reader["interceptionsThrown"]);
                                    passer.Touchdowns = Convert.ToInt32(reader["touchdownPasses"]);
                                    passers.Add(passer);
                                }
                            }

                        }


                }

                */

                return passers;

        }

        public List<Receiver> ReadAllReceivers()
        {
            List<Receiver> receivers = new List<Receiver>();

            return receivers;
        }

        public List<Rusher> ReadAllRushers()
        {
            List<Rusher> rushers = new List<Rusher>();

            return rushers;
        }

        
        private static string GetConnectionString()
        {

            //var resources = new Windows.ApplicationModel.Resources.ResourceLoader("Resources");

            string returnValue = "";
            
            return returnValue;
        }

        private async void SelectDatabase()
        {
            StorageFile fileSource = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///sqliteDB.db", UriKind.RelativeOrAbsolute));
            StorageFolder desFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile fileCheck = await desFolder.GetFileAsync("sqliteDB.db");
            }
            catch
            {
                await fileSource.CopyAsync(desFolder, "sqliteDB.db", NameCollisionOption.ReplaceExisting);
            }
            
        }

        private void MakeDB()
        {
            using (SqliteConnection db =
       new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS NFLOffensePassing (number INTEGER)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        private async void AddToDB()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("test.json");
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            using (SqliteConnection db =
        new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                throw new NotImplementedException();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO NFLOffensePassing VALUES (5);";
                //insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        
        #endregion
    }
}
