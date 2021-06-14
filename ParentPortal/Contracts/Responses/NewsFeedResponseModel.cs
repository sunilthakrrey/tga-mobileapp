using Newtonsoft.Json;
using ParentPortal.Enums;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentPortal.Contracts.Responses
{
    public class NewsFeedResponseModel:BaseMultipleRecordResponse<NewsFeedResponseData>
    {
        //public string status { get; set; }
        //public List<NewsFeedResponseData> data { get; set; }
    }
    public class NewsFeedResponseData
    {
        public NewsFeed feed { get; set; }
        public NewsFeedStatus stat { get; set; }
        public string createdById { get; set; }
    }
    public class NewsFeed
    {
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string createdOn { get; set; }
        public Enums.TGA_Type type { get; set; }
    }
    public class NewsFeedStatus
    {
        public int totalLikes { get; set; }
        public int totalComments { get; set; }


    }



}
