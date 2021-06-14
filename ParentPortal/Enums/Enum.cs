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
        FeedFilter
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
        SendAppreciation
    }
    //public enum ImageSize
    public enum PictureSize
    { 
        Small,
        Medium,
        None
    }

    public enum TGA_Type
    {
        Event,
        DailyChart,
        Wellness,
        Announcement,
        None
    }
    public enum Module
    {
        BookMark,
        Like
    }
}
