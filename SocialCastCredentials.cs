using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Reflection;

namespace SocialCastLib
{
    public static class ObjectType
    {
        static string defaultFormat = ".xml";
        public static string Users = "users" + defaultFormat;
        public static string Streams = "streams" + defaultFormat;
        public static string Messages = "messages" + defaultFormat;
        public static string StreamMessages = "streams/{0}/messages" + defaultFormat;
        public static string MessagesById = "messages/{0}" + defaultFormat;
        public static string SearchUsers = "users/search" + defaultFormat;
        public static string Groups = "groups" + defaultFormat;
        public static string GroupMembers = "groups/{0}/members" + defaultFormat;
        public static string Followers = "users/{0}/followers" + defaultFormat;
        public static string Following = "users/{0}/following" + defaultFormat;
    }

     public class SocialCastData
    {
        /// <summary>
        /// These are the private variables which are configured
        /// as per your socialcast site
        /// </summary>
        string skeletonURL = "https://{0}.socialcast.com/api/{1}";

        //This method uses reflection to provide the API url
        // value based on an agument to this method
        protected string GetSocialCastURL(string apiUrl,string domainName,string parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(parameter))
                    return String.Format(skeletonURL, domainName, apiUrl.ToLower());
                else
                    return String.Format(skeletonURL, domainName, String.Format(apiUrl, parameter));
            }
            catch (Exception _eObj) { throw new Exception("There was no corresponding API URL found", _eObj); }
        }

    }

    /// <summary>
    /// This is the helper class which provides the URL 
    /// and Credentials to the WebServiceHelper object. Only the Helper
    /// class has access to the SocialCastData members since all its 
    /// members are protected.
    /// </summary>
    public class SocialcastHelper:SocialCastData
    {

        public string GetSocialcastURL(string _apiURL,string domainName,string _parameter)
        {
            return base.GetSocialCastURL(_apiURL,domainName,_parameter);
        }

        public string GetSocialcastURL(string _apiURL,string domainName,string _parameter, List<KeyValuePair<string, string>> _paramMessages)
        {
            //Get the URL from the base class method and append
            //the query params
            string _url = base.GetSocialCastURL(_apiURL,domainName,_parameter);
            if (_paramMessages.Count > 0)
            {
                _url += "?";
                foreach (var item in _paramMessages)
                {
                    //appending each param key and value
                    _url += String.Format("{0}={1}&", item.Key, item.Value);
                }
                //String the last ampersand sign
                return _url.Substring(0, _url.Length - 1);
            }
            return _url;
        }
    }


}
