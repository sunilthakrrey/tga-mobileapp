using ParentPortal.Contracts.Responses;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private AnnouncementResponseModel _announcementResponseModel;
        public AnnouncementResponseModel AnnouncementResponseModel
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

        private List<MyDayBoxComponenetModel> _componentCollectionData;
        public List<MyDayBoxComponenetModel> ComponentCollectionData
        {
            get
            {
                return _componentCollectionData;
            }
            set
            {
                _componentCollectionData = value;
                OnPropertyChanged(nameof(ComponentCollectionData));
            }
        }


        private List<NewsFeedBoxComponentModel> _newsFeedBoxCollectionData;
        public List<NewsFeedBoxComponentModel> NewsFeedBoxCollectionData
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

        private void ConfigureSource()
        {
            GetDashBoardData();


            var date = new System.DateTime(2021, 3, 3, 11, 30, 00);

            //my meal day
            ComponentCollectionData = new List<MyDayBoxComponenetModel> {
                 new MyDayBoxComponenetModel
                {
                    Title = "Morning Tea",
                    Type = ImageSource.FromFile("morning_tea_icon.svg"),
                    Description = "Toast with Jam",
                    NoOfMorningtea = 1.ToString(),
                    NoOfFruits = 2.ToString(),
                    NoOfWater = 3.ToString(),
                    NoOfBootles = 2.ToString(),
                    Kid = new KidDetail
                    {
                        Id = "1",
                        Name = "Lily",
                       // Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=true,
                        Size=Enums.ImageSize.Small
                    }
                },
                 new MyDayBoxComponenetModel
                {
                    Title = "Morning Tea",
                    Type = ImageSource.FromFile("morning_tea_icon.svg"),
                    Description = "Toast with Jam",
                    NoOfMorningtea = 1.ToString(),
                    NoOfFruits = 2.ToString(),
                    NoOfWater = 3.ToString(),
                    NoOfBootles = 2.ToString(),
                    Kid = new KidDetail
                    {
                        Id = "1",
                        Name = "Lily",
                       // Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=true,
                        Size=Enums.ImageSize.Small
                    }
                }
            };


            //news feeds
            NewsFeedBoxCollectionData = new List<NewsFeedBoxComponentModel>
            {
            new NewsFeedBoxComponentModel
            {
                BackGroundImage = ImageSource.FromUri(new System.Uri("https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg")),
                Date = date.ToString("dd MMMM yyyy, hh:mm"),
                Title = "WaterPlay In The Yard",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Porta egestas aenean viverra molestie non.",
                Image = ImageSource.FromFile("sun_icon.svg"),
                FeedBackComponentModel = new FeedBackComponentModel
                {
                    Likes = 7,
                    Comments = 3,
                    IsfeebackLayoutVisible = true,
                    KidDetail = new KidDetail
                    {
                        Id = "1",
                        Name = "Lily",
                       // Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=true,
                        Size=Enums.ImageSize.Small

                    }
                }
            },
            new NewsFeedBoxComponentModel
            {
                BackGroundImage = ImageSource.FromUri(new System.Uri("https://helpx.adobe.com/content/dam/help/en/photoshop/using/convert-color-image-black-white/jcr_content/main-pars/before_and_after/image-before/Landscape-Color.jpg")),
                Date = date.ToString("dd MMMM yyyy, hh:mm"),// new System.DateTime(2021, 3, 3, 11, 30, 00),
                Title = "WaterPlay In The Yard",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Porta egestas aenean viverra molestie non.",
                Image = ImageSource.FromFile("events_Icon.svg"),
                FeedBackComponentModel = new FeedBackComponentModel
                {
                    IsfeebackLayoutVisible = false,
                    KidDetail = new KidDetail
                    {
                        Id = "1",
                        Name = "Lily",
                       // Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=true,
                        Size=Enums.ImageSize.Small
                    }
                }
            }
            };

            isVisibleAll = ParentkidsDetails.parent.kids.Count > 1;
        }


        private async void GetDashBoardData()
        {
            //Load Parent And Kid detail From Storage(saved at time of login)
            ParentkidsDetails = await SecureStorage.GetAsync<Data>(Enums.SecureStorageKey.AuthorizedUserInfo);
            //get selected kid , first time we will continue with  Announcements
            List<KidDetail> selectedkid = await SecureStorage.GetAsync<List<KidDetail>>(Enums.SecureStorageKey.SelectedKids);

            //api call for announcements

            //gets ids in form of string
            string[] kidsIds = selectedkid.Select(x => x.Id).ToArray();
            var str = String.Join(",", kidsIds);
            List<AnnouncementResponseModel> announcements = await DashBoardService.GetAnnounments(str);
            AnnouncementResponseModel = announcements.OrderByDescending(x => x.data.date).FirstOrDefault();

        }
        private async void FilterPopupRequest_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new FilterPopup());
        }
    }
}