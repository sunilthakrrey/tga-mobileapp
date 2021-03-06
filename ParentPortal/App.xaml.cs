using ParentPortal.Content.Styles;
using ParentPortal.Contracts.Requests;
using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;
using ParentPortal.Modules.Auth.Login;
using ParentPortal.Modules.Secure.Dashboard;
using ParentPortal.Services.TGA;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal
{
    public partial class App : Application
    {

        Storage.AccountCredentialStorage accountCredentialStorage = new Storage.AccountCredentialStorage();
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


            MainPage = AppNavigation = new NavigationPage(new MainPage(isNeedToListnerConfigured: true));

            //Login through following credentials
            LoginRequestModel loginRequestModel = accountCredentialStorage.GetAsync<LoginRequestModel>(SecureStorageKey.AccountCredential).Result;
            if (loginRequestModel != null)
            {
                RedirectToDashboard(loginRequestModel);
            }
            else
            {
                MainPage = AppNavigation = new NavigationPage(new LoginPage());
            }

        }

        public static void HandleError(Exception ex)
        {
            Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }


        protected override void OnStart()
        {

        }
        private async void RedirectToDashboard(LoginRequestModel loginRequestModel)
        {
            IdentityService identityService = new IdentityService();
            LoginResponseModel responseModel = await identityService.LoginAsync(loginRequestModel);
            if (responseModel.code == "200")
                await App.AppNavigation.PushAsync(new MainPage() { ContentView = new DashboardView() });
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

    }
}
