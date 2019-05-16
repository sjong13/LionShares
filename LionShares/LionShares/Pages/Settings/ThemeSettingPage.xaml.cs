using Plugin.Shared.Extensions;
using LionShares.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamo.Framework.Core;

namespace LionShares.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeSettingPage : ThemeSettingPageXaml
    {
        public ThemeSettingPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
            list.SelectedItem = null;
        }
    }

    public abstract class ThemeSettingPageXaml : ModelBoundContentPage<ThemeSettingViewModel> { }
}


namespace LionShares.ViewModels
{
    public class ThemeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color AccentColor { get; set; }
        public Color BaseTextColor { get; set; }
        public Color BasePageColor { get; set; }
        public Color MainWrapperBackgroundColor { get; set; }
    }

    public class ThemeSettingViewModel : BaseViewModel
    {
        public IEnumerable<ThemeData> ThemeList
        {
            get
            {
                return
                ThemeHelper.GetThemes()
                    .Select((theme, index) => new ThemeData
                    {
                        Id = index,
                        Name = theme.GetType().Name.InsertSpaceToCamelCase(),
                        AccentColor = (Color)theme["AccentColor"],
                        BaseTextColor = (Color)theme["BaseTextColor"],
                        BasePageColor = (Color)theme["BasePageColor"],
                        MainWrapperBackgroundColor = (Color)theme["MainWrapperBackgroundColor"],
                    })
                    .OrderBy(o => o.Name);
            }
        }

        #region // Constructor(s)
        public ThemeSettingViewModel()
        {
            Title = "Theme Setting";
        }
        #endregion        
    }
}