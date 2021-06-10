using ParentPortal.Modules.Secure.ParentRequest.ChangeOfAttendance;
using ParentPortal.Views.Shared;
using Rg.Plugins.Popup.Services;
using System;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Modules.Secure.ChangeOfAttendance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeOfAttendanceView : BaseContentView
    {
        public ChangeOfAttendanceView()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Clicked(object sender, EventArgs e)
        {
             PopupNavigation.Instance.PushAsync(new SubmitPopupPage());
        }
    }
}