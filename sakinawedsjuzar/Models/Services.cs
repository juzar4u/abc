using sakinawedsjuzar.Models.AccountModel;
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

        public int insertComment(Comment model)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return (int)context.Insert(model);
            }
        }

        public int InsertContactUs(ContactUs model)
        {
            ContactUs contactUs = new ContactUs();
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                contactUs = model;
                return (int)context.Insert(contactUs);
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

        public int DeleteEvent(OurEvent model)
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


        public CommentList GetComments()
        {
            CommentList commentList = new CommentList();
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                commentList.ParentComments = context.Fetch<ParentCommentItem>("select * from Comments where ParentCommentID is null order by datetimenow desc");

                foreach (var item in commentList.ParentComments)
                {
                    item.childcomments = context.Fetch<CommentItem>("select * from Comments where ParentCommentID = @0 order by datetimenow desc", item.CommentID);
                }
            }
            return commentList;

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

        public OurEvent GetOurEventByID(int id)
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<OurEvent>("select * from OurEvents where OurEventID = @0", id).FirstOrDefault();
            }
        }

        public bool isCommentExist(string name, string content)
        {
            bool isExists = false;
            Comment comment = new Comment();
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                comment = context.Fetch<Comment>("select * from Comments where UserName = @0 and Content = @1", name, content).FirstOrDefault();
                if(comment == null)
                {
                    isExists = false;
                }
                else
                {
                    isExists = true;
                }
            }
            return isExists;
        }


        public UserModel GetUserModelByEmailID(string emailid)
        {
            UserModel user = new UserModel();
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                user = context.Fetch<UserModel>("select * from Users where Email = @0", emailid).FirstOrDefault();
            }

            return user;
        }


        public UserModel GetUserByEmailandPassword(string email, string password)
        {
            
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
               return context.Fetch<UserModel>("select * from Users where Email = @0 and Password = @1", email, password).FirstOrDefault();
            }
        }


    }
}