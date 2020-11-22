using BlazorManageLettings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorManageLettings.Services
{
    public class LandlordServices : ILandlordServices
    {
        private readonly HttpClient _client;
        public LandlordServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<LandlordDto[]> GetLandlords()
        {
            return await _client.GetFromJsonAsync<LandlordDto[]>("/api/Landlords/GetLandlords");
        }
        public async Task<LandlordDto> GetLandlordById(int Id)
        {
            return await _client.GetFromJsonAsync<LandlordDto>($"/api/Landlords/GetLandlord/{Id}");
        }
        public async Task SaveLandlord(LandlordDto landlord)
        {
            await _client.PutAsJsonAsync($"/api/Landlords/UpdateLandlord/{landlord.Id}", landlord);
        }
        public async Task<LandlordDto> AddLandlord(LandlordDto landlord)
        {
            var result = await _client.PostAsJsonAsync("/api/Landlords/AddLandlord", landlord);
            var Resultlandlord = await result.Content.ReadFromJsonAsync<LandlordDto>();
            return Resultlandlord;
        }
        public async Task DelateLandlord(int Id)
        {
             await _client.DeleteAsync($"/api/Landlords/DeleteLandlord/{Id}");
        }
        public async Task<LandlordWithHouseDto> GetLandlordWithHouse(int Id)
        {
            return await _client.GetFromJsonAsync<LandlordWithHouseDto>($"api/Landlords/GetLandlordWithHouse/{Id}");
        }

    }
}
