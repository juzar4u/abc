using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models
{
    public class LoveStoryModel
    {
        public int OurStoryID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string PublishDate { get; set; }
        public string Content { get; set; }
        public string SpecialComment { get; set; }
        public string CommentBy { get; set; }
        public int TemplateId { get; set; }
        public string ImageUrl { get; set; }
    }
}