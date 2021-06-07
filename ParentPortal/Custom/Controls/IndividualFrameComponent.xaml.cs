using ParentPortal.Contracts.Responses;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividualFrameComponent : StackLayout
    {
        //public IndividualFrameComponent(string kidId)
        //{
        //    InitializeComponent();
        //    KidDetail = GetKidDetailsFromStorage(kidId).Result;
        //    OnPropertyChanged(nameof(KidDetail));
        //    BindingContext = KidDetail;
            
        //}

        public IndividualFrameComponent()
        {
            InitializeComponent();
           // BindingContext = KidDetail;
        }
        // var txtColor1 = (Color)Application.Current.Resources["TextColor1"];
        //private KidDetail _kidDetail;
        //public KidDetail KidDetail
        //{
        //    get
        //    {
        //        return _kidDetail;

        //    }
        //    set
        //    {
        //        _kidDetail = GetKidDetailsFromStorage(993182.ToString()).Result;
        //        //_kidDetail = value;
        //        OnPropertyChanged(nameof(KidDetail));
        //    }
        //}


        public static readonly BindableProperty KidDetailProperty = BindableProperty.Create(nameof(kidDetail), typeof(KidDetail), typeof(IndividualFrameComponent), default(KidDetail), BindingMode.TwoWay,propertyChanged:ControlpropertyChanges);
        public KidDetail kidDetail
        {
            get
            {
                return (KidDetail)GetValue(KidDetailProperty);
            }

            set
            {
               // BindingContext = value;
               
                SetValue(KidDetailProperty, value);
              //  OnPropertyChanged(nameof(kidDetail));
            }
        }
        public async Task<KidDetail> GetKidDetailsFromStorage(int kidId)
        {
            SecureStorageService secureStorageService = new SecureStorageService();
            Data userInfo = await secureStorageService.GetAsync<Data>(Enums.SecureStorageKey.AuthorizedUserInfo);
            KidDetail kidDetail = userInfo.parent.kids.Where(x => x.Id == kidId).FirstOrDefault();
            kidDetail.IsShowName = true;
            kidDetail.Size = Enums.ImageSize.Small;
            return kidDetail;
        }

        public static void ControlpropertyChanges(BindableObject bindable,object oldvalue, object newvalue)
        {

        }


    }
}