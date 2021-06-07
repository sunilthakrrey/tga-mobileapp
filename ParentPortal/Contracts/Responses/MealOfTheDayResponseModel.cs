using Newtonsoft.Json;
using ParentPortal.Enums;
using ParentPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Contracts.Responses
{
    public class MealOfTheDayResponseModel
    {
        public string status { get; set; }
        public List<MealData> data { get; set; }
    }
    public class MealData
    {
        public string title { get; set; }
        public string description { get; set; }
        [JsonIgnore]
        public NewsFeedType Type { get; set; } = NewsFeedType.DailyChart;
        public string NoOfMorningtea { get; set; }
        public string NoOfFruits { get; set; }
        public string NoOfWater { get; set; }
        public string NoOfBootles { get; set; }
        public string createdById { get; set; }
        public List<int> MorningTea
        {
            get
            {
                return GetList(NoOfMorningtea);
            }
        }
        public List<int> Fruits
        {
            get
            {
                return GetList(NoOfFruits);
            }
        }
        public List<int> WaterIntake
        {
            get
            {
                return GetList(NoOfWater);
            }
        }
        public List<int> Bottles
        {
            get
            {
                return GetList(NoOfBootles);
            }
        }
        public List<int> GetList(string count)
        {
            List<int> retval = new List<int> { };
            int result;

            if (int.TryParse(count, out result))
            {
                for (int index = 0; index <= result - 1; index++)
                {
                    retval.Add(index);
                }
            }

            return retval;
        }
        [JsonIgnore]
        public KidDetail KidDetail { get; set; }
    }
}
