using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReplyTitle { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
