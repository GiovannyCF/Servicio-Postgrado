using Aplicaction.DTOs;
using Application.UseCase;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly InterfacesModulo _repositorio;
        private readonly IMapper _mapper;
        private readonly CrearModulo _crearModulo;

        public ModuloController(InterfacesModulo repositorio, IMapper mapper, CrearModulo crearModulo)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _crearModulo = crearModulo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return Ok(_mapper.Map<IEnumerable<ModulosDTOs>>(lista));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound();
            return Ok(_mapper.Map<ModulosDTOs>(entidad));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearModuloDTO crearDto)
        {
            try
            {
                var entidad = _mapper.Map<Modulo>(crearDto);
                await _crearModulo.EjecutarAsync(entidad);
                var dtoSalida = _mapper.Map<ModulosDTOs>(entidad);
                return CreatedAtAction(nameof(GetById), new { id = entidad.Id }, dtoSalida);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CrearModuloDTO updateDto)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound();

            _mapper.Map(updateDto, entidad);
            await _repositorio.Update(entidad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound();

            await _repositorio.Delete(id);
            return NoContent();
        }
    }
}