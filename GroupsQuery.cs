using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib
{
   static class GroupsQuery
    {
       static Dictionary<string, int> Groups = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

       static GroupsQuery()
       {
           InitializeDictionary();
       }

       private static void InitializeDictionary()
       {
           
       }

       public static void AddToDictionary(string key, int value)
       {
           Groups.Add(key, value);
       }

       

       public static int QueryForGroupID(string groupName)
       {
           int groupKey=0;
           if (Groups.ContainsKey(groupName) && Groups.TryGetValue(groupName, out groupKey)) ;
           return groupKey;
           
               
       }

    }
}
