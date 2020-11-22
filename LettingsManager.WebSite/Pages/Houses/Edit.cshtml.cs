using AutoMapper;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Dto;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Houses
{
    public class EditModel : PageModel
    {
        private readonly ILettingRepository _repo;
        private readonly IMapper _mapper;
        public EditModel(ILettingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [BindProperty]
        public ReturnHouseWithLandlordDto House { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Id = id ?? default;
            var houseResult =  await _repo.GetHomeById(Id);
            House = _mapper.Map<House, ReturnHouseWithLandlordDto>(houseResult);

            if (House == null)
            {
                return NotFound();
            }
            var landlordsResult = await _repo.GetLandlords();
            ViewData["LandlordId"] = new SelectList(landlordsResult, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var mapHouse = _mapper.Map<ReturnHouseWithLandlordDto, House>(House);
            _repo.UpdateEntity(mapHouse);

            try
            {
                await _repo.SaveAllAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _repo.HouseExists(House.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
