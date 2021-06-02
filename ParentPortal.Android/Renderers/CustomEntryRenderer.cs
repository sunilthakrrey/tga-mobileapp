using System;
using Xamarin.Forms;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Util;
using ParentPortal.Custom.Controls;
using ParentPortal.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ParentPortal.Droid.Renderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		GradientDrawable _gradientBackground;
		#region Constructor
		public CustomEntryRenderer(Context context)
			: base(context)
		{

		}

		[Obsolete("This constructor is obsolete as of version 2.5. Please use CurvedEntryRenderer(Context) instead.")]
		public CustomEntryRenderer()
		{

		}
		#endregion

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var view = (CustomEntry)Element;
				if (view.CornerRadius != 0)
				{
					// creating gradient drawable for the curved background
					_gradientBackground = new GradientDrawable();
					_gradientBackground.SetShape(ShapeType.Rectangle);
					_gradientBackground.SetColor(view.CurveBackgroundColor.ToAndroid());
					// Thickness of the stroke line
					//	_gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());
					
					// Radius for the curves
					_gradientBackground.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));
					// set the background of the label
					Control.SetBackground(_gradientBackground);
				}
				Control.SetHintTextColor(view.PlaceholderColor.ToAndroid());
                // Set padding for the internal text from border
                //Control.SetHeight(170);
                if (view.IsRemoveDefaultPadding)
                {
					Control.SetPadding((int)view.Padding.Left, (int)view.Padding.Top, (int)view.Padding.Right, (int)view.Padding.Bottom);
				}
				else
                {
					Control.SetPadding(
						  (int)DpToPixels(this.Context, Convert.ToSingle(12)),
						  Control.PaddingTop,
						  (int)DpToPixels(this.Context, Convert.ToSingle(12)),
						  Control.PaddingBottom);
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			var view = (CustomEntry)Element;
			
			if (view != null)
			{
				//if (e.PropertyName == CustomEntry.IsFocusedProperty.PropertyName)
				//{ 
				//	SetControlBackground(view.IsFocused ? view.FocusedCurveBackgroundColor : view.CurveBackgroundColor); 
				//}
				
					SetControlBackground(view.BackgroundColor);
			}
		}

		private void SetControlBackground(Color backgroundColor)
		{
			if (_gradientBackground != null)
			{
				_gradientBackground.SetColor(backgroundColor.ToAndroid());
				

				// set the background of the label
				Control.SetBackground(_gradientBackground);
			}
		}

		private static float DpToPixels(Context context, float valueInDp)
		{
			DisplayMetrics metrics = context.Resources.DisplayMetrics;
			return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
		}
	}
}