using ParentPortal.Helpers;
using ParentPortal.Models;
using ParentPortal.Modules.Auth.Login;
using ParentPortal.Services.TGA;
using Rg.Plugins.Popup.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RequestModels = ParentPortal.Contracts.Requests;

namespace ParentPortal.Modules.Auth.ForgotPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage, INotifyPropertyChanged
    {
        #region Data Members
        private View _View;
        IdentityService identityService = new IdentityService();

        #endregion
        #region properties

        private RequestModels.FOrgotPasswordRequestModel _fOrgotPasswordRequest = new RequestModels.FOrgotPasswordRequestModel();
        public RequestModels.FOrgotPasswordRequestModel FOrgotPasswordRequest
        {
            get { return _fOrgotPasswordRequest; }
            set
            {
                _fOrgotPasswordRequest = value;
                OnPropertyChanged("FOrgotPasswordRequest");
            }
        }





       

        #endregion
        public ForgotPasswordPage()
        {
            InitializeComponent();
            _View = this.Content;
            BindingContext = this;
           
            NavigationPage.SetHasNavigationBar(this, false);
        }
      
        public async void ResetPasswordButton_Clicked(object sender, EventArgs e)
        {
            ForgotPasswordRequest_StackError.IsVisible = false;
            if (!ValidationHelper.IsValid(FOrgotPasswordRequest, _View))
            {
                ForgotPasswordRequest_StackError.IsVisible = true;
                return;
            }

            //api call for link

            //var response = await identityService.ForgotPassword(FOrgotPasswordRequest);
            //if (response.status)
            //{
            //    await App.AppNavigation.DisplayAlert("Email Sent", "Email has been sent to provided Email to Reset Your Password", "OK");
            //}

            //  await App.AppNavigation.PushAsync(new ForgotPasswordPopup());
            await PopupNavigation.Instance.PushAsync(new ForgotPasswordPopup());
         
        }
       
        

    }
}