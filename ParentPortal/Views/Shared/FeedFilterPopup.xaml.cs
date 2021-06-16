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
        public FeedFilterPopup()
        {
            InitializeComponent();
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
            if (button.IsChecked)
            {
                dateFilter = GetDate();
                FilterSelection filterSelection = new FilterSelection
                {
                    FilterDate = dateFilter,
                    FilteType = button.Content.ToString()
                };
                //MessagingCenter.Send<DashboardView, FilterSelection>(new DashboardView(isNeedToFilterSubsciberRegistered: false), MessageCenterAuthenticator.FeedFilter.ToString(), filterSelection);
            }
        }

        void FeedFilterDateCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            string typefilter = string.Empty;
            if (button.IsChecked)
            {
                typefilter = GetFilterType();
                FilterSelection filterSelection = new FilterSelection
                {
                    FilterDate = typefilter,
                    FilteType = button.Content.ToString()
                };
                //MessagingCenter.Send<DashboardView, FilterSelection>(new DashboardView(isNeedToFilterSubsciberRegistered: false), MessageCenterAuthenticator.FeedFilter.ToString(), filterSelection);

            }
        }



        public string GetDate()
        {
            string retVal = string.Empty;
            if (RadDateAll.IsChecked)
                retVal = "All";
            else if (RadDateLastMonth.IsChecked)
                retVal = "Last Month";
            else if (RadDateLastWeek.IsChecked)
                retVal = "LastWeek";
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
                retVal = "DailyChart";
            else if (RadTypeWellness.IsChecked)
                retVal = "Wellness";
            return retVal;
        }
    }
}