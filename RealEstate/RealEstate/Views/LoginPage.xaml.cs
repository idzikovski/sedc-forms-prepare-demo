using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set(PreferenceKeys.IsUserLoggedInKey, true);
            Application.Current.MainPage = new NavigationPage(new ListPage());
        }
    }
}
