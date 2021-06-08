using Newtonsoft.Json;
using ParentPortal.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParentPortal.Models
{
   public class KidDetail
    {
        public KidDetail()
        {
            IsShowImage = true;
            Size = PictureSize.Medium;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("avtar")]
        public string Avtaar { get; set; }
        
        [JsonIgnore]
        public bool IsShowName { get; set; }
        
        [JsonIgnore]
        public bool IsShowImage { get; set; }
        
        [JsonIgnore]
        public PictureSize Size { get; set; }
        
        [JsonIgnore]
        public Style FrameStyle
        {
            get
            {
                Style style = null;
                switch (Size)
                {

                    case PictureSize.Small:
                        style = (Style)Application.Current.Resources["ImageCircleFrameStyle"];
                        break;
                    case PictureSize.Medium:
                        style = (Style)Application.Current.Resources["ImageUserCircleStyle"];
                        break;
                    default:
                        break;
                }
                return style;
            }

        }

        [JsonIgnore]
        public Style ImageStyle
        {
            get
            {
                Style style = null;
                switch (Size)
                {

                    case PictureSize.Small:
                        style = (Style)Application.Current.Resources["ImageUserIconStyle"];
                        break;
                    case PictureSize.Medium:
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
