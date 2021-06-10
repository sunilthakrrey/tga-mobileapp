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
        public DashboardView()
        {
            InitializeComponent();
            BindingContext = this;
            ConfigureSource();
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


        private Data _parentkidsDetails;
        public Data ParentkidsDetails
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

        private async void ConfigureSource()
        {
            //get selected kid , first time we will continue with  Announcements
            List<KidDetail> selectedkid = await SecureStorage.GetAsync<List<KidDetail>>(Enums.SecureStorageKey.SelectedKids);

            //api call for announcements

            //gets ids in form of string
            int[] kidsIds = selectedkid.Select(x => x.Id).ToArray();
            var str = String.Join(",", kidsIds);
            GetDashBoardData(str);
            isVisibleAll = ParentkidsDetails.parent.kids.Count > 1;
        }


        private async void GetDashBoardData(string kidIds)
        {
            //Load Parent And Kid detail From Storage(saved at time of login)
            ParentkidsDetails = await SecureStorage.GetAsync<Data>(Enums.SecureStorageKey.AuthorizedUserInfo);

            //announcements
            AnnouncementResponseModel announcements = await DashBoardService.GetAnnounments(kidIds);
            AnnouncementResponseModel = announcements.data.OrderByDescending(x => x.date).FirstOrDefault();

            //news Feeds 
            NewsFeedResponseModel responseModel = await DashBoardService.GetNewFeeedData(kidIds);
            NewsFeedBoxCollectionData = responseModel.data;

            //get Meal Data
            MealChartResponseModel mealResponse = await DashBoardService.GetMealData(kidIds);
            MealComponentCollectionData = mealResponse.data;

            //get poll Data
            PollResponseModel pollResponse = await DashBoardService.GetPollresponse();
            PollData = pollResponse.PollDataCollection;

            int i = 65;
            foreach (var data in PollData)
            {
                foreach (var option in data.Options)
                {
                    option.optionIndex = ((char)i).ToString() + " ";
                    i = i++;
                }

                
            }

        }
        private async void FilterPopupRequest_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new FilterPopup());
        }

        private async void optionSelected_Clicked(object sender, EventArgs e)
        {
            Frame stackLayout = (Frame)sender;
            var item = (TapGestureRecognizer)stackLayout.GestureRecognizers[0];
           var s = item.CommandParameter;
            
        }


    }
}