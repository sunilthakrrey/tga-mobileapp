using Newtonsoft.Json;
using ParentPortal.Enums;
using ParentPortal.Extensions;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using ParentPortal.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentPortal.Contracts.Responses
{
    public class FeedResponseModel : BaseMultipleRecordResponse<FeedResponseData>
    {
    }

    public class FeedResponseData
    {
        public int kidIds { get; set; }
        public Feed feed { get; set; }
        public FeedStat stat { get; set; }
        public string createdById { get; set; }
    }

    public class Feed
    {
        BookMarkStorageService bookMarkStorageService = new BookMarkStorageService();
        [JsonProperty("feedid")]
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }

        [JsonProperty("createdOn")]
        public string createdOnAsString { get; set; }

        [JsonIgnore]
        public DateTime createdOn
        {
            get
            {
                return Convert.ToDateTime(createdOnAsString);
            }
        }

        public string Type { get; set; }

        [JsonIgnore]
        public Enums.TGA_Type TypeAsEnum
        {
            get
            {
                Enums.TGA_Type _typeAsEnum = Type.ParseToEnum<TGA_Type>();
                return _typeAsEnum;
            }
        }
        public string Activity { get; set; }
        public string TeachingTeam { get; set; }
        public string IntentionalTeaching { get; set; }

        public string IsBookMarked
        {
            get
            {
                bool retVal= bookMarkStorageService.IsExists(new Bookmark_Like_Model
                {
                    FeedId = Id,
                    Type = TypeAsEnum,
                    Module = Module.BookMark
                }).Result;
                return retVal.ToString();
            }
        }


        public string IsLiked
        {
            get
            {
                bool retVal = bookMarkStorageService.IsExists(new Bookmark_Like_Model
                {
                    FeedId = Id,
                    Type = TypeAsEnum,
                    Module = Module.Like
                }).Result;
                return retVal.ToString();
            }
        }

    }
    public class FeedStat
    {
        public int totalLikes { get; set; }
        public int totalComments { get; set; }


    }



}
