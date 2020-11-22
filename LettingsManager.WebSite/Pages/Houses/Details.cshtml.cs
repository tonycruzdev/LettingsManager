using AutoMapper;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Dto;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Houses
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

        public ReturnHouseWithLandlordDto House { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Id =  id ?? default;
            var houseResult = await _repo.GetHomeById(Id);
            House = _mapper.Map<House, ReturnHouseWithLandlordDto>(houseResult);

            if (House == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
