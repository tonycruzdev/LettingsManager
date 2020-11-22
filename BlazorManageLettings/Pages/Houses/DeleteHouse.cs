using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Houses
{
    public partial class DeleteHouse
    {
       // [Inject]
      //  public HttpClient http { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        public HouseEditDto House { get; set; } = new HouseEditDto();
        [Parameter]
        public int Id { get; set; }
        //string url = "https://lettings-manager.azurewebsites.net";
        [Inject]
        public IHouseSevices HouseSevices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            House = await HouseSevices.GetHouseById(Id);
           // House = await http.GetFromJsonAsync<HouseEditDto>($"{url}/api/Houses/GetHouseById/{Id}");

        }
        protected async Task HandleVilidDelete()
        {
            await HouseSevices.DelateHouse(Id);
            //await http.DeleteAsync($"{url}/api/Houses/DeleteHouse/{Id}");

            NavigationManager.NavigateTo("/listhomes");

        }
    }
}
