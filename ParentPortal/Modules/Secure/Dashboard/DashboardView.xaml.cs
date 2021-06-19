using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;
using ParentPortal.Extensions;
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

        public FilterSelection filterSelection { get; set; }
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

        private List<FeedResponseData> _newsFeedBoxCollectionData = new List<FeedResponseData>();
        public List<FeedResponseData> NewsFeedBoxCollectionData
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

        private bool _isHighlightAllKidsOption;
        public bool IsHighlightAllKidsOption
        {
            get
            {
                return _isHighlightAllKidsOption;
            }
            set
            {
                _isHighlightAllKidsOption = value;
                OnPropertyChanged(nameof(IsHighlightAllKidsOption));
            }
        }

        public List<int> _selectedKidId = default(List<int>);


        #endregion

        private async void ConfigureSource(bool isSubscibed)
        {
            if (isSubscibed)
            {

                //get selected kid , first time we will continue with  Announcements
                List<KidDetail> selectedkid = await SecureStorage.GetAsync<List<KidDetail>>(Enums.SecureStorageKey.SelectedKids);
                _selectedKidId = selectedkid.Select(x => x.Id).ToList();
                //gets ids in form of string
                string kidIds = GetKidsIsAsString(_selectedKidId);

                //parentkid detail

                ParentkidsDetails = await SecureStorage.GetAsync<Parent>(Enums.SecureStorageKey.AuthorizedUserInfo);
                ParentkidsDetails.kids.FirstOrDefault().IsHighlighted = true.ToString();
                //var aaa = ParentkidsDetails.SelectedKid.Id;


                await GetDashBoardData(kidIds);
                isVisibleAll = ParentkidsDetails.kids.Count > 1;
                MessagingCenter.Unsubscribe<DashboardView, FilterSelection>(this, Enums.MessageCenterAuthenticator.FeedFilter.ToString());
                MessagingCenter.Subscribe<DashboardView, FilterSelection>(this, Enums.MessageCenterAuthenticator.FeedFilter.ToString(), async (sender, arg) =>
                {
                    if (arg != null)
                    {

                        NewsFeedBoxCollectionData = new List<FeedResponseData>();
                        MealComponentCollectionData = new List<MealChartData>();


                        if (arg.FilteType == "Daily Chart")
                            await GetMealChart(kidIds, arg.FilterDate);
                        else if (arg.FilteType != "All")
                            await GetNewFeeds(kidIds, arg.FilterDate, arg.FilteType);
                        else
                        {
                            await GetMealChart(kidIds, arg.FilterDate);
                            await GetNewFeeds(kidIds, arg.FilterDate);
                        }

                        filterSelection = arg;
                    }
                });
            }

        }

        private async Task<bool> GetDashBoardData(string kidIds)
        {
            await GetAnnouncement(kidIds);

            await GetNewFeeds(kidIds);

            await GetMealChart(kidIds);

            await GetPollings(ParentkidsDetails.id, 607667);
            return true;

        }

        private async Task GetPollings(int parentId, int campusId)
        {
            //get poll Data
            PollResponseModel pollResponse = await DashBoardService.GetPolls(campusId, parentId, Enums.Views.DashBoard);
            PollData = pollResponse.data;
            foreach (var data in PollData)
            {
                int i = 65;
                foreach (var option in data.Options)
                {
                    option.OptionIndex = ((char)i).ToString() + " ";
                    i = i + 1;
                };
            }
        }

        private async Task GetMealChart(string kidIds, string date = "today")
        {
            //get Meal Data
            MealChartResponseModel mealResponse = await DashBoardService.GetMeals(kidIds, date, Enums.Views.DashBoard);
            MealComponentCollectionData = mealResponse.data;
        }

        private async Task GetNewFeeds(string kidIds, string date = "today", string type = "all")
        {
            //news Feeds 
            FeedResponseModel responseModel = await DashBoardService.GetFeeds(kidIds, date, type, Enums.Views.DashBoard);
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
            FilterSelection selectedOptions = new FilterSelection();
            if (filterSelection != null)
                selectedOptions = filterSelection;
            else
                selectedOptions = new FilterSelection{FilterDate = "All", FilteType = "All"};
                await PopupNavigation.Instance.PushAsync(new FeedFilterPopup(selectedOptions));
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
        private string GetKidsIsAsString(List<int> selectedkid)
        {
            return String.Join(",", selectedkid);
        }

        private async void kidselection_changed(object sender, EventArgs e)
        {
            nameFrame.BorderColor = Color.Transparent;
            IsHighlightAllKidsOption = false;
            StackLayout stackLayout = (StackLayout)sender;
            var gestureRecognizer = (TapGestureRecognizer)stackLayout.GestureRecognizers[0];
            int kidId = (int)gestureRecognizer.CommandParameter;
            //add in storage

            foreach (KidDetail kid in ParentkidsDetails.kids)
            {
                kid.IsHighlighted = (kid.Id == kidId).ToString();
            }
            _selectedKidId = new List<int> { kidId };
            await GetDashBoardData(kidId.ToString());
        }

        private async void selectAllKids_Tapped(object sender, EventArgs e)
        {
            ParentkidsDetails.kids.ForEach(x => x.IsHighlighted = "false");
            IsHighlightAllKidsOption = true;
            _selectedKidId = ParentkidsDetails.kids.Select(x => x.Id).ToList();
            string kidIds = GetKidsIsAsString(ParentkidsDetails.kids.Select(x => x.Id).ToList());
            nameFrame.BorderColor =(Color)Application.Current.Resources["Feijoa"];
            await GetDashBoardData(kidIds);
        }
    }
}