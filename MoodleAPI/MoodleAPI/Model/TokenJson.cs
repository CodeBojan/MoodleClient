using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{
    public class TokenJson
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("privatetoken")]
        public string PrivateToken { get; set; }
    }
}
