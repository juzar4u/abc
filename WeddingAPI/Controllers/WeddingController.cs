
using sakinawedsjuzar.Models.APIModels;
using sakinawedsjuzar.Models.APIModels.APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WeddingAPI.Controllers
{
    public class WeddingController : ApiController
    {
        // GET: Wedding

        [System.Web.Http.HttpGet]
        public CommonInfoModel Index()
        {
            CommonInfoModel model = APIServices.GetInstance.GetCommonInfo();

            return model;
        }
    }
}