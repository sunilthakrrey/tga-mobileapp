

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ParentPortal.Contracts.Responses
{
    public class AnnouncementResponseModel
    {
        public string status { get; set; }
        public  List<AnnouncementData> data { get; set; }
    }
    public class AnnouncementData
    {
        public string id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        [JsonIgnore]
        public DateTime ConvertedIntoDate
        {
            get
            {
              return  Convert.ToDateTime(date);
            }
        }
    }
}
