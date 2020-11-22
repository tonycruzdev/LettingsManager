using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LettingsManager.WebSite.Data;
using LettingsManager.WebSite.Models;
using AutoMapper;
using LettingsManager.WebSite.Dto;

namespace LettingsManager.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly ILettingRepository _lettingRepository;
        private readonly IMapper _mapper;
        private readonly LettingsManagerContext _context;

        public HousesController(ILettingRepository lettingRepository, IMapper mapper, LettingsManagerContext context)
        {
            _lettingRepository = lettingRepository;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Houses
        [HttpGet("GetHouses")]
        public async Task<ActionResult<List<ReturnHousesDto>>> GetHouses()
        {
            var homeResult = await _lettingRepository.GetHomes();
            var mapResult = _mapper.Map<List<House>, List<ReturnHousesDto>>(homeResult);
            return Ok(mapResult);
         
        }

        // GET: api/Houses/5
        [HttpGet("GetHouseById/{id}")]
        public async Task<ActionResult<ReturnHousesDto>> GetHouse(int id)
        {
            var homeResult = await _lettingRepository.GetHomeById(id);
            if (homeResult == null)
            {
                return NotFound();
            }
            var mapResult = _mapper.Map<House,ReturnHousesDto>(homeResult);
            return mapResult;
        }

        [HttpGet("GetHouseWithLandlord/{id}")]
        public async Task<ActionResult<HouseToPrintDto>> GetHouseWithLandlord(int id)
        {
            var homeResult = await _lettingRepository.GetHomeById(id);
            if (homeResult == null)
            {
                return NotFound();
            }
            var mapResult = _mapper.Map<House, HouseToPrintDto>(homeResult);
            return mapResult;
        }


        [HttpPut("UpdateHouse/{id}")]
        public async Task<IActionResult> PutHouse(int id, HouseInsertDto house)
        {
            if (id != house.Id)
            {
                return BadRequest();
            }
            var mapHouse = _mapper.Map<HouseInsertDto, House>(house);
            _lettingRepository.UpdateEntity(mapHouse);
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

        [HttpPost("AddHouse")]
        public async Task<ActionResult<House>> PostHouse(HouseInsertDto house)
        {

            var mapHouse = _mapper.Map<HouseInsertDto, House>(house);

            _lettingRepository.AddEntity(mapHouse);
             await _lettingRepository.SaveAllAsync();

            return CreatedAtAction("GetHouse", new { id = mapHouse.Id }, house);
        }

        // DELETE: api/Houses/5
        [HttpDelete("DeleteHouse/{id}")]
        public async Task<ActionResult<ReturnHousesDto>> DeleteHouse(int id)
        {
           
            var homeResult = await _lettingRepository.GetHomeById(id);
            if (homeResult == null)
            {
                return NotFound();
            }

            _lettingRepository.DelteEntity(homeResult);
           await _lettingRepository.SaveAllAsync();
            var mapResult = _mapper.Map<House, ReturnHousesDto>(homeResult);

            return mapResult;
        }
    }
}
