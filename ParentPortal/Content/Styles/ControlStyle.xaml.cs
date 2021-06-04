using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Content.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlStyle : ContentPage
    {
        public static ControlStyle SharedInstance { get; } = new ControlStyle();
        public ControlStyle()
        {
            InitializeComponent();
        }
    }
}