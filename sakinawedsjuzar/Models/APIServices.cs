using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models.APIModels.APIServices
{
    public class APIServices
    {
        private static APIServices _instace;

        public static APIServices GetInstance
        {
            get
            {
                if (_instace == null)
                {
                    _instace = new APIServices();
                }

                return _instace;
            }
        }
        public CommonInfoModel GetCommonInfo()
        {
            using (PetaPoco.Database context = new PetaPoco.Database("DefaultConnection"))
            {
                return context.Fetch<CommonInfoModel>("select * from CommonInfo where CommonInfoID = 1").FirstOrDefault();
            }
        }
    }

}