using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{

    public class GetEnrolledCoursesReturnObject
    {
        [JsonProperty("courses")]
        public List<Course> Courses { get; set; }

        [JsonProperty("nextoffset")]
        public int NextOffset { get; set; }
    }

    public class CourseSection
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visible")]
        public int Visible { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("summaryformat")]
        public int Summaryformat { get; set; }

        [JsonProperty("section")]
        public int Section { get; set; }

        [JsonProperty("hiddenbynumsections")]
        public int Hiddenbynumsections { get; set; }

        [JsonProperty("uservisible")]
        public bool Uservisible { get; set; }

        [JsonProperty("modules")]
        public List<CourseModule> Modules { get; set; }
    }

    public class CourseModule
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("instance")]
        public int Instance { get; set; }

        [JsonProperty("contextid")]
        public int ContextId { get; set; }

        [JsonProperty("visible")]
        public int Visible { get; set; }

        [JsonProperty("uservisible")]
        public bool UserVisible { get; set; }

        [JsonProperty("visibleoncoursepage")]
        public int VisibleOnCoursePage { get; set; }

        [JsonProperty("modicon")]
        public string ModIcon { get; set; }

        [JsonProperty("modname")]
        public string ModName { get; set; }

        [JsonProperty("modplural")]
        public string ModPlural { get; set; }

        [JsonProperty("indent")]
        public int Indent { get; set; }

        [JsonProperty("onclick")]
        public string Onclick { get; set; }

        [JsonProperty("afterlink")]
        public object Afterlink { get; set; }

        [JsonProperty("customdata")]
        public string Customdata { get; set; }

        [JsonProperty("noviewlink")]
        public bool NoViewLink { get; set; }

        [JsonProperty("completion")]
        public int Completion { get; set; }

        [JsonProperty("dates")]
        public List<Date> Dates { get; set; }

        [JsonProperty("completiondata")]
        public CompletionData CompletionData { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("contents")]
        public List<Content> Contents { get; set; }

        [JsonProperty("contentsinfo")]
        public ContentsInfo ContentsInfo { get; set; }
    }

    public class MoodleFile
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("filepath")]
        public string FilePath { get; set; }

        [JsonProperty("filesize")]
        public int FileSize { get; set; }

        [JsonProperty("fileurl")]
        public string FileUrl { get; set; }

        [JsonProperty("timemodified")]
        public int TimeModified { get; set; }

        [JsonProperty("mimetype")]
        public string MimeType { get; set; }

        [JsonProperty("isexternalfile")]
        public int IsExternalFile { get; set; }

        [JsonProperty("repositorytype")]
        public string RepositoryType { get; set; }
    }

    public class Date
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

    }

    public class CompletionData
    {
        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("timecompleted")]
        public int Timecompleted { get; set; }

        [JsonProperty("overrideby")]
        public object OverrideBy { get; set; }

        [JsonProperty("valueused")]
        public bool ValueUsed { get; set; }

        [JsonProperty("hascompletion")]
        public bool HasCompletion { get; set; }

        [JsonProperty("isautomatic")]
        public bool IsAutomatic { get; set; }

        [JsonProperty("istrackeduser")]
        public bool IsTrackedUser { get; set; }

        [JsonProperty("uservisible")]
        public bool UserVisible { get; set; }

        [JsonProperty("details")]
        public Detail[] Details { get; set; }
    }

    public class Detail
    {
        [JsonProperty("rulename")]
        public string RuleName { get; set; }

        [JsonProperty("rulevalue")]
        public RuleValue RuleValue { get; set; }
    }

    public class RuleValue
    {

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ContentsInfo
    {
        [JsonProperty("filescount")]
        public int FilesCount { get; set; }

        [JsonProperty("filessize")]
        public int FilesSize { get; set; }

        [JsonProperty("lastmodified")]
        public int LastModified { get; set; }

        [JsonProperty("mimetypes")]
        public string[] MimeTypes { get; set; }

        [JsonProperty("repositorytype")]
        public string RepositoryType { get; set; }
    }

    public class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("filepath")]
        public string FilePath { get; set; }

        [JsonProperty("filesize")]
        public int FileSize { get; set; }

        [JsonProperty("fileurl")]
        public string FileUrl { get; set; }

        [JsonProperty("timecreated")]
        public int? TimeCreated { get; set; }

        [JsonProperty("timemodified")]
        public int TimeModified { get; set; }

        [JsonProperty("sortorder")]
        public int? SortOrder { get; set; }

        [JsonProperty("userid")]
        public int? UserId { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("licence")]
        public string License { get; set; }

        [JsonProperty("mimetype")]
        public string MimeType { get; set; }

        [JsonProperty("isexternalfile")]
        public bool IsExternalFile { get; set; }
    }

}
