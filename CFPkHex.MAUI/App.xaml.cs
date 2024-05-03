using CFPkHex.MAUI.ViewModels;

namespace CFPkHex.MAUI
{
    public partial class App : Application
    {
        public App(MainPageViewModel viewModel)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(viewModel));
        }
    }
}
