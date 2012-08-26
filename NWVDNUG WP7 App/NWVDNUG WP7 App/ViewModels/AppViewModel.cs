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
            this.UpcomingMeetings.Add(new MeetingViewModel()
                                          {
                                              MeetingId = 11,
                                              Title = "Developing with RavenDB",
                                              Details = "Abstract:\r\n\r\nRavenDB is a Document Database written entirely in .Net.\r\n\r\nIn this presentation we will cover what a Document Database is and how developing with one requires thinking in a radically different way than you may be used to if you have traditionally used SQL Databases with .Net centric clients. \r\n\r\nIn the sample code we will walk through creating the Models(both .Net and JSON), Views and ViewModels for a modern HTML5, MVVM Website using KnockoutJS and JavaScript (no .Net on the Client) with a full REST WebAPI backend written in .Net using RavenDB as the Database.\r\n\r\nI will demonstrate how this can make Web Based development much more intuitive and friendly for the developer.  We will look at how the architecture for the Semantic Web has made Web Based development the modern standard for both humans and machines.  We will look at the common Design Patterns that you can leverage when working in this style of development and how they are applied across multiple client platforms.\r\n\r\nBio:\r\n\r\nSteele Price has been professionally designing and developing databases and interfaces to them for 30 years. He has also been professionally developing with Microsoft Visual Basic, C#, SQL Server and Visual Studio since their inception many years ago. Recently he has focused on the Semantic Web, HTML5 and cross-platform Web Enabled solutions.\r\n\r\nHe started professionally developing software in 1983.  Software development has not only been his primary source of income since; it is his passion.  Many of his software development processes grew to fruition by seeing a business or consumer need and working diligently to fulfill that need with a real application.  When you love to do something it invades every aspect of your life.  \r\n\r\nIn recent years he has focused on improving the software development process, design patterns and application reach.  Learning from his own process failures as well as successes let him demonstrate how to achieve better real-world delivery of applications to companies ranging from \"mom and pop\" stores to top tier Insurance Carriers and Airlines.\r\n\r\nHe has always maintained a passion for taking that knowledge back to the community by speaking and sharing often with local user groups.\r\n",
                                              Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
                                              SpeakerName = "Steele Price",
                                              SpeakerBioUrl = "http://steeleprice.net/",
                                              StartDateTime = "8/28/2012 6:00:00 PM",
                                              EndDateTime = "8/28/2012 8:00:00 PM"
                                          });
            this.UpcomingMeetings.Add(new MeetingViewModel()
                                          {
                                              MeetingId = 13,
                                              Title = "MythBusters: Is ASP.Net Web API the Best Way to Build RESTFul Services?",
                                              Details = "MythBusters: Is ASP.Net Web API the Best Way to Build RESTFul Services?\r\n Brendon Birdoes, Director, Connected Systems Neudesic\r\n\r\n The pace of innovation in application development has increased significantly over the last few years, driven by the web and a multitude of new mobile devices. Surprisingly, to support this innovation, existing web technologies like HTTP, HTML, CSS and JavaScript continue to evolve enabling a whole new breed of connected applications. \r\n\r\nContinuing on this trend of using existing web technologies, most communication between backend capabilities and mobile/web applications is easily achieved through the HTTP protocol in the form of REST services. Microsoft has followed suit with a new framework to support HTTP and REST services called ASP.Net Web API. So with HTTP and REST becoming so prevalent, is it time to abandon Windows Communication Foundation and default to ASP.NET Web API? This talk explores the strengths and weaknesses of both ASP.NET Web API and WCF, and compares the two messaging technologies for building HTTP/REST services. You might be surprised by the results!\r\n",
                                              Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
                                              SpeakerName = "Brendon Birdoes",
                                              SpeakerBioUrl = "http://twitter.com/brendonbirdoes",
                                              StartDateTime = "9/25/2012 6:00:00 PM",
                                              EndDateTime = "9/25/2012 8:00:00 PM"
                                          });
            this.UpcomingMeetings.Add(new MeetingViewModel()
                                          {
                                              MeetingId = 14,
                                              Title = "TBA",
                                              Details = "Looking for topics and speakers. Any suggestions email them to mikescott8@nwvdnug.org",
                                              Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
                                              SpeakerName = "TBA",
                                              SpeakerBioUrl = "http://twitter.com/brendonbirdoes",
                                              StartDateTime = "10/23/2012 6:00:00 PM",
                                              EndDateTime = "10/23/2012 8:00:00 PM"
                                          });

            
            this.PastMeetings.Add(new MeetingViewModel()
                                          {
                                              MeetingId = 11,
                                              Title = "Developing with RavenDB",
                                              Details = "Abstract:\r\n\r\nRavenDB is a Document Database written entirely in .Net.\r\n\r\nIn this presentation we will cover what a Document Database is and how developing with one requires thinking in a radically different way than you may be used to if you have traditionally used SQL Databases with .Net centric clients. \r\n\r\nIn the sample code we will walk through creating the Models(both .Net and JSON), Views and ViewModels for a modern HTML5, MVVM Website using KnockoutJS and JavaScript (no .Net on the Client) with a full REST WebAPI backend written in .Net using RavenDB as the Database.\r\n\r\nI will demonstrate how this can make Web Based development much more intuitive and friendly for the developer.  We will look at how the architecture for the Semantic Web has made Web Based development the modern standard for both humans and machines.  We will look at the common Design Patterns that you can leverage when working in this style of development and how they are applied across multiple client platforms.\r\n\r\nBio:\r\n\r\nSteele Price has been professionally designing and developing databases and interfaces to them for 30 years. He has also been professionally developing with Microsoft Visual Basic, C#, SQL Server and Visual Studio since their inception many years ago. Recently he has focused on the Semantic Web, HTML5 and cross-platform Web Enabled solutions.\r\n\r\nHe started professionally developing software in 1983.  Software development has not only been his primary source of income since; it is his passion.  Many of his software development processes grew to fruition by seeing a business or consumer need and working diligently to fulfill that need with a real application.  When you love to do something it invades every aspect of your life.  \r\n\r\nIn recent years he has focused on improving the software development process, design patterns and application reach.  Learning from his own process failures as well as successes let him demonstrate how to achieve better real-world delivery of applications to companies ranging from \"mom and pop\" stores to top tier Insurance Carriers and Airlines.\r\n\r\nHe has always maintained a passion for taking that knowledge back to the community by speaking and sharing often with local user groups.\r\n",
                                              Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
                                              SpeakerName = "Steele Price",
                                              SpeakerBioUrl = "http://steeleprice.net/",
                                              StartDateTime = "8/28/2012 6:00:00 PM",
                                              EndDateTime = "8/28/2012 8:00:00 PM"
                                          });
            this.PastMeetings.Add(new MeetingViewModel()
                                          {
                                              MeetingId = 13,
                                              Title = "MythBusters: Is ASP.Net Web API the Best Way to Build RESTFul Services?",
                                              Details = "MythBusters: Is ASP.Net Web API the Best Way to Build RESTFul Services?\r\n Brendon Birdoes, Director, Connected Systems Neudesic\r\n\r\n The pace of innovation in application development has increased significantly over the last few years, driven by the web and a multitude of new mobile devices. Surprisingly, to support this innovation, existing web technologies like HTTP, HTML, CSS and JavaScript continue to evolve enabling a whole new breed of connected applications. \r\n\r\nContinuing on this trend of using existing web technologies, most communication between backend capabilities and mobile/web applications is easily achieved through the HTTP protocol in the form of REST services. Microsoft has followed suit with a new framework to support HTTP and REST services called ASP.Net Web API. So with HTTP and REST becoming so prevalent, is it time to abandon Windows Communication Foundation and default to ASP.NET Web API? This talk explores the strengths and weaknesses of both ASP.NET Web API and WCF, and compares the two messaging technologies for building HTTP/REST services. You might be surprised by the results!\r\n",
                                              Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
                                              SpeakerName = "Brendon Birdoes",
                                              SpeakerBioUrl = "http://twitter.com/brendonbirdoes",
                                              StartDateTime = "9/25/2012 6:00:00 PM",
                                              EndDateTime = "9/25/2012 8:00:00 PM"
                                          });
            this.PastMeetings.Add(new MeetingViewModel()
                                          {
                                              MeetingId = 14,
                                              Title = "TBA",
                                              Details = "Looking for topics and speakers. Any suggestions email them to mikescott8@nwvdnug.org",
                                              Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
                                              SpeakerName = "TBA",
                                              SpeakerBioUrl = "http://twitter.com/brendonbirdoes",
                                              StartDateTime = "10/23/2012 6:00:00 PM",
                                              EndDateTime = "10/23/2012 8:00:00 PM"
                                          });


            this.IsDataLoaded = true;
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