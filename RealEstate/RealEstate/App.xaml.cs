using RealEstate.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            if (Preferences.ContainsKey(PreferenceKeys.IsUserLoggedInKey)
                && Preferences.Get(PreferenceKeys.IsUserLoggedInKey, false))
            {
                MainPage = new ListPage();
            }
            else
            {
                MainPage = new LoginPage();
            }
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
