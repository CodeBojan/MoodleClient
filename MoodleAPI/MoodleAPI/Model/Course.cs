using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{
    public class Course
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("shortname")]
        public string ShortName { get; set; }

        [JsonProperty("idnumber")]
        public string IdNumber { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("summaryformat")]
        public int SummaryFormat { get; set; }

        [JsonProperty("startdate")]
        public int StartDate { get; set; }

        [JsonProperty("enddate")]
        public int EndDate { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("showactivitydates")]
        public bool ShowActivityDates { get; set; }

        [JsonProperty("showcompletionconditions")]
        public bool ShowCompletionConditions { get; set; }

        [JsonProperty("fullnamedisplay")]
        public string FullNameDisplay { get; set; }

        [JsonProperty("viewurl")]
        public string ViewUrl { get; set; }

        [JsonProperty("courseimage")]
        public string CourseImage { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("hasprogress")]
        public bool HasProgress { get; set; }

        [JsonProperty("isfavourite")]
        public bool IsFavourite { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("showshortname")]
        public bool ShowShortName { get; set; }

        [JsonProperty("coursecategory")]
        public string CourseCategory { get; set; }

    }


    public class CourseByUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("shortname")]
        public string ShortName { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("displayname")]
        public string DisplayName { get; set; }

        [JsonProperty("enrolledusercount")]
        public int EnrolledUserCount { get; set; }

        [JsonProperty("idnumber")]
        public string IdNumber { get; set; }

        [JsonProperty("visible")]
        public int Visible { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("summaryformat")]
        public int SummaryFormat { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("showgrades")]
        public bool ShowGrades { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("enablecompletion")]
        public bool EnableCompletion { get; set; }

        [JsonProperty("completionhascriteria")]
        public bool CompletionHasCriteria { get; set; }

        [JsonProperty("completionusertracked")]
        public bool CompletionUserTracked { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("progress")]
        public double? Progress { get; set; }

        [JsonProperty("completed")]
        public bool? Completed { get; set; }

        [JsonProperty("startdate")]
        public int StartDate { get; set; }

        [JsonProperty("enddate")]
        public int EndDate { get; set; }

        [JsonProperty("marker")]
        public int Marker { get; set; }

        [JsonProperty("lastaccess")]
        public int LastAccess { get; set; }

        [JsonProperty("isfavourite")]
        public bool? IsFavourite { get; set; }

        [JsonProperty("hidden")]
        public bool? Hidden { get; set; }

        [JsonProperty("overviewfiles")]
        public List<object> OverviewFiles { get; set; }

        [JsonProperty("showactivitydates")]
        public bool? ShowActivityDates { get; set; }

        [JsonProperty("showcompletionconditions")]
        public bool? ShowCompletionConditions { get; set; }
    }

}
