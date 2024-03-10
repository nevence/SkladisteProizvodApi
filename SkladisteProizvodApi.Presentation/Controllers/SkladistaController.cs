using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using SkladisteProizvodApi.Presentation.ActionFilters;
using SkladisteProizvodApi.Presentation.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SkladisteProizvodApi.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SkladistaController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SkladistaController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles ="Menadzer")]
        public async Task<IActionResult> GetSkladista([FromQuery] SkladisteParameters skladisteParameters)
        { 
            var result = await _service.SkladisteService.GetAllSkladistaAsync(skladisteParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(result.skladista);
        }

        [HttpGet("{id:guid}", Name = "SkladisteById")]
        public async Task<IActionResult> GetSkladiste(Guid id)
        {
            var skladiste = await _service.SkladisteService.GetSkladistaAsync(id, trackChanges: false);
            return Ok(skladiste);
        }

        [HttpGet("collection/({ids})", Name = "SkladistaCollection")]
        public async Task<IActionResult> GetSkladistaCollection([ModelBinder(BinderType =
            typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var skladista = await _service.SkladisteService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(skladista);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> CreateSkladiste([FromBody] SkladisteForCreationDto skladisteDto)
        {
            var createdSkladiste = await _service.SkladisteService.CreateSkladisteAsync(skladisteDto);

            return CreatedAtRoute("SkladisteById", new { id = createdSkladiste.Id }, createdSkladiste);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateSkladisteCollection([FromBody] IEnumerable<SkladisteForCreationDto> skladisteCollection)
        {
            var result = await _service.SkladisteService.CreateSkladisteCollectionAsync(skladisteCollection);
            return CreatedAtRoute("SkladisteCollection", new {result.ids}, result.skladista);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSkladiste(Guid id)
        {
            await _service.SkladisteService.DeleteSkladisteAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateSkladiste(Guid id, SkladisteForUpdateDto skladisteDto)
        {
            await _service.SkladisteService.UpdateSkladisteAsync(id, skladisteDto, trackChanges: true);
            return NoContent();
        }

    }
}
