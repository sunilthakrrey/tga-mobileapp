using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
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
    public partial class UserInfo : StackLayout
    {

        public UserInfo()
        {

            InitializeComponent();

        }
        //public static readonly BindableProperty KidDetailProperty = BindableProperty.Create(nameof(kidDetail), typeof(KidDetail), typeof(IndividualFrameComponent), default(KidDetail), BindingMode.TwoWay, propertyChanged: ControlpropertyChanges);

        //public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(KidDetail), typeof(BindableComponent), defaultValue: default(KidDetail), defaultBindingMode: BindingMode.TwoWay, propertyChanged: ControlpropertyChanges);
        //public static void ControlpropertyChanges(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    var control = (BindableComponent)bindable;
        //    KidDetail kid =(KidDetail) newvalue;
        //    control.BindingContext= kid;
        //}

        //public KidDetail TitleText
        //{
        //    get
        //    {
        //        return (KidDetail)GetValue(TitleTextProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(TitleTextProperty, value);
        //    }
        //}

        // Component Name: UserInfo
        // Property: imageSize (enum), IsNameDisplay

        #region UserId

        public static readonly BindableProperty UserIdProperty = BindableProperty.Create(nameof(UserId), typeof(int), typeof(UserInfo), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: UserIdPropertyChanged);
        //public static void UserIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        //{

        //    if (newvalue != default(object))
        //    {
        //        var control = (BindableComponent)bindable;
        //        KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
        //        control.lblName.Text = aa.Name;
        //    }

        //}
        public int UserId
        {
            get
            {
                return (int)GetValue(UserIdProperty);
            }
            set
            {
                base.SetValue(UserIdProperty, value);
            }
        }

        #endregion

        #region ImageSize

        public static readonly BindableProperty ImageSizeProperty = BindableProperty.Create(nameof(ImageSize), typeof(string), typeof(UserInfo), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: ImageSizePropertyChanged);

        public string ImageSize
        {
            get
            {
                return (string)GetValue(ImageSizeProperty);
            }
            set
            {
                base.SetValue(ImageSizeProperty, value);
            }
        }


        #endregion

        #region IsNameDisplay
        public static readonly BindableProperty IsNameDisplayProperty = BindableProperty.Create(nameof(IsNameDisplay), typeof(string), typeof(UserInfo), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: NameDisplyPropertyChanged);

        public string IsNameDisplay
        {
            get
            {
                return (string)GetValue(ImageSizeProperty);
            }
            set
            {
                base.SetValue(ImageSizeProperty, value);
            }
        }
        #endregion


        #region onpropertychanged
        public static void UserIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (UserInfo)bindable;
                KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
                control.lblName.Text = aa.Name;
                control.img.Source = aa.Avtaar;
            }

        }
        public static void NameDisplyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                //var control = (UserInfo)bindable;
                ////KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
                //string boolValue = (string)newvalue;
                //bool isNameVisible = true;
                //control.lblName.IsVisible = bool.TryParse(boolValue, out isNameVisible);

                var control = (UserInfo)bindable;
                //KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
                string boolValue = (string)newvalue;
                bool isNameVisible = boolValue == "true";
                control.lblName.IsVisible = isNameVisible;
            }
        }


        public static void ImageSizePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (UserInfo)bindable;
                //KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
                string SizeasString = (string)newvalue;
                PictureSize imgSize = PictureSize.None;
                Enum.TryParse(SizeasString, out imgSize);

                switch (imgSize)
                {
                    case Enums.PictureSize.Small:
                        control.imgFrame.Style = (Style)Application.Current.Resources["ImageCircleFrameStyle"];
                        control.img.Style = (Style)Application.Current.Resources["ImageUserIconStyle"];
                        break;
                    case Enums.PictureSize.Medium:
                        control.imgFrame.Style = (Style)Application.Current.Resources["ImageUserCircleStyle"];
                        control.img.Style = (Style)Application.Current.Resources["ImageUserPicStyle"];
                        break;
                    default:
                        break;
                }
            }
        }



        #endregion

        public static async Task<KidDetail> GetKidDetailsFromStorage(int kidId)
        {
            SecureStorageService secureStorageService = new SecureStorageService();
            Data userInfo = await secureStorageService.GetAsync<Data>(Enums.SecureStorageKey.AuthorizedUserInfo);
            KidDetail kidDetail = userInfo.parent.kids.Where(x => x.Id == kidId).FirstOrDefault();
            return kidDetail;
        }
    }
}