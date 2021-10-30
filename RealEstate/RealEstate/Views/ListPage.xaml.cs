using System.Linq;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Estate selectedEstate = e.CurrentSelection.FirstOrDefault() as Estate;

            if (selectedEstate == null)
                return;

            try
            {
                Navigation.PushAsync(new DetailsPage(selectedEstate));
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            collectionView.SelectedItem = null;
        }
    }
}
