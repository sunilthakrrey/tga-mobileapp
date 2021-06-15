using ParentPortal.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Models
{
    public class Bookmark_Like_Model
    {
        public int FeedId { get; set; }
        public TGA_Type Type { get; set; }
        public Module Module { get; set; }

    }
}
