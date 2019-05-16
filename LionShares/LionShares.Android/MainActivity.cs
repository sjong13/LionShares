using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Util;
using LionShares.Android.Helpers;

namespace LionShares.Android
{
    [Activity(
        Label = "LionShares",
        Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            base.SetTheme(Resource.Style.MainTheme);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            if (name.Equals("android.support.v7.view.menu.ActionMenuItemView", StringComparison.InvariantCultureIgnoreCase))
            {
                System.Diagnostics.Debug.WriteLine(name);
                var customFontToolbar = AndroidHelper.CreateCustomToolbarItem(name, context, attrs);
                if (customFontToolbar != null)
                    return customFontToolbar;
            }

            return base.OnCreateView(name, context, attrs);
        }

        public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        {
            if (name.Equals("android.support.v7.view.menu.ActionMenuItemView", StringComparison.InvariantCultureIgnoreCase))
            {
                System.Diagnostics.Debug.WriteLine(name);
                var customFontToolbar = AndroidHelper.CreateCustomToolbarItem(name, context, attrs);
                if (customFontToolbar != null)
                    return customFontToolbar;
            }

            return base.OnCreateView(parent, name, context, attrs);
        }
    }
}