using ParentPortal.Contracts.Responses;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnnouncementComponent : StackLayout
    {
        public AnnouncementComponent()
        {
            InitializeComponent();
        }

        #region Feed

        public static readonly BindableProperty FeedProperty = BindableProperty.Create(nameof(Feed), typeof(Feed), typeof(AnnouncementComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: FeedPropertyChanged);

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
                var control = (AnnouncementComponent)bindable;
                Feed newsFeed = (Feed)newvalue;
                control.BindingContext = newsFeed;
                control.title.Text = newsFeed.title;
                //control.titleWebView.Source = new HtmlWebViewSource
                //{
                //    Html = string.Format("<label style='font-size:17px;'>{0}</label>", newsFeed.title) 
                //};
                control.DescriptionWebView.Source = new HtmlWebViewSource
                {
                    Html = newsFeed.description
                };
                control.IsVisible = newsFeed.TypeAsEnum == Enums.TGA_Type.Announcement;
            }

        }
        #endregion
    }
}