using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Modules.Secure.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : BaseContentView
    {
        #region Data Members

        SecureStorageService SecureStorage = new SecureStorageService();
        DashBoardService DashBoardService = new DashBoardService();

        #endregion
        public DashboardView(bool isNeedToFilterSubsciberRegistered = true)
        {
            InitializeComponent();
            BindingContext = this;
            ConfigureSource(isNeedToFilterSubsciberRegistered);
        }

        #region Properties

        private AnnouncementData _announcementResponseModel;
        public AnnouncementData AnnouncementResponseModel
        {
            get
            {
                return _announcementResponseModel;

            }
            set
            {
                _announcementResponseModel = value;
                OnPropertyChanged(nameof(AnnouncementResponseModel));
            }
        }

        private Parent _parentkidsDetails;
        public Parent ParentkidsDetails
        {
            get
            {
                return _parentkidsDetails;

            }
            set
            {
                _parentkidsDetails = value;
                OnPropertyChanged(nameof(ParentkidsDetails));
            }
        }

        private List<MealChartData> _mealcomponentCollectionData;
        public List<MealChartData> MealComponentCollectionData
        {
            get
            {
                return _mealcomponentCollectionData;
            }
            set
            {
                _mealcomponentCollectionData = value;
                OnPropertyChanged(nameof(MealComponentCollectionData));
            }
        }

        private List<NewsFeedResponseData> _newsFeedBoxCollectionData = new List<NewsFeedResponseData>();
        public List<NewsFeedResponseData> NewsFeedBoxCollectionData
        {
            get
            {
                return _newsFeedBoxCollectionData;
            }
            set
            {
                _newsFeedBoxCollectionData = value;
                OnPropertyChanged(nameof(NewsFeedBoxCollectionData));
            }
        }

        private List<PollData> _pollData = new List<PollData>();
        public List<PollData> PollData
        {
            get
            {
                return _pollData;
            }
            set
            {
                _pollData = value;
                OnPropertyChanged(nameof(PollData));
            }
        }


        private bool _isVisibleAll;
        public bool isVisibleAll
        {
            get
            {
                return _isVisibleAll;
            }
            set
            {
                _isVisibleAll = value;
                OnPropertyChanged(nameof(isVisibleAll));
            }

        }




        #endregion

        private async void ConfigureSource(bool isSubscibed)
        {
            if (isSubscibed)
            {
                //get selected kid , first time we will continue with  Announcements
                List<KidDetail> selectedkid = await SecureStorage.GetAsync<List<KidDetail>>(Enums.SecureStorageKey.SelectedKids);

                //gets ids in form of string
                string kidIds = GetKidsIsAsString(selectedkid);
               await GetDashBoardData(kidIds);
                isVisibleAll = ParentkidsDetails.kids.Count > 1;



                MessagingCenter.Unsubscribe<DashboardView, string>(this, Enums.MessageCenterAuthenticator.FeedFilter.ToString());
                MessagingCenter.Subscribe<DashboardView, FilterSelection>(this, Enums.MessageCenterAuthenticator.FeedFilter.ToString(), async (sender, arg) =>
                {
                    if (arg != null)
                    {
                        await GetNewFeeds(kidIds, arg.FilterDate, arg.FilteType);
                        await PopupNavigation.Instance.PopAllAsync();
                    }
                });
            }

        }

        private async Task<bool> GetDashBoardData(string kidIds)
        {
            //Load Parent And Kid detail From Storage(saved at time of login)
            ParentkidsDetails = await SecureStorage.GetAsync<Parent>(Enums.SecureStorageKey.AuthorizedUserInfo);

            await GetAnnouncement(kidIds);

            await GetNewFeeds(kidIds);

            await GetMealChart(kidIds);

            await GetPollings(ParentkidsDetails.id, 607667);
            return true;

        }

        private async Task GetPollings(int parentId, int campusId)
        {
            //get poll Data
            PollResponseModel pollResponse = await DashBoardService.GetPollresponse(campusId, parentId, Enums.Views.DashBoard);
            PollData = pollResponse.data;

            //int i = 65;
            //foreach (var data in PollData)
            //{
            //    foreach (var option in data.Options)
            //    {
            //        option.optionIndex = ((char)i).ToString() + " ";
            //        if(data.Selected == option.Name)
            //        {
            //            option.IsSelected = true;
            //        }
            //        i = i++;
            //    }
            //}
        }

        private async Task GetMealChart(string kidIds)
        {
            //get Meal Data
            MealChartResponseModel mealResponse = await DashBoardService.GetMealData(kidIds, Enums.Views.DashBoard);
            MealComponentCollectionData = mealResponse.data;
        }

        private async Task GetNewFeeds(string kidIds, string date = "today", string type = "all")
        {
            //news Feeds 
            NewsFeedResponseModel responseModel = await DashBoardService.GetNewFeeedData(kidIds, date, type, Enums.Views.DashBoard);
            NewsFeedBoxCollectionData = responseModel.data;
        }

        private async Task GetAnnouncement(string kidIds)
        {
            //announcements
            AnnouncementResponseModel retVal = await DashBoardService.GetAnnounments(kidIds, Enums.Views.DashBoard);
            GridAnnouncement.IsVisible = retVal.IsRecordExist;

            AnnouncementResponseModel = retVal.data?.OrderByDescending(x => x.date).FirstOrDefault();
        }

        private async void FilterPopupRequest_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new FeedFilterPopup());
        }

        private async void optionSelected_Clicked(object sender, EventArgs e)
        {
            Frame optionFrame = (Frame)sender;
            var item = (TapGestureRecognizer)optionFrame.GestureRecognizers[0];
            object[] parameters = (object[])item.CommandParameter;
            PollData pollData = (PollData)parameters[0];
            if (pollData.IsAnswerSubmitted == false)
            {
                int optionValue = (int)parameters[1];
                PollOption selectedOption = pollData.Options.Where(x => x.Value == optionValue).FirstOrDefault();
                if (!selectedOption.IsSelected)
                    selectedOption.IsSelected = true;
                PollResponseModel pollResponseModel = await DashBoardService.AddPoll(pollId: Convert.ToInt32(pollData.id), parentId: ParentkidsDetails.id, selectedOption.Name);
            }
        }
        private string GetKidsIsAsString(List<KidDetail> selectedkid)
        {
            int[] kidsIds = selectedkid.Select(x => x.Id).ToArray();
            return String.Join(",", kidsIds);
        }
        private void kidselection_changed(object sender, EventArgs e)
        {
            StackLayout stackLayout = (StackLayout)sender;
            var gestureRecognizer = (TapGestureRecognizer)stackLayout.GestureRecognizers[0];
            int kidId = (int)gestureRecognizer.CommandParameter;
            GetDashBoardData(kidId.ToString());
        }

        private void selectAllKids_Tapped(object sender, EventArgs e)
        {
            string kidIds = GetKidsIsAsString(ParentkidsDetails.kids);
            GetDashBoardData(kidIds);
        }


    }
}