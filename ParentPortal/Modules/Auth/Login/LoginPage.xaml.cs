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
                _loginRequestModel = value ;
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

        private  void LoginBtn_ClickedAsync(object sender, EventArgs e)
        {

            _View = this.Content;   
            if (!ValidationHelper.IsFormValid(LoginRequestModel, _View))
            {
                return;
            }
         // ResponseModel.LoginResponseModel loginResponseModel =   await identityService.LoginAsync(LoginRequestModel);


            //if rememberme checked then add credentials to storage
            if(LoginRequestModel.RememberMe)
            {
                //add credentials to storage
            }
        }

        private async void ForgotPasswordButton_Clicked(object sender, EventArgs e)
        {
            await App.AppNavigation.PushAsync(new ForgotPassword.ForgotPasswordPage());
        }


        private async Task AddCredentialsToStorageAsync()
        {

            if (LoginRequestModel.RememberMe)
            {
                await accountCredentialStorage.SaveCredential(LoginRequestModel.Email, LoginRequestModel.Password, LoginRequestModel.RememberMe);
            }
            else
            {
                await secureStorageService.RemoveAsync(SecureStorageKey.AccountCredential);
            }

        }
        #endregion


    }
}