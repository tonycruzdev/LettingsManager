using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Houses
{
    public partial class HouseDetail
   {
    //    [Inject]
    //    public HttpClient http { get; set; }
        public ReturnHouseWithLandlordDto House { get; set; } = new ReturnHouseWithLandlordDto();
        public LandlordDto landlord { get; set; } = new LandlordDto();
        [Inject]
        IJSRuntime JS { get; set; }
        [Parameter]
        public int Id { get; set; }
       // string url = "https://lettings-manager.azurewebsites.net";
        [Inject]
        public IHouseSevices HouseSevices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            House = await HouseSevices.GetHouseWithLandlord(Id);
            landlord = House.Landlord;
            //House = await http.GetFromJsonAsync<ReturnHouseWithLandlordDto>($"{url}/api/Houses/GetHouseWithLandlord/{Id}");
            //landlord = House.Landlord;

        }
        protected async void PrintContract()
        {
            await JS.InvokeAsync<bool>("printWindows", null);
        }
    }
}
