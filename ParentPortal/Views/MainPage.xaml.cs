using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private View _contentView;
        public View ContentView
        {
            get { return _contentView; }
            set
            {
                _contentView = value;

                if (_contentView != null)
                {
                    OnPropertyChanged("ContentView");
                    CView.Content = _contentView;
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private async void GetMenuItems_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new SideNavPopup());
        }
    }
}
