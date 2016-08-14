using sakinawedsjuzar.Helper;
using sakinawedsjuzar.Models;
using sakinawedsjuzar.Models.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sakinawedsjuzar.Controllers
{
    public class WeddingController : Controller
    {
        //
        // GET: /Wedding/

        public ActionResult Index()
        {
            MasterModel model = new MasterModel();

            UserModel user = AuthHelper.LoginFromCookie();

            if (user != null)
            {
                model.isUserLoggedin = true;
            }
            model.loginModel = new Models.AccountModel.LoginModel();
            model.CommonInfo = Services.GetInstance.GetCommonInfo();
            model.MainSlideImages = Services.GetInstance.GetMainSliderImages();
            model.OurMemoriesPhotos = Services.GetInstance.GetImagesBySectionID(1);
            model.Bridesmaids = Services.GetInstance.GetImagesBySectionID(4);
            model.Groomsmens = Services.GetInstance.GetImagesBySectionID(5);
            model.lovestories = Services.GetInstance.GetLoveStories();
            model.events = Services.GetInstance.GetEvents();
            //model.comments = Services.GetInstance.GetComments();
            model.comments = Services.GetInstance.GetComments();
            return View(model);
        }

        public ActionResult LoveStories(MasterModel model)
        {

            return PartialView("~/Views/Shared/PartialLoveStoryTable.cshtml", model.lovestories);
        }
        public ActionResult Events(MasterModel model)
        {

            return PartialView("~/Views/Shared/PartialEventsTable.cshtml", model.events);
        }


        public ActionResult AddNewStory()
        {
            return PartialView("~/Views/Shared/PartialLoveStory.cshtml");
        }

        public ActionResult AddNewEvent()
        {
            return PartialView("~/Views/Shared/PartialEvents.cshtml");
        }

        public ActionResult AboutUsFooter()
        {
            CommonInfoModel model = Services.GetInstance.GetCommonInfo();
            return PartialView("~/Views/Shared/PartialAboutUS.cshtml", model);
        }

        public JsonResult UploadImageForCommonInfo(string imageData, string section)
        {
            string fileName = Guid.NewGuid().ToString();
            string url = "";
            string message = "";
            try
            {
                byte[] data = Convert.FromBase64String(imageData);
                System.IO.FileStream file = System.IO.File.Create(Server.MapPath("~/FileUpload/") + fileName + ".jpg");

                url = "/FileUpload/" + fileName + ".jpg";
                file.Write(data, 0, data.Length);
                file.Close();

                if (section == "6")
                {
                    EntityImage image = new EntityImage();

                    image.SectionID = 6;
                    image.Url = url;

                    Services.GetInstance.InsertEntityImage(image);
                }
                else if (section == "0couple")
                {
                    CommonInfo commonInfo = new CommonInfo();

                    commonInfo = Services.GetInstance.GetCommonInfoData();
                    commonInfo.CouplePictureUrl = url;

                    Services.GetInstance.UpdateCommonInfoData(commonInfo);

                }
                else if (section == "0gift")
                {
                    CommonInfo commonInfo = new CommonInfo();

                    commonInfo = Services.GetInstance.GetCommonInfoData();
                    commonInfo.GiftRegistryImageUrl = url;

                    Services.GetInstance.UpdateCommonInfoData(commonInfo);
                }
                else if (section == "1")
                {
                    EntityImage image = new EntityImage();

                    image.SectionID = 1;
                    image.Url = url;
                    image.thumbnail = url;

                    Services.GetInstance.InsertEntityImage(image);
                }

                else if (section == "4")
                {
                    EntityImage image = new EntityImage();

                    image.SectionID = 4;
                    image.thumbnail = url;

                    Services.GetInstance.InsertEntityImage(image);
                }
                else if (section == "5")
                {
                    EntityImage image = new EntityImage();

                    image.SectionID = 5;
                    image.thumbnail = url;

                    Services.GetInstance.InsertEntityImage(image);
                }

                message = "Image Uploaded Successfully!";
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UploadImageForLoveStory(string imageData)
        {
            string fileName = Guid.NewGuid().ToString();
            string url = "";
            string message = "";
            try
            {
                byte[] data = Convert.FromBase64String(imageData);
                System.IO.FileStream file = System.IO.File.Create(Server.MapPath("~/FileUpload/") + fileName + ".jpg");

                url = "/FileUpload/" + fileName + ".jpg";
                file.Write(data, 0, data.Length);
                file.Close();


            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }

            return Json(new { Message = message, ImageUrl = url }, JsonRequestBehavior.AllowGet);
        }
    }
}