using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RealEstate.Models;
using Xamarin.Forms;

namespace RealEstate.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private readonly int PageSize = 30;

        private ObservableCollection<Estate> _estatesCollection;
        public ObservableCollection<Estate> EstatesCollection
        {
            get => _estatesCollection;
            set
            {
                _estatesCollection = value;
                OnPropertyChanged(nameof(EstatesCollection));
            }
        }

        public ICommand RemainingItemsThresholdReachedCommand => new Command(() =>
        {
            if (EstatesCollection.Count < EstateGenerator.Estates.Count)
            {

                var nexList = EstateGenerator.Estates.Skip(EstatesCollection.Count).Take(PageSize);

                foreach (var estate in nexList)
                {
                    EstatesCollection.Add(estate);
                }
            }
        });

        public ListViewModel()
        {
            EstatesCollection = new ObservableCollection<Estate>(EstateGenerator.Estates.Take(PageSize));
        }
    }
}
