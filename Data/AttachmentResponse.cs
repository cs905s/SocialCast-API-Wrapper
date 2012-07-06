using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class AttachmentResponse
    {
        public int AttachmentID {get;set;}
        public string FileName {get;set;}
        public string URL {get;set;}
        public string SecureURL {get;set;}
        public string FileExtension {get;set;}
        public string MimeType {get;set;}


    }
}
