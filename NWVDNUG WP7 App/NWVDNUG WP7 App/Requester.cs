using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using NWVDNUG_WP7_App.ViewModels;

namespace NWVDNUG_WP7_App
{
    public class Requester
    {
        public void LoadUpcoming()
        {
            const string restUrl = "http://nwvdnug.org/api/upcomingmeetings/";
            var req = BuildHttpWebRequestObj(restUrl);

            //call async
            req.BeginGetResponse(UpcomingMeetingJsonGetRequestStreamCallback, req);
        }

        public void LoadPast()
        {
            const string restUrl = "http://nwvdnug.org/api/pastmeetings/";
            var req = BuildHttpWebRequestObj(restUrl);

            //call async
            req.BeginGetResponse(PastMeetingJsonGetRequestStreamCallback, req);
        }

        private HttpWebRequest BuildHttpWebRequestObj(string restUrl)
        {
            var req = (HttpWebRequest) WebRequest.Create(new Uri(restUrl));
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            return req;
        }

        public void UpcomingMeetingJsonGetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                WebResponse response = ((HttpWebRequest)asynchronousResult.AsyncState).EndGetResponse(asynchronousResult);    
        
                using (var reader = new StreamReader(response.GetResponseStream()))    
                {        
                    string responseString = reader.ReadToEnd();        
                    reader.Close();        

                    //deserialize using datacontract serializer (not shown)    
                    var json = (JsonArray) SimpleJson.DeserializeObject(responseString);

                    json.ForEach(mtg =>
                                 Deployment.Current.Dispatcher.BeginInvoke(() => App.ViewModel.UpcomingMeetings.Add(ParseJsonObject(mtg))));
                }
            }
            catch (WebException e)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                                                          App.ViewModel.UpcomingMeetings.Add(new MeetingViewModel
                                                                                                 {
                                                                                                     Title = "Error connecting to server.",
                                                                                                     SpeakerName = e.Message,
                                                                                                     Location = "Please press and hold the 'Upcoming' header to try again."
                                                                                                 }));
            }
        }

        public void PastMeetingJsonGetRequestStreamCallback(IAsyncResult asynchronousResult)
        {    
            try
            {
                WebResponse response = ((HttpWebRequest)asynchronousResult.AsyncState).EndGetResponse(asynchronousResult);    
        
                using (var reader = new StreamReader(response.GetResponseStream()))    
                {        
                    string responseString = reader.ReadToEnd();        
                    reader.Close();        

                    //deserialize using datacontract serializer (not shown)    
                    var json = (JsonArray) SimpleJson.DeserializeObject(responseString);

                    json.ForEach(mtg =>
                                 Deployment.Current.Dispatcher.BeginInvoke(() => App.ViewModel.PastMeetings.Add(ParseJsonObject(mtg))));
                }
            }
            catch (WebException e)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                                                          App.ViewModel.PastMeetings.Add(new MeetingViewModel
                                                                                             {
                                                                                                 Title = "Error connecting to server.",
                                                                                                 SpeakerName = e.Message,
                                                                                                 Location = "Please press and hold the 'Upcoming' header to try again."
                                                                                             }));
            }
        }

        private MeetingViewModel ParseJsonObject(object jsonMtg)
        {
            var jsonDict = ((IDictionary<string, object>) jsonMtg);
            return new MeetingViewModel
                       {
                           MeetingId =Convert.ToInt16((long)jsonDict["Id"]),
                           Title = (string)jsonDict["Title"],
                           Details = (string)jsonDict["Notes"],
                           Location = (string)jsonDict["Location"],
                           SpeakerName = (string)jsonDict["SpeakerName"],
                           SpeakerBioUrl = (string)jsonDict["SpeakerBioLink"],
                           StartDateTime = (string)jsonDict["MeetingStartTime"],
                           EndDateTime = (string)jsonDict["MeetingEndTime"]
                       };
        }
    }
}
