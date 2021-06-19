using Newtonsoft.Json;
using ParentPortal.Enums;
using ParentPortal.Extensions;
using ParentPortal.Models;
using ParentPortal.Storage;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParentPortal.Contracts.Responses
{
    public class FeedResponseModel : BaseMultipleRecordResponse<FeedResponseData>
    {
    }

    public class FeedResponseData
    {
        public int? kidIds { get; set; }
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
        public string ShortDescription { get; set; }
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

       
        public string Strengths { get; set; }
        public string Interests { get; set; }
        public string DevelopmentAreas { get; set; }
        public string ShortTermGoals { get; set; }
        public string StartDate { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public string EndDate { get; set; }

    }
    public class FeedStat : INotifyPropertyChanged
    {
        private int _totallikes;
        public int totalLikes 
        {
            get
            {
                return _totallikes;
            }
            set
            {
                _totallikes = value;
                OnPropertyChanged(nameof(totalLikes));
            }
        }
        private int _totalComments;
        public int totalComments 
        {
            get
            {
                return _totalComments;
            }
            set
            {
                _totalComments = value;
                OnPropertyChanged(nameof(totalComments));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
