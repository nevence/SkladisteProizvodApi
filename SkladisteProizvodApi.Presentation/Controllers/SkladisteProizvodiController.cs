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
using SkladisteProizvodApi.Presentation.ActionFilters;
using Shared.DataTransferObjects;


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

        [HttpGet("{id}/{proizvodId}", Name = "SkladisteProizvodById")]
        public async Task<IActionResult> GetProizvod([FromRoute] Guid id, Guid proizvodId)
        {
            var result = await _service.SkladisteProizvodService.GetProizvodAsync(proizvodId, id, trackChanges: false);
            return Ok(result);
        }

        [HttpPost("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddProizvod([FromBody] SkladisteProizvodForCreationDto skladisteProizvodDto, [FromRoute] Guid id)
        {
            var proizvod = await _service.SkladisteProizvodService.AddProizvodAsync(skladisteProizvodDto);
            return RedirectToRoute("SkladisteProizvodById", new { id, proizvod.Id });
        }


        [HttpPut("Order/{id}/{proizvodId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]  
        public async Task<IActionResult> OrderProizvod(SkladisteProizvodForOrderDto skladisteProizvodDto, [FromRoute] Guid id, Guid proizvodId)
        {
            await _service.SkladisteProizvodService.OrderProizvodAsync(skladisteProizvodDto, trackChanges: true);
            return RedirectToRoute("SkladisteProizvodById", new { id, proizvodId });
        }


        [HttpPut("Deliver/{id}/{proizvodId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> DeliverProizvod(SkladisteProizvodForOrderDto skladisteProizvodDto, [FromRoute] Guid id, Guid proizvodId)
        {
            await _service.SkladisteProizvodService.DeliverProizvodAsync(skladisteProizvodDto, trackChanges: true);
            return RedirectToRoute("SkladisteProizvodById", new { id, proizvodId });
        }

        [HttpDelete("Delete/{id}/{proizvodId}")]
        public async Task<IActionResult> RemoveProizvod([FromRoute] Guid id, Guid proizvodId)
        {
            await _service.SkladisteProizvodService.RemoveProizvodAsync(proizvodId, id, trackChanges: false);
            return NoContent();
        }

    }
}
