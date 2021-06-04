using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParentPortal.Models
{
    public class NewsFeedBoxComponentModel
    {
        public ImageSource BackGroundImage { get; set; }
        public string Title { get; set; }
        public ImageSource Image { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public FeedBackComponentModel FeedBackComponentModel { get; set; }
    }
}
