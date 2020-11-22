using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Landlords
{
    public partial class LandlordList
    {
        public LandlordDto[] Landlords { get; set; }
       // [Inject]
      //  public HttpClient http { get; set; }

        [Inject]
        public ILandlordServices LandlordServices { get; set; }

        public ManagePagination<LandlordDto> ManagePagination { get; set; } 
        public LandlordDto[] DataSource { get; set; }
        public LandlordDto[] DisplaySource { get; set; }

        public int PageStart { get; set; } = 0;
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; } = 8;
        public int PageCount { get; set; }
        public string Searchtxt { get; set; }
        public bool IsLoading { get; set; } = false;

        [Inject]
        NavigationManager NavigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
                
            {
                IsLoading = true;
                ManagePagination = new ManagePagination<LandlordDto>();
                
                Landlords = await LandlordServices.GetLandlords();
                ManagePagination.DataSource = Landlords;
                ManagePagination.SearchSource = Landlords;

                ManagePagination.PageCount = (int)Math.Ceiling((int)ManagePagination.SearchSource.Length / (decimal)ManagePagination.ItemPerPage);
                ManagePagination.Paginate(0);
                IsLoading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                IsLoading = false;
                throw;
            }

        }

        private void AddnewHome()
        {
            NavigationManager.NavigateTo("/addLandlord");
        }
        private void Search()
        {
            ManagePagination.SearchSource = ManagePagination.DataSource
                .Where(
                  h => h.Address1.ToLower().Contains(Searchtxt.ToLower()) 
                 || h.Name.ToLower().Contains(Searchtxt))
                .ToArray();
            ManagePagination.PageCount = (int)Math.Ceiling((int)ManagePagination.SearchSource.Length / (decimal)ManagePagination.ItemPerPage);
            ManagePagination.Paginate(0);
        }
    }
}
