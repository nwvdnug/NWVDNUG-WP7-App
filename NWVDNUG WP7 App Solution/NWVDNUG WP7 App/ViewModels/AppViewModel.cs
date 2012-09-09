using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;


namespace NWVDNUG_WP7_App.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public AppViewModel()
        {
            this.UpcomingMeetings = new ObservableCollection<MeetingViewModel>();
            this.PastMeetings = new ObservableCollection<MeetingViewModel>();
        }

        /// <summary>
        /// A collection for MeetingViewModel objects.
        /// </summary>
        public ObservableCollection<MeetingViewModel> UpcomingMeetings { get; private set; }
        /// <summary>
        /// A collection for MeetingViewModel objects.
        /// </summary>
        public ObservableCollection<MeetingViewModel> PastMeetings { get; private set; }

        public bool IsDataLoaded { get; private set; }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            UpcomingMeetings.Clear();
            PastMeetings.Clear();

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                var req = new Requester();
                req.LoadUpcoming();
                req.LoadPast();

                this.IsDataLoaded = true;
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                                                          App.ViewModel.UpcomingMeetings.Add(new MeetingViewModel
                                                                                             {
                                                                                                 Title = "No Network detected.",
                                                                                                 SpeakerName = "",
                                                                                                 Location = "Please connect to WiFi or data connection"
                                                                                             }));
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                                                          App.ViewModel.PastMeetings.Add(new MeetingViewModel
                                                                                             {
                                                                                                 Title = "No Network detected.",
                                                                                                 SpeakerName = "",
                                                                                                 Location = "Please connect to WiFi or data connection"
                                                                                             }));
                Deployment.Current.Dispatcher.BeginInvoke(() => (((PhoneApplicationFrame)App.Current.RootVisual).Content as MainPage).HideProgressIndicator());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}