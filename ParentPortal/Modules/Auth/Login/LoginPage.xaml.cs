using GalaSoft.MvvmLight.Command;
using ParentPortal.Modules.Auth.ForgotPassword;
using ParentPortal.Modules.Secure.Dashboard;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Modules.Auth.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }


        private RelayCommand _loadForgotPasswordPage;

        public RelayCommand LoadForgotPasswordPage
        {
            get
            {
                return _loadForgotPasswordPage ?? (_loadForgotPasswordPage = new RelayCommand(async () =>
                {
                    await App.AppNavigation.PushAsync(new ForgotPasswordPage());
                }));
            }
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await App.AppNavigation.PushAsync(new MainPage() { ContentView = new DashboardView() });
        }

    }
}