using ParentPortal.Extensions;
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
    public partial class StatComponent : StackLayout
    {
        public StatComponent()
        {
            InitializeComponent();
        }

        public bool _isShowLike { get; set; } = false;

        public bool _isShowComments { get; set; } = false;
        public bool _isShowMessage { get; set; } = false;


        #region Type

        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: TypePropertyChanged);

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
        public void ShowControls(bool isShowLikes, bool isShowComments, string message = null)
        {
            lblLikes.IsVisible = isShowLikes;
            lblComments.IsVisible = isShowComments;
            lblMessage.Text = message;
            lblMessage.IsVisible = string.IsNullOrEmpty(message) == false;

        }
        public static void TypePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (StatComponent)bindable;
                string TypeasString = (string)newvalue;
                //Enums.TGA_Type TGAType = Enums.TGA_Type.None;
                //Enum.TryParse(TypeasString, out TGAType);

                Enums.TGA_Type TGAType =  TypeasString.ParseToEnum<Enums.TGA_Type>();
                switch (TGAType)
                {
                    case Enums.TGA_Type.Event:
                        //You are going to this event
                        control.ShowControls(isShowLikes: true, isShowComments: true, message: "");
                        break;
                    case Enums.TGA_Type.DailyChart:
                        break;
                    case Enums.TGA_Type.Wellness:
                        control.ShowControls(false, true, message: "");
                        break;
                    case Enums.TGA_Type.Announcement:
                        control.ShowControls(isShowLikes: false, isShowComments: false);
                        break;
                    case Enums.TGA_Type.Grove_Curriculum:
                        control.ShowControls(true, true);
                        break;
                    case Enums.TGA_Type.None:
                        break;
                    default:
                        break;
                }

            }

        }
        #endregion
        #region TotalLikes

        public static readonly BindableProperty TotalLikesProperty = BindableProperty.Create(nameof(TotalLikes), typeof(int), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: TotalLikesPropertyChanged);

        public int TotalLikes
        {
            get
            {
                return (int)GetValue(TotalLikesProperty);
            }
            set
            {
                base.SetValue(TotalLikesProperty, value);
            }
        }

        public static void TotalLikesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (StatComponent)bindable;
                control.lblLikes.Text = string.Format("{0} Likes", (int)newvalue);
            }

        }

        #endregion

        #region TotalComments

        public static readonly BindableProperty TotalCommentsProperty = BindableProperty.Create(nameof(TotalComments), typeof(int), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: TotalCommentsPropertyChanged);

        public int TotalComments
        {
            get
            {
                return (int)GetValue(TotalCommentsProperty);
            }
            set
            {
                base.SetValue(TotalCommentsProperty, value);
            }
        }

        public static void TotalCommentsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (StatComponent)bindable;
                control.lblComments.Text = string.Format("{0} Comments", (int)newvalue);
            }

        }

        #endregion

        //#region isShowLikes

        //public static readonly BindableProperty isShowLikesProperty = BindableProperty.Create(nameof(isShowLikes), typeof(string), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowLikesPropertyChanged);

        //public string isShowLikes
        //{
        //    get
        //    {
        //        return (string)GetValue(isShowLikesProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(isShowLikesProperty, value);
        //    }
        //}

        //public static void isShowLikesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    if (newvalue != default(object))
        //    {
        //        var control = (StatComponent)bindable;
        //        string Value = (string)newvalue;
        //        Value = Value.ToLowerInvariant();
        //        bool isVisible = Value == "true";
        //        if (!isVisible)
        //            control.lblMessage.IsVisible = true;
        //        control.lblLikes.IsVisible = isVisible;
        //    }

        //}

        //#endregion


        //#region isShowComments

        //public static readonly BindableProperty isShowCommentsProperty = BindableProperty.Create(nameof(isShowComments), typeof(string), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowCommentsPropertyChanged);

        //public string isShowComments
        //{
        //    get
        //    {
        //        return (string)GetValue(isShowCommentsProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(isShowCommentsProperty, value);
        //    }
        //}

        //public static void isShowCommentsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    if (newvalue != default(object))
        //    {
        //        var control = (StatComponent)bindable;
        //        string Value = (string)newvalue;
        //        Value = Value.ToLowerInvariant();
        //        bool isVisible = Value == "true";
        //        if (!isVisible)
        //            control.lblEventGoing.IsVisible = true;
        //        control.lblComments.IsVisible = isVisible;
        //    }

        //}

        //#endregion


        //#region Message

        //public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: MessagePropertyChanged);

        //public string Message
        //{
        //    get
        //    {
        //        return (string)GetValue(MessageProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(MessageProperty, value);
        //    }
        //}

        //public static void MessagePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    if (newvalue != default(object))
        //    {
        //        var control = (StatComponent)bindable;
        //    } 
        //}

        //#endregion

        #region isShowUserInfo

        public static readonly BindableProperty isShowUserInfoProperty = BindableProperty.Create(nameof(isShowUserInfo), typeof(string), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowUserInfoPropertyChanged);

        public string isShowUserInfo
        {
            get
            {
                return (string)GetValue(isShowUserInfoProperty);
            }
            set
            {
                base.SetValue(isShowUserInfoProperty, value);
            }
        }

        public static void isShowUserInfoPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (StatComponent)bindable;
                string Value = (string)newvalue;
                bool isVisible = Value == "true";
                control.userInfoComponent.IsVisible = isVisible;
            }

        }

        #endregion

        #region Createdbyid

        public static readonly BindableProperty CreatedbyidProperty = BindableProperty.Create(nameof(Createdbyid), typeof(int), typeof(StatComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: CreatedbyidPropertyChanged);

        public int Createdbyid
        {
            get
            {
                return (int)GetValue(CreatedbyidProperty);
            }
            set
            {
                base.SetValue(CreatedbyidProperty, value);
            }
        }

        public static void CreatedbyidPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (StatComponent)bindable;
                control.userInfoComponent.UserId = (int)newvalue;
            }

        }

        #endregion


    }
}