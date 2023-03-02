using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{
    public class FileDTO
    {
        public int[] Data { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public int CourseId { get; set; }
        public int CourseSectionId { get; set; }
        public int CourseModuleId { get; set; }
    }
}
