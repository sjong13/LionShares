using LionShares.Helpers;
using LionShares.Interfaces;
using LionShares.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LionShares
{
    public partial class App : Application
    {
        #region // Fields + Properties
        private static Application _app;
        public static Application CurrentApp
        {
            get { return App._app; }
        }

        public static string ActivePageTitle { get; set; }
        #endregion

        #region // Ctor
        public App()
        {
            InitializeComponent();

            _app = this;
            SettingHelper.Init();
            CurrentApp.MainPage = new RootPage();
        }
        #endregion

        #region // Overrides
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion

        #region // Methods
        public static void PushModalPage(Page page, IViewModel viewModel, bool animated = true, bool exitable = true)
        {
            if (viewModel != null)
            {
                viewModel.Navigation = Current.MainPage.Navigation;
                page.BindingContext = viewModel;
            }

            if (exitable)
            {
                ToolbarItem tbItem = new ToolbarItem(FontAwesomeFont.Times, null, () => Current.MainPage.Navigation.PopModalAsync());
                if (Device.RuntimePlatform == Device.UWP)
                {
                    tbItem.Text = "Close";
                    tbItem.Icon = "Assets/cancel.png";
                }

                NavigationPage navPage = new NavigationPage(page);
                navPage.ToolbarItems.Add(tbItem);
                Current.MainPage.Navigation.PushModalAsync(navPage, animated);
            }
            else
            {
                Current.MainPage.Navigation.PushModalAsync(page, animated);
            }
        }
        #endregion
    }
}
