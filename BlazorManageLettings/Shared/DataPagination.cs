using BlazorManageLettings.Dto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Shared
{
    public partial class DataPagination
    {
        [Parameter]
        public ManagePagination<LandlordDto> ManagePagination { get; set; } = new ManagePagination<LandlordDto>();
    }
}
