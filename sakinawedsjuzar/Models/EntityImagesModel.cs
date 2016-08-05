using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models
{
    public class EntityImagesModel
    {
        public int EntityImageID { get; set; }
        public int SectionID { get; set; }
        public string Url { get; set; }
        public string thumbnail { get; set; }
        public int EntityID { get; set; }
    }
}