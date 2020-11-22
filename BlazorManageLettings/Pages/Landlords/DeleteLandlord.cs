using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Landlords
{
    public partial class DeleteLandlord
    {
        [Inject]
        public ILandlordServices LandlordServices { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        public LandlordDto Landlord { get; set; } = new LandlordDto();
        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Landlord = await LandlordServices.GetLandlordById(Id);
        }
        protected async Task HandleVilidDelete()
        {
            await LandlordServices.DelateLandlord(Id);
            NavigationManager.NavigateTo("/landlordlist");

        }
    }
}
