using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
        public IActionResult GetSkladista()
        { 
            var skladista = _service.SkladisteService.GetAllSkladista(trackChanges: false);
            return Ok(skladista);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetSkladiste(Guid id)
        {
            var skladiste = _service.SkladisteService.GetSkladista(id, trackChanges: false);
            return Ok(skladiste);
        }
    }
}
