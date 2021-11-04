using Xamarin.Forms;
using XamarinFormsSandbox.FormsGeneral;

namespace XamarinFormsSandbox
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CascadingStylesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
