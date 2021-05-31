using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Content.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonStyle : ResourceDictionary
    {
        public static CommonStyle SharedInstance { get; } = new CommonStyle();
        public CommonStyle()
        {
            InitializeComponent();
        }
    }
}