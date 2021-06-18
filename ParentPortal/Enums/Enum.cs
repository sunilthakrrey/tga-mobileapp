using System;
using System.Collections.Generic;
using System.Text;

namespace ParentPortal.Enums
{
    public enum Theme
    {
        Light,
        Dark
    }
    public enum MessageCenterAuthenticator
    {
        PageTitle,
        RequestStarted,
        RequestCompleted,
        NavigationBar,
        FeedFilter,
        CommentResponseCode
    }

    public enum Views
    {
        None,
        DashBoard
    }
   
    public enum SecureStorageKey
    {
       
        AuthorizedUserInfo,
        AccountCredential,
        AuthorizedToken,
        SelectedKids,
        ToolBarStorage
    }

    public enum ViewType
    {
        ChangeOfAttendance,
        ChangeOfDetails,
        CasualDay,
        UpcomingAbsences,
        SendAppreciation,

        RemoteLearning,
        Staff,
        Photos,
        Announcements,
        Settings,
        HelpAndFeedback
    }
    //public enum ImageSize
    public enum PictureSize
    {
        None,
        Small,
        Medium
    }

    public enum TGA_Type
    {
        None,
        Event,
       DailyChart,
        Wellness,
        Announcement,
        Grove_Curriculum,
        My_Day,
        //Daily_Chart,
        //Dailychart_Feed

    }
    public enum Module
    {
        None,
        BookMark,
        Like
    }
}
