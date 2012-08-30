using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using TombstoneHelper;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

//using GestureEventArgs = Microsoft.Phone.Controls.GestureEventArgs;

namespace NWVDNUG_WP7_App
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        public void HideProgressIndicator()
        {
            performanceProgressBar.Visibility=Visibility.Collapsed;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                performanceProgressBar.Visibility=Visibility.Visible;
                
                App.ViewModel.LoadData();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.SaveState(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RestoreState();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            performanceProgressBar.Visibility = Visibility.Visible;

            App.ViewModel.LoadData();
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute)); 
        }
    }
}