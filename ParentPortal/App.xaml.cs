using ParentPortal.Content.Styles;
using ParentPortal.Enums;
using ParentPortal.Modules.Auth.Login;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal
{
    public partial class App : Application
    {

        public static Theme AppTheme { get; set; }

        const int smallWidthResolution = 500;
        const int smallHeightResolution = 800;

        const int mediumWidthResolution = 1080;
        const int mediumHeightResolution = 1990;

        public static NavigationPage AppNavigation;
        public App()
        {
            InitializeComponent();
            LoadStyles();
            LoadTheme();
            MainPage = AppNavigation = new NavigationPage(new LoginPage());
        }

        public static void HandleError(Exception ex)
        {
            Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            LoadTheme();
        }

        void LoadStyles()
        {
            dictionary.MergedDictionaries.Add(CommonStyle.SharedInstance);

            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDeviceStyle.SharedInstance);
            }
            else if (IsAMediumDevice())
            {
                dictionary.MergedDictionaries.Add(MediumDeviceStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(LargeDeviceStyle.SharedInstance);
            }

        }

        void LoadTheme()
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            if (currentTheme == OSAppTheme.Dark)
            {
                dictionary.MergedDictionaries.Add(DarkThemeStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(LightThemeStyle.SharedInstance);
            }
        }

        public static bool IsAMediumDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= mediumWidthResolution && height <= mediumHeightResolution);
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWidthResolution && height <= smallHeightResolution);
        }

    }
}
