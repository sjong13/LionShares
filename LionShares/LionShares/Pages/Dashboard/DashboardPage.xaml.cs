using LionShares.ViewModels;
using Xamarin.Forms.Xaml;

namespace LionShares.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : DashboardPageXaml
    {
        public DashboardPage()
        {
            InitializeComponent();
        }
    }

    public abstract class DashboardPageXaml : ModelBoundContentPage<DashboardViewModel> { }
}