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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TermProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasserPage : Page
    {
        public PasserPage()
        {
            this.InitializeComponent();
        }

        private void PasserPage_Loaded(object sender, RoutedEventArgs e)
        {
            ListPassers();

        }

        public void ListPassers()
        {
            SQLRepository repo = new SQLRepository(Table.Passers);
            List<Passer> passers = new List<Passer>();
            passers = repo.ReadAllPassers();

            /*
            ListView listView1 = new ListView();
            ObservableCollection<Passer> listViewItems = new ObservableCollection<Passer>();
            foreach (Passer p in passers)
            {
                listViewItems.Add(p);
            }
            listView1.ItemsSource = listViewItems;
            stackPanel1.Children.Add(listView1);
            */
        }
    }
}
