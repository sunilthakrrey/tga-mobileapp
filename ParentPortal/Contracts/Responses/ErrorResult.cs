using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Contracts.Responses
{

    public class ErrorResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }

}
