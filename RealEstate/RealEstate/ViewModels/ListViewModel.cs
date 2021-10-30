using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using RealEstate.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private readonly int PageSize = 30;

        private readonly int ValidLocalDataTimeInMinutes = 2;

        private readonly string EstatesFilePath;

        private bool IsLocalDataValid => DateTime.Now < Preferences.Get(PreferenceKeys.LastEstateUpdateTimeKey, default(DateTime))
            .AddMinutes(ValidLocalDataTimeInMinutes);

        public ICommand RemainingItemsThresholdReachedCommand => new Command(() =>
        {
            if (EstateCollection.Count < EstateGenerator.Estates.Count)
            {

                var nexList = EstateGenerator.Estates.Skip(EstateCollection.Count).Take(PageSize);

                foreach (var estate in nexList)
                {
                    EstateCollection.Add(estate);
                }
            }
        });

        private ObservableCollection<Estate> _estatesCollection;
        public ObservableCollection<Estate> EstateCollection
        {
            get => _estatesCollection;
            set
            {
                _estatesCollection = value;
                OnPropertyChanged(nameof(EstateCollection));
            }
        }

        public ListViewModel()
        {
            //EstateCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));

            EstatesFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "estate_data.txt");

            List<Estate> estates;

            if (File.Exists(EstatesFilePath) && IsLocalDataValid)
            {
                estates = JsonConvert.DeserializeObject<List<Estate>>(File.ReadAllText(EstatesFilePath));
            }
            else
            {
                estates = EstateGenerator.Estates;
                File.WriteAllText(EstatesFilePath, JsonConvert.SerializeObject(estates));
                Preferences.Set(PreferenceKeys.LastEstateUpdateTimeKey, DateTime.Now);
            }

            EstateCollection = new ObservableCollection<Estate>(estates);
        }
    }
}
