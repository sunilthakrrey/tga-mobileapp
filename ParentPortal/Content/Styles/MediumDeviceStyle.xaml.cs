using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Content.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediumDeviceStyle : ResourceDictionary
    {
        public static MediumDeviceStyle SharedInstance { get; } = new MediumDeviceStyle();
        public MediumDeviceStyle()
        {
            InitializeComponent();
        }
    }
}