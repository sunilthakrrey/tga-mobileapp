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
    public partial class Grove_CurriculumComponent : StackLayout
    {
        public Grove_CurriculumComponent()
        {
            InitializeComponent();
        }

        #region Feed

        public static readonly BindableProperty FeedProperty = BindableProperty.Create(nameof(Feed), typeof(NewsFeed), typeof(Grove_CurriculumComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: FeedPropertyChanged);

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
                var control = (Grove_CurriculumComponent)bindable;
                NewsFeed newsFeed = (NewsFeed)newvalue;
                control.BindingContext = newsFeed;
                control.IsVisible = newsFeed.TypeAsEnum == Enums.TGA_Type.Grove_Curriculum;




            }

        }
        #endregion
    }
}