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
	public partial class TGANewsFeedContainerComponent : StackLayout
	{
		public TGANewsFeedContainerComponent ()
		{
			InitializeComponent ();
			BindingContext = NewsFeedBoxComponentModel;
		}

		private NewsFeedBoxComponentModel _newsFeedBoxComponentModel;
		public NewsFeedBoxComponentModel NewsFeedBoxComponentModel
        {
            get
            {
				return _newsFeedBoxComponentModel;
            }
            set
            {
				_newsFeedBoxComponentModel = value;
				OnPropertyChanged(nameof(NewsFeedBoxComponentModel));
            }
        }

		
	}
}