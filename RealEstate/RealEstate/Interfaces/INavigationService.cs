using System.Threading.Tasks;

namespace RealEstate.Interfaces
{
    public interface INavigationService
    {
        Task NavigateAsync(string route);
    }
}
