using ParentPortal.Modules.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Modules.Auth.ForgotPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ResetPasswordButton_Clicked(object sender, EventArgs e)
        {
            //await App.AppNavigation.PushAsync(new LoginPage());
            await App.AppNavigation.PushAsync(new ForgotPasswordPopup());
        }
    }
}