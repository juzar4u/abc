using sakinawedsjuzar.Models.CommentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models
{
    public class Services
    {
        private static Services _instace;

        public static Services GetInstance
        {
            get
            {
                if (_instace == null)
                {
                    _instace = new Services();
                }

                return _instace;
            }
        }

        

        public int UpdateCommonInfoData(CommonInfo model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Update(model);
            }
        }

        public int DeleteEntityImage(EntityImage model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Delete(model);
            }
        }

        public int DeleteLoveStory(OurLoveStory model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Delete(model);
            }
        }

        public int InsertLoveStory(OurLoveStory model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Insert(model);
            }
        }

        public int InsertOurEvent(OurEvent model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Insert(model);
            }
        }

        public int InsertEntityImage(EntityImage model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Insert(model);
            }
        }

        public CommonInfoModel GetCommonInfo()
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<CommonInfoModel>("select * from CommonInfo where CommonInfoID = 1").FirstOrDefault();
            }
        }

        public CommonInfo GetCommonInfoData()
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<CommonInfo>("select * from CommonInfo where CommonInfoID = 1").FirstOrDefault();
            }
        }


        public List<EntityImage> GetMainSliderImages()
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<EntityImage>("select * from EntityImages where SectionID = 6");
            }
        }

        public List<EntityImage> GetImagesBySectionID(int sectionID)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<EntityImage>("select * from EntityImages where SectionID = @0", sectionID);
            }
        }

        public List<LoveStoryModel> GetLoveStories()
        {
            List<LoveStoryModel> models = new List<LoveStoryModel>();
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                models = context.Fetch<LoveStoryModel>("select * from OurLoveStory");
                foreach (var item in models)
                {
                    item.ImageUrl = context.Fetch<string>("select Url from EntityImages where SectionID = 3 and EntityID = @0", item.OurStoryID).FirstOrDefault();
                }
            }
            return models;
        }


        public List<EventModel> GetEvents()
        {
            List<EventModel> models = new List<EventModel>();
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                models = context.Fetch<EventModel>("select * from OurEvents");
                foreach (var item in models)
                {
                    item.Images = context.Fetch<EntityImage>("select * from EntityImages where SectionID = 2 and EntityID = @0", item.OurEventID);
                }
            }
            return models;
        }


        public List<CommentMaster> GetComments()
        {
            List<CommentMaster> models = new List<CommentMaster>();
            List<CommentItem> comments = new List<CommentItem>();

            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                comments = context.Fetch<CommentItem>("select * from Comments where ParentCommentID is null");

                foreach (var item in comments)
                {

                    models.Add(new CommentMaster()
                    {
                        comment = item,
                        
                        childcomments = context.Fetch<CommentItem>("select * from Comments where ParentCommentID = @0", item.CommentID)
                    });
                }
            }
            return models;

        }


        public EntityImage GetEntityImageByImageID(int id)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<EntityImage>("select * from EntityImages where EntityImageID = @0", id).FirstOrDefault();
            }
        }

        public OurLoveStory GetLoveStoryByLoveStoryID(int id)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<OurLoveStory>("select * from OurLoveStory where OurStoryID = @0", id).FirstOrDefault();
            }
        }
    }
}