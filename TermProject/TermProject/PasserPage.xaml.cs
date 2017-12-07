using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.AppService;
using System.ServiceModel;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TermProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasserPage : Page
    {
        public ObservableCollection<Passer> Passers { get; set; }

        public PasserPage()
        {
            Passer p = new Passer { FirstName = "Fred", LastName = "Fred", Interceptions = 44, RecordNumber = 1000000, Touchdowns = 3432, Yards = 45434 };
            this.InitializeComponent();
            JSONRepository repo = new JSONRepository();
            repo.GetAllPassers();
            //repo.GetAllRushers();
            //repo.InsertPasser(p);
            //repo.GetAllReceivers();
            //repo.SelectByRecordNumber(10000, Table.Passers);
            repo.InsertPasser(p);
            Passers = repo.AllPassers;

        }

        private void PasserPage_Loaded(object sender, RoutedEventArgs e)
        {
            
           
        }

        
    }
}
