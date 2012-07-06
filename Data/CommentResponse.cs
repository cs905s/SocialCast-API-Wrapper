using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class CommentResponse
    {
        public int ID { get; set; }
        public string CommentText {get;set;}
        public string URL {get;set;}
        public UserResponse OwnerUser {get;set;}
        public DateTime CreatedDate {get;set;}
        public bool Editable {get;set;}
        public bool Deletable {get;set;}
        public bool Likeable {get;set;}
        public List<LikeResponse> Likes {get;set;}
        public int ListCount {get;set;}
        public List<AttachmentResponse> Attachments {get;set;}

    }
}
