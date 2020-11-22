using BlazorManageLettings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorManageLettings.Services
{
    public class HouseSevices : IHouseSevices
    {
        //private readonly IHttpClientFactory _clientFactor;
        private readonly HttpClient _client;

        public HouseSevices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ReturnHousesDto[]> GetHouses()
        {
            return await _client.GetFromJsonAsync<ReturnHousesDto[]>($"api/Houses/GetHouses");
        }
        public async Task<HouseEditDto> GetHouseById(int Id)
        {
            return await _client.GetFromJsonAsync<HouseEditDto>($"/api/Houses/GetHouseById/{Id}");
        }
        public async Task<ReturnHouseWithLandlordDto> GetHouseWithLandlord(int Id)
        {
            return await _client.GetFromJsonAsync<ReturnHouseWithLandlordDto>($"/api/Houses/GetHouseWithLandlord/{Id}");
        }

        public async Task UpdateHome(HouseEditDto home)
        {
            await _client.PutAsJsonAsync($"/api/Houses/UpdateHouse/{home.Id}", home);
        }
        public async Task<ReturnHousesDto> AddHome(HouseEditDto Home)
        {
            var result = await _client.PostAsJsonAsync("/api/Houses/AddHouse", Home);
            var ResultHome = await result.Content.ReadFromJsonAsync<ReturnHousesDto>();
            return ResultHome;
        }
        public async Task DelateHouse(int Id)
        {
            await _client.DeleteAsync($"/api/Houses/DeleteHouse/{Id}");
        }
    }
}
