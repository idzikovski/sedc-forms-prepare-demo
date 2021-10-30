using System.Collections.Generic;
using RealEstate.Models;

namespace RealEstate.ViewModels
{
    public class DetailsViewModel
    {
        public string EstateName { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonPhone { get; set; }

        public string ContactPersonEmail { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public string PhotoUrl { get; set; }

        public List<string> Tags => new List<string>
        {
            "Apartment",
            "City",
            "Suburbs",
            "Premium",
            "Expensive"
        };

        public DetailsViewModel(Estate estate)
        {
            EstateName = estate.EstateName;
            ContactPersonName = estate.ContactPersonName;
            ContactPersonPhone = estate.ContactPersonPhone;
            ContactPersonEmail = estate.ContactPersonEmail;
            Latitude = estate.Latitude;
            Longitude = estate.Longitude;
            Address = estate.Address;
            PhotoUrl = estate.PhotoUrl;
        }
    }
}
