using RequestModel = ParentPortal.Contracts.Requests;
using ResponseModel = ParentPortal.Contracts.Responses;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using ParentPortal.Helpers;
using ParentPortal.Services.TGA;
using Storage = ParentPortal.Storage;
using System.Threading.Tasks;
using ParentPortal.Enums;
using static ParentPortal.Config.Constant;
using ParentPortal.Modules.Secure.Dashboard;
using static ParentPortal.Config.SecureStorage;
using ParentPortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParentPortal.Modules.Auth.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        #region Data Members
        private View _View;
        IdentityService identityService = new IdentityService();
        Storage.AccountCredentialStorage accountCredentialStorage = new Storage.AccountCredentialStorage();
        SecureStorageService secureStorageService = new SecureStorageService();

        #endregion

        #region Properties

        private RequestModel.LoginRequestModel _loginRequestModel = new RequestModel.LoginRequestModel();
        public RequestModel.LoginRequestModel LoginRequestModel
        {
            get { return _loginRequestModel; }
            set
            {
                _loginRequestModel = value;
                OnPropertyChanged("LoginRequestModel");
            }
        }
        #endregion

        #region Ctor
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        #endregion
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            LoginRequestModel_StackError.IsVisible = false;
            _View = this.Content;
            if (!ValidationHelper.IsFormValid(LoginRequestModel))
            {
                LoginRequestModel_Error.Text = ValidationMesages.LoginErrorMessage;
                LoginRequestModel_StackError.IsVisible = true;
                return;
            }
             ResponseModel.LoginResponseModel loginResponseModel =   await identityService.LoginAsync(LoginRequestModel);

            //add credentials to storage
            await AddCredentialsToStorageAsync();

            //add Authrize token To storage
            await secureStorageService.SaveAsync(SecureStorageKey.AuthorizedToken, new AuthorizedToken { Token = loginResponseModel.token, RefreshToken = loginResponseModel.refreshToken });

            //  save user info into storage
            bool isAuthorizedInfoSaved = await secureStorageService.SaveAsync(SecureStorageKey.AuthorizedUserInfo, loginResponseModel.data);

            //save SelectedKid in Storage

            await secureStorageService.SaveAsync(SecureStorageKey.SelectedKids, new List<KidDetail>
           {
              loginResponseModel.data.parent.kids.FirstOrDefault()
           }) ;
            await App.AppNavigation.PushAsync(new MainPage() { ContentView = new DashboardView() });

        }

        private async void ForgotPasswordButton_Clicked(object sender, EventArgs e)
        {
            await App.AppNavigation.PushAsync(new ForgotPassword.ForgotPasswordPage());
        }


        private async Task AddCredentialsToStorageAsync()
        {

            if (LoginRequestModel.RememberMe)
            {
                await accountCredentialStorage.SaveCredential(LoginRequestModel);
            }
            else
            {
                await secureStorageService.RemoveAsync(SecureStorageKey.AccountCredential);
            }

        }
       


    }
}