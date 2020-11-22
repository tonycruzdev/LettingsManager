using LettingsManager.WebSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Data
{
    public interface ILettingRepository
    {
       
        Task<House> GetHomeById(int id);
        Task<List<House>> GetHomes();
        Task<Landlord> GetLandlordById(int Id);
        Task<List<Landlord>> GetLandlords();
        Task<PaginatedList<House>> GetHomePagination(string sortOrder, string currentFilter, string searchString, int? pageIndex);
        Task<PaginatedList<Landlord>> GetLandlordPagination(string sortOrder, string currentFilter, string searchString, int? pageIndex);
       
        Task<bool> LandlordExists(int id);
        Task<bool> HouseExists(int id);

        void AddEntity<T>(T model);
        void DelteEntity<T>(T model);
        void UpdateEntity<T>(T Entity);
        Task<bool> SaveAllAsync();
        Task<Landlord> GetLandlordWithHomesById(int Id);
    }
}