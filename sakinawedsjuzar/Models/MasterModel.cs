
using sakinawedsjuzar.Models.CommentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models
{
    public class MasterModel
    {
        public CommonInfoModel CommonInfo { get; set; }
        public List<EntityImage> MainSlideImages { get; set; }
        public List<EntityImage> OurMemoriesPhotos { get; set; }
        public List<EntityImage> Bridesmaids { get; set; }
        public List<EntityImage> Groomsmens { get; set; }
        public List<LoveStoryModel> lovestories { get; set; }
        public List<EventModel> events { get; set; }
        public List<CommentMaster> comments { get; set; }
        

    }
}