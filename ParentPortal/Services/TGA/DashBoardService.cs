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
        Task<AnnouncementResponseModel> GetAnnounments(string kidsIds, Enums.Views page = Enums.Views.None);
        Task<FeedResponseModel> GetNewFeeedData(string kidsIds, string date = "today", string type = "all", Enums.Views page = Enums.Views.None);
        Task<MealChartResponseModel> GetMealData(string kidsIds, Enums.Views page = Enums.Views.None);
        Task<PollResponseModel> GetPollresponse(int campusId, int parentId, Enums.Views page = Enums.Views.None);
        Task<PostLikeResponseModel> AddLike(int post_id, string post_type, int like, Enums.Views page = Enums.Views.None);
    }
    public class DashBoardService : BaseHttpService, IDashBoardService
    {
        public async Task<AnnouncementResponseModel> GetAnnounments(string kidsIds, Enums.Views page = Enums.Views.None)
        {
            AnnouncementResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}", ConfigSettings.EndPoint.DashBoard.Announcements, kidsIds);
            retVal = await CreateHttpGETRequestAsync<AnnouncementResponseModel>(url, page: page);
            return retVal;
        }

        public async Task<FeedResponseModel> GetNewFeeedData(string kidsIds, string date = "today", string type = "all", Enums.Views page = Enums.Views.None)
        {
            //"1010286", "thismonth"
            FeedResponseModel retVal;
            string url = string.Format("{0}?kidIds={1}&date={2}&type={3}", ConfigSettings.EndPoint.DashBoard.NewsFeeds, kidsIds, date, type);
            retVal = await CreateHttpGETRequestAsync<FeedResponseModel>(url, page: page);
            return retVal;
        }

        public async Task<MealChartResponseModel> GetMealData(string kidsIds, Enums.Views page = Enums.Views.None)
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

        public async Task<PollResponseModel> GetPollresponse(int campusId, int parentId, Enums.Views page = Enums.Views.None)
        {
            PollResponseModel retVal;
            string url = string.Format("{0}?campusId={1}&parentId={2}", ConfigSettings.EndPoint.DashBoard.GetPoll, campusId, parentId);
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

        public async Task<PollResponseModel> AddPoll(int pollId, int parentId, string selectedOption, Enums.Views page = Enums.Views.None)
        {
            PollResponseModel retVal;
            string url = string.Format("{0}?pollId={1}&parentId={2}&selected={3}", ConfigSettings.EndPoint.DashBoard.AddPoll, pollId, parentId, selectedOption);
            retVal = await CreatHttpPOSTRequestAsync<PollResponseModel>(url, page: page);
            return retVal;
        }

        public async Task<PostLikeResponseModel> AddLike(int post_id, string post_type, int like, Enums.Views page = Enums.Views.None)
        {
            PostLikeResponseModel retVal;
            string url = string.Format("{0}?post_id={1}&post_type={2}&like={3}", ConfigSettings.EndPoint.DashBoard.Like, post_id, post_type, like);
            retVal = await CreatHttpPOSTRequestAsync<PostLikeResponseModel>(url, page: page);
            return retVal;
        }

        public async Task<PostCommentResponseModel> AddComment(int user_id, int comment_post_ID, string comment_content, Enums.Views page = Enums.Views.None)
        {
            PostCommentResponseModel retVal;
            string url = string.Format("{0}?user_id={1}&comment_post_ID={2}&comment_content={3}", ConfigSettings.EndPoint.DashBoard.Comment, user_id, comment_post_ID, comment_content);
            retVal = await CreateHttpGETRequestAsync<PostCommentResponseModel>(url, page: page);
            return retVal;
        }




    }
}
