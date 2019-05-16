using LionShares.Interfaces;
using LionShares.Localization;
using LionShares.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LionShares.Pages
{
    public class RootPage : MasterDetailPage
    {
        #region // Fields
        private Type _defaultPageType;
        private Type _defaultPageViewModelType;
        #endregion

        #region // Properties
        private Dictionary<Type, NavigationPage> Pages { get; set; }
        #endregion

        #region // Constructor(s)
        public RootPage()
        {
            _defaultPageType = typeof(DashboardPage);
            _defaultPageViewModelType = typeof(DashboardViewModel);
            Pages = new Dictionary<Type, NavigationPage>();
            Master = new MenuPage(this, _defaultPageType);

            // add this if you want to hide menu in iPad landscape mode
            // by default the menu will be visible in landscape mode
            MasterBehavior = MasterBehavior.Popover;

            // disabled swipe if set to false
            if (Device.RuntimePlatform == Device.Android)
            {
                IsGestureEnabled = true;
            }
            else
            {
                IsGestureEnabled = false;
            }

            // seting base view model
            BindingContext = new BaseViewModel(Navigation)
            {
                Title = TextResources.AppNameText,
                Icon = "hamburguer_icon.png"
            };

            // default page
            // not needed - menu loads a default
            //NavigateToLandingPage(defaultPageType, defaultPageViewModelType);
        }
        #endregion

        #region // Methods
        private async void NavigateToLandingPage(Type pageType, Type bindingType = null, string title = null)
        {
            await NavigateAsync(pageType, bindingType, title);
        }

        private void SetDetailIfNull(Page page)
        {
            if (Detail == null && page != null)
                Detail = page;
        }

        public void ClearPageEvents()
        {
            if (Detail != null && Detail is BaseNavigationPage)
            {
                var dt = (BaseNavigationPage)Detail;
                if (dt.CurrentPage is IPage)
                {
                    var page = (IPage)dt.CurrentPage;
                    page.Cleanup();
                }
            }
        }

        public void ClearPages()
        {
            Pages.Clear();
        }

        private void InitPageEvents()
        {
            if (Detail != null && Detail is BaseNavigationPage)
            {
                var dt = (BaseNavigationPage)Detail;
                if (dt.CurrentPage is IPage)
                {
                    var page = (IPage)dt.CurrentPage;
                    page.Init();
                }
            }
        }

        public async Task NavigateAsync(Type pageType, Type bindingType = null, string title = null)
        {
            // handles navigation to new menu page
            if (!Pages.ContainsKey(pageType))
            {
                // create page instance
                var p = Activator.CreateInstance(pageType) as Page;

                // set title; 
                // if p.Title is not set here; it will be taken from the pageType xaml or cs page.
                if (title != null) p.Title = title;

                // create binding context 
                if (bindingType != null)
                {
                    var vm = Activator.CreateInstance(bindingType) as IViewModel;
                    vm.Navigation = this.Navigation;
                    p.BindingContext = vm;
                }

                // set
                var page = new BaseNavigationPage(p);
                page.Title = p.Title;
                SetDetailIfNull(page);
                Pages.Add(pageType, page);
            }

            // if page  already exist, unregister its events before loading it (only for main level menu pages)
            // for child pages that is push & pop - BaseNavigationPage.cs handles push/pop init/cleanup
            // logout page also calls ClearPageEvents.
            ClearPageEvents();

            // do nothing if page is null
            Page newPage = Pages[pageType];
            if (newPage == null)
                return;

            // pop to root for Windows Phone
            // if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            if (Detail != null && Device.RuntimePlatform == Device.UWP)
                await Detail.Navigation.PopToRootAsync();

            // set new page as Detail page
            // hide menu
            Detail = newPage;
            IsPresented = false;

            // registered new page events (only for main level menu pages)
            // for child pages that is push & pop - BaseNavigationPage.cs handles push/pop init/cleanup
            InitPageEvents();

            // set current page title
            App.ActivePageTitle = newPage.Title;

            //if (Device.Idiom != TargetIdiom.Tablet)
            //    IsPresented = false;
        }
        #endregion       
    }
}
