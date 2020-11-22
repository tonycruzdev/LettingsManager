using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Landlords
{
    public partial class LandlordDetail
    {
        [Inject]
        public ILandlordServices LandlordServices { get; set; }
        public LandlordWithHouseDto Landlord { get; set; } = new LandlordWithHouseDto();
        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Landlord = await LandlordServices.GetLandlordWithHouse(Id);
        }
    }
}
