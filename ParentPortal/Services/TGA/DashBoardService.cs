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
        Task<MealChartResponseModel> GetMealData(string kidsIds, Enums.Page page = Enums.Page.None);
        Task<PollResponseModel> GetPollresponse(int campusId, int parentId, Page page = Page.None);
    }
    public class DashBoardService : BaseHttpService, IDashBoardService
    {
        public async Task<AnnouncementResponseModel> GetAnnounments(string kidsIds, Page page = Page.None)
        {
            AnnouncementResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}", ConfigSettings.EndPoint.DashBoard.Announcements, kidsIds);
            retVal = await CreateHttpGETRequestAsync<AnnouncementResponseModel>(url, page: page);
            //retVal = new AnnouncementResponseModel
            //{
            //    status = "200",
            //    data = new List<AnnouncementData>
            //    {
            //        new AnnouncementData
            //        {
            //            id="1",
            //            date=DateTime.UtcNow.ToString(),
            //            title="Sarah' Speech Tips:Sound Prouduction",
            //            time="10:35 am"
            //        },
            //        new AnnouncementData
            //        {
            //            date=DateTime.UtcNow.ToString(),
            //            title="Sarah' Speech Tips:Sound Prouduction",
            //            time="10:35 am"
            //        }
            //    }

            //};
            return retVal;
        }

        public async Task<NewsFeedResponseModel> GetNewFeeedData(string kidsIds, Page page = Page.None)
        {
            var date = new System.DateTime(2021, 3, 3, 11, 30, 00);
            NewsFeedResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}&date=today&type=all", ConfigSettings.EndPoint.DashBoard.NewsFeeds, kidsIds, DateTime.UtcNow.ToString("MMMM dd, yyyyy"), Enums.TGA_Type.Wellness);
            // retVal = await CreateHttpGETRequestAsync<NewsFeedResponseModel>(url, page: page);
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
                           type = Enums.TGA_Type.Wellness,
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
                           type = Enums.TGA_Type.Event,
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

        public async Task<MealChartResponseModel> GetMealData(string kidsIds, Page page = Page.None)
        {
            var date = new System.DateTime(2021, 3, 3, 11, 30, 00);
            MealChartResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}&date={2}", ConfigSettings.EndPoint.DashBoard.MealChart, kidsIds, DateTime.UtcNow.ToString("MMMM dd, yyyy"));
            //  retVal = await CreateHttpGETRequestAsync<MealChartResponseModel>(url, page: page);
            retVal = new MealChartResponseModel
            {
                status = "success",
                data = new List<MealChartData>
                {
                    new MealChartData
                    {
                        title = "Morning Tea",
                        description = "Toast with Jam",
                        NoOfMorningtea = "No Thank You",
                        NoOfFruits = 2.ToString(),
                        NoOfWater = 3.ToString(),
                        NoOfBootles = 2.ToString(),
                        createdById="993182"
                    },
                    new MealChartData
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

        public async Task<PollResponseModel> GetPollresponse(int campusId,int parentId, Page page = Page.None)
        {
            PollResponseModel retVal;
            string url = string.Format("{0}?campusId={1}&parentId={2}", ConfigSettings.EndPoint.DashBoard.Poll, campusId,parentId);
             retVal = await CreateHttpGETRequestAsync<PollResponseModel>(url, page: page);
            //retVal = new PollResponseModel
            //{
            //    Status = "success",
            //    PollDataCollection = new List<PollData>
            //    {
            //        new PollData
            //        {
            //           Question="Do you currently follow us on social media?",
            //           id=862181,
            //            Options= new List<PollOption>
            //            {
            //                new PollOption
            //                {
            //                  Name="Facebook",
            //                  Id=64,
            //                },
            //                new PollOption
            //                {
            //                  Name="Instagram",
            //                  Id=65,
            //                },
            //                new PollOption
            //                {
            //                  Name="Neither",
            //                  Id=68,
            //                },
            //                new PollOption
            //                {
            //                  Name="Both",
            //                  Id=73,
            //                }
            //            },
            //            Selected="Neither"
            //        },
            //        new PollData
            //        {
            //           Question="Do you currently follow us on social media?",
            //           id=862182,
            //            Options= new List<PollOption>
            //            {
            //                new PollOption
            //                {
            //                  Name="Facebook",
            //                  Id=64,
            //                },
            //                new PollOption
            //                {
            //                  Name="Instagram",
            //                  Id=65,
            //                },
            //                new PollOption
            //                {
            //                  Name="Neither",
            //                  Id=68,
            //                },
            //                new PollOption
            //                {
            //                  Name="Both",
            //                  Id=73,
            //                }
            //            },
            //            Selected="Both"
            //        }

            //    }
            //};
            return retVal;
        }
    }
}
