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

namespace LettingsManager.WebSite.Landlords
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LandlordDto Landlord { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var mapLandlord = _mapper.Map<LandlordDto, Landlord>(Landlord);
            _repo.AddEntity(mapLandlord);
            await _repo.SaveAllAsync();
            return RedirectToPage("./Index");
        }
    }
}
