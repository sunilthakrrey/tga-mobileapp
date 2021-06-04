using ParentPortal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividualFrameComponent : StackLayout
    {
        public IndividualFrameComponent()
        {
            InitializeComponent();
            BindingContext = KidDetail;
        }
        //var txtColor1 = (Color)Application.Current.Resources["TextColor1"];
        private KidDetail _kidDetail;
        public KidDetail KidDetail
        {
            get
            {
                return _kidDetail;

            }
            set
            {
                _kidDetail = value;
                OnPropertyChanged(nameof(KidDetail));
            }
        }

    }
}