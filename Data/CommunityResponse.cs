using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class CommunityResponse
    {

        public string CommunityName {get;set;}
        public string SubdomainName {get;set;}
        public string FullyQualifiedDomain {get;set;}
        public UserProfileResponse CommunityProfile {get;set;}

    }
}
