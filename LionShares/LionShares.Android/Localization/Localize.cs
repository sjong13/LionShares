using LionShares.Android.Localization;
using LionShares.Interfaces;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace LionShares.Android.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            //// turns pt_BR into pt-BR
            //var androidLocale = Java.Util.Locale.Default;
            //var netLanguage = androidLocale.ToString().Replace("_", "-"); 

            //return new CultureInfo(netLanguage);

            return CultureInfo.CurrentCulture;
        }
    }
}