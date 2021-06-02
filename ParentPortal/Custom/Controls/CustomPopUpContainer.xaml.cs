using ParentPortal.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopUpContainer : ContentView
    {
        public CustomPopUpContainer()
        {
            InitializeComponent();
            BindingContext = PopupDataModel;
        }

        #region PopupContent
        public object PopupContent
        {
            get { return (object)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }
        public static readonly BindableProperty PopupContentProperty =
          BindableProperty.Create(
            propertyName: "PopupContent",
            returnType: typeof(object),
            declaringType: typeof(CustomPopUpContainer),
            propertyChanged: null);
        #endregion

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

        private async void ClosePopup_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAllAsync();
        }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            double Verticaltransition = 0;
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (e.TotalY > 0)
                    {
                        await RecordPlayFrame.TranslateTo(0, e.TotalY);
                        Verticaltransition = e.TotalY;
                        if(Verticaltransition > 125)
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                    break;
                case GestureStatus.Completed:
                    if (Verticaltransition > 75)
                    {
                        await RecordPlayFrame.TranslateTo(0, 200, 100);
                        if (PopupNavigation.Instance.PopupStack.Any())
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                    else
                    {
                        await RecordPlayFrame.TranslateTo(0, e.TotalY);
                    }
                    break;
            }
        }

        #endregion
    }
}