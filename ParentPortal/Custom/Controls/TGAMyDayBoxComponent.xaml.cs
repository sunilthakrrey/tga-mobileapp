using FFImageLoading.Svg.Forms;
using ParentPortal.Contracts.Responses;
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
       
        private List<MealData> _componentCollectionData;
        public List<MealData> ComponentCollectionData
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