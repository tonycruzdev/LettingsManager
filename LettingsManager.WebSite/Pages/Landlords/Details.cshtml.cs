using AutoMapper;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Dto;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Landlords
{
    public class DetailsModel : PageModel
    {
        private readonly ILettingRepository _repo;
        private readonly IMapper _mapper;

        public DetailsModel(ILettingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public LandlordWithHouseDto Landlord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Id = id ?? default;

            var landlordResult = await _repo.GetLandlordWithHomesById(Id);
            Landlord = _mapper.Map<Landlord, LandlordWithHouseDto>(landlordResult);

            if (Landlord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
