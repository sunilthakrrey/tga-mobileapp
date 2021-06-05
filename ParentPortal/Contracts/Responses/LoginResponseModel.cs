using ParentPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Contracts.Responses
{
    public class LoginResponseModel
    {
        public string status { get; set; }
        public string code { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
        public Data data { get; set; }

    }
    public class Data
    {
        public Parent parent { get; set; }
    }
    public class Parent
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<KidDetail> kids { get; set; }
    }
    
}
