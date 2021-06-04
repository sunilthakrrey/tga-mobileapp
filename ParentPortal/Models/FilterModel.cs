using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public List<string> Options { get; set; }
    }

    
    public class Options
    {
        public string Name { get; set; }
    }
}
