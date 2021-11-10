using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Models;

namespace RealEstate.Interfaces
{
    public interface IEstatesService
    {
        Task<User> Login(AuthenticateModel authenticateModel);

        Task<List<Estate>> GetAllEastates();

        Task<Estate> GetEstate(long id);

        Task<Estate> CreateEstate(Estate estate);

        Task<Estate> UpdateEstate(Estate estate);

        Task<bool> DeleteEstate(long id);
    }
}
