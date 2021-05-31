using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Content.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmallDeviceStyle : ResourceDictionary
    {
        public static SmallDeviceStyle SharedInstance { get; } = new SmallDeviceStyle();
        public SmallDeviceStyle()
        {
            InitializeComponent();
        }
    }
}