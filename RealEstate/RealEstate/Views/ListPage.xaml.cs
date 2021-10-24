using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            collectionView.ItemsSource = EstateGenerator.GenerateEstates();
        }
    }
}
