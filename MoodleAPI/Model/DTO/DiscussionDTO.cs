using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model.DTO
{
    public class DiscussionDTO
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}
