using Xamarin.Forms;

namespace LionShares
{
    public partial class Badge : ContentView
    {
        public Badge()
        {
            InitializeComponent();
        }

        public static BindableProperty BadgeAutoHideProperty =
            BindableProperty.Create(
                nameof(BadgeAutoHide),
                typeof(bool),
                typeof(Badge),
                defaultValue: true,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) => ((Badge)bindable).UpdateVisibility()
            );

        public bool BadgeAutoHide
        {
            get { return (bool)GetValue(BadgeAutoHideProperty); }
            set { SetValue(BadgeAutoHideProperty, value); }
        }

        public static BindableProperty BadgeBackgroundColorProperty =
            BindableProperty.Create(
                nameof(BadgeBackgroundColor),
                typeof(Color),
                typeof(Badge),
                defaultValue: Color.Default,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) => ((Badge)bindable).LabelBackground.TextColor = (Color)newValue
            );

        public Color BadgeBackgroundColor
        {
            get { return (Color)GetValue(BadgeBackgroundColorProperty); }
            set { SetValue(BadgeBackgroundColorProperty, value); }
        }

        public static BindableProperty BadgeTextColorProperty =
            BindableProperty.Create(
                nameof(BadgeTextColor),
                typeof(Color),
                typeof(Badge),
                defaultValue: Color.Default,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) => ((Badge)bindable).LabelText.TextColor = (Color)newValue
            );

        public Color BadgeTextColor
        {
            get { return (Color)GetValue(BadgeTextColorProperty); }
            set { SetValue(BadgeTextColorProperty, value); }
        }

        public static BindableProperty BadgeTextProperty =
            BindableProperty.Create(
                nameof(BadgeText),
                typeof(string),
                typeof(Badge),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var badge = (Badge)bindable;
                    badge.LabelText.Text = (string)newValue;
                    badge.UpdateVisibility();
                }
            );

        public string BadgeText
        {
            get { return (string)GetValue(BadgeTextProperty); }
            set { SetValue(BadgeTextProperty, value); }
        }

        private void UpdateVisibility()
        {
            Root.IsVisible = BadgeAutoHide ?
                !string.IsNullOrWhiteSpace(LabelText.Text) && LabelText.Text.Trim() != "0" :
                Root.IsVisible = true;
        }
    }
}

