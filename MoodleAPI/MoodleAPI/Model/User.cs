using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{

    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("fullname")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("lastaccess")]
        public int LastAccess { get; set; }

        [JsonProperty("auth")]
        public string Auth { get; set; }

        [JsonProperty("suspended")]
        public bool Suspended { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("mailformat")]
        public int MailFormat { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("descriptionformat")]
        public int DescriptionFormat { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("profileimageurlsmall")]
        public string ProfileImageUrlSmall { get; set; }

        [JsonProperty("profileimageurl")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("preferences")]
        public List<Preference> Preferences { get; set; }
    }

    public class Preference
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }

}
