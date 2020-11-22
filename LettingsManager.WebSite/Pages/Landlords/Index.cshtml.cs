using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace LettingsManager.WebSite.Landlords
{
    public class IndexModel : PageModel
    {
        private readonly ILettingRepository _repo;
        public IndexModel(ILettingRepository repo)
        {
            _repo = repo;
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public PaginatedList<Landlord> Landlord { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CurrentFilter = searchString;
            Landlord = await _repo.GetLandlordPagination(CurrentSort, CurrentFilter, SearchString, pageIndex);
        }


        
    }
}
