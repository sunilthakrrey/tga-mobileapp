using ParentPortal.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Models
{
    public class ToolStorageModel
    {
        public int id { get; set; }
        public TGA_Type Type { get; set; }
        public Module Module { get; set; }

    }
}
