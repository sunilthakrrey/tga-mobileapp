using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Contracts.Responses
{
    public class BaseMultipleRecordResponse<T> where T : class
    {
        public string status { get; set; }
        public List<T> data { get; set; }
        public bool IsRecordExist
        {
            get
            {
                return data != null;
            }
        }
    }
}
