namespace ParentPortal.Config
{
    public class EndPoint
    {
        private static string baseURL = Gateway.ParentPortal;
        public static class Identity
        {
            public static string LOGIN = baseURL + "login";
            public static string FORGOT = "";
        }
    }
}
