﻿using Contracts;
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

        [HttpPost]

        public async Task<IActionResult> CreateProizvod([FromBody] ProizvodForCreationDto proizvod)
        {
            if (proizvod is null)
                return BadRequest("ProizvodForCreationDto objekat je null");
           var createdProizvod = await _service.ProizvodService.CreateProizvodAsync(proizvod);

            return CreatedAtRoute("ProizvodById", new { id = createdProizvod.Id }, createdProizvod);
        }

    }
}
