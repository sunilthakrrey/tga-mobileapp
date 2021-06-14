using GalaSoft.MvvmLight.Command;
using ParentPortal.Enums;
using ParentPortal.Modules.Secure.ChangeOfAttendance;
using ParentPortal.Modules.Secure.ParentRequest.CasualDay;
using ParentPortal.Modules.Secure.ParentRequest.ChangeOfDetails;
using ParentPortal.Modules.Secure.ParentRequest.SendAppreciation;
using ParentPortal.Modules.Secure.ParentRequest.UpcomingAbsences;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideNavPopup : PopupPage
    {
        public SideNavPopup()
        {
            InitializeComponent();
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