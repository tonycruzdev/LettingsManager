using AutoMapper;
using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Dto;
using LettingsManager.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LettingsManager.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordsController : ControllerBase
    {
        private readonly ILettingRepository _lettingRepository;
        private readonly IMapper _mapper;
        private readonly LettingsManagerContext _context;

        public LandlordsController(ILettingRepository lettingRepository, IMapper mapper, LettingsManagerContext context)
        {
            _lettingRepository = lettingRepository;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Landlords
        [HttpGet("GetLandlords")]
        public async Task<ActionResult<List<ReturnLandlordDto>>> GetLandlords()
        {
            var landlordResult = await _lettingRepository.GetLandlords();
            var mapLandlords = _mapper.Map<List<Landlord>, List<ReturnLandlordDto>>(landlordResult);
            return mapLandlords;
        }

        // GET: api/Landlords/5
        [HttpGet("GetLandlord/{id}")]
        public async Task<ActionResult<ReturnLandlordDto>> GetLandlord(int id)
        {
            var landlordResult = await _lettingRepository.GetLandlordById(id);
            if (landlordResult == null)
            {
                return NotFound();
            }
            var mapResult = _mapper.Map<Landlord, ReturnLandlordDto>(landlordResult);
            return mapResult;
        }
        [HttpGet("GetLandlordWithHouse/{id}")]
        public async Task<ActionResult<LandlordWithHouseDto>> GetLandlordWithHouse(int id)
        {
            var landlordResult = await _lettingRepository.GetLandlordWithHomesById(id);
            if (landlordResult == null)
            {
                return NotFound();
            }
            var mapResult = _mapper.Map<Landlord, LandlordWithHouseDto>(landlordResult);
            return mapResult;
        }
        // PUT: api/Landlords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("UpdateLandlord/{id}")]
        public async Task<IActionResult> PutLandlord(int id, LandlordDto landlord)
        {
            if (id != landlord.Id)
            {
                return BadRequest();
            }
            var mapUpdate = _mapper.Map<LandlordDto, Landlord>(landlord);

            _lettingRepository.UpdateEntity(mapUpdate);
            var result = false;
            try
            {
                result = await _lettingRepository.SaveAllAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Landlords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("AddLandlord")]
        public async Task<ActionResult<Landlord>> PostLandlord(LandlordDto landlord)
        {

            var mapInsert = _mapper.Map<LandlordDto, Landlord>(landlord);
            _lettingRepository.AddEntity(mapInsert);
            await _lettingRepository.SaveAllAsync();

            return CreatedAtAction("GetLandlord", new { id = mapInsert.Id }, mapInsert);
        }

        // DELETE: api/Landlords/5
        [HttpDelete("DeleteLandlord/{id}")]
        public async Task<ActionResult<Landlord>> DeleteLandlord(int id)
        {
            var landlordResult = await _lettingRepository.GetLandlordById(id);
            if (landlordResult == null)
            {
                return NotFound();
            }
            _lettingRepository.DelteEntity(landlordResult);
            await _lettingRepository.SaveAllAsync();

            return landlordResult;
        }
    }
}
