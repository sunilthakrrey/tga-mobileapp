using ParentPortal.Models;
using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Modules.Secure.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : BaseContentView
    {
        public DashboardView()
        {
            InitializeComponent();
            BindingContext = this;
            ConfigureSource();
        }

        #region Properties

        private List<KidDetail> _kidsDetails;
        public List<KidDetail> KidsDetails
        {
            get
            {
                return _kidsDetails;

            }
            set
            {
                _kidsDetails = value;
                OnPropertyChanged(nameof(KidsDetails));
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

        #endregion

        private void ConfigureSource()
        {
            var date = new System.DateTime(2021, 3, 3, 11, 30, 00);

           
            

            //Kids Info Component

            KidsDetails = new List<KidDetail>
            {
                new KidDetail
                {
                    Id = "1",
                        Name = "Lily",
                        Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=false,
                        Size=Enums.ImageSize.Large
                },

                  new KidDetail
                {
                    Id = "1",
                        Name = "Lily",
                        Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=false,
                        Size=Enums.ImageSize.Large
                }
            };

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
                        Avtaar = ImageSource.FromFile("user_f.svg"),
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
                        Avtaar = ImageSource.FromFile("user_f.svg"),
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
                        Avtaar = ImageSource.FromFile("user_f.svg"),
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
                        Avtaar = ImageSource.FromFile("user_f.svg"),
                        IsShowImage=true,
                        IsShowName=true,
                        Size=Enums.ImageSize.Small
                    }
                }
            }
        };
        }
        private async void FilterPopupRequest_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new FilterPopup());
        }
    }
}