
using Newtonsoft.Json;
using ParentPortal.Enums;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ParentPortal.Models
{
    public class MyDayBoxComponenetModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Type { get; set; }
        public string NoOfMorningtea { get; set; }
        public string NoOfFruits { get; set; }
        public string NoOfWater { get; set; }
        public string NoOfBootles { get; set; }
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
        public KidDetail Kid { get; set; }

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

    }


    public class KidDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("avtar")]
        public ImageSource Avtaar { get; set; }
        [JsonIgnore]
        public bool IsShowName { get; set; }
        [JsonIgnore]
        public bool IsShowImage { get; set; }
        [JsonIgnore]
        public ImageSize Size { get; set; }
        public Style FrameStyle
        {
            get
            {
                Style style = null;
                switch (Size)
                {
                    
                    case ImageSize.Small:
                        style= (Style)Application.Current.Resources["ImageCircleFrameStyle"];
                        break;
                    case ImageSize.Large:
                        style = (Style)Application.Current.Resources["ImageUserCircleStyle"];
                        break;
                    default:
                        break;
                }
                return style;
            }
        
        }

        public Style ImageStyle
        {
            get
            {
                Style style = null;
                switch (Size)
                {

                    case ImageSize.Small:
                        style = (Style)Application.Current.Resources["ImageUserIconStyle"];
                        break;
                    case ImageSize.Large:
                        style = (Style)Application.Current.Resources["ImageUserPicStyle"];
                        break;
                    default:
                        break;
                }
                return style;
            }

        }

    }



}
