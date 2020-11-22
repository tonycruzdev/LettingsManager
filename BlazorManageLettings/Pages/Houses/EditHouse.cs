using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Houses
{
    public partial class EditHouse
    {
        //[Inject]
       // public HttpClient http { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        public HouseEditDto House { get; set; } = new HouseEditDto();
        [Parameter]
        public int Id { get; set; }
        public LandlordDto[] Landlords { get; set; } = new LandlordDto[] { };
        //string url = "https://lettings-manager.azurewebsites.net";

        [Inject]
        public IHouseSevices HouseSevices { get; set; }
        [Inject]
        public ILandlordServices LandlordServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Landlords = await LandlordServices.GetLandlords();
            //Landlords = await http.GetFromJsonAsync<LandlordDto[]>($"{url}/api/Landlords/GetLandlords");

            House = await HouseSevices.GetHouseById(Id); 
            //House = await http.GetFromJsonAsync<HouseEditDto>($"{url}/api/Houses/GetHouseById/{Id}");
        }
        protected async Task HandleVilideSubmit()
        {
            await HouseSevices.UpdateHome(House);
           // await http.PutAsJsonAsync($"{url}/api/Houses/UpdateHouse/{Id}", House);
            NavigationManager.NavigateTo("/listhomes");

        }
    }
}
