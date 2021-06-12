using ParentPortal.Enums;
using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Enums.Views> processingRequests = new ObservableCollection<Enums.Views>();
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
        public bool _isBusy = false;
        public bool isBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(isBusy));
            }
        }

        public MainPage(bool isListnerConfigured = true)
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
            if (!isListnerConfigured)
            {
                AttachListner();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AttachListner()
        {
            MessagingCenter.Unsubscribe<MainPage, string>(this, MessageCenterAuthenticator.RequestStarted.ToString());
            MessagingCenter.Subscribe<MainPage, Enums.Views>(this, MessageCenterAuthenticator.RequestStarted.ToString(), (sender, arg) =>
            {
                if (arg != Enums.Views.None)
                {
                    processingRequests.Add(arg);
                    isBusy = true;
                }
            });


            MessagingCenter.Unsubscribe<MainPage, string>(this, MessageCenterAuthenticator.RequestCompleted.ToString());
            MessagingCenter.Subscribe<MainPage, Enums.Views>(this, MessageCenterAuthenticator.RequestCompleted.ToString(), (sender, arg) =>
            {
                if (arg != Enums.Views.None)
                {
                    processingRequests.Remove(arg);

                    if (processingRequests.Count == 0)
                    {
                        // Task.Delay(2000);

                        isBusy = false;
                    }
                }
            });
        }

        private async void GetMenuItems_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new SideNavPopup());
        }
    }
}
