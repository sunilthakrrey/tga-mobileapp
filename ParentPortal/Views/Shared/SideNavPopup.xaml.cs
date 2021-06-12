using ParentPortal.Enums;
using ParentPortal.Modules.Auth.Login;
using ParentPortal.Services.TGA;
using Rg.Plugins.Popup.Pages;
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
    }
}