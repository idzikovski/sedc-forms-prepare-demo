using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Services
{
    public class EstatesRepository : IRepository<Estate>
    {
        

        public async Task<List<Estate>> GetAll()
        {
            return await Task.FromResult(StaticDb.Estates);
        }

        public async Task<Estate> Insert(Estate estate)
        {
            StaticDb.Estates.Add(estate);
            return await Task.FromResult(estate);
        }

        public async Task<Estate> GetById(int id)
        {
            return await Task.FromResult(StaticDb.Estates.FirstOrDefault(x => x.Id == id));
        }

        public async Task<Estate> Update(Estate estate)
        {
            var estateToUpdate = StaticDb.Estates.FirstOrDefault(x => x.Id == estate.Id);

            estateToUpdate.EstateName = estate.EstateName;
            estateToUpdate.ContactPersonName = estate.ContactPersonName;
            estateToUpdate.ContactPersonPhone = estate.ContactPersonPhone;
            estateToUpdate.ContactPersonEmail = estate.ContactPersonEmail;
            estateToUpdate.Latitude = estate.Latitude;
            estateToUpdate.Longitude = estate.Longitude;
            estateToUpdate.Address = estate.Address;
            estateToUpdate.PhotoUrl = estate.PhotoUrl;
            estateToUpdate.Available = estate.Available;

            return await Task.FromResult(estateToUpdate);
        }

        public async Task<bool> Delete(int id)
        {
            var estateToDelete = StaticDb.Estates.FirstOrDefault(x => x.Id == id);

            if (estateToDelete != null)
            {
                StaticDb.Estates.Remove(estateToDelete);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
