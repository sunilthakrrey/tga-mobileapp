using ParentPortal.Contracts.Responses;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WellnessComponent1 : StackLayout
    {
        public WellnessComponent1()
        {
            InitializeComponent();
        }

        //#region Type

        //public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(string), typeof(WellnessComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: TypePropertyChanged);

        //public string Type
        //{
        //    get
        //    {
        //        return (string)GetValue(TypeProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(TypeProperty, value);
        //    }
        //}
        //public static void TypePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    if (newvalue != default(object))
        //    {
        //        var control = (WellnessComponent)bindable;
        //        string TypeasString = (string)newvalue;
        //        Enums.TGA_Type TGAType = Enums.TGA_Type.None;
        //        Enum.TryParse(TypeasString, out TGAType);

        //        control.IsVisible = TGAType == Enums.TGA_Type.Wellness;
        //        //switch (TGAType)
        //        //{
        //        //    case Enums.TGA_Type.Event:
        //        //        //control.stckLike.IsVisible = false;
        //        //        //control.stckComment.IsVisible = false;
        //        //        //control.stckBookmark.IsVisible = false;
        //        //        control.toolbarstack.IsVisible = false;
        //        //        break;
        //        //    case Enums.TGA_Type.DailyChart:
        //        //        break;
        //        //    case Enums.TGA_Type.Wellness:
        //        //        control.stckLike.IsVisible = true;
        //        //        control.stckComment.IsVisible = true;
        //        //        control.stckBookmark.IsVisible = true;
        //        //        break;
        //        //    case Enums.TGA_Type.Announcement:
        //        //        break;
        //        //    case Enums.TGA_Type.None:
        //        //        break;
        //        //    default:
        //        //        break;
        //        //}

        //    }

        //}
        //#endregion

        #region Feed

        public static readonly BindableProperty FeedProperty = BindableProperty.Create(nameof(Feed), typeof(Feed), typeof(WellnessComponent1), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: FeedPropertyChanged);

        public string Feed
        {
            get
            {
                return (string)GetValue(FeedProperty);
            }
            set
            {
                base.SetValue(FeedProperty, value);
            }
        }
        public static void FeedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != default(object))
            {
                var control = (WellnessComponent1)bindable;
                Feed newsFeed = (Feed)newvalue;
                control.BindingContext = newsFeed;
                control.titleWebView.Source = new HtmlWebViewSource
                {
                    Html = newsFeed.title
                };
                control.DescriptionWebView.Source = new HtmlWebViewSource
                {
                    Html = newsFeed.description
                };
                control.IsVisible = newsFeed.TypeAsEnum == Enums.TGA_Type.Wellness;
            }

        }
        #endregion
    }
}