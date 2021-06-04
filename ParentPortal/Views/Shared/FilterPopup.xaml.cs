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
                    Name="Room",
                    Options = new List<string>
                    {
                       "All",
                       "Adventures Room","Explorers Rooms"
                       ,"Voygers 2-3",
                       "Achievers rom",
                        "Explorers 0-2"
                    }
                },
                 new FilterModel
                {
                    Name="Campus",
                    Options = new List<string>
                    {
                       "All",
                       "Bexely","Woolongongs"
                       ,"Edmondson Park",
                       "Mount Annan"
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

        #endregion
    }
}