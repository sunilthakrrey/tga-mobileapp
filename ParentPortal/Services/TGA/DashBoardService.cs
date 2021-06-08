using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;
using System.Threading.Tasks;
using ConfigSettings = ParentPortal.Config;
using System.Collections.Generic;
using System;

namespace ParentPortal.Services.TGA
{

    public interface IDashBoardService
    {
        Task<AnnouncementResponseModel> GetAnnounments(string kidsIds, Enums.Page page = Enums.Page.None);
        Task<NewsFeedResponseModel> GetNewFeeedData(string kidsIds, Enums.Page page = Enums.Page.None);
        Task<MealOfTheDayResponseModel> GetMealData(string kidsIds, Enums.Page page = Enums.Page.None);
    }
    public class DashBoardService : BaseHttpService, IDashBoardService
    {
        public async Task<AnnouncementResponseModel> GetAnnounments(string kidsIds, Page page = Page.None)
        {
            AnnouncementResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}", ConfigSettings.EndPoint.DashBoard.Announcements, kidsIds);
            //   retVal = await CreateHttpGETRequestAsync<List<AnnouncementResponseModel>>(url, page: page);
            retVal = new AnnouncementResponseModel
            {
                status = "200",
                data = new List<AnnouncementData>
                {
                    new AnnouncementData
                    {
                        id="1",
                        date=DateTime.UtcNow.ToString(),
                        title="Sarah' Speech Tips:Sound Prouduction",
                        time="10:35 am"
                    },
                    new AnnouncementData
                    {
                        date=DateTime.UtcNow.ToString(),
                        title="Sarah' Speech Tips:Sound Prouduction",
                        time="10:35 am"
                    }
                }

            };
            return retVal;
        }

        public async Task<NewsFeedResponseModel> GetNewFeeedData(string kidsIds, Page page = Page.None)
        {
            var date = new System.DateTime(2021, 3, 3, 11, 30, 00);
            NewsFeedResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}&date={1}&type={2},", ConfigSettings.EndPoint.DashBoard.Announcements, kidsIds, DateTime.UtcNow, NewsFeedType.Wellness);
            //   retVal = await CreateHttpGETRequestAsync<List<AnnouncementResponseModel>>(url, page: page);
            retVal = new NewsFeedResponseModel
            {
                status = "success",
                data = new List<NewsFeedResponseData>
                {
                    new NewsFeedResponseData
                    {
                        createdById = "993182",
                        feed= new NewsFeed
                        {
                           imageUrl = "https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg",
                           createdOn= date.ToString("dd MMMM yyyy, hh:mm"),
                           title = "WaterPlay In The Yard",
                           description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Porta egestas aenean viverra molestie non.",
                           type = NewsFeedType.Wellness,
                        },
                        stat= new NewsFeedStatus
                        {
                            totalLikes = 7,
                            totalComments=21
                        }
                    },
                       new NewsFeedResponseData
                    {
                        createdById = "607667",
                        feed= new NewsFeed
                        {
                           imageUrl = "https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg",
                           createdOn= date.ToString("dd MMMM yyyy, hh:mm"),
                           title = "Yoga With Gina",
                           description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Porta egestas aenean viverra molestie non.",
                           type = NewsFeedType.Event,
                        },
                        stat= new NewsFeedStatus
                        {
                            totalLikes = 7,
                            totalComments=21
                        }
                    }
                }
            };
            return retVal;
        }

        public async Task<MealOfTheDayResponseModel> GetMealData(string kidsIds, Page page = Page.None)
        {
            var date = new System.DateTime(2021, 3, 3, 11, 30, 00);
            MealOfTheDayResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}&date={1}&type={2},", ConfigSettings.EndPoint.DashBoard.Announcements, kidsIds, DateTime.UtcNow, NewsFeedType.Wellness);
            //   retVal = await CreateHttpGETRequestAsync<List<AnnouncementResponseModel>>(url, page: page);
            retVal = new MealOfTheDayResponseModel
            {
                status = "success",
                data = new List<MealData>
                {
                    new MealData
                    {
                        title = "Morning Tea",
                        description = "Toast with Jam",
                        NoOfMorningtea = 1.ToString(),
                        NoOfFruits = 2.ToString(),
                        NoOfWater = 3.ToString(),
                        NoOfBootles = 2.ToString(),
                        createdById="993182"
                    },
                    new MealData
                    {
                        title = "Morning Tea",
                        description = "Toast with Jam",
                        NoOfMorningtea = 1.ToString(),
                        NoOfFruits = 2.ToString(),
                        NoOfWater = 3.ToString(),
                        NoOfBootles = 2.ToString(),
                         createdById="993182"
                    }
                }
            };
            return retVal;
        }

       
    }
}
