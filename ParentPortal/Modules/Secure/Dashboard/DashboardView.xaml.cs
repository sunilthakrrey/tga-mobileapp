using ParentPortal.Views.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Modules.Secure.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : BaseContentView
    {
        public DashboardView()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}