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

      
    }
}