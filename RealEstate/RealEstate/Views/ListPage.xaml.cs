using System.Linq;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListViewModel(Startup.ServiceProvider.GetService<IEstatesService>(),
                Startup.ServiceProvider.GetService<IPlatformService>(),
                Startup.ServiceProvider.GetService<INavigationService>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (ListViewModel)BindingContext;
            await viewModel.InitializeAsync();
        }
    }
}
