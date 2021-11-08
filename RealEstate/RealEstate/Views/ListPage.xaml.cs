using System.Linq;
using RealEstate.Models;
using RealEstate.ViewModels;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await ((ListViewModel)BindingContext).InitializeAsync();
        }
    }
}
