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
                Enums.TGA_Type TGAType = Enums.TGA_Type.None;
                Enum.TryParse(TypeasString, out TGAType);
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
                    case Enums.TGA_Type.None:
                        break;
                    default:
                        break;
                }

            }

        }
        #endregion
        #region referId

        public static readonly BindableProperty ReferIdProperty = BindableProperty.Create(nameof(ReferId), typeof(int), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: ReferIdPropertyChanged);

        public int ReferId
        {
            get
            {
                return (int)GetValue(ReferIdProperty);
            }
            set
            {
                base.SetValue(ReferIdProperty, value);
            }
        }
        public static void ReferIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
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

        #region CreatedBy

        public static readonly BindableProperty CreatedByProperty = BindableProperty.Create(nameof(CreatedBy), typeof(int), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: CreatedByPropertyChanged);

        public int CreatedBy
        {
            get
            {
                return (int)GetValue(ReferIdProperty);
            }
            set
            {
                base.SetValue(ReferIdProperty, value);
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
                return (string)GetValue(ReferIdProperty);
            }
            set
            {
                base.SetValue(ReferIdProperty, value);
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
                return (string)GetValue(ReferIdProperty);
            }
            set
            {
                base.SetValue(ReferIdProperty, value);
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
                return (string)GetValue(ReferIdProperty);
            }
            set
            {
                base.SetValue(ReferIdProperty, value);
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
                string Value = (string)newvalue;
                bool isVisible = Value.ToLower() == "true";
              //  control.ActiveBookMark.IsVisible = isVisible;
                control.InactiveBookMark.IsVisible = !isVisible;
            }

        }
        #endregion


        private async void CreateComment_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new CommentSectionPopup());
        }


        private async void CreateBookMark_Tapped(object sender, EventArgs e)
        {
            var isalredayBookMarked = isBookMarked.ToLower() == "true";
            if (isalredayBookMarked)
            {
                await bookMarkStorageService.RemoveRecord(new Models.ToolStorageModel
                {
                    id = ReferId,
                    Type = Enums.TGA_Type.Announcement,
                    Module = Enums.Module.BookMark
                });
                isBookMarked = false.ToString();
            }
            else
            {
                await bookMarkStorageService.AddRecord(new Models.ToolStorageModel
                {
                    id = ReferId,
                    Type = Enums.TGA_Type.Announcement,
                    Module = Enums.Module.BookMark
                });
                isBookMarked = true.ToString();
            }

        }
    }
}