﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace TermProject
{ 
    public class ViewModel
    {
        public ObservableCollection<Passer> p { get; set; }

        public ViewModel()
        {
            p = new ObservableCollection<Passer>();
        }

        public void GetAllPassers()
        {
            BusinessLayer b = new BusinessLayer();
            p = b.GetAllPassers();
        }
    }
}