using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Models;
using LettingsManager.WebSite.Dto;
using AutoMapper;

namespace LettingsManager.WebSite.Landlords
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
        public LandlordDto Landlord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Id = id ?? default;
            var landlordResut = await _repo.GetLandlordById(Id);
            Landlord = _mapper.Map<Landlord, LandlordDto>(landlordResut) ; 

            if (landlordResut == null)
            {
                return NotFound();
            }
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mapLandlord = _mapper.Map<LandlordDto, Landlord>(Landlord);
            _repo.UpdateEntity(mapLandlord);

            try
            {
                await _repo.SaveAllAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _repo.LandlordExists(mapLandlord.Id))
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
