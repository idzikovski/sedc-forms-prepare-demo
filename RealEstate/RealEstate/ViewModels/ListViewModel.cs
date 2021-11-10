using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private readonly int PageSize = 30;

        private readonly int ValidLocalEstateDataInMinutes;

        private readonly IEstatesService _estatesService;
        private readonly IPlatformService _platformService;
        private readonly INavigationService _navigationService;

        private bool IsLocalDataValid => DateTime.Now < _platformService.PreferencesGetDate(PreferencesKeys.LastEsateUpdateTime,
            default(DateTime)).AddMinutes(ValidLocalEstateDataInMinutes);

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

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public ListViewModel(IEstatesService estatesService,
            IPlatformService platformService,
            INavigationService navigationService)
        {
            //EstateCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));

            _estatesService = estatesService;
            _platformService = platformService;
            _navigationService = navigationService;
        }

        public async Task InitializeAsync()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullPath = Path.Combine(path, "estate_data.txt");

            List<Estate> estates;

            if (File.Exists(fullPath) && IsLocalDataValid)
            {
                estates = JsonConvert.DeserializeObject<List<Estate>>(File.ReadAllText(fullPath));
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = true;
                });

                estates = await _estatesService.GetAllEastates(); ;
                File.WriteAllText(fullPath, JsonConvert.SerializeObject(estates));
                _platformService.PreferencesSetDate(PreferencesKeys.LastEsateUpdateTime, DateTime.Now);
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                EstateCollection = new ObservableCollection<Estate>(estates);
                IsBusy = false;
            });
        }

        public ICommand SelectionChangedCommand => new Command(async (arg) =>
        {
            var estate = (Estate)arg;
            await _navigationService.NavigateAsync($"DetailsPage?Id={estate.Id}");
        });

        public ICommand DeleteCommand => new Command(async (arg) =>
        {
            var estate = (Estate)arg;
            var success = await _estatesService.DeleteEstate(estate.Id);

            if (success)
            {
                await InitializeAsync();
            }
        });
    }
}
