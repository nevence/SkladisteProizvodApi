using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladisteProizvodApi.Presentation.Controllers
{
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
        public async Task<IActionResult> GetSkladista()
        { 
            var skladista = await _service.SkladisteService.GetAllSkladistaAsync(trackChanges: false);
            return Ok(skladista);
        }

        [HttpGet("{id:guid}", Name = "SkladisteById")]
        public async Task<IActionResult> GetSkladiste(Guid id)
        {
            var skladiste = await _service.SkladisteService.GetSkladistaAsync(id, trackChanges: false);
            return Ok(skladiste);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkladiste([FromBody] SkladisteForCreationDto skladiste)
        {
            if (skladiste is null)
                return BadRequest("SkladisteForCreationDto objekat je null");

            var createdSkladiste = await _service.SkladisteService.CreateSkladisteAsync(skladiste);

            return CreatedAtRoute("SkladisteById", new { id = createdSkladiste.Id }, createdSkladiste);
        }


    }
}
