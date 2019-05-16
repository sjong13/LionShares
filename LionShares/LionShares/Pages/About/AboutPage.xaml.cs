using LionShares.Constants;
using LionShares.Helpers;
using LionShares.Localization;
using LionShares.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LionShares.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : AboutPageXaml
    {
        private int _tapCount;
        private bool _isTimerSet;

        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            IsBusyIndicatorEnabled = true;
            base.OnAppearing();
            ViewModel.RefreshStatus();
        }

        /// <summary>
        /// NumberOfTapsRequired does not work on android so we implement this custom solution
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void TapGestureCount(object s, EventArgs e)
        {
            _tapCount++;
            if (_tapCount >= 5)
            {
                _tapCount = 0;
                OnApplicationNameTapped(s, e);
            }

            if (!_isTimerSet)
            {
                _isTimerSet = true;
                Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 0, 2, 0), () =>
                {
                    _isTimerSet = false;
                    _tapCount = 0;
                    return false;
                });
            }
        }

        private async void OnApplicationNameTapped(object s, EventArgs e)
        {
            SettingHelper.IsAdminMode = !SettingHelper.IsAdminMode;
            ViewModel.RefreshStatus();

            await DisplayAlert(TextResources.AdminMode, string.Format(TextResources.AdminModeMessageText, SettingHelper.IsAdminMode ? TextResources.Now : TextResources.NoLonger), TextResources.Okay);
            MessagingCenter.Send(this, MessagingService.REBUILD_MENU);
        }

        private void ThemeTapped(object sender, EventArgs e)
        {
            App.PushModalPage(new ThemeSettingPage(), new ThemeSettingViewModel());
        }
    }

    public abstract class AboutPageXaml : ModelBoundContentPage<AboutViewModel> { }
}