using ParentPortal.Contracts.Responses;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindableComponent : StackLayout
    {




        public BindableComponent()
        {

            InitializeComponent();

        }
        //public static readonly BindableProperty KidDetailProperty = BindableProperty.Create(nameof(kidDetail), typeof(KidDetail), typeof(IndividualFrameComponent), default(KidDetail), BindingMode.TwoWay, propertyChanged: ControlpropertyChanges);

        //public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(KidDetail), typeof(BindableComponent), defaultValue: default(KidDetail), defaultBindingMode: BindingMode.TwoWay, propertyChanged: ControlpropertyChanges);
        //public static void ControlpropertyChanges(BindableObject bindable, object oldvalue, object newvalue)
        //{
        //    var control = (BindableComponent)bindable;
        //    KidDetail kid =(KidDetail) newvalue;
        //    control.BindingContext= kid;
        //}

        //public KidDetail TitleText
        //{
        //    get
        //    {
        //        return (KidDetail)GetValue(TitleTextProperty);
        //    }
        //    set
        //    {
        //        base.SetValue(TitleTextProperty, value);
        //    }
        //}


        public static readonly BindableProperty UserIdProperty = BindableProperty.Create(nameof(UserId), typeof(int), typeof(BindableComponent), defaultValue: default(int), defaultBindingMode: BindingMode.OneTime, propertyChanged: UserIdPropertyChanged);
        public static void UserIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            
            if (newvalue != default(object))
            {
                var control = (BindableComponent)bindable;
                control.BindingContext = GetKidDetailsFromStorage((int)newvalue).Result;

            }

        }

        public int UserId
        {
            get
            {
                return (int)GetValue(UserIdProperty);
            }
            set
            {
                base.SetValue(UserIdProperty, value);
            }
        }

        public static async Task<KidDetail> GetKidDetailsFromStorage(int kidId)
        {
            SecureStorageService secureStorageService = new SecureStorageService();
            Data userInfo = await secureStorageService.GetAsync<Data>(Enums.SecureStorageKey.AuthorizedUserInfo);
            KidDetail kidDetail = userInfo.parent.kids.Where(x => x.Id == kidId).FirstOrDefault();
            kidDetail.IsShowName = true;
            kidDetail.Size = Enums.ImageSize.Small;
            return kidDetail;
        }
    }
}