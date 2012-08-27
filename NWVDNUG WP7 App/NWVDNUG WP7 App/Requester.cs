using System;
using System.IO;
using System.Net;

namespace NWVDNUG_WP7_App
{
    public class Requester
    {
        public void StartJsonRequest(string restUrl)
        {
            var req = (HttpWebRequest) WebRequest.Create(new Uri(restUrl));
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            
            //call async
            req.BeginGetResponse(JsonGetRequestStreamCallback, req);
        }

        public void JsonGetRequestStreamCallback(IAsyncResult asynchronousResult)
        {    
            WebResponse response = ((HttpWebRequest)asynchronousResult.AsyncState).EndGetResponse(asynchronousResult);    
        
            using (var reader = new StreamReader(response.GetResponseStream()))    
            {        
                string responseString = reader.ReadToEnd();        
                reader.Close();        

                //deserialize using datacontract serializer (not shown)    
            }
        }
    }
}
