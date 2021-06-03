using ParentPortal.Models;
using ParentPortal.Modules.Auth.Login;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class ForgotPasswordPopup : PopupPage
    {
        public ForgotPasswordPopup()
        {
            InitializeComponent();
            ConfigureSource();
            BindingContext = this;
        }

        #region Properties


        private PopupDataModel _popupDataModel;
        public PopupDataModel PopupDataModel
        {
            get
            {
                return _popupDataModel;
            }
            set
            {
                _popupDataModel = value;
                OnPropertyChanged(nameof(PopupDataModel));
            }
        }
        public void ConfigureSource()
        {
            PopupDataModel = new PopupDataModel
            {
                Message = "Reset password link has been sent to your registered email address",
                PopUpNavigatioButtonCommand = new Command(ExecutePopUpNavigatioButtonCommand)
            };
        }
        public async void ExecutePopUpNavigatioButtonCommand()
        {
            await PopupNavigation.Instance.PopAllAsync();
            await App.AppNavigation.PushAsync(new LoginPage());
        }

        #endregion

    }
}