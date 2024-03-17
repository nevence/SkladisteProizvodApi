using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace SkladisteProizvodApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladisteProizvodiController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SkladisteProizvodiController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProizvodi([FromQuery] SkladisteProizvodParameters proizvodParameters, [FromRoute] Guid id)
        {
            var result = await _service.SkladisteProizvodService.GetAllProizvodiAsync(proizvodParameters, id, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(result.skladisteProizvodi);
        }
    }
}
