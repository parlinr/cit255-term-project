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



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TermProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasserPage : Page
    {
        

        //the app pages need an ObservableCollection, but the operations I want only work on Lists
        public ObservableCollection<Passer> Passers { get; set; }
        public ViewModel viewmodel { get; set; }
        public List<Passer> PassersList { get; set; }
        public Passer APasser { get; set; }
        

        public PasserPage()
        {
            //Passer p = new Passer { FirstName = "Fred", LastName = "Fred", Interceptions = 44, RecordNumber = 1000000, Touchdowns = 3432, Yards = 45434 };
            this.InitializeComponent();
            Passers = new ObservableCollection<Passer>();
            viewmodel = new ViewModel();
            APasser = new Passer();

           

        }

        private void PasserPage_Loaded(object sender, RoutedEventArgs e)
        {
            
           
        }

        private async void GetAllPassersButton_Clicked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Passer> test = new ObservableCollection<Passer>();
            test = await viewmodel.GetAllPassers();
            
            foreach (Passer p in test)
            {
                Passers.Add(p);
            }
                   
            //Passers = (ObservableCollection<Passer>)test;
            //Passer p = new Passer { FirstName = "Fred", LastName = "Fred", Interceptions = 44, RecordNumber = 1000000, Touchdowns = 3432, Yards = 45434 };
            //Passers.Add(p);


        }

        private void ClearScreenButton_Clicked(object sender, RoutedEventArgs e)
        {
            var passersForLoop = Passers.ToList();
            foreach (Passer q in passersForLoop)
            {
                Passers.Remove(q);
            }
        }

        private async void AddPasserButton_Clicked(object sender, RoutedEventArgs e)
        {
            
            var passerDialogResult = await addPasserDialog.ShowAsync();            
            switch (passerDialogResult)
            {
                case ContentDialogResult.Primary:
                    if (!Int32.TryParse(recordNumberTextBox.Text, out int recordNumber))
                    {
                        ContentDialog fail = new ContentDialog
                        {
                            Title = "Failure",
                            IsPrimaryButtonEnabled = true,
                            Content = @"The value 'Record Number' is required and must be an integer.",
                            PrimaryButtonText = "OK"
                        };
                        await fail.ShowAsync();
                    }
                    else
                    {
                        APasser = new Passer();
                        Int32.TryParse(scoreTextBox.Text, out int score);
                        APasser.Score = score;
                        APasser.FirstName = firstNameTextBox.Text;
                        APasser.LastName = lastNameTextBox.Text;
                        APasser.TeamNameLong = teamNameLongTextBox.Text;
                        APasser.TeamNameShort = teamNameShortTextBox.Text;
                        APasser.RecordNumber = Convert.ToInt32(recordNumberTextBox.Text);
                        Int32.TryParse(touchdownsTextBox.Text, out int touchdowns);
                        Int32.TryParse(yardsTextBox.Text, out int yards);
                        Int32.TryParse(interceptionsTextBox.Text, out int interceptions);
                        APasser.Yards = yards;
                        APasser.Touchdowns = touchdowns;
                        APasser.Interceptions = interceptions;
                        viewmodel.InsertPasser(APasser);
                    }
                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
        }
    }
}
