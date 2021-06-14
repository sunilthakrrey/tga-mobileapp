using ParentPortal.Storage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedComponent : StackLayout
    {
        BookMarkStorageService BookMarkStorageService = new BookMarkStorageService();
        public FeedComponent()
        {
            InitializeComponent();
           
        }

        #region isShowUserInfo

        public static readonly BindableProperty isShowUserInfoProperty = BindableProperty.Create(nameof(isShowUserInfo), typeof(string), typeof(ToolbarComponent), defaultValue: null, defaultBindingMode: BindingMode.OneTime, propertyChanged: isShowUserInfoPropertyChanged);

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
                var control = (FeedComponent)bindable;
                string Value = (string)newvalue;
                

            }

        }
        #endregion

        #region isBookMarked

       

        public bool isBookMarked
        {
            get
            {
                return true;
            }
            
        }

       
        #endregion

    }
}