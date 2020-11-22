using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Houses
{
    public class IndexModel : PageModel
    {
        private readonly ILettingRepository _repo;
        public IndexModel(ILettingRepository repo)
        {
            _repo = repo;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }     
        public string SearchString { get; set; }
        public PaginatedList<House> House { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CurrentFilter = searchString;
            
            House = await _repo.GetHomePagination(CurrentSort, CurrentFilter, searchString, pageIndex);
        }
    }
}
