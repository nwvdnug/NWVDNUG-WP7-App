using System;
using System.Collections.Generic;
using System.Device.Location;
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
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Tasks;
using NWVDNUG_WP7_App.ViewModels;
using TombstoneHelper;

namespace NWVDNUG_WP7_App
{
	public partial class MeetingDetails : PhoneApplicationPage
	{
		public MeetingDetails()
		{
			InitializeComponent();
		}

		// BING MAPS KEY
		// Ami-b_D_xJEWRkz_gYAo4RFTL2Q29OY8lZ9s1EeCnD2YWM15uSp-ETbXUh1mrYdR
		// reference: http://www.braincastexception.com/wp7-web-services-first-part-geocodeservice/

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
					//LocationMap.ZoomBarVisibility = Visibility.Visible;
					LocationMap.Center = new GeoCoordinate(Convert.ToDouble(33.65467), Convert.ToDouble(-112.17849));
					LocationMap.ZoomLevel = 11.00;

					var pin1 = new Pushpin
								   {
									   Location = LocationMap.Center,
									   Content= "Foothills Rec Center",
								   };
					LocationMap.Children.Add(pin1);
				}
			}

		}

		private void GetDirections_Click(object sender, RoutedEventArgs e)
		{
			var task = new BingMapsDirectionsTask();
			task.End = new LabeledMapLocation {Label = ((MeetingViewModel) DataContext).Location};
			task.Show();
		}

		private void RSVP_Click(object sender, RoutedEventArgs e)
		{
			var wbt = new WebBrowserTask {Uri = new Uri("http://nwvdnugmonthly.eventday.com")};
			wbt.Show();
		}

	}
}