﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TermProject
{
    public class Rusher
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
        public Rusher()
        {

        }
        #endregion

        #region METHODS


        #endregion


    }
}
