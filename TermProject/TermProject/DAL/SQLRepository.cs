using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;




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
            List<Passer> passers = new List<Passer>();

            string connString = GetConnectionString();
            /*
            if (connString != null)
            {
                throw new NotImplementedException();
            }
            */
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
            var resources = new Windows.ApplicationModel.Resources.ResourceLoader("Resources");
            string returnValue = resources.GetString("connString");
                        
            return returnValue;
        }
        
        #endregion
    }
}
