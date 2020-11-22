using AutoMapper;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Dto;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Landlords
{
    public class DeleteModel : PageModel
    {
        private readonly ILettingRepository _repo;
        private readonly IMapper _mapper;

        public DeleteModel(ILettingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [BindProperty]
        public LandlordDto Landlord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Id = id ?? default;
            var LandlordResult = await _repo.GetLandlordById(Id);
            Landlord = _mapper.Map<Landlord, LandlordDto>(LandlordResult);

            if (Landlord == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Id = id ?? default;
            var LandlordResult = await _repo.GetLandlordById(Id);

            if (LandlordResult != null)
            {
                _repo.DelteEntity(LandlordResult);
                await _repo.SaveAllAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
