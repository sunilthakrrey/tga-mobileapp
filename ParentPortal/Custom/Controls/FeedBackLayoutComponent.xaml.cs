using ParentPortal.Contracts.Responses;
using ParentPortal.Models;
using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedBackLayoutComponent : StackLayout
    {
        public FeedBackLayoutComponent()
        {
            InitializeComponent();
            BindingContext = FeedBackComponentModel;
        }
       

        private NewsFeedResponseData _feedBackComponentModel;
        public NewsFeedResponseData FeedBackComponentModel
        {
            get
            {
                return _feedBackComponentModel;
            }
            set
            {
                _feedBackComponentModel = value;
                OnPropertyChanged(nameof(FeedBackComponentModel));
            }
        }

        private async void CreateComment_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CommentSectionPopup());
        }

    }
}