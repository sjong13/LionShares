using LionShares.Constants;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamo.Framework.Core;

namespace LionShares.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class SettingHelper
    {
        #region // Properties
        public static string UserName
        {
            get { return Preferences.Get(Setting.USERNAME_KEY, Setting.USERNAME_DEFAULT); }
            set { Preferences.Set(Setting.USERNAME_KEY, value); }
        }

        public static string Password
        {
            get { return Preferences.Get(Setting.PASSWORD_KEY, Setting.PASSWORD_DEFAULT); }
            set { Preferences.Set(Setting.PASSWORD_KEY, value); }
        }

        public static string UserId
        {
            get { return Preferences.Get(Setting.USERID_KEY, Setting.USERID_DEFAULT); }
            set { Preferences.Set(Setting.USERID_KEY, value); }
        }

        public static string Email
        {
            get { return Preferences.Get(Setting.EMAIL_KEY, Setting.EMAIL_DEFAULT); }
            set { Preferences.Set(Setting.EMAIL_KEY, value); }
        }

        public static string FirstName
        {
            get { return Preferences.Get(Setting.USERFIRSTNAME_KEY, Setting.USERFIRSTNAME_DEFAULT); }
            set { Preferences.Set(Setting.USERFIRSTNAME_KEY, value); }
        }

        public static string LastName
        {
            get { return Preferences.Get(Setting.USERLASTNAME_KEY, Setting.USERLASTNAME_DEFAULT); }
            set { Preferences.Set(Setting.USERLASTNAME_KEY, value); }
        }

        public static string Gender
        {
            get { return Preferences.Get(Setting.USERGENDER_KEY, Setting.USERGENDER_DEFAULT); }
            set { Preferences.Set(Setting.USERGENDER_KEY, value); }
        }

        public static string CompanyCode
        {
            get { return Preferences.Get(Setting.COMPANYCODE_KEY, Setting.COMPANYCODE_DEFAULT); }
            set { Preferences.Set(Setting.COMPANYCODE_KEY, value); }
        }

        public static string CompanyId
        {
            get { return Preferences.Get(Setting.COMPANYID_KEY, Setting.COMPANYID_DEFAULT); }
            set { Preferences.Set(Setting.COMPANYID_KEY, value); }
        }

        public static string DeviceToken
        {
            get { return Preferences.Get(Setting.DEVICETOKEN_KEY, Setting.DEVICETOKEN_DEFAULT); }
            set { Preferences.Set(Setting.DEVICETOKEN_KEY, value); }
        }

        public static string InitializeDate
        {
            get { return Preferences.Get(Setting.INITIALIZEDATE_KEY, Setting.INITIALIZEDATE_DEFAULT); }
            set { Preferences.Set(Setting.INITIALIZEDATE_KEY, value); }
        }

        public static DateTime SyncDate
        {
            get { return Preferences.Get(Setting.SYNCDATE_KEY, Setting.SYNCDATE_DEFAULT); }
            set { Preferences.Set(Setting.SYNCDATE_KEY, value); }
        }

        public static bool IsAutoSync
        {
            get { return Preferences.Get(Setting.ISAUTOSYNC_KEY, Setting.ISAUTOSYNC_DEFAULT); }
            set { Preferences.Set(Setting.ISAUTOSYNC_KEY, value); }
        }

        public static bool IsAdminMode
        {
            get { return Preferences.Get(Setting.ISADMIN_KEY, Setting.ISADMIN_DEFAULT); }
            set { Preferences.Set(Setting.ISADMIN_KEY, value); }
        }

        public static string CurrentTheme
        {
            get { return Preferences.Get(Setting.THEME_KEY, Setting.THEME_DEFAULT); }
            set { Preferences.Set(Setting.THEME_KEY, value); }
        }
        #endregion

        #region // Methods
        public static void Purge(List<string> keep = null)
        {
            keep = keep ?? new List<string>();
            foreach (var key in Setting.GetAllKeys())
            {
                if (!keep.Contains(key))
                    Preferences.Remove(key);
            }
        }

        public static void SetTheme(string name)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // verify if new theme is valid
                var theme = ThemeHelper.GetTheme(name);
                if (theme == null)
                    return;

                // clear current dictionary
                Application.Current.Resources.MergedDictionaries.Clear();

                // apply new dictionary
                CurrentTheme = name;
                Application.Current.Resources.MergedDictionaries.Add(theme);
            });
        }

        public static void Init()
        {
            if (!string.IsNullOrWhiteSpace(CurrentTheme))
                SetTheme(CurrentTheme);

            FirstName = FirstName ?? Global.GUEST_FIRSTNAME;
            LastName = LastName ?? Global.GUEST_LASTNAME;
        }
        #endregion
    }
}