using Foundation;
using LionShares.Interfaces;
using LionShares.iOS.Localization;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace LionShares.iOS.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            // WARNING: this code will crash app if the device does not have "en" set.
            //var netLanguage = "en";
            //if (NSLocale.PreferredLanguages.Length > 0)
            //{
            //    // turns es_ES into es-ES
            //    var pref = NSLocale.PreferredLanguages[0];
            //    netLanguage = pref.Replace("_", "-"); 

            //    // get the correct Brazilian language strings from the PCL RESX
            //    //(note the local iOS folder is still "pt")
            //    if (pref == "pt")
            //        pref = "pt-BR"; 
            //}
            //return new CultureInfo(netLanguage);

            // SAFER ALTERNATIVE
            return CultureInfo.CurrentCulture;
        }
    }
}