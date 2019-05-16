using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LionShares
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusyIndicator : Grid
    {
        #region // statics
        private static BusyIndicator _instance = null;
        private static readonly object padlock = new object();

        public static BusyIndicator Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new BusyIndicator();
                    }
                    return _instance;
                }
            }
        }
        #endregion

        public BusyIndicator()
        {
            InitializeComponent();
        }
    }
}