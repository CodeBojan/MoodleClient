using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model.DTO
{
    public class UrlDTO
    {
        //for assignments, choices, and links
        public int Id { get; set; } 
        public int CourseId { get; set; }
        public string Url { get; set; } 
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
