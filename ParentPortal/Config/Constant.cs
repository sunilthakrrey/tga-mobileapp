namespace ParentPortal.Config
{
    public static class Constant
    {
        public class RequestMethod
        {
            public static string Get = "GET";
            public static string Post = "POST";
        }

        public class ContentType
        {
            public static string Json = "application/json";
            public static string FormUrlencoded = "application/x-www-form-urlencoded";
        }

        public class HeaderKey
        {
            public static string Authorization = "Authorization";
        }

        public class HeaderValue
        {
            public static string AuthorizationKey = "";
        }
        public class ValidationMesages
        {
            public static string LoginErrorMessage = "ERROR: Invalid credentials, please try again. If you have forgotten your password";
        }
    }
}
