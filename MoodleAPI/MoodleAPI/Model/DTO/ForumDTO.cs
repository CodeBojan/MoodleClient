using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model.DTO
{
    public class ForumDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<DiscussionDTO> Discussions { get; set;}
        public string Type { get; set; }

    }
}
