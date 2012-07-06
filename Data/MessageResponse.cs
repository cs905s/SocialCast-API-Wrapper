using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialCastLib.Data
{
    class MessageResponse
    {
        public string Title { get; set; }
        public string Body {get;set;}
        public string URL {get;set;}
        public string PermalinkURL {get;set;}
        public string Action {get;set;}
        public string ExternalURL {get;set;}
        public string Icon {get;set;}
        public string ID {get;set;}
        public bool Likeable {get;set;}
        public DateTime CreatedDate {get;set;}
        public DateTime LastInteractedDate {get;set;}
        public string PlayerURL {get;set;}
        public string ThumbnailURL {get;set;}
        public string FlashPlayerParams {get;set;}
        public UserResponse Owner {get;set;}
        public List<GroupResponse> Groups {get;set;}
        public Source Source {get;set;}
        public List<AttachmentResponse> Attachments {get;set;}
        public List<CommentResponse> Comments {get;set;}
        public int CommentCount {get;set;}
        public List<LikeResponse> Likes {get;set;}
        public int LikeCount {get;set;}
        public List<MediaFile> MediaFiles {get;set;}
        public List<UserResponse> Recipients {get;set;}
        public List<string> Tags {get;set;}
        public FlagResponse Flag {get;set;}

    }
}
