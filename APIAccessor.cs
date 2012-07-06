using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Web;

namespace SocialCastLib
{
    public class APIAccessor : WebServiceHelper
    {
        //Creating the Helper class Instance
        SocialcastHelper helper = new SocialcastHelper();

        public XmlDocument GetUsers(string searchString, SocialCastAuthDetails auth)
        {
            XmlDocument users = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("q", searchString));

            users.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.SearchUsers, auth.DomainName, null, serviceParams), GetCredentials(auth.Username, auth.Password)));
            return users;
        }

        public XmlDocument GetUsers(string numberOfusers, string page, SocialCastAuthDetails auth)
        {
            XmlDocument Users = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfusers));
            serviceParams.Add(new KeyValuePair<string, string>("page", page));
            Users.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.Users, auth.DomainName, null, serviceParams), GetCredentials(auth.Username, auth.Password)));


            return Users;

        }

        public XmlDocument GetMessage(string _messageID, SocialCastAuthDetails auth)
        {
            XmlDocument Message = new XmlDocument();
            Message.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.MessagesById, auth.DomainName, _messageID), GetCredentials(auth.Username, auth.Password)));
            return Message;
        }

        public XmlDocument GetMessage(string _messageID, string numberOfUsers, string page, SocialCastAuthDetails auth)
        {
            XmlDocument Message = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfUsers));
            serviceParams.Add(new KeyValuePair<string, string>("page", page));
            Message.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.MessagesById, auth.DomainName, _messageID, serviceParams), GetCredentials(auth.Username, auth.Password)));
            return Message;
        }

        public XmlDocument GetCompanyStream(SocialCastAuthDetails auth)
        {
            int companyStreamID = GetStreamIdbyStreamName("company stream", auth);
            var streams = new XmlDocument();
            streams.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.StreamMessages, auth.DomainName, companyStreamID.ToString()), GetCredentials(auth.Username, auth.Password)));
            return streams;
        }

        public XmlDocument GetStreamMessages(string streamName, string numberOfMessages, string page, string sinceWhen, SocialCastAuthDetails auth)
        {
            XmlDocument streams = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfMessages));
            serviceParams.Add(new KeyValuePair<string, string>("page", page));
            if (sinceWhen != null)
                serviceParams.Add(new KeyValuePair<string, string>("since", sinceWhen));
            int GroupID = GetGroupIdByGroupName(streamName, auth);
            if (GroupID == 0)
                throw new GroupNotFoundException(streamName, String.Format("The Group {0} was not found. Please try again", streamName));
            serviceParams.Add(new KeyValuePair<string, string>("group_id", GroupID.ToString()));
            streams.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.Messages, auth.DomainName, GroupID.ToString(), serviceParams), GetCredentials(auth.Username, auth.Password)));
            return streams;
        }

        public XmlDocument GetStreamMessagesDirectly(string streamName, string numberOfMessages, string page, SocialCastAuthDetails auth)
        {
            XmlDocument streams = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfMessages));
            serviceParams.Add(new KeyValuePair<string, string>("page", page));
            streams.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.StreamMessages, auth.DomainName, streamName, serviceParams), GetCredentials(auth.Username, auth.Password)));
            return streams;
        }


        public XmlDocument GetCompanyStream(string numberOfMessages, string page, SocialCastAuthDetails auth)
        {
            XmlDocument streams = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfMessages));
            serviceParams.Add(new KeyValuePair<string, string>("page", page));
            int companyStreamID = GetStreamIdbyStreamName("company stream", auth);
            streams.XmlResolver = null;
            streams.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.StreamMessages, auth.DomainName, companyStreamID.ToString(), serviceParams), GetCredentials(auth.Username, auth.Password)));
            return streams;
        }

        public XmlDocument GetFollowers(string username, int page, int numberOfMessages, SocialCastAuthDetails auth)
        {
            XmlDocument followers = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfMessages.ToString()));
            serviceParams.Add(new KeyValuePair<string, string>("page", page.ToString()));
            followers.XmlResolver = null;
            followers.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.Followers, auth.DomainName, username, serviceParams), GetCredentials(auth.Username, auth.Password)));
            return followers;
        }

        public XmlDocument PostMessage(string title, string body, SocialCastAuthDetails auth)
        {
            string data = String.Format("message[title]={0}&message[body]={1}", HttpUtility.UrlEncode(title), HttpUtility.UrlEncode(body));
            XmlDocument update = new XmlDocument();
            update.LoadXml(base.MakeServiceCallsPOST(helper.GetSocialcastURL(ObjectType.Messages, auth.DomainName, null), GetCredentials(auth.Username, auth.Password), data));
            return update;
        }

        private NetworkCredential GetCredentials(string userName, string password)
        {
            return new NetworkCredential(userName, password);
        }

        public XmlDocument GetGroupMembers(string groupName, string page, string numberOfRecords, SocialCastAuthDetails auth)
        {
            XmlDocument users = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfRecords));
            serviceParams.Add(new KeyValuePair<string, string>("page", page));
            users.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.GroupMembers, auth.DomainName, groupName, serviceParams), GetCredentials(auth.Username, auth.Password)));
            return users;
        }

        public XmlDocument GetGroups(int page, int numberOfRecords, SocialCastAuthDetails auth)
        {
            XmlDocument groups = new XmlDocument();
            var serviceParams = new List<KeyValuePair<string, string>>();
            serviceParams.Add(new KeyValuePair<string, string>("per_page", numberOfRecords.ToString()));
            serviceParams.Add(new KeyValuePair<string, string>("page", page.ToString()));
            groups.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.Groups, auth.DomainName, null, serviceParams), GetCredentials(auth.Username, auth.Password)));
            return groups;
        }

        private int GetGroupIdByGroupName(string groupName, SocialCastAuthDetails auth)
        {

            int _groupId = 0;
            int _pageNumber = 1;
            bool moreItems = true;


            _groupId = GroupsQuery.QueryForGroupID(groupName);
            if (_groupId != 0)
                return _groupId;
            else
            {

                while (moreItems)
                {
                    XmlDocument group = new XmlDocument();
                    var serviceParams = new List<KeyValuePair<string, string>>();
                    serviceParams.Add(new KeyValuePair<string, string>("page", _pageNumber.ToString()));
                    serviceParams.Add(new KeyValuePair<string, string>("per_page", "500"));
                    group.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.Groups, auth.DomainName, null, serviceParams), GetCredentials(auth.Username, auth.Password)));
                    if (group.SelectNodes("//groups/group") == null || group.SelectNodes("//groups/group").Count == 0)
                        moreItems = false;
                    else
                    {
                        foreach (XmlNode groupNode in group.SelectNodes("//groups/group"))
                        {
                            if (String.Compare(GetNodeInnerText(groupNode, "groupname"), groupName, true) == 0)
                            {
                                string id = GetNodeInnerText(groupNode, "id");
                                _groupId = Convert.ToInt32(id);
                                GroupsQuery.AddToDictionary(groupName, _groupId);
                                moreItems = false;
                                break;
                            }
                        }
                    }
                    _pageNumber++;
                }
                return _groupId;
            }
        }

        private string GetNodeInnerText(XmlNode node, string xpath)
        {
            try
            {
                if (node.SelectSingleNode(xpath) != null)
                {
                    return node.SelectSingleNode(xpath).InnerText;
                }
                return String.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private int GetStreamIdbyStreamName(string _streamName, SocialCastAuthDetails auth)
        {
            int _streamID = 0;
            XmlDocument streams = new XmlDocument();
            streams.LoadXml(base.MakeServiceCalls(helper.GetSocialcastURL(ObjectType.Streams, auth.DomainName, null), GetCredentials(auth.Username, auth.Password)));

            foreach (XmlNode node in streams.SelectNodes("//stream"))
            {
                if (node.SelectSingleNode("group/groupname") != null && node.SelectSingleNode("group/groupname").InnerText.ToLower() == _streamName.ToLower())
                {
                    _streamID = int.Parse(node.SelectSingleNode("id").InnerText);
                    break;
                }
            }
            return _streamID;
        }
    }
}
