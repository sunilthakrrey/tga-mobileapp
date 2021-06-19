using ParentPortal.Contracts.Responses;
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
    public partial class WellnessComponent : StackLayout
    {
        public WellnessComponent()
        {
            InitializeComponent();
        }
        #region Feed

        public static readonly BindableProperty FeedProperty = BindableProperty.Create(nameof(Feed), typeof(Feed), typeof(WellnessComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: FeedPropertyChanged);

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
                var control = (WellnessComponent)bindable;
                Feed newsFeed = (Feed)newvalue;
                control.BindingContext = newsFeed;
                if (string.IsNullOrEmpty(newsFeed.Interests))
                    control.lblInterest.IsVisible = false;
                if (string.IsNullOrEmpty(newsFeed.DevelopmentAreas))
                    control.lblDevelopmentArea.IsVisible = false;
                if (string.IsNullOrEmpty(newsFeed.ShortTermGoals))
                    control.lblShortTermGoals.IsVisible = false;
                control.IsVisible = newsFeed.TypeAsEnum == Enums.TGA_Type.Wellness;
            }

        }
        #endregion
    }
}