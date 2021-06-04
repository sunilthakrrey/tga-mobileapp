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
        NavigationBar
    }

    public enum Page
    {
        None
    }

    public enum SecureStorageKey
    {
       
        AuthorizedUserInfo,
        AccountCredential,
        AuthorizedToken
    }
}
