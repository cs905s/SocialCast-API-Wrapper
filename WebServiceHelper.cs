using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Web;

namespace SocialCastLib
{

    public class WebServiceHelper
    {
        public string MakeServiceCalls(string _requestURL, NetworkCredential credential)
        {

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(_requestURL) as HttpWebRequest;
            request.Credentials = credential;
            request.Timeout = 120000;
            // Get response  %
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                var stringXmlDoc = reader.ReadToEnd();
                stringXmlDoc = stringXmlDoc.Replace("video:", string.Empty);
                stringXmlDoc = stringXmlDoc.Replace("ogp.", string.Empty);
                return stringXmlDoc;
            }

            
        }

        public string MakeServiceCallsPOST(string _requestURL, NetworkCredential credentials, string data)
        {
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(_requestURL) as HttpWebRequest;

            request.Credentials = credentials;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            return MakePostCall(data, request);
        }

        public string MakeServiceCallsPOST(string _requestURL, string data)
        {
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(_requestURL) as HttpWebRequest;

            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            return MakePostCall(data, request);
        }

        private string MakePostCall(string data, HttpWebRequest request)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

    }
    
}
