using FFImageLoading.Svg.Forms;
using ParentPortal.Models;
using System;
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
            BindingContext = ComponentData;
            //for(int i = 1;i <= ComponentData.NoOfMorningtea; i++)
            //{
            //    MorningTeaStack.Children.Add(new StackLayout
            //    { 
            //        Children.Add(new SvgCachedImage() { Source=ImageSource.FromFile("Meal_icon.svg") })
            //    }
            //    );

            //}

        }

        #region Properties
        private MyDayBoxComponenetModel _componentData;
        public MyDayBoxComponenetModel ComponentData 
		{
            get
            {
                return _componentData;
            }
            set
            {
                _componentData = value;
                OnPropertyChanged(nameof(ComponentData));
            }
		}
       

        #endregion
    }
}