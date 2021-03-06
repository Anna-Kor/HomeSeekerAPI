using HomeSeeker_API.Data;
using HomeSeeker_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSeeker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHomeRepository _homeRepository;

        public AdminPanelController(IConfiguration configuration, IHomeRepository homeRepository)
        {
            _configuration = configuration;
            _homeRepository = homeRepository;
        }

        [HttpGet("GetHomes")]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] decimal minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string city, [FromQuery] int minLivingArea, [FromQuery] int? maxLivingArea, [FromQuery] int? categoryId, [FromQuery] int? typeId, [FromQuery] int? floorId, [FromQuery] int? floorsNumberId, [FromQuery] string furniture, [FromQuery] int? roomsNumberId, [FromQuery] int? bathroomsId, [FromQuery] int? statusId)
        {
            try
            {
                var homes = await _homeRepository.Get(name, minPrice, maxPrice, city, minLivingArea, maxLivingArea, categoryId, typeId, floorId, floorsNumberId, furniture, roomsNumberId, bathroomsId, statusId);
                if (homes.Count == 0)
                {
                    return StatusCode(404, "No homes found");
                }
                return Ok(homes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }
        }
    }
}
