using Plugin.Shared.Extensions;
using System;
using System.Collections.Generic;

namespace LionShares.Constants
{
    public static partial class Setting
    {
        public static List<string> GetAllKeys()
        {
            return
                typeof(Setting)
                .GetAllPublicConstantValues<string>();
        }

        public const string USERNAME_KEY = "username_key";
        public static readonly string USERNAME_DEFAULT = string.Empty;

        public const string PASSWORD_KEY = "password_key";
        public static readonly string PASSWORD_DEFAULT = string.Empty;

        public const string USERID_KEY = "userid_key";
        public static readonly string USERID_DEFAULT = string.Empty;

        public const string EMAIL_KEY = "email_key";
        public static readonly string EMAIL_DEFAULT = string.Empty;

        public const string USERFIRSTNAME_KEY = "userfirstname_key";
        public static readonly string USERFIRSTNAME_DEFAULT = string.Empty;

        public const string USERLASTNAME_KEY = "userlastname_key";
        public static readonly string USERLASTNAME_DEFAULT = string.Empty;

        public const string USERGENDER_KEY = "usergender_key";
        public static readonly string USERGENDER_DEFAULT = string.Empty;

        public const string COMPANYCODE_KEY = "companycode_key";
        public static readonly string COMPANYCODE_DEFAULT = string.Empty;

        public const string COMPANYID_KEY = "companyid_key";
        public static readonly string COMPANYID_DEFAULT = string.Empty;

        public const string DEVICETOKEN_KEY = "devicetoken_key";
        public static readonly string DEVICETOKEN_DEFAULT = string.Empty;

        public const string INITIALIZEDATE_KEY = "initializedate_key";
        public static readonly string INITIALIZEDATE_DEFAULT = string.Empty;

        public const string SYNCDATE_KEY = "syncdate_key";
        public static readonly DateTime SYNCDATE_DEFAULT = DateTime.Now;

        public const string ISAUTOSYNC_KEY = "isautosync_key";
        public static readonly bool ISAUTOSYNC_DEFAULT = true;

        public const string ISADMIN_KEY = "isadmin_key";
        public static readonly bool ISADMIN_DEFAULT = false;

        public const string THEME_KEY = "theme_key";
        public static readonly string THEME_DEFAULT = "Custom Theme";
    }
}
