using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class UserProfileResponse
    {

        public int ID {get;set;}
        public string FullName {get;set;}
        public string UserName {get;set;}
        public MessageResponse StatusMessage {get;set;}
        public List<CustomField> CustomFields {get;set;}
        public Contact ContactInfo {get;set;}
        public bool Followable {get;set;}
        public int ContactID {get;set;}
        public Avatar AvatarURL {get;set;}


    }
}
