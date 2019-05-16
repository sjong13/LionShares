using LionShares.Constants;
using LionShares.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LionShares.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeItemTemplate : ContentView
    {
        public ThemeItemTemplate()
        {
            InitializeComponent();
        }

        public void ApplyClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string themeName = button.CommandParameter.ToString();
            SettingHelper.SetTheme(themeName);
        }
    }
}