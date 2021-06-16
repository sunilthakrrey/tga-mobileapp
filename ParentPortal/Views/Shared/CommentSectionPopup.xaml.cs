using ParentPortal.Contracts.Responses;
using ParentPortal.Custom.Controls;
using ParentPortal.Enums;
using ParentPortal.Services.TGA;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentSectionPopup : PopupPage
    {
        SecureStorageService secureStorageService = new SecureStorageService();
        DashBoardService DashBoardService = new DashBoardService();
        public CommentSectionPopup(int FeedId)
        {
            InitializeComponent();
            Feed_Id = FeedId;
            BindingContext = this;
        }
        #region Properties
        public int Feed_Id { get; set; }

        

        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        #endregion

        #region Methods

        private async void PostComment_Clicked(object sender, EventArgs e)
        {
            Parent parent = await secureStorageService.GetAsync<Parent>(Enums.SecureStorageKey.AuthorizedUserInfo);
            PostCommentResponseModel responseModel = await DashBoardService.AddComment(parent.id, Feed_Id, Comment);
            //  PostCommentResponseModel responseModel = await DashBoardService.AddComment(1005890, 971363, "test");
            if (responseModel.Code == 200)
                await PopupNavigation.Instance.PopAllAsync();
            MessagingCenter.Send<ToolbarComponent, int>(new ToolbarComponent(), MessageCenterAuthenticator.CommentResponseCode.ToString(), responseModel.Code);
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
                        if (Verticaltransition > 125)
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