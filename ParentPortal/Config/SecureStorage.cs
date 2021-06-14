using ParentPortal.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Config
{
    public class SecureStorage
    {
        public class AuthorizedToken
        {
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }

        //public class AuthorizedInfo
        //{
        //    public Parent parent { get; set; }
        //}

    }
}
