using LionShares.Constants;
using LionShares.Helpers;
using LionShares.Interfaces;
using Xamarin.Forms;

namespace LionShares.Pages
{
    public class BaseNavigationPage : NavigationPage
    {
        #region // Constructor(s)
        public BaseNavigationPage()
        {
            Init();
        }

        public BaseNavigationPage(Page root) : base(root)
        {
            Init();
        }
        #endregion

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // remote navigation helper
            // since we cannot not push / pop globally (for whatever reason), we borrow the current navigation page to do this
            Device.BeginInvokeOnMainThread(() =>
            {
                MessagingCenter.Subscribe<Page>(this, MessagingService.NAV_REMOTE_PUSH, p =>
                {
                    Navigation.PushAsync(p);
                });

                MessagingCenter.Subscribe<string>(this, MessagingService.NAV_REMOTE_POP, s =>
                {
                    Navigation.PopAsync();
                });
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Page>(this, MessagingService.NAV_REMOTE_PUSH);
            MessagingCenter.Unsubscribe<string>(this, MessagingService.NAV_REMOTE_POP);
        }

        #region // Methods
        private void Init()
        {
            Pushed += (object sender, NavigationEventArgs e) =>
            {
                if (e.Page is IPage page)
                    page.Init();
            };

            Popped += (object sender, NavigationEventArgs e) =>
            {
                if (e.Page is IPage page)
                    page.Cleanup();
            };
        }
        #endregion
    }
}
