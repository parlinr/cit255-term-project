using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class SQLRepository
    {
        #region FIELDS
        private List<Passers> _passers = new List<Passers>(); 
        private List<Rushers> _rushers = new List<Rushers>();
        private List<Receivers> _receivers = new List<Receivers>();
        #endregion

        #region PROPERTIES

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
        public List<Passers> ReadAllPassers()
        {
            List<Passers> passers = new List<Passers>();

            return passers;

        }

        public List<Receivers> ReadAllReceivers()
        {
            List<Receivers> receivers = new List<Receivers>();

            return receivers;
        }

        public List<Rushers> ReadAllRushers()
        {
            List<Rushers> rushers = new List<Rushers>();

            return rushers;
        }
        #endregion
    }
}
