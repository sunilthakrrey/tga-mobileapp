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
    public class NewsFeedResponseModel
    {
        public string status { get; set; }
        public List<NewsFeedResponseData> data { get; set; }
    }
    public class NewsFeedResponseData
    {
        public NewsFeed feed { get; set; }
        public NewsFeedStatus stat { get; set; }
        public string createdById { get; set; }
        [JsonIgnore]
        public bool IsfeebackLayoutVisible {
            get
            {
                if (feed.type == NewsFeedType.Event)
                {
                    return false;
                }
                else return true;
            }
        }

        //public async Task<KidDetail> GetKidDetailsFromStorage(string kidId)
        //{
        //    SecureStorageService secureStorageService = new SecureStorageService();
        //    Data userInfo = await secureStorageService.GetAsync<Data>(Enums.SecureStorageKey.AuthorizedUserInfo);
        //    KidDetail kidDetail = userInfo.parent.kids.Where(x => x.Id == kidId).FirstOrDefault();
        //    KidDetail.Size = ImageSize.Small;
        //    kidDetail.IsShowName = true;
        //    return kidDetail;

        //}
    }
    public class NewsFeed
    {
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string createdOn { get; set; }
        public NewsFeedType type { get; set; }
    }
    public class NewsFeedStatus
    {
        public int totalLikes { get; set; }
        public int totalComments { get; set; }


    }



}
