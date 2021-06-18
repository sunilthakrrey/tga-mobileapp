using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;
using ParentPortal.Extensions;
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
            // imgFrame.BorderColor = Color.Red;


        }
        public Color _BorderColor = Color.White;
        #region Highlight


        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(string), typeof(UserInfo), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: IsSelectedPropertyChanged);
        public string IsSelected
        {
            get
            {
                return (string)GetValue(IsSelectedProperty);
            }
            set
            {
                base.SetValue(IsSelectedProperty, value);
            }
        }

        public static void IsSelectedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (UserInfo)bindable;
                //control.imgFrame.BorderColor = Color.Red;
                string value = (string)newvalue;
                if (value.ToLower() == "true")
                    control.imgFrame.BorderColor = (Color)Application.Current.Resources["Feijoa"];
                else
                    control.imgFrame.BorderColor = Color.Transparent;
            }
        }

        #endregion Highlight


        #region UserId

        public static readonly BindableProperty UserIdProperty = BindableProperty.Create(nameof(UserId), typeof(int), typeof(UserInfo), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: UserIdPropertyChanged);
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
                if (aa != null)
                {
                    control.lblName.Text = aa.Name;
                    // control.imgFrame.IsVisible = false;

                    if (!string.IsNullOrEmpty(aa.Avtaar))
                    {
                        control.img.Source = aa.Avtaar;
                        control.nameFrame.IsVisible = false;
                    }
                    else
                    {
                        control.img.IsVisible = false;
                        control.lblNameFrame.Text = aa.Name.Substring(0, 1);
                    }

                }
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
                // KidDetail aa = GetKidDetailsFromStorage((int)newvalue).Result;
                string SizeasString = (string)newvalue;
                //PictureSize imgSize = PictureSize.None;
                //Enum.TryParse(SizeasString, out imgSize);
                Enums.PictureSize imgSize = SizeasString.ParseToEnum<Enums.PictureSize>();

                switch (imgSize)
                {
                    case Enums.PictureSize.Small:
                        control.imgFrame.Style = (Style)Application.Current.Resources["ImageCircleFrameStyle"];
                        control.nameFrame.Style = (Style)Application.Current.Resources["ImageCircleFrameStyle"];
                        control.img.Style = (Style)Application.Current.Resources["ImageUserIconStyle"];
                        break;
                    case Enums.PictureSize.Medium:
                        control.imgFrame.Style = (Style)Application.Current.Resources["ImageUserCircleStyle"];
                        control.nameFrame.Style = (Style)Application.Current.Resources["ImageUserCircleStyle"];
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
            Parent userInfo = await secureStorageService.GetAsync<Parent>(Enums.SecureStorageKey.AuthorizedUserInfo);
            KidDetail kidDetail = userInfo.kids.Where(x => x.Id == kidId).FirstOrDefault();
            return kidDetail;
        }
    }
}