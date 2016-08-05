using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models
{
    public class EventModel
    {
        public int OurEventID { get; set; }
        public string Title { get; set; }
        public string EventLocation { get; set; }
        public string EventContent { get; set; }
        public int TemplateID { get; set; }
        public List<EntityImage> Images { get; set; }
    }
}