using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Houses
{
    public partial class CreateHouse
    {
        //[Inject]
        //public HttpClient http { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILandlordServices LandlordServices { get; set; }
        [Inject]
        public IHouseSevices HouseSevices { get; set; }

        public HouseEditDto House { get; set; } = new HouseEditDto();
        public LandlordDto[] Landlords { get; set; } = new LandlordDto[] { };

        protected override async Task OnInitializedAsync()
        {
            House.LandlordId = 1;
            House.Address1 = "";
            Landlords = await LandlordServices.GetLandlords();
            House.DateFrom = DateTime.Now;
            House.DateTo = DateTime.Now.AddYears(1);
            // House.LandlordId = 0;
        }
        protected async Task HandleVilideSubmit()
        {
            await HouseSevices.AddHome(House);
            NavigationManager.NavigateTo("/listhomes");
            //    http.PostAsJsonAsync($"{url}/api/Houses/addHouse", House);
        }
    }
}
