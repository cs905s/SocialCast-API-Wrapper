using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class UserResponse
    {
        public int ID { get; set; }
        public string Name {get;set;}
        public string URL {get;set;}
        public string UserName {get;set;}
        public bool Terminated {get;set;}
        public Avatar AvatarURL {get;set;}

    }
}
