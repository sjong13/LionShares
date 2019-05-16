using LionShares.Helpers;
using Xamarin.Essentials;

namespace LionShares.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region // Fields
        private bool _isAdmin;
        private string _currentTheme;
        #endregion

        public string AppVersion
        {
            get
            {
                return string.Format("{0} ({1})", AppInfo.VersionString, AppInfo.BuildString);
            }
        }

        public string DeviceId
        {
            get
            {
                return DeviceInfo.Name;
            }
        }

        public string Model
        {
            get
            {
                return DeviceInfo.Model;
            }
        }

        public string Version
        {
            get
            {
                return DeviceInfo.VersionString;
            }
        }

        public string Platform
        {
            get
            {
                return DeviceInfo.Platform.ToString();
            }
        }

        public string User
        {
            get
            {
                return SettingHelper.Email;
            }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; OnPropertyChanged(); }
        }

        public string CurrentTheme
        {
            get { return _currentTheme; }
            set { _currentTheme = value; OnPropertyChanged(); }
        }

        public AboutViewModel()
        {
            Title = "About";
        }

        public void RefreshStatus()
        {
            IsBusy = true;
            IsAdmin = SettingHelper.IsAdminMode;
            CurrentTheme = SettingHelper.CurrentTheme;
            IsBusy = false;
        }
    }
}
