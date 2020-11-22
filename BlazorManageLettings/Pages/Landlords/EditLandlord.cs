using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Landlords
{
    public partial class EditLandlord
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
        protected async Task HandleVilideSubmit()
        {
            await LandlordServices.SaveLandlord(Landlord);
            NavigationManager.NavigateTo("/landlordlist");
        }

    }
}
