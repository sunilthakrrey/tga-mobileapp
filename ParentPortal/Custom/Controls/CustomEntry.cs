using Xamarin.Forms;

namespace ParentPortal.Custom.Controls
{
   public class CustomEntry:Entry
    {
		#region Ctor
		public CustomEntry()
		{
			this.ReturnType = ReturnType.Next;
			this.IsTextPredictionEnabled = false;
		}
		#endregion

		#region Binding Properties


		public bool IsRemoveDefaultPadding
		{
			get => (bool)GetValue(IsRemoveDefaultPaddingProperty);
			set => SetValue(IsRemoveDefaultPaddingProperty, value);
		}

		public static readonly BindableProperty IsRemoveDefaultPaddingProperty =
		   BindableProperty.Create(nameof(IsRemoveDefaultPadding), typeof(bool), typeof(Editor), false);

		public static readonly BindableProperty PaddingProperty =
		   BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(Editor), default(Thickness));

		public static readonly BindableProperty IconTextSpacing =
		 BindableProperty.Create(nameof(Icon_TextSpacing), typeof(int), typeof(CustomEntry), 15);

		#region BorderColor
		public static readonly BindableProperty BorderColorProperty =
			 BindableProperty.Create(nameof(BorderColor),
					 typeof(Color), typeof(CustomEntry), Color.Gray);
		// Gets or sets BorderColor value
		public Color BorderColor
		{
			get => (Color)GetValue(BorderColorProperty);
			set => SetValue(BorderColorProperty, value);
		}
		#endregion

		#region BorderWidth
		public static readonly BindableProperty BorderWidthProperty =
				BindableProperty.Create(nameof(BorderWidth), typeof(int),
						typeof(CustomEntry), Device.OnPlatform<int>(1, 2, 2));
		// Gets or sets BorderWidth value
		public int BorderWidth
		{
			get => (int)GetValue(BorderWidthProperty);
			set => SetValue(BorderWidthProperty, value);
		}
		#endregion

		#region CornerRadius
		public static readonly BindableProperty CornerRadiusProperty =
				BindableProperty.Create(nameof(CornerRadius),
						typeof(double), typeof(CustomEntry), Device.OnPlatform<double>(6, 7, 7));
		// Gets or sets CornerRadius value
		public double CornerRadius
		{
			get => (double)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}
		#endregion

		#region ReturnType
		public static new readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(
		   nameof(ReturnType),
		   typeof(ReturnType),
		   typeof(CustomEntry),
		   ReturnType.Done,
		   BindingMode.OneWay
	   );

		public new ReturnType ReturnType
		{
			get { return (ReturnType)GetValue(ReturnTypeProperty); }
			set { SetValue(ReturnTypeProperty, value); }
		}
		#endregion

		#region CurveBackgroundColor
		public static readonly BindableProperty CurveBackgroundColorProperty =
			 BindableProperty.Create(nameof(CurveBackgroundColor),
					 typeof(Color), typeof(CustomEntry), Color.White);
		// Gets or sets BorderColor value
		public Color CurveBackgroundColor
		{
			get => (Color)GetValue(CurveBackgroundColorProperty);
			set => SetValue(CurveBackgroundColorProperty, value);
		}
		#endregion

		#region FocusedCurveBackgroundColor
		public static readonly BindableProperty FocusedCurveBackgroundColorProperty =
			 BindableProperty.Create(nameof(FocusedCurveBackgroundColor),
					 typeof(Color), typeof(CustomEntry), Color.White);
		// Gets or sets BorderColor value
		public Color FocusedCurveBackgroundColor
		{
			get => (Color)GetValue(FocusedCurveBackgroundColorProperty);
			set => SetValue(FocusedCurveBackgroundColorProperty, value);
		}

		public Thickness Padding
		{
			get => (Thickness)GetValue(PaddingProperty);
			set => SetValue(PaddingProperty, value);
		}

		public int Icon_TextSpacing
		{
			get => (int)GetValue(IconTextSpacing);
			set => SetValue(IconTextSpacing, value);
		}


		#endregion

		#endregion
	}
}

