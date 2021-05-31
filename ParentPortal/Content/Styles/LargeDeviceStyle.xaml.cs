using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Content.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LargeDeviceStyle : ResourceDictionary
    {
        public static LargeDeviceStyle SharedInstance { get; } = new LargeDeviceStyle();
        public LargeDeviceStyle()
        {
            InitializeComponent();
        }
    }
}