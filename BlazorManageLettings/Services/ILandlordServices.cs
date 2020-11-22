using BlazorManageLettings.Dto;
using System.Threading.Tasks;

namespace BlazorManageLettings.Services
{
    public interface ILandlordServices
    {
        Task<LandlordDto> AddLandlord(LandlordDto landlord);
        Task DelateLandlord(int Id);
        Task<LandlordDto> GetLandlordById(int Id);
        Task<LandlordDto[]> GetLandlords();
        Task<LandlordWithHouseDto> GetLandlordWithHouse(int Id);
        Task SaveLandlord(LandlordDto landlord);
    }
}