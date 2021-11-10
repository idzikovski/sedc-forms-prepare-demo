using System;
using RealEstate.Interfaces;
using RealEstate.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Startup.ServiceProvider.GetService<IEstatesService>(),
                Startup.ServiceProvider.GetService<IPlatformService>(),
                Startup.ServiceProvider.GetService<INavigationService>());
        }
    }
}
