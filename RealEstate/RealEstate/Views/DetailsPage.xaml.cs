using System;
using System.Collections.Generic;
using RealEstate.Components;
using Xamarin.Forms;

namespace RealEstate.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        void ChipView_ChipDeleted(object sender, EventArgs e)
        {
            if (flexLayout.Children.Contains((ChipView)sender))
            {
                flexLayout.Children.Remove((ChipView)sender);
            }
        }
    }
}
