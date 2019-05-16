using LionShares.ViewModels;
using System;
using Xamarin.Forms;

namespace LionShares.Pages
{
    public abstract class ModelBoundContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the generically typed ViewModel from the underlying BindingContext.
        /// </summary>
        /// <value>The generically typed ViewModel.</value>
        protected TViewModel ViewModel
        {
            get { return base.BindingContext as TViewModel; }
        }

        /// <summary>
        /// Sets the underlying BindingContext as the defined generic type.
        /// </summary>
        /// <value>The generically typed ViewModel.</value>
        /// <remarks>Enforces a generically typed BindingContext, instead of the underlying loosely object-typed BindingContext.</remarks>
        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Sets the flag to inject a busy indicator while ViewMOdel is loading
        /// </summary>
        public bool IsBusyIndicatorEnabled { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // inject busy indicator to all model bound content pages
            // if it has a RelativeLayout and IsBusyIndicatorEnabled = true
            if (IsBusyIndicatorEnabled && Content is RelativeLayout)
            {
                RelativeLayout layout = (RelativeLayout)Content;
                layout.Children.Add(BusyIndicator.Instance,
                    Constraint.RelativeToParent((p) => { return p.X; }),
                    Constraint.RelativeToParent((p) => { return p.Y; }),
                    Constraint.RelativeToParent((p) => { return p.Width; }),
                    Constraint.RelativeToParent((p) => { return p.Height; }));
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected async virtual void OnCancelButtonClicked(object s, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected async virtual void OnCancelModalButtonClicked(object s, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}