using FFImageLoading.Svg.Forms;
using ParentPortal.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Custom.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TGAMyDayBoxComponent : StackLayout
	{
		public TGAMyDayBoxComponent ()
		{
			InitializeComponent ();
            BindingContext = ComponentCollectionData;
        }

        #region Properties
       
        private List<MyDayBoxComponenetModel> _componentCollectionData;
        public List<MyDayBoxComponenetModel> ComponentCollectionData
        {
            get
            {
                return _componentCollectionData;
            }
            set
            {
                _componentCollectionData = value;
                OnPropertyChanged(nameof(ComponentCollectionData));
            }
        }


        #endregion
    }
}