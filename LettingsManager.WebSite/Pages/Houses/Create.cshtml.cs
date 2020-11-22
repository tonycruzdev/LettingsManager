using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Models;
using AutoMapper;
using LettingsManager.WebSite.Dto;

namespace LettingsManager.WebSite.Houses
{
    public class CreateModel : PageModel
    {
        private readonly ILettingRepository _repo;
        private readonly IMapper _mapper;

        public CreateModel(ILettingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGet()
        {
            var landlords = await _repo.GetLandlords();
            ViewData["LandlordId"] = new SelectList(landlords, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ReturnHouseWithLandlordDto House { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var mapHouse = _mapper.Map<ReturnHouseWithLandlordDto, House>(House);
            _repo.AddEntity(mapHouse);
            await _repo.SaveAllAsync();
            return RedirectToPage("./Index");
        }
    }
}
