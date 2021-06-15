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
        public static class DashBoard
        {
            public static string Announcements = baseURL + "kid/latest-annoucement";
            public static string NewsFeeds = baseURL + "kid/new-feeds";
            public static string MealChart = baseURL + "kid/food";
            public static string GetPoll = baseURL + "poll/getAll";
            public static string AddPoll = baseURL + "poll/add";
            public static string Like = baseURL + "like/add";
            public static string Comment = baseURL + "feed/addComment";
        }
    }
}
