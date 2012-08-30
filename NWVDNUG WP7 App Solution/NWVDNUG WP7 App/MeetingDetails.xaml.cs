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
using TombstoneHelper;

namespace NWVDNUG_WP7_App
{
    public partial class MeetingDetails : PhoneApplicationPage
    {
        public MeetingDetails()
        {
            InitializeComponent();
        }

        //private void MeetingDetails_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //if (!App.ViewModel.IsDataLoaded)
        //    //{
        //    //    App.ViewModel.LoadData();
        //    //}
        //}

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.SaveState(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RestoreState();
            string meetingIdToLoad = "0";

            if (NavigationContext.QueryString.TryGetValue("MeetingId", out meetingIdToLoad))
            {
                var foundMeeting = App.ViewModel.UpcomingMeetings.FirstOrDefault(m => m.MeetingId == int.Parse(meetingIdToLoad)) ??
                                   App.ViewModel.PastMeetings.FirstOrDefault(m => m.MeetingId == int.Parse(meetingIdToLoad));

                if (foundMeeting != null)
                {
                    DataContext = foundMeeting;
                }
            }

        }

    }
}