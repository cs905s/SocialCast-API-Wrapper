using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class LikeResponse
    {
        public int ID {get;set;}
        public bool Unlikeable {get;set;}
        public DateTime CreatedAt {get;set;}
        public UserResponse User {get;set;}
    }
}
