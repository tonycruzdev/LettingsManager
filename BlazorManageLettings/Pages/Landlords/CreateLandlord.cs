using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Landlords
{
    public partial class CreateLandlord
    {
        [Inject]
        public ILandlordServices LandlordServices { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }
        public LandlordDto Landlord { get; set; } = new LandlordDto();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        //protected override async Task OnInitializedAsync()
        //{
        //    Landlord.Id = 0;
        //}
        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();
        //}
        protected async Task HandleVilideSubmit()
        {
            await LandlordServices.AddLandlord(Landlord);
            NavigationManager.NavigateTo("/landlordlist");
        }
        protected async Task HandleInvalidSubmit()
        {
            await LandlordServices.AddLandlord(Landlord);
            NavigationManager.NavigateTo("/landlordlist");
        }

    }
}
