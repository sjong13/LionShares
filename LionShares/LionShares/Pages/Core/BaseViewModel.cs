using LionShares.Interfaces;
using LionShares.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LionShares.ViewModels
{
    public class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly IDependencyService _dependencyService;
        public IDependencyService DependencyService
        {
            get { return _dependencyService; }
        }

        #region // Constructor        
        public BaseViewModel(INavigation navigation = null) : this(new DependencyServiceWrapper())
        {
            Navigation = navigation;
        }

        public BaseViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
        }
        #endregion

        #region // Navigation 
        public INavigation Navigation { get; set; }

        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopAsync();
        }
        #endregion

        #region // Property Info
        public bool IsInitialized { get; set; }

        bool canLoadMore;
        /// <summary>
        /// Gets or sets the "CanLoadMore" property
        /// </summary>
        /// <value>The isbusy property.</value>
        public const string CanLoadMorePropertyName = "CanLoadMore";

        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value, CanLoadMorePropertyName); }
        }

        bool isBusy;
        /// <summary>
        /// Gets or sets the "IsBusy" property
        /// </summary>
        /// <value>The isbusy property.</value>
        public const string IsBusyPropertyName = "IsBusy";

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value, IsBusyPropertyName); }
        }

        string title = string.Empty;
        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>
        public const string TitlePropertyName = "Title";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value, TitlePropertyName); }
        }

        string subTitle = string.Empty;
        /// <summary>
        /// Gets or sets the "Subtitle" property
        /// </summary>
        public const string SubtitlePropertyName = "Subtitle";

        public string Subtitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value, SubtitlePropertyName); }
        }

        string icon = null;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public const string IconPropertyName = "Icon";

        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value, IconPropertyName); }
        }

        protected void SetProperty<U>(
            ref U backingStore, U value,
            string propertyName,
            Action onChanged = null,
            Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            if (onChanging != null)
                onChanging(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }
        #endregion

        #region INotifyPropertyChanging implementation

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        #endregion

        public void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
