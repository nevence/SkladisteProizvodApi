using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using SkladisteProizvodApi.Presentation.ActionFilters;
using SkladisteProizvodApi.Presentation.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladisteProizvodApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProizvodiController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProizvodi()
        {
            var proizvodi = await _service.ProizvodService.GetAllProizvodiAsync(trackChanges : false);
            return Ok(proizvodi);
        }

        [HttpGet("{id:guid}", Name = "ProizvodById")]
        public async Task<IActionResult> GetProizvod(Guid id)
        {
            var proizvod = await _service.ProizvodService.GetProizvodAsync(id, trackChanges : false);
            return Ok(proizvod);
        }

        [HttpGet("collection/({ids})", Name = "ProizvodiCollection")]
        public async Task<IActionResult> GetProizvodiCollection([ModelBinder(BinderType =
            typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var proizvodi = await _service.ProizvodService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(proizvodi);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> CreateProizvod([FromBody] ProizvodForCreationDto proizvodDto)
        {
           var createdProizvod = await _service.ProizvodService.CreateProizvodAsync(proizvodDto);

            return CreatedAtRoute("ProizvodById", new { id = createdProizvod.Id }, createdProizvod);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateProizvodCollecton([FromBody] IEnumerable<ProizvodForCreationDto> proizvodCollection)
        {
            var result = await _service.ProizvodService.CreateProizvodCollectionAsync(proizvodCollection);
            return CreatedAtRoute("ProizvodiCollection", new { result.ids }, result.proizvodi);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProizvod(Guid id)
        {
            await _service.ProizvodService.DeleteProizvodAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProizvod(Guid id, [FromBody] ProizvodForUpdateDto proizvodDto)
        {
            await _service.ProizvodService.UpdateProizvodAsync(id, proizvodDto, trackChanges: true);
            return NoContent();
        }

    }
}
