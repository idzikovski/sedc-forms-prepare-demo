using NSubstitute;
using NUnit.Framework;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.ViewModels;

namespace RealEstate.UnitTests
{
    public class ListViewModelTests
    {
        private INavigationService _navigationService;
        private IEstatesService _estatesService;

        private ListViewModel _sut;
        private Estate _estate;

        [SetUp]
        public void Setup()
        {
            _estatesService = Substitute.For<IEstatesService>();
            IPlatformService platformService = Substitute.For<IPlatformService>();
            _navigationService = Substitute.For<INavigationService>();

            _sut = new ListViewModel(_estatesService, platformService, _navigationService);
            _estate = new Estate { Id = 1 };
        }

        [Test]
        public void WhenSelectionIsChanged_NavigateToDetailsIsCalled()
        {
            _sut.SelectionChangedCommand.Execute(_estate);

            _navigationService.Received(1).NavigateAsync($"DetailsPage?Id={_estate.Id}");
        }

        [Test]
        public void WhenDeleteIsInvoked_DeleteIsCalledOnEstatesServices()
        {
            _sut.DeleteCommand.Execute(_estate);

            _estatesService.Received(1).DeleteEstate(_estate.Id);
        }
    }
}
