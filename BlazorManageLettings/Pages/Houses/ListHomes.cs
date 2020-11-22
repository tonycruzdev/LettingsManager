using Blazored.Toast.Services;
using BlazorManageLettings.Dto;
using BlazorManageLettings.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorManageLettings.Pages.Houses
{
    public partial class ListHomes
    {
        [Inject]
        public IHouseSevices HouseSevices { get; set; }
        public ReturnHousesDto[] Houses { get; set; }
       // [Inject]
       // public HttpClient http { get; set; }
        public ReturnHousesDto[] DataSource { get; set; }
        public ReturnHousesDto[] SearchSource { get; set; }
        public ReturnHousesDto[] DisplaySource { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        public int PageStart { get; set; } = 0;
        public int  CurrentPage { get; set; }
        public int ItemPerPage { get; set; } = 10;
        public int PageCount { get; set; }
        public string Searchtxt { get; set; }
        public bool IsLoading { get; set; } = false;

        [Inject]
        NavigationManager NavigationManager { get; set; }


       // string url = "https://lettings-manager.azurewebsites.net";
        protected override async Task OnInitializedAsync()
        {
            try
            {
                IsLoading = true;
                Houses = await HouseSevices.GetHouses(); 
                //Houses = await http.GetFromJsonAsync<ReturnHousesDto[]>($"{url}/api/Houses/GetHouses");

                DataSource = Houses;
                SearchSource = Houses;
                PageCount = (int)Math.Ceiling((int)DataSource.Length / (decimal)ItemPerPage);
                Paginate(0);
                IsLoading = false;
                ToastService.ShowInfo("House Loaded","Home list");
            }
            catch (Exception)
            {
                IsLoading = false;
                ToastService.ShowError("Error Loading List");
                throw;
            }
           
        }
       
        private void Paginate (int page ) 
        {
           var size = ItemPerPage;
           var start = page * size;
           
            var nextPage = SearchSource.Skip(start).Take(size).ToArray();
            DisplaySource = nextPage;
            CurrentPage = page;
        }
        private void NextPage()
        {
            Paginate(CurrentPage + 1);
        }
        private void PreviousPage()
        {
            Paginate(CurrentPage - 1);
        }
        private void FirstPage()
        {
            Paginate(0);
        }
        private void LastPage()
        {
            Paginate(PageCount -1);
        }
        private void AddnewHome()
        {
            NavigationManager.NavigateTo("/addHome");
        }
        private void Search()
        {
            SearchSource = DataSource.Where(h => h.Address1.ToLower().Contains(Searchtxt.ToLower())).ToArray();
            PageCount = (int)Math.Ceiling((int)SearchSource.Length / (decimal)ItemPerPage);
            Paginate(0);
        }
    }
}
