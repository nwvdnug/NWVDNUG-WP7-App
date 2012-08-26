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
    public class MeetingViewModel : INotifyPropertyChanged
    {
        public MeetingViewModel()
        {
        }

        private int _meetingId;
        public int MeetingId
        {
            get {return _meetingId; }
            set
            {
                if(_meetingId == value) return;
                _meetingId = value;
                OnPropertyChanged("MeetingId");
            }
        }

        private string _title;
        public string Title
        {
            get {return _title; }
            set
            {
                if(_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _speakerName;
        public string SpeakerName
        {
            get {return _speakerName; }
            set
            {
                if(_speakerName == value) return;
                _speakerName = value;
                OnPropertyChanged("SpeakerName");
            }
        }

        private string _speakerBioUrl;
        public string SpeakerBioUrl
        {
            get {return _speakerBioUrl; }
            set
            {
                if(_speakerBioUrl == value) return;
                _speakerBioUrl = value;
                OnPropertyChanged("SpeakerBioUrl");
            }
        }

        private string _location;
        public string Location
        {
            get {return _location; }
            set
            {
                if(_location == value) return;
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        private string _startDateTime;
        public string StartDateTime
        {
            get {return _startDateTime; }
            set
            {
                if(_startDateTime == value) return;
                _startDateTime = value;
                OnPropertyChanged("StartDateTime");
            }
        }

        private string _endDateTime;
        public string EndDateTime
        {
            get {return _endDateTime; }
            set
            {
                if(_endDateTime == value) return;
                _endDateTime = value;
                OnPropertyChanged("EndDateTime");
            }
        }

        private string _details;
        public string Details
        {
            get {return _details; }
            set
            {
                if(_details == value) return;
                _details = value;
                OnPropertyChanged("Details");
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