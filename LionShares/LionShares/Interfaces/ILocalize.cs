using System.Globalization;

namespace LionShares.Interfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}