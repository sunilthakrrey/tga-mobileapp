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
        Task<List<AnnouncementResponseModel>> GetAnnounments(string kidsIds, Enums.Page page = Enums.Page.None);
    }
    public class DashBoardService :BaseHttpService, IDashBoardService
    {
        public async Task<List<AnnouncementResponseModel>> GetAnnounments(string kidsIds, Page page = Page.None)
        {
            List <AnnouncementResponseModel> retVal;
            string url = string.Format("{0}?kidIds={1}", ConfigSettings.EndPoint.DashBoard.Announcements, kidsIds);
          //   retVal = await CreateHttpGETRequestAsync<List<AnnouncementResponseModel>>(url, page: page);

            retVal = new List<AnnouncementResponseModel>
            {
                new AnnouncementResponseModel
                {
                    status="200",
                    data = new AnnouncementData
                    {
                        date=DateTime.UtcNow,
                        title="Sarah' Speech Tips:Sound Prouduction",
                        time="10:35 am"
                    }
                },
                 new AnnouncementResponseModel
                {
                    status="200",
                    data = new AnnouncementData
                    {
                        date=DateTime.UtcNow,
                        title="Sarah' Speech Tips:Sound Prouduction",
                        time="10:35 am"
                    }
                }
            };
            return retVal;
        }
    }
}
