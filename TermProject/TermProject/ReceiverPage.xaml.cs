using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TermProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReceiverPage : Page
    {
        public ObservableCollection<Receiver> Receivers { get; set; }
        public ViewModel viewmodel { get; set; }
        public List<Receiver> ReceiversList { get; set; }
        public Receiver AReceiver { get; set; }

        public ReceiverPage()
        {
            this.InitializeComponent();
            viewmodel = new ViewModel();
            Receivers = new ObservableCollection<Receiver>();
            ReceiversList = new List<Receiver>();
            AReceiver = new Receiver();
        }

        private async void GetAllReceiversButton_Clicked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Receiver> test = new ObservableCollection<Receiver>();
            test = await viewmodel.GetAllReceivers();

            foreach (Receiver p in test)
            {
                Receivers.Add(p);
            }

        }

        private void ClearScreenButton_Clicked(object sender, RoutedEventArgs e)
        {
            var receiversForLoop = Receivers.ToList();
            foreach (Receiver q in receiversForLoop)
            {
                Receivers.Remove(q);
            }
        }

        private async void AddReceiverButton_Clicked(object sender, RoutedEventArgs e)
        {

            var receiverDialogResult = await addReceiverDialog.ShowAsync();
            switch (receiverDialogResult)
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
                        AReceiver = new Receiver();
                        Int32.TryParse(scoreTextBox.Text, out int score);
                        AReceiver.Score = score;
                        AReceiver.FirstName = firstNameTextBox.Text;
                        AReceiver.LastName = lastNameTextBox.Text;
                        AReceiver.TeamNameLong = teamNameLongTextBox.Text;
                        AReceiver.TeamNameShort = teamNameShortTextBox.Text;
                        AReceiver.RecordNumber = Convert.ToInt32(recordNumberTextBox.Text);
                        Int32.TryParse(touchdownsTextBox.Text, out int touchdowns);
                        Int32.TryParse(yardsTextBox.Text, out int yards);
                        AReceiver.Yards = yards;
                        AReceiver.Touchdowns = touchdowns;
                        viewmodel.InsertReceiver(AReceiver);
                        ContentDialog success = new ContentDialog
                        {
                            Title = "Success",
                            Content = "The receiver was successfully added.",
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

        private async void DeleteReceiverButton_Clicked(object sender, RoutedEventArgs e)
        {
            var deleteReceiverDialogResult = await deleteReceiverDialog.ShowAsync();
            bool deleteResult = false;
            switch (deleteReceiverDialogResult)
            {
                case ContentDialogResult.Primary:
                    if (Int32.TryParse(recordNumberInput.Text, out int recordNumber))
                    {
                        JSONRepository j = new JSONRepository();
                        j.DeleteReceiver(recordNumber);
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

        private async void UpdateReceiverButton_Clicked(object sender, RoutedEventArgs e)
        {
            var updateReceiverDialogResult = await updateReceiverDialog.ShowAsync();
            switch (updateReceiverDialogResult)
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
                        Receiver newReceiver = new Receiver();
                        newReceiver.FirstName = updateFirstNameTextBox.Text;
                        newReceiver.LastName = updateLastNameTextBox.Text;
                        if (!Int32.TryParse(updateTouchdownsTextBox.Text, out int touchdowns))
                        {
                            newReceiver.Touchdowns = -1;
                        }
                        else
                        {
                            newReceiver.Touchdowns = touchdowns;
                        }

                        if (!Int32.TryParse(updateYardsTextBox.Text, out int yards))
                        {
                            newReceiver.Yards = -999;
                        }
                        else
                        {
                            newReceiver.Yards = yards;
                        }

                        Int32.TryParse(updateRecordNumberTextBox.Text, out int receiverRecordNumber);
                        newReceiver.RecordNumber = receiverRecordNumber;
                        if (!Int32.TryParse(updateScoreTextBox.Text, out int score))
                        {
                            newReceiver.Score = -1;
                        }
                        else
                        {
                            newReceiver.Score = score;
                        }

                        JSONRepository j = new JSONRepository();
                        newReceiver.TeamNameLong = updateTeamNameLongTextBox.Text;
                        newReceiver.TeamNameShort = updateTeamNameShortTextBox.Text;
                        j.UpdateReceiver(newReceiver);

                    }

                    break;
                case ContentDialogResult.Secondary:
                    break;
                default:
                    break;
            }
        }

        private async void SelectReceiverByRecordNumberButton_Clicked(object sender, RoutedEventArgs e)
        {
            var selectReceiverByRecordNumberDialogResult = await selectReceiverByRecordNumberDialog.ShowAsync();

            switch (selectReceiverByRecordNumberDialogResult)
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


                        ObservableCollection<Receiver> output = new ObservableCollection<Receiver>();
                        output = await j.GetReceiverByRecordNumber(Convert.ToInt32(selectRecordNumberInput.Text));

                        var receiversForLoop = Receivers.ToList();
                        foreach (Receiver q in receiversForLoop)
                        {
                            Receivers.Remove(q);
                        }

                        foreach (Receiver p in output)
                        {
                            Receivers.Add(p);
                        }

                        ContentDialog success = new ContentDialog
                        {
                            Title = "Success",
                            IsPrimaryButtonEnabled = true,
                            PrimaryButtonText = "OK",
                            Content = "The specific receiver was successfully selected."
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

        private async void QueryReceiversButton_Clicked(object sender, RoutedEventArgs e)
        {
            var queryReceiverDialogResult = await queryReceiverDialog.ShowAsync();

            switch (queryReceiverDialogResult)
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
                    ObservableCollection<Receiver> results = await b.QueryReceivers(opData);

                    var receiversForLoop = Receivers.ToList();
                    foreach (Receiver q in receiversForLoop)
                    {
                        Receivers.Remove(q);
                    }

                    foreach (Receiver p in results)
                    {
                        Receivers.Add(p);
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

        private async void SortReceiversButton_Clicked(object sender, RoutedEventArgs e)
        {
            var sortReceiverDialogResult = await sortReceiverDialog.ShowAsync();

            switch (sortReceiverDialogResult)
            {
                case ContentDialogResult.Primary:
                    PasserSortData sData = new PasserSortData();
                    if ((bool)scoreCheckbox.IsChecked)
                    {
                        sData.SortByScore = true;
                    }
                    if ((bool)yardsCheckbox.IsChecked)
                    {
                        sData.SortByYards = true;
                    }
                    if ((bool)touchdownsCheckbox.IsChecked)
                    {
                        sData.SortByTouchdowns = true;
                    }

                    BusinessLayer b = new BusinessLayer();
                    ObservableCollection<Receiver> sorted = b.SortReceivers(sData, Receivers);

                    var receiversForLoop = Receivers.ToList();
                    foreach (Receiver q in receiversForLoop)
                    {
                        Receivers.Remove(q);
                    }

                    foreach (Receiver p in sorted)
                    {
                        Receivers.Add(p);
                    }

                    ContentDialog completed = new ContentDialog
                    {
                        Title = "Completed",
                        IsPrimaryButtonEnabled = true,
                        PrimaryButtonText = "OK",
                        Content = "The selected sort has been completed."
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
