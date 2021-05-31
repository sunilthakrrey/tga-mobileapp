using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Content.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LightThemeStyle : ResourceDictionary
    {
        public static LightThemeStyle SharedInstance { get; } = new LightThemeStyle();
        public LightThemeStyle()
        {
            InitializeComponent();
        }
    }
}