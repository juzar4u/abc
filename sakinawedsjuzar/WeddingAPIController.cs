using Newtonsoft.Json.Linq;
using sakinawedsjuzar.Models;
using sakinawedsjuzar.Models.CommentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace sakinawedsjuzar
{
    public class WeddingAPIController : ApiController
    {
        //
        // GET: /WeddingAPI/

        public CommonInfoModel GetCommonInfo()
        {
            CommonInfoModel model = Services.GetInstance.GetCommonInfo();
            model.StringWeddingDate = model.WeddingDate.ToString("yyyy-MM-dd");
            return model;
        }

        public List<EntityImage> GetImagesBySectionID(int sectionID)
        {
            List<EntityImage> images = new List<EntityImage>();
            images = Services.GetInstance.GetImagesBySectionID(sectionID);
            return images;
        }

        public EntityCollectionModel GetCollectionEntityImages()
        {
            EntityCollectionModel entities = new EntityCollectionModel();

            entities.OurMemoriesImages = GetImagesBySectionID(1);
            entities.BridesmaidImages = GetImagesBySectionID(4);
            entities.GroomsmenImages = GetImagesBySectionID(5);
            entities.MainSliderImages = GetImagesBySectionID(6);

            return entities;
        }

        public HttpResponseMessage PostCommonInfo([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                CommonInfo model = Services.GetInstance.GetCommonInfoData();

                var jObj = (JObject)data;
                if (jObj["AboutUs"].Value<string>() != null || !string.IsNullOrEmpty(jObj["AboutUs"].Value<string>()))
                    model.AboutUs = jObj["AboutUs"].Value<string>();

                if (jObj["Address"].Value<string>() != null || !string.IsNullOrEmpty(jObj["Address"].Value<string>()))
                    model.Address = jObj["Address"].Value<string>();

                if (jObj["AttendCount"].Value<int>() > 0)
                    model.AttendCount = jObj["AttendCount"].Value<int>();

                if (jObj["BrideFullName"].Value<string>() != null || !string.IsNullOrEmpty(jObj["BrideFullName"].Value<string>()))
                    model.BrideFullName = jObj["BrideFullName"].Value<string>();

                if (jObj["BridemaidsContent"].Value<string>() != null || !string.IsNullOrEmpty(jObj["BridemaidsContent"].Value<string>()))
                    model.BridemaidsContent = jObj["BridemaidsContent"].Value<string>();

                if (jObj["BridesmaidCount"].Value<string>() != null || !string.IsNullOrEmpty(jObj["BridesmaidCount"].Value<string>()))
                    model.BridesmaidCount = jObj["BridesmaidCount"].Value<int>();

                if (jObj["ContactInfo"].Value<string>() != null || !string.IsNullOrEmpty(jObj["ContactInfo"].Value<string>()))
                    model.ContactInfo = jObj["ContactInfo"].Value<string>();

                if (jObj["CoupleInfo"].Value<string>() != null || !string.IsNullOrEmpty(jObj["CoupleInfo"].Value<string>()))
                    model.CoupleInfo = jObj["CoupleInfo"].Value<string>();

                if (jObj["GiftRegistryContent"].Value<string>() != null || !string.IsNullOrEmpty(jObj["GiftRegistryContent"].Value<string>()))
                    model.GiftRegistryContent = jObj["GiftRegistryContent"].Value<string>();

                if (jObj["GoogleMapAddress"].Value<string>() != null || !string.IsNullOrEmpty(jObj["GoogleMapAddress"].Value<string>()))
                    model.GoogleMapAddress = jObj["GoogleMapAddress"].Value<string>();

                if (jObj["GroomFullName"].Value<string>() != null || !string.IsNullOrEmpty(jObj["GroomFullName"].Value<string>()))
                    model.GroomFullName = jObj["GroomFullName"].Value<string>();

                if (jObj["GroomsmenContent"].Value<string>() != null || !string.IsNullOrEmpty(jObj["GroomsmenContent"].Value<string>()))
                    model.GroomsmenContent = jObj["GroomsmenContent"].Value<string>();

                if (jObj["GroomsmenCount"].Value<int>() > 0)
                    model.GroomsmenCount = jObj["GroomsmenCount"].Value<int>();

                if (jObj["GuestCount"].Value<int>() > 0)
                    model.GuestCount = jObj["GuestCount"].Value<int>();

                if (jObj["WeddingDate"].Value<DateTime>() != null)
                    model.WeddingDate = jObj["WeddingDate"].Value<DateTime>();
                model.CommonInfoID = 1;


                Services.GetInstance.UpdateCommonInfoData(model);

                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Data has been updated successfully!" });
            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }


        public HttpResponseMessage PostNewLoveStory([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                OurLoveStory model = new OurLoveStory();
                EntityImage image = new EntityImage();
                var jObj = (JObject)data;

                model.Title1 = jObj["Title1"].Value<string>();
                model.Title2 = jObj["Title2"].Value<string>();
                model.Content = jObj["Content"].Value<string>();
                model.CommentBy = jObj["CommentBy"].Value<string>();
                model.PublishDate = jObj["PublishDate"].Value<string>();
                model.SpecialComment = jObj["SpecialComment"].Value<string>();
                model.TemplateId = jObj["TemplateId"].Value<int>();
                //model.ImageUrl = jObj["ImageUrl"].Value<string>();
                model.OurStoryID = Services.GetInstance.InsertLoveStory(model);
                image.EntityID = model.OurStoryID;
                image.SectionID = 3;
                image.Url = jObj["ImageUrl"].Value<string>();
                Services.GetInstance.InsertEntityImage(image);
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Data has been Posted successfully!" });
            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return response;
        }


        public HttpResponseMessage PostNewEvent([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;

            try
            {
                OurEvent model = new OurEvent();

                var jObj = (JObject)data;

                model.Title = jObj["Title"].Value<string>();
                model.EventLocation = jObj["EventLocation"].Value<string>();
                model.EventContent = jObj["EventContent"].Value<string>();
                string urlcollection = jObj["eventImageUrl"].Value<string>();
                string[] values = urlcollection.Split(',').Select(sValue => sValue.Trim()).ToArray();
                model.OurEventID = Services.GetInstance.InsertOurEvent(model);
                foreach (var item in values)
                {
                    EntityImage img = new EntityImage();
                    img.EntityID = model.OurEventID;
                    img.SectionID = 2;
                    img.Url = item;

                    Services.GetInstance.InsertEntityImage(img);

                }
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Data has been Posted successfully!" });

            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        public HttpResponseMessage PostDeleteImage([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                EntityImage image = new EntityImage();
                var jObj = (JObject)data;

                image = Services.GetInstance.GetEntityImageByImageID(jObj["EntityImageID"].Value<int>());

                Services.GetInstance.DeleteEntityImage(image);
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Image has been Deleted Successfully!", ImageID = image.EntityImageID });

            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        public HttpResponseMessage PostDeleteLoveStory([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                OurLoveStory story = new OurLoveStory();
                var jObj = (JObject)data;

                story = Services.GetInstance.GetLoveStoryByLoveStoryID(jObj["OurStoryID"].Value<int>());

                Services.GetInstance.DeleteLoveStory(story);
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Image has been Deleted Successfully!", storyID = story.OurStoryID });

            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        public HttpResponseMessage PostDeleteEvent([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                OurEvent events = new OurEvent();
                var jObj = (JObject)data;

                events = Services.GetInstance.GetOurEventByID(jObj["EventID"].Value<int>());

                Services.GetInstance.DeleteEvent(events);
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Image has been Deleted Successfully!", eventid = events.OurEventID });

            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }



        public HttpResponseMessage PostComment([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                Comment comment = new Comment();
                var jObj = (JObject)data;

                comment.UserName = jObj["Username"].Value<string>();
                comment.Content = jObj["Comment"].Value<string>();
                Services.GetInstance.insertComment(comment);
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Comment has been Posted Successfully!" });
            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return response;
        }

        public HttpResponseMessage PostReplyComment([FromBody]dynamic data)
        {
            HttpResponseMessage response = null;
            try
            {
                Comment comment = new Comment();
                var jObj = (JObject)data;
                
                comment.UserName = jObj["Username"].Value<string>();
                comment.Content = jObj["Comment"].Value<string>();
                comment.ParentCommentID = jObj["ParentCommentID"].Value<int>();
                Services.GetInstance.insertComment(comment);
                response = this.Request.CreateResponse(HttpStatusCode.Created, new { Created = 200, Message = "Comment has been Posted Successfully!" });
            }
            catch (Exception ex)
            {
                response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return response;
        }


        public CommentList GetComments()
        {
            CommentList comment = new CommentList();
            comment.ParentComments = Services.GetInstance.GetComments();

            return comment;
        }
        
    }
}
