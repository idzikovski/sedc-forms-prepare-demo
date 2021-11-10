using System;
using System.Windows.Input;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.Services;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IEstatesService _estatesService;
        private readonly IPlatformService _platformService;
        private readonly INavigationService _navigationService;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel(IEstatesService estatesService,
            IPlatformService platformService,
            INavigationService navigationService)
        {
            _estatesService = estatesService;
            _platformService = platformService;
            _navigationService = navigationService;

            if (_platformService.PreferencesContainsKey(PreferencesKeys.IsUserLoggedIn)
                && _platformService.PreferencesGetBool(PreferencesKeys.IsUserLoggedIn, false))
            {
                _navigationService.NavigateAsync("//ListPage");
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            var user = await _estatesService.Login(new AuthenticateModel { Username = Username, Password = Password });

            if (user != null)
            {
                await _platformService.SecureSetAsync(PreferencesKeys.UsernameKey, user.Username);
                await _platformService.SecureSetAsync(PreferencesKeys.PasswordKey, Password);

                _platformService.PreferencesSetBool(PreferencesKeys.IsUserLoggedIn, true);
                await _navigationService.NavigateAsync("//ListPage");
            }
        });
    }
}
