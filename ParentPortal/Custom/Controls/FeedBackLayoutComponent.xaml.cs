using ParentPortal.Models;
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
	public partial class FeedBackLayoutComponent : StackLayout
	{
		public FeedBackLayoutComponent ()
		{
			InitializeComponent ();
			BindingContext = FeedBackComponentModel;
		}

		private FeedBackComponentModel _feedBackComponentModel;
        public FeedBackComponentModel FeedBackComponentModel 
		{
            get
            {
				return _feedBackComponentModel;
            }
            set
            {
				_feedBackComponentModel = value;
				OnPropertyChanged(nameof(FeedBackComponentModel));
            }
		}
    }
}