using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage()
        {
            InitializeComponent();
        }
    }
}
