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

        private List<MealData> _mealcomponentCollectionData;
        public List<MealData> MealComponentCollectionData
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
           
            //foreach (NewsFeedResponseData newsFeedResponseData in responseModel.data)
            //{
            //  newsFeedResponseData.KidDetail =  await GetKidDetailsFromStorage(newsFeedResponseData.createdById);
            //}
            NewsFeedBoxCollectionData = responseModel.data;

            //get Meal Data
            MealOfTheDayResponseModel mealResponse = await DashBoardService.GetMealData(kidIds);
            
            foreach (MealData data in mealResponse.data)
            {
               // data.KidDetail = await GetKidDetailsFromStorage(data.createdById);
            }
            MealComponentCollectionData = mealResponse.data;
           
        }
        private async void FilterPopupRequest_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new FilterPopup());
        }


    }
}