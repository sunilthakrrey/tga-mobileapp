using GalaSoft.MvvmLight.Command;
using ParentPortal.Enums;
using ParentPortal.Models;
using ParentPortal.Modules.Secure.Dashboard;
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
    public partial class FeedFilterPopup : PopupPage
    {
        public FeedFilterPopup(FilterSelection  filterSelection)
        {

            InitializeComponent();
            NotFireChangeEvent = true;
            ConfigureFilter(filterSelection);
            NotFireChangeEvent = false;
        }
        public bool NotFireChangeEvent { get; set; }
        public void ConfigureFilter(FilterSelection filterSelection)
        {
            //date

            if (filterSelection.FilterDate =="All")
                RadDateAll.IsChecked =true;
            else if (filterSelection.FilterDate == "Last Month")
                RadDateLastMonth.IsChecked = true;
            else if (filterSelection.FilterDate == "Last Week")
                RadDateLastWeek.IsChecked = true;
            else if (filterSelection.FilterDate == "Today")
                RadDateToday.IsChecked = true;
            else if (filterSelection.FilterDate == "Yesterday")
                RadDateYesterday.IsChecked = true;

            //type

            if (filterSelection.FilteType == "All")
                RadTypeAll.IsChecked = true;
            else if (filterSelection.FilteType == "Event")
                RadTypeEvent.IsChecked = true;
            else if (filterSelection.FilteType == "Announcement")
                RadTypeAnnouncement.IsChecked = true;
            else if (filterSelection.FilteType == "Daily Chart")
                RadTypeDailyChart.IsChecked = true;
            else if (filterSelection.FilteType == "Wellness")
                RadTypeWellness.IsChecked = true;
           
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

        void FeedFilterTypeCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            string dateFilter = string.Empty;
            if (button.IsChecked && NotFireChangeEvent == false)
            {
                dateFilter = GetDate();
                FilterSelection filterSelection = new FilterSelection
                {
                    FilterDate = dateFilter,
                    FilteType = button.Content.ToString()
                };
                MessagingCenter.Send<DashboardView, FilterSelection>(new DashboardView(isNeedToFilterSubsciberRegistered: false), MessageCenterAuthenticator.FeedFilter.ToString(), filterSelection);
            }
        }

        void FeedFilterDateCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            string typefilter = string.Empty;
            if (button.IsChecked && NotFireChangeEvent == false)
            {
                typefilter = GetFilterType();
                FilterSelection filterSelection = new FilterSelection
                {
                    FilterDate = button.Content.ToString(),
                    FilteType = typefilter
                };
                MessagingCenter.Send<DashboardView, FilterSelection>(new DashboardView(isNeedToFilterSubsciberRegistered: false), MessageCenterAuthenticator.FeedFilter.ToString(), filterSelection);

            }
        }



        public string GetDate()
        {
            string retVal = string.Empty;
            if (RadDateAll.IsChecked )
                retVal = "All";
            else if (RadDateLastMonth.IsChecked)
                retVal = "Last Month";
            else if (RadDateLastWeek.IsChecked)
                retVal = "Last Week";
            else if (RadDateToday.IsChecked)
                retVal = "Today";
            else if (RadDateYesterday.IsChecked)
                retVal = "Yesterday";
            return retVal;
        }
        public string GetFilterType()
        {
            string retVal = string.Empty;
            if (RadTypeAll.IsChecked)
                retVal = "All";
            else if (RadTypeEvent.IsChecked)
                retVal = "Event";
            else if (RadTypeAnnouncement.IsChecked)
                retVal = "Announcement";
            else if (RadTypeDailyChart.IsChecked)
                retVal = "Daily Chart";
            else if (RadTypeWellness.IsChecked)
                retVal = "Wellness";
            return retVal;
        }
    }
}