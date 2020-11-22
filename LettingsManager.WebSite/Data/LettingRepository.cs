using LettingsManager.WebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Data
{
    public class LettingRepository : ILettingRepository
    {
        private readonly LettingsManagerContext _context;
        private readonly ILogger<LettingRepository> _logger;

        public LettingRepository(LettingsManagerContext context, ILogger<LettingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<House>> GetHomes()
        {
            var results = await _context.Houses
                .AsNoTracking()
                .Include(l => l.Landlord)
                .OrderBy(h => h.Address1)
                .ToListAsync();

            return results;
        }
        public async Task<House> GetHomeById(int id)
        {
            var result = await _context.Houses
                .Include(l => l.Landlord)
                .OrderBy(h => h.Address1)
                .SingleOrDefaultAsync(h => h.Id == id);
            return result;
        }
        public async Task<House> GetHomeWithLandlordById(int id)
        {
            var result = await _context.Houses
                .Include(l => l.Landlord)
                .OrderBy(h => h.Address1)
                .SingleOrDefaultAsync(h => h.Id == id);
            return result;
        }
        public async Task<List<Landlord>> GetLandlords()
        {
            var results = await _context.Landlords
                .AsNoTracking()
                .OrderBy(l => l.Name)
                .ToListAsync();
            return results;
        }
       
        public async Task<Landlord> GetLandlordById(int Id)
        {
            var result = await _context.Landlords
                .OrderBy(l => l.Name)
                .SingleOrDefaultAsync(h => h.Id == Id);
            return result;
        }
        public async Task<Landlord> GetLandlordWithHomesById(int Id)
        {
            var result = await _context.Landlords
                .Include(h => h.Houses)
                .OrderBy(l => l.Name)
                .SingleOrDefaultAsync(h => h.Id == Id);
            return result;
        }
        public async Task<PaginatedList<House>> GetHomePagination(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            var currentSort = sortOrder;
    
            var nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var dateSort = sortOrder == "Date" ? "date_desc" : "Date";
            var LocalFilter = searchString;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            IQueryable<House> HousesIQ = from ho in _context.Houses select ho;

            if (!string.IsNullOrEmpty(searchString))
            {
                HousesIQ = HousesIQ.Where(h => h.Address1.ToUpper().Contains(searchString.ToUpper())
                                       || h.Tenant1.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    HousesIQ = HousesIQ.OrderByDescending(h => h.Address1);
                    break;
                case "Date":
                    HousesIQ = HousesIQ.OrderBy(h => h.DateFrom);
                    break;
                case "date_desc":
                    HousesIQ = HousesIQ.OrderByDescending(h => h.DateFrom);
                    break;
                default:
                    HousesIQ = HousesIQ.OrderByDescending(h => h.Id);
                    break;
            }
            int pageSize = 10;
            var houses = await PaginatedList<House>.CreateAsync(
                HousesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            return houses;
        }

        public async Task<PaginatedList<Landlord>> GetLandlordPagination(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
          
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Landlord> LandlordIQ = from land in _context.Landlords select land;

            if (!string.IsNullOrEmpty(searchString))
            {
                LandlordIQ = LandlordIQ
                    .Where(l => l.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    LandlordIQ = LandlordIQ.OrderByDescending(l => l.Name);
                    break;

                default:
                    LandlordIQ = LandlordIQ.OrderByDescending(l => l.Id);
                    break;
            }
            int pageSize = 5;
            var landlords = await PaginatedList<Landlord>.CreateAsync(
            LandlordIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            return landlords;
        }
        public void AddEntity<T>(T model)
        {
            _context.Add(model);
        }
        public void DelteEntity<T>(T model)
        {
            _context.Remove(model);
        }
        public void UpdateEntity<T>(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> HouseExists(int id)
        {
            return await _context.Houses.AnyAsync(e => e.Id == id);
        }
        public async Task<bool> LandlordExists(int id)
        {
            return await _context.Landlords.AnyAsync(e => e.Id == id);
        }


    }
}
