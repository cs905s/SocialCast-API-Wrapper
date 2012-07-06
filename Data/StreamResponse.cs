using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class StreamResponse
    {
        public int StreamID {get;set;}
        public string Name {get;set;}
        public bool IsDefaultStream {get;set;}
        public DateTime LastInteractedAt {get;set;}
        public bool IsCustomStream {get;set;}
        public GroupResponse Group {get;set;}


    }
}
