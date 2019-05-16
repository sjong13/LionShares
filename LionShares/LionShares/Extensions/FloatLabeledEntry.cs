using Plugin.Controls.FloatingLabelEntry.Base;
using Plugin.Controls.FloatingLabelEntry.Enumerations;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace LionShares.Extensions
{
    public class FloatLabeledEntry : FloatingLabelEntryBase
    {
        public object Tag { get; set; }
        public string LabelId { get; set; }
        public bool IsSelected { get; set; }

        public FloatLabeledEntry()
        {
            // NOTE: provide initial values; Styles from App.xaml will override this if exist
            HeightRequest = 46;
            FontSize = 16;
            CornerRadius = 0f;
            BorderColor = Color.FromHex("#dedede");
            BorderThickness = 0;
            BottomBorderThickness = 1;

            // turn on validation
            MustValidate = true;
            InputValidator = InputValidatorDelegate;

            var errorEntryStateProperties = new FloatingLabelEntryStateProperties { BorderColor = Color.Red };
            var normalEntryStateProperties = new FloatingLabelEntryStateProperties { BorderColor = Color.FromHex("#dedede") };

            AddPropertiesForState(errorEntryStateProperties, FloatingLabelEntryState.Error);
            AddPropertiesForState(normalEntryStateProperties, FloatingLabelEntryState.Neutral);
        }

        public FloatingLabelEntryState InputValidatorDelegate(string inputValue, string regEx = null)
        {
            if (!string.IsNullOrEmpty(regEx))
            {
                inputValue = inputValue ?? string.Empty;
                Regex r = new Regex(regEx);
                Match match = r.Match(inputValue);

                if ((regEx == "^$" && (match.Success))      // match IsRequired
                    || (regEx != "^$" && (!match.Success))) // match specific expression
                    return FloatingLabelEntryState.Error;
            }

            return FloatingLabelEntryState.Neutral;
        }
    }
}
