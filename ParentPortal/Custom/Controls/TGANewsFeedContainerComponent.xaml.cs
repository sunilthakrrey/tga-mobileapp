using ParentPortal.Contracts.Responses;
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
		//	BindingContext = NewsFeedResponseCollection;
		}

		


		private  List<NewsFeedResponseData> _newsFeedResponseCollection;
		public List<NewsFeedResponseData> NewsFeedResponseCollection
		{
			get
			{
				return _newsFeedResponseCollection;
			}
			set
			{
				_newsFeedResponseCollection = value;
				OnPropertyChanged(nameof(_newsFeedResponseCollection));
			}
		}


	}
}