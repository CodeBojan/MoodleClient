using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{
    public class Forum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("course")]
        public int Course { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("intro")]
        public string Intro { get; set; }

        [JsonProperty("introformat")]
        public int IntroFormat { get; set; }

        [JsonProperty("introfiles")]
        public List<object> IntroFiles { get; set; }

        [JsonProperty("duedate")]
        public int DueDate { get; set; }

        [JsonProperty("cutoffdate")]
        public int CutOffDate { get; set; }

        [JsonProperty("assessed")]
        public int Assessed { get; set; }

        [JsonProperty("assesstimestart")]
        public int AssessTimeStart { get; set; }

        [JsonProperty("assesstimefinish")]
        public int AssessTimeFinish { get; set; }

        [JsonProperty("scale")]
        public int Scale { get; set; }

        [JsonProperty("grade_forum")]
        public int GradeForum { get; set; }

        [JsonProperty("grade_forum_notify")]
        public int GradeForumNotify { get; set; }

        [JsonProperty("maxbytes")]
        public int MaxBytes { get; set; }

        [JsonProperty("maxattachments")]
        public int MaxAttachments { get; set; }

        [JsonProperty("forcesubscribe")]
        public int ForceSubscribe { get; set; }

        [JsonProperty("trackingtype")]
        public int TrackingType { get; set; }

        [JsonProperty("rsstype")]
        public int RssType { get; set; }

        [JsonProperty("rssarticles")]
        public int RssArticles { get; set; }

        [JsonProperty("timemodified")]
        public int TimeModified { get; set; }

        [JsonProperty("warnafter")]
        public int WarnAfter { get; set; }

        [JsonProperty("blockafter")]
        public int BlockAfter { get; set; }

        [JsonProperty("blockperiod")]
        public int BlockPeriod { get; set; }

        [JsonProperty("completiondiscussions")]
        public int CompletionDiscussions { get; set; }

        [JsonProperty("completionreplies")]
        public int CompletionReplies { get; set; }

        [JsonProperty("completionposts")]
        public int CompletionPosts { get; set; }

        [JsonProperty("cmid")]
        public int Cmid { get; set; }

        [JsonProperty("numdiscussions")]
        public int NumDiscussions { get; set; }

        [JsonProperty("cancreatediscussions")]
        public bool CanCreateDiscussions { get; set; }

        [JsonProperty("lockdiscuttionafter")]
        public int LockDiscussionAfter { get; set; }

        [JsonProperty("istracked")]
        public bool IsTracked { get; set; }
    }


    public class PostsWrapperObject
    {
        [JsonProperty("posts")]
        public List<Post> Posts { get; set; }

        [JsonProperty("forumid")]
        public int ForumId { get; set; }

        [JsonProperty("courseid")]
        public int CourseId { get; set; }

        [JsonProperty("ratinginfo")]
        public RatingInfo RatingInfo { get; set; }

        [JsonProperty("warnings")]
        public List<object> warnings { get; set; }
    }

    public class RatingInfo
    {
        [JsonProperty("contextid")]
        public int ContextId { get; set; }

        [JsonProperty("component")]
        public string Component { get; set; }

        [JsonProperty("ratingarea")]
        public string RatingArea { get; set; }

        [JsonProperty("canviewall")]
        public object CanViewAll { get; set; }

        [JsonProperty("canviewany")]
        public object CanViewAny { get; set; }

        [JsonProperty("scales")]
        public List<object> Scales { get; set; }

        [JsonProperty("ratings")]
        public List<object> Ratings { get; set; }
    }

    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("replysubject")]
        public string ReplySubject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("messageformat")]
        public int MessageFormat { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("discussionid")]
        public int DiscussionId { get; set; }

        [JsonProperty("hasparent")]
        public bool HasParent { get; set; }

        [JsonProperty("parentid")]
        public int? ParentId { get; set; }

        [JsonProperty("timecreated")]
        public int TimeCreated { get; set; }

        [JsonProperty("timemodified")]
        public int TimeModified { get; set; }

        [JsonProperty("unread")]
        public object Unread { get; set; }

        [JsonProperty("isdeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("isprivatereply")]
        public bool IsPrivateReply { get; set; }

        [JsonProperty("haswordcount")]
        public bool HasWordCount { get; set; }

        [JsonProperty("wordcount")]
        public int? WordCount { get; set; }

        [JsonProperty("charcount")]
        public int? CharCount { get; set; }

        [JsonProperty("capabilities")]
        public Capabilities Capabilities { get; set; }

        [JsonProperty("urls")]
        public Urls1 Urls { get; set; }

        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }

        [JsonProperty("tags")]
        public List<object> Tags { get; set; }

        [JsonProperty("html")]
        public Html Html { get; set; }
    }

    public class Author
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("isdeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("groups")]
        public List<object> Groups { get; set; }

        [JsonProperty("urls")]
        public Urls urls { get; set; }
    }

    public class Urls
    {
        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("profileimage")]
        public string ProfileImage { get; set; }
    }

    public class Capabilities
    {
        [JsonProperty("view")]
        public bool View { get; set; }

        [JsonProperty("edit")]
        public bool Edit { get; set; }

        [JsonProperty("delete")]
        public bool Delete { get; set; }

        [JsonProperty("split")]
        public bool Split { get; set; }

        [JsonProperty("reply")]
        public bool Reply { get; set; }

        [JsonProperty("selfenrol")]
        public bool SelfEnrol { get; set; }

        [JsonProperty("export")]
        public bool Export { get; set; }

        [JsonProperty("controlreadstatus")]
        public bool ControlReadStatus { get; set; }

        [JsonProperty("canreplyprivately")]
        public bool CanReplyPrivately { get; set; }
    }

    public class Urls1
    {
        [JsonProperty("view")]
        public string View { get; set; }

        [JsonProperty("viewisolated")]
        public string ViewIsolated { get; set; }

        [JsonProperty("viewparent")]
        public string ViewParent { get; set; }

        [JsonProperty("edit")]
        public object Edit { get; set; }

        [JsonProperty("delete")]
        public object Delete { get; set; }

        [JsonProperty("split")]
        public object Split { get; set; }

        [JsonProperty("reply")]
        public object Reply { get; set; }

        [JsonProperty("export")]
        public object Export { get; set; }

        [JsonProperty("markasread")]
        public object MarkAsRead { get; set; }

        [JsonProperty("markasunread")]
        public object MarkAsUnread { get; set; }

        [JsonProperty("discuss")]
        public string Discuss { get; set; }
    }

    public class Html
    {
        [JsonProperty("rating")]
        public object Rating { get; set; }

        [JsonProperty("taglist")]
        public object TagList { get; set; }

        [JsonProperty("authorsubheading")]
        public string AuthorSubheading { get; set; }
    }

}
