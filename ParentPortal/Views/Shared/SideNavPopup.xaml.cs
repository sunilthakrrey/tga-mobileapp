using GalaSoft.MvvmLight.Command;
using ParentPortal.Enums;
using ParentPortal.Modules.Secure.ChangeOfAttendance;
using ParentPortal.Modules.Secure.ParentRequest.CasualDay;
using ParentPortal.Modules.Secure.ParentRequest.ChangeOfDetails;
using ParentPortal.Modules.Secure.ParentRequest.SendAppreciation;
using ParentPortal.Modules.Secure.ParentRequest.UpcomingAbsences;
using ParentPortal.Enums;
using ParentPortal.Modules.Auth.Login;
using ParentPortal.Services.TGA;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideNavPopup : PopupPage
    {
        SecureStorageService secureStorageService = new SecureStorageService();
        public SideNavPopup()
        {
            InitializeComponent();
        }
        public async void SignOutbtn_Tapped(object sender, EventArgs e)
        {
            await secureStorageService.RemoveAsync(SecureStorageKey.AuthorizedToken);
            await secureStorageService.RemoveAsync(SecureStorageKey.AuthorizedUserInfo);
            await secureStorageService.RemoveAsync(SecureStorageKey.SelectedKids);
            await secureStorageService.RemoveAsync(SecureStorageKey.AccountCredential);
            await PopupNavigation.Instance.PopAllAsync();
            await App.AppNavigation.PushAsync(new LoginPage());
        }

        private async void ChangeView_Tapped(object sender, System.EventArgs e)
        {
            Label label = (Label)sender;

            var item = (TapGestureRecognizer)label.GestureRecognizers[0];
            var parameters = item.CommandParameter;
            var viewType = (ViewType)parameters;
            await PopupNavigation.Instance.PopAllAsync();
            switch (viewType)
            {

                case ViewType.ChangeOfAttendance:
                    await App.AppNavigation.PushAsync(new MainPage() { ContentView = new ChangeOfAttendanceView() });
                    break;

                case ViewType.ChangeOfDetails:
                    await App.AppNavigation.PushAsync(new MainPage() { ContentView = new ChangeOfDetailsView() });
                    break;

                case ViewType.CasualDay:
                    await App.AppNavigation.PushAsync(new MainPage() { ContentView = new CasualDayView() });
                    break;

                case ViewType.UpcomingAbsences:
                    await App.AppNavigation.PushAsync(new MainPage() { ContentView = new UpcomingAbsencesView() });
                    break;

                case ViewType.SendAppreciation:
                    await App.AppNavigation.PushAsync(new MainPage() { ContentView = new SendAppreciationView() });
                    break;


            }
        }
    }

    internal class CasualDay : View
    {
    }
}