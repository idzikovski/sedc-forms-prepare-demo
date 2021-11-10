using System;
using NSubstitute;
using NUnit.Framework;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.ViewModels;

namespace RealEstate.UnitTests
{
    public class LoginViewModelTests
    {
        private INavigationService _navigationService;
        private LoginViewModel _sut;
        private IEstatesService _estatesService;

        [SetUp]
        public void Setup()
        {
            _estatesService = Substitute.For<IEstatesService>();
            IPlatformService platformService = Substitute.For<IPlatformService>();
            _navigationService = Substitute.For<INavigationService>();

            _sut = new LoginViewModel(_estatesService, platformService, _navigationService);
        }

        [Test]
        public void WhenButtonIsCLicked_LoginIsCalled()
        {
            _sut.Username = "User";
            _sut.Password = "Pass";

            _sut.LoginCommand.Execute(null);

            _estatesService.Received(1).Login(
                Arg.Is<AuthenticateModel>(x=> x.Username == _sut.Username && x.Password == _sut.Password));
        }

        [Test]
        public void WhenCredentialsAreCorrect_NavigateToListViewIsCalled()
        {
            AuthenticateModel authenticateModel = new AuthenticateModel { Username = "User", Password = "Pass" };

            _estatesService.Login(Arg.Is<AuthenticateModel>(x => x.Username == authenticateModel.Username && x.Password == authenticateModel.Password))
                .Returns(new User { Id = 1, FirstName = "Test", LastName = "Test", Username = "User" });
            _sut.Username = authenticateModel.Username;
            _sut.Password = authenticateModel.Password;

            _sut.LoginCommand.Execute(null);

            _navigationService.Received(1).NavigateAsync("//ListPage");
        }
    }
}
