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
	public partial class MealChartComponent : StackLayout
	{
		public MealChartComponent()
		{
			InitializeComponent ();
            BindingContext = ComponentCollectionData;
        }

        #region Properties
       
        private List<MealChartData> _componentCollectionData;
        public List<MealChartData> ComponentCollectionData
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