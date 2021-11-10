using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using RealEstate.Models;
using RealEstate.Services;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(EstateString), nameof(Estate))]
    [QueryProperty(nameof(Action), nameof(Action))]
    public class UpsertViewModel : BaseViewModel
    {
        private EstatesService _estatesService;

        private string _action;
        public string Action
        {
            get => _action;
            set
            {
                _action = Uri.UnescapeDataString(value);

                if (Action == "Create")
                {
                    ButtonAction = new Command(async () => await CreateEstate());
                    Title = "Create";
                }
                else
                {
                    ButtonAction = new Command(async () => await UpdateEstate());
                    Title = "Update";
                    InitializeForm();
                }

                OnPropertyChanged(Action);
            }
        }

        private Estate _estate;
        private string _estateString;
        public string EstateString
        {
            get => _estateString;
            set
            {
                _estateString = Uri.UnescapeDataString(value);
                _estate = JsonConvert.DeserializeObject<Estate>(_estateString);
            }
        }

        private string _estateName;
        public string EstateName
        {
            get => _estateName;
            set
            {
                _estateName = value;
                OnPropertyChanged(nameof(EstateName));
            }
        }

        private string _contactName;
        public string ContactName
        {
            get => _contactName;
            set
            {
                _contactName = value;
                OnPropertyChanged(nameof(ContactName));
            }
        }

        private ICommand _buttonAction;
        public ICommand ButtonAction
        {
            get => _buttonAction;
            set
            {
                _buttonAction = value;
                OnPropertyChanged(nameof(ButtonAction));
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public UpsertViewModel()
        {
            _estatesService = new EstatesService();
        }

        private async Task CreateEstate()
        {
            Estate newEstate = new Estate
            {
                Id = 255,
                EstateName = EstateName,
                ContactPersonName = ContactName
            };

            Estate result = await _estatesService.CreateEstate(newEstate);

            if (result != null)
            {
                await Shell.Current.GoToAsync("../..");
            }
        }

        private async Task UpdateEstate()
        {
            _estate.EstateName = EstateName;
            _estate.ContactPersonName = ContactName;
            Estate result = await _estatesService.UpdateEstate(_estate);

            if (result != null)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        private void InitializeForm()
        {
            EstateName = _estate.EstateName;
            ContactName = _estate.ContactPersonName;
        }
    }
}
