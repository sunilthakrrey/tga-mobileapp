using ParentPortal.Models;
using ParentPortal.Views.Shared;
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

        private MyDayBoxComponenetModel _componentData;
        public MyDayBoxComponenetModel ComponentData
        {
            get
            {
                return _componentData;
            }
            set
            {
                _componentData = value;
                OnPropertyChanged(nameof(ComponentData));
            }
        }


        private NewsFeedBoxComponentModel _newsFeedBoxComponentModel;
        public NewsFeedBoxComponentModel NewsFeedBoxComponentModel
        {
            get
            {
                return _newsFeedBoxComponentModel;
            }
            set
            {
                _newsFeedBoxComponentModel = value;
                OnPropertyChanged(nameof(NewsFeedBoxComponentModel));
            }
        }

        private NewsFeedBoxComponentModel _newsFeedBoxComponentYoga;
        public NewsFeedBoxComponentModel NewsFeedBoxComponentYoga
        {
            get
            {
                return _newsFeedBoxComponentYoga;
            }
            set
            {
                _newsFeedBoxComponentYoga = value;
                OnPropertyChanged(nameof(NewsFeedBoxComponentYoga));
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
                        Avtaar = ImageSource.FromFile("user_f.svg")
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
                        Avtaar = ImageSource.FromFile("user_f.svg")
                    }
                }
            };

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
                    }
                }
            }
        };
        }
    }
}