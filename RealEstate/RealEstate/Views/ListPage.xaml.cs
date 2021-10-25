using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        private readonly int PageSize = 30;

        private ObservableCollection<Estate> estatesCollection;

        public ListPage()
        {
            InitializeComponent();
            collectionView.ItemsSource = estatesCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));
        }

        void RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            if (estatesCollection.Count< EstateGenerator.Estates.Count)
            {
                AddRange(EstateGenerator.Estates.Skip(estatesCollection.Count).Take(PageSize).ToList());
            }
        }

        private void AddRange(List<Estate> estates)
        {
            foreach(var estate in estates)
            {
                estatesCollection.Add(estate);
            }
        }

        void RefreshView_Refreshing(object sender, EventArgs e)
        {
        }

        void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushAsync(new DetailsPage());
        }
    }
}
