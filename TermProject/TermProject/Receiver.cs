using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class Receiver
    {
        #region FIELDS
        private double _score;
        private string _lastName;
        private string _firstName;
        private string _teamNameLong;
        private string _teamNameShort;
        private int _yards;
        private int _touchdowns;
        
        #endregion

        #region PROPERTIES
        public double Score { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string TeamNameLong { get; set; }
        public string TeamNameShort { get; set; }
        public int Yards { get; set; }
        public int Touchdowns { get; set; }
        

        #endregion

        #region CONSTRUCTORS
        public Receiver()
        {

        }
        #endregion

        #region METHODS


        #endregion


    }
}
