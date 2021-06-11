using ParentPortal.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParentPortal.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPopup : PopupPage
    {
        public FilterPopup()
        {
            InitializeComponent();
            BindingContext = this;
            Configure();
        }

        #region Properties
        private List<FilterModel> _filters;
        public List<FilterModel> Filters
        {
            get
            {
                return _filters;
            }
            set
            {
                _filters = value;
                OnPropertyChanged(nameof(Filters));
            }
        }

        public void Configure()
        {
            Filters = new List<FilterModel>
            {
                new FilterModel
                {
                    Name="Date",
                    Options = new List<string>
                    {
                       "All",
                       "Last Week","Today"
                       ,"Last Month",
                       "Yesterday"
                    }
                },
                 new FilterModel
                {
                    Name="Type",
                    Options = new List<string>
                    {
                       "All",
                       "Daily Chart","Event"
                       ,"Wellness",
                       "Announcement"
                    }
                }
            };
        }


        private void ClosePopup_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync();
        }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            double Verticaltransition = 0;
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (e.TotalY > 0)
                    {
                        await RecordPlayFrame.TranslateTo(0, e.TotalY);
                        Verticaltransition = e.TotalY;
                        if (Verticaltransition > 125)
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                    break;
                case GestureStatus.Completed:
                    if (Verticaltransition > 75)
                    {
                        await RecordPlayFrame.TranslateTo(0, 200, 100);
                        if (PopupNavigation.Instance.PopupStack.Any())
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                    else
                    {
                        await RecordPlayFrame.TranslateTo(0, e.TotalY);
                    }
                    break;
            }
        }

      
        void onSelection_Changed(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
           
        }

        #endregion
    }
}