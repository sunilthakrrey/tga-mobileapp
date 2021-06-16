using ParentPortal.Contracts.Responses;
using ParentPortal.Extensions;
using ParentPortal.Services.TGA;
using ParentPortal.Storage;
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
    public partial class ToolbarComponent : StackLayout
    {
        BookMarkStorageService bookMarkStorageService = new BookMarkStorageService();
        DashBoardService dashBoardService = new DashBoardService();
       
        public ToolbarComponent()
        {
            InitializeComponent();
        }
        #region Type

        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: TypePropertyChanged);

        public string Type
        {
            get
            {
                return (string)GetValue(TypeProperty);
            }
            set
            {
                base.SetValue(TypeProperty, value);
            }
        }
        public static void TypePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;
                string TypeasString = (string)newvalue;
                //Enums.TGA_Type TGAType = Enums.TGA_Type.None;
                //Enum.TryParse(TypeasString, out TGAType);
                Enums.TGA_Type TGAType = TypeasString.ParseToEnum<Enums.TGA_Type>();
                switch (TGAType)
                {
                    case Enums.TGA_Type.Event:
                        //control.stckLike.IsVisible = false;
                        //control.stckComment.IsVisible = false;
                        //control.stckBookmark.IsVisible = false;
                        control.toolbarstack.IsVisible = false;
                        break;
                    case Enums.TGA_Type.DailyChart:
                        break;
                    case Enums.TGA_Type.Wellness:
                        control.stckLike.IsVisible = true;
                        control.stckComment.IsVisible = true;
                        control.stckBookmark.IsVisible = true;
                        break;
                    case Enums.TGA_Type.Announcement:
                        break;
                    case Enums.TGA_Type.Grove_Curriculum:
                        control.stckLike.IsVisible = true;
                        control.stckComment.IsVisible = true;
                        control.stckBookmark.IsVisible = true;
                        break;
                    case Enums.TGA_Type.None:
                        break;
                    default:
                        break;
                }

            }

        }
        #endregion
        #region postId

        public static readonly BindableProperty PostIdProperty = BindableProperty.Create(nameof(PostId), typeof(int), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: PostIdPropertyChanged);

        public int PostId
        {
            get
            {
                return (int)GetValue(PostIdProperty);
            }
            set
            {
                base.SetValue(PostIdProperty, value);
            }
        }
        public static void PostIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;


            }

        }

        #endregion

        #region CreatedBy

        public static readonly BindableProperty CreatedByProperty = BindableProperty.Create(nameof(CreatedBy), typeof(int), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: CreatedByPropertyChanged);

        public int CreatedBy
        {
            get
            {
                return (int)GetValue(CreatedByProperty);
            }
            set
            {
                base.SetValue(CreatedByProperty, value);
            }
        }
        public static void CreatedByPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;
                //KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
                //control.lblName.Text = aa.Name;
                //control.img.Source = aa.Avtaar;
            }

        }

        #endregion

        #region isShowLikeButton

        public static readonly BindableProperty isShowLikeButtonProperty = BindableProperty.Create(nameof(isShowLikeButton), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowLikeButtonPropertyChanged);

        public string isShowLikeButton
        {
            get
            {
                return (string)GetValue(isShowLikeButtonProperty);
            }
            set
            {
                base.SetValue(isShowLikeButtonProperty, value);
            }
        }
        public static void isShowLikeButtonPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;
                string Value = (string)newvalue;
                bool isVisible = Value.ToLower() == "true";
                control.stckLike.IsVisible = (bool)isVisible;
            }

        }

        #endregion

        #region isShowCommentButton

        public static readonly BindableProperty isShowCommentButtonProperty = BindableProperty.Create(nameof(isShowCommentButton), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowCommentButtonPropertyChanged);

        public string isShowCommentButton
        {
            get
            {
                return (string)GetValue(isShowCommentButtonProperty);
            }
            set
            {
                base.SetValue(isShowCommentButtonProperty, value);
            }
        }

        public static void isShowCommentButtonPropertyChanged
                (BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;
                string Value = (string)newvalue;
                bool isVisible = Value == "true";
                control.stckComment.IsVisible = (bool)isVisible;
            }

        }

        #endregion

        #region isShowBookmarkButton

        public static readonly BindableProperty isShowBookmarkButtonProperty = BindableProperty.Create(nameof(isShowBookmarkButton), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowBookmarkButtonPropertyChanged);

        public string isShowBookmarkButton
        {
            get
            {
                return (string)GetValue(isShowBookmarkButtonProperty);
            }
            set
            {
                base.SetValue(isShowBookmarkButtonProperty, value);
            }
        }

        public static void isShowBookmarkButtonPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;
                string Value = (string)newvalue;
                bool isVisible = Value == "true";
                control.stckBookmark.IsVisible = (bool)isVisible;
            }

        }
        #endregion

        #region isBookMarked

        public static readonly BindableProperty isBookMarkedProperty = BindableProperty.Create(nameof(isBookMarked), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isBookMarkedPropertyChanged);

        public string isBookMarked
        {
            get
            {
                return (string)GetValue(isBookMarkedProperty);
            }
            set
            {
                base.SetValue(isBookMarkedProperty, value);
            }
        }

        public static void isBookMarkedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {

                var control = (ToolbarComponent)bindable;

                string updatedValue = (string)newvalue;
                bool isVisible = updatedValue.ToLower() == "true";
                if (isVisible)
                {
                    control.lblBookMark.Text = "BookMarked";
                    control.imgBookMark.Source = ImageSource.FromFile("Bookmarked_icon.svg");
                }
                else
                {
                    control.lblBookMark.Text = "BookMark";
                    control.imgBookMark.Source = ImageSource.FromFile("bookmark_icon.svg");
                }
            }
        }

        private async void CreateBookMark_Tapped(object sender, EventArgs e)
        {
            bool isalreadyBookMarked = isBookMarked.ToLower() == "true";
            Enums.TGA_Type _type = Type.ParseToEnum<Enums.TGA_Type>();
            if (isalreadyBookMarked)
            {
                var retVal = await bookMarkStorageService.Remove(new Models.Bookmark_Like_Model
                {
                    FeedId = PostId,
                    Type = _type,
                    Module = Enums.Module.BookMark
                });
                isBookMarked = "false";
            }
            else
            {
                await bookMarkStorageService.Add(new Models.Bookmark_Like_Model
                {
                    FeedId = PostId,
                    Type = _type,
                    Module = Enums.Module.BookMark
                });
                isBookMarked = "true";
            }

        }
        #endregion

        #region isLiked

        public static readonly BindableProperty isLikedProperty = BindableProperty.Create(nameof(isLiked), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isLikedPropertyChanged);

        public string isLiked
        {
            get
            {
                return (string)GetValue(isLikedProperty);
            }
            set
            {
                base.SetValue(isLikedProperty, value);
            }
        }

        public static void isLikedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {

                var control = (ToolbarComponent)bindable;

                string updatedValue = (string)newvalue;
                bool isVisible = updatedValue.ToLower() == "true";
                if (isVisible)
                {
                    control.lblLike.Text = "Liked";
                    control.imgLike.Source = ImageSource.FromFile("Liked_icon.svg");
                }
                else
                {
                    control.lblLike.Text = "Like";
                    control.imgLike.Source = ImageSource.FromFile("tga_like.svg");
                }
            }
        }

        private async void CreateLike_Tapped(object sender, EventArgs e)
        {
            bool isalreadyLiked = isLiked.ToLower() == "true";
            Enums.TGA_Type _type = Type.ParseToEnum<Enums.TGA_Type>();
            if (isalreadyLiked)
            {
                var retVal = await bookMarkStorageService.Remove(new Models.Bookmark_Like_Model
                {
                    FeedId = PostId,
                    Type = _type,
                    Module = Enums.Module.Like
                });

                PostLikeResponseModel responseModel = await dashBoardService.AddLike(post_id: PostId, post_type: Type, -1);
                if (responseModel.Code == 200)
                    isLiked = "false";
              //  Stat.totalLikes = responseModel.Like

            }
            else
            {
                await bookMarkStorageService.Add(new Models.Bookmark_Like_Model
                {
                    FeedId = PostId,
                    Type = _type,
                    Module = Enums.Module.Like
                });
                PostLikeResponseModel responseModel = await dashBoardService.AddLike(post_id: PostId, post_type: Type, 1);
                if (responseModel.Code == 200)
                    isLiked = "true";
            }
        }
        #endregion

        #region Type

        public static readonly BindableProperty StatProperty = BindableProperty.Create(nameof(Type), typeof(FeedStat), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: StatPropertyChanged);

        public FeedStat Stat
        {
            get
            {
                return (FeedStat)GetValue(TypeProperty);
            }
            set
            {
                base.SetValue(TypeProperty, value);
            }
        }
        public static void StatPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (ToolbarComponent)bindable;

            }

        }
        #endregion

        private async void CreateComment_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CommentSectionPopup(PostId));
        }
    }
}