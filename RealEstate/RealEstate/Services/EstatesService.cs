using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class EstatesService
    {
        private readonly RestClientService _restClientService;

        public EstatesService()
        {
            _restClientService = new RestClientService();
        }

        public async Task<User> Login(AuthenticateModel authenticateModel)
        {
            return await _restClientService.PostAsync<User>("estates/authenticate", authenticateModel);
        }

        public async Task<List<Estate>> GetAllEstates()
        {
            return await _restClientService.GetAsync<List<Estate>>("estates");
        }

        public async Task<Estate> GetEstate(long id)
        {
            return await _restClientService.GetAsync<Estate>($"estates/{id}");
        }

        public async Task<Estate> CreateEstate(Estate estate)
        {
            return await _restClientService.PostAsync<Estate>("estates/create", estate);
        }

        public async Task<Estate> UpdateEstate(Estate estate)
        {
            return await _restClientService.PatchAsync<Estate>("estates/update", estate);
        }

        public async Task<bool> DeleteEstate(long id)
        {
            return await _restClientService.DeleteAsync<bool>($"estates/delete/{id}");
        }
    }
}
