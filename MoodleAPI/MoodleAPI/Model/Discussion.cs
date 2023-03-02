using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{


    public class DiscussionsWrapperObject
    {
        [JsonProperty("discussions")]
        public List<Discussion> Discussions { get; set; }

        [JsonProperty("warnings")]
        public List<object> Warnings { get; set; }
    }

    public class Discussion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("timemodified")]
        public int TimeModified { get; set; }

        [JsonProperty("usermodified")]
        public int UserModified { get; set; }

        [JsonProperty("timestart")]
        public int TimeStart { get; set; }

        [JsonProperty("timeend")]
        public int TimeEnd { get; set; }

        [JsonProperty("discussion")]
        public int DiscussionId { get; set; }

        [JsonProperty("parent")]
        public int Parent { get; set; }

        [JsonProperty("userid")]
        public int UserId { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("modified")]
        public int Modified { get; set; }

        [JsonProperty("mailed")]
        public int Mailed { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("messageformat")]
        public int MessageFormat { get; set; }

        [JsonProperty("messagetrust")]
        public int MessageTrust { get; set; }

        [JsonProperty("attachment")]
        public bool Attachment { get; set; }

        [JsonProperty("totalscore")]
        public int TotalScore { get; set; }

        [JsonProperty("mailnow")]
        public int MailNow { get; set; }

        [JsonProperty("userfullname")]
        public string UserFullName { get; set; }

        [JsonProperty("usermodifiedfullname")]
        public string UserModifiedFullName { get; set; }

        [JsonProperty("userpictureurl")]
        public string UserPictureUrl { get; set; }

        [JsonProperty("usermodifiedpictureurl")]
        public string UserModifiedPictureUrl { get; set; }

        [JsonProperty("numreplies")]
        public int NumReplies { get; set; }

        [JsonProperty("numunread")]
        public int NumUnread { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("starred")]
        public bool Starred { get; set; }

        [JsonProperty("canreply")]
        public bool CanReply { get; set; }

        [JsonProperty("canlock")]
        public bool CanLock { get; set; }

        [JsonProperty("canfavourite")]
        public bool CanFavourite { get; set; }
    }

}
