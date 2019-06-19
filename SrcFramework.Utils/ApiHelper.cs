using System;
using System.IO;
using System.Net;

namespace SrcFramework.Utils
{
    public class ApiHelper
    {
        public static string MakeACall(string url,string contentType= "text/json",string method ="GET",string dataToPost=null)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new Exception("Url can't be empty");
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType =contentType;
            httpWebRequest.Method = method;

            if (method=="POST")
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(dataToPost);
                }
            }

            
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse==null)
            {
                throw new Exception("httpResponse is null");
            }
            var responseStream = httpResponse.GetResponseStream();
            if (responseStream==null)
            {
                throw  new Exception("responseStream is null");
            }
            using (var streamReader = new StreamReader(responseStream))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }
    }
}
