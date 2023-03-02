using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ForumDTO> Forums { get; set; }
        public List<FileDTO> Files { get; set; }
        public List<UrlDTO> Urls { get; set; }
    }
}
