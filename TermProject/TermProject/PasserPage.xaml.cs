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
using System.Threading.Tasks;



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
                        ContentDialog success = new ContentDialog
                        {
                            Title = "Success",
                            Content = "The passer was successfully added.",
                            IsPrimaryButtonEnabled = true,
                            PrimaryButtonText = "OK"
                        };
                        await success.ShowAsync();

                        
                    }
                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
        }

        private async void DeletePasserButton_Clicked(object sender, RoutedEventArgs e)
        {
            var deletePasserDialogResult = await deletePasserDialog.ShowAsync();
            bool deleteResult = false;
            switch (deletePasserDialogResult)
            {
                case ContentDialogResult.Primary:
                    if (Int32.TryParse(recordNumberInput.Text, out int recordNumber))
                    {
                        JSONRepository j = new JSONRepository();
                        j.DeletePasser(recordNumber);
                    }
                    else
                    {
                        ContentDialog badInput = new ContentDialog
                        {
                            Title = "Failure",
                            Content = "The input value was not an integer.",
                            IsPrimaryButtonEnabled = true,
                            PrimaryButtonText = "OK"
                        };
                        await badInput.ShowAsync();
                    }
                    
                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
            
        }

        private async void UpdatePasserButton_Clicked(object sender, RoutedEventArgs e)
        {
            var updatePasserDialogResult = await updatePasserDialog.ShowAsync();
            switch(updatePasserDialogResult)
            {
                case ContentDialogResult.Primary:
                    if (!Int32.TryParse(updateRecordNumberTextBox.Text, out int recordNumber))
                    {
                        ContentDialog badInput = new ContentDialog
                        {
                            Title = "Failed",
                            Content = "The given Record Number was not an integer.",
                            IsPrimaryButtonEnabled = true,
                            PrimaryButtonText = "OK"
                        };
                        await badInput.ShowAsync();
                    }
                    else
                    {
                        //if the user didn't change the interceptions, set the sent object's
                        //to -1 for validation further on
                        Passer newPasser = new Passer();
                        newPasser.FirstName = updateFirstNameTextBox.Text;
                        newPasser.LastName = updateLastNameTextBox.Text;
                        if (!Int32.TryParse(updateInterceptionsTextBox.Text, out int interceptions))
                        {
                            newPasser.Interceptions = -1;
                        }
                        else
                        {
                            newPasser.Interceptions = interceptions;
                        }
                        
                        if (!Int32.TryParse(updateTouchdownsTextBox.Text, out int touchdowns))
                        {
                            newPasser.Touchdowns = -1;
                        }
                        else
                        {
                            newPasser.Touchdowns = touchdowns;
                        }
                       
                        if (!Int32.TryParse(updateYardsTextBox.Text, out int yards))
                        {
                            newPasser.Yards = -999;
                        }
                        else
                        {
                            newPasser.Yards = yards;
                        }
                        
                        Int32.TryParse(updateRecordNumberTextBox.Text, out int passerRecordNumber);
                        newPasser.RecordNumber = passerRecordNumber;
                        if (!Int32.TryParse(updateScoreTextBox.Text, out int score))
                        {
                            newPasser.Score = -1;
                        }
                        else
                        {
                            newPasser.Score = score;
                        }

                        JSONRepository j = new JSONRepository();
                        newPasser.TeamNameLong = updateTeamNameLongTextBox.Text;
                        newPasser.TeamNameShort = updateTeamNameShortTextBox.Text;
                        j.UpdatePasser(newPasser);
                        
                    }

                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
        }

        private async void SelectPasserByRecordNumberButton_Clicked(object sender, RoutedEventArgs e)
        {
            var selectPasserByRecordNumberDialogResult = await selectPasserByRecordNumberDialog.ShowAsync();

            switch(selectPasserByRecordNumberDialogResult)
            {
                case ContentDialogResult.Primary:
                    if (!Int32.TryParse(selectRecordNumberInput.Text, out int recoedNumber))
                    {
                        ContentDialog badInput = new ContentDialog
                        {
                            Title = "Failed",
                            Content = "The given Record Number was not an integer.",
                            IsPrimaryButtonEnabled = true,
                            PrimaryButtonText = "OK"
                        };
                        await badInput.ShowAsync();
                    }
                    else
                    {
                        JSONRepository j = new JSONRepository();

                        
                        ObservableCollection<Passer> output = new ObservableCollection<Passer>();
                        output = await j.GetPasserByRecordNumber(Convert.ToInt32(selectRecordNumberInput.Text));

                        var passersForLoop = Passers.ToList();
                        foreach (Passer q in passersForLoop)
                        {
                            Passers.Remove(q);
                        }

                        foreach (Passer p in output)
                        {
                            Passers.Add(p);
                        }

                        ContentDialog success = new ContentDialog
                        {
                            Title = "Success",
                            IsPrimaryButtonEnabled = true,
                            PrimaryButtonText = "OK",
                            Content = "The specific passer was successfully selected."
                        };
                        await success.ShowAsync();
                    }
                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
        }

        private async void QueryPassersButton_Clicked(object sender, RoutedEventArgs e)
        {
            var queryPasserDialogResult = await queryPasserDialog.ShowAsync();

            switch (queryPasserDialogResult)
            {
                case ContentDialogResult.Primary:
                    PasserOperationData opData = new PasserOperationData();
                    try
                    {
                        opData.MaxScore = Convert.ToInt32(queryMaxScoreTextBox.Text);
                    }
                    catch (Exception x)
                    {
                        opData.MaxScore = -99999;
                    }
                    try
                    {
                        opData.MinScore = Convert.ToInt32(queryMinScoreTextBox.Text);
                    }
                    catch (Exception x)
                    {
                        opData.MinScore = -99999;
                    }
                    try
                    {
                        opData.MaxYards = Convert.ToInt32(queryMaxYardsTextBox.Text);
                    }
                    catch (Exception x)
                    {
                        opData.MaxYards = -99999;
                    }
                    try
                    {
                        opData.MinYards = Convert.ToInt32(queryMinYardsTextBox.Text);
                    }
                    catch
                    {
                        opData.MinYards = -99999;
                    }
                    try
                    {
                        opData.MinTouchdowns = Convert.ToInt32(queryMinTouchdownsTextBox.Text);
                    }
                    catch (Exception x)
                    {
                        opData.MinTouchdowns = -99999;
                    }
                    try
                    {
                        opData.MaxTouchdowns = Convert.ToInt32(queryMaxTouchdownsTextBox.Text);
                    }
                    catch (Exception x)
                    {
                        opData.MaxTouchdowns = -99999;
                    }

                    BusinessLayer b = new BusinessLayer();
                    ObservableCollection<Passer> results = await b.QueryPassers(opData);

                    var passersForLoop = Passers.ToList();
                    foreach (Passer q in passersForLoop)
                    {
                        Passers.Remove(q);
                    }

                    foreach (Passer p in results)
                    {
                        Passers.Add(p);
                    }

                    ContentDialog completed = new ContentDialog
                    {
                        Title = "Query Complete",
                        IsPrimaryButtonEnabled = true,
                        PrimaryButtonText = "OK",
                        Content = "The chosen query has been completed."

                    };
                    await completed.ShowAsync();
                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
        }
    }
}
