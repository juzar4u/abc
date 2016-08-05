using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sakinawedsjuzar.Models.APIModels
{
    public class CommonInfoModel
    {
        public int CommonInfoID { get; set; }
        public DateTime WeddingDate { get; set; }
        public string CouplePictureUrl { get; set; }
        public string CoupleInfo { get; set; }
        public string BrideFullName { get; set; }
        public string GroomFullName { get; set; }
        public string GiftRegistryContent { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public int GuestCount { get; set; }
        public int AttendCount { get; set; }
        public int BridesmaidCount { get; set; }
        public int GroomsmenCount { get; set; }
        public string AboutUs { get; set; }
        public string BridemaidsContent { get; set; }
        public string GroomsmenContent { get; set; }
        public string GiftRegistryImageUrl { get; set; }
        public string GoogleMapAddress { get; set; }
    }

    public class MyCustomData
    {
        public int Foo { get; set; }
        public string Bar { get; set; }
    }

   

}