using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib
{
    public class GroupNotFoundException: Exception
    {
        public string GroupName { get; set; }

        public GroupNotFoundException(string groupName, string exceptionMessage)
            : base(exceptionMessage)
        {
            this.GroupName = groupName;
        }
    }
}
