using BlazorManageLettings.Dto;
using System.Threading.Tasks;

namespace BlazorManageLettings.Services
{
    public interface IHouseSevices
    {
        Task<ReturnHousesDto> AddHome(HouseEditDto Home);
        Task DelateHouse(int Id);
        Task<HouseEditDto> GetHouseById(int Id);
        Task<ReturnHouseWithLandlordDto> GetHouseWithLandlord(int Id);

        Task<ReturnHousesDto[]> GetHouses();
        Task UpdateHome(HouseEditDto home);
    }
}