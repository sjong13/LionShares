using Plugin.Controls.GestureFrame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace LionShares.Extensions
{
    public partial class ListItemIndicator : GestureFrame
    {
        #region // Bindable Properties
        /// <summary>
        /// PickerItemSource Property
        /// </summary>
        private static readonly string ItemsSourcePropertyName = "ItemsSource";
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(ItemsSourcePropertyName, typeof(IEnumerable), typeof(ListItemIndicator), null, propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var indicator = (ListItemIndicator)bindable;
            indicator.ListItems = newValue as IEnumerable<object>;
            indicator.AddDots();
        }

        /// <summary>
        /// Get or set the ItemsSource for the picker control; if this is set, then the entry control becomes a picker control
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// SelectedIndex Property of the PickerItemSource
        /// </summary>
        private static readonly string SelectedIndexPropertyName = "SelectedIndex";
        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(SelectedIndexPropertyName, typeof(int), typeof(ListItemIndicator), -1, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);

        /// <summary>
        /// Get or set the selected index of the PickerItemSource
        /// </summary>
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var indicator = (ListItemIndicator)bindable;
            indicator.ItemIndex = Convert.ToInt32(newValue);
            indicator.AddDots();

        }
        #endregion

        public IEnumerable<object> ListItems { get; set; }
        public int ItemIndex { get; set; }

        #region // Constructor
        public ListItemIndicator()
        {
        }
        #endregion

        #region // Methods
        protected void AddDots()
        {
            if (ListItems == null || ItemIndex == -1)
                return;

            StackLayout sl = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            int fontSize = ListItems.Count() > 45 ? 5 : 10;

            if (ListItems.Count() > 80) fontSize = 4;

            for (int i = 0; i < ListItems.Count(); i++)
            {
                Label label = new Label
                {
                    Text = "\uf10c",
                    FontFamily = "FontAwesome",
                    FontSize = fontSize,
                    TextColor = Color.Black
                };

                // add selected
                if (i == ItemIndex)
                    label.Text = "\uf111";

                sl.Children.Add(label);
            }

            // set content
            Content = sl;
        }
        #endregion
    }
}
