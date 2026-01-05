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
    public class DocenteController : ControllerBase
    {
        private readonly InterfacesDocente _repositorio;
        private readonly IMapper _mapper;
        private readonly CrearDocente _crearDocente;

        public DocenteController(InterfacesDocente repositorio, IMapper mapper, CrearDocente crearDocente)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _crearDocente = crearDocente;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return Ok(_mapper.Map<IEnumerable<DocenteDTOs>>(lista));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound();
            return Ok(_mapper.Map<DocenteDTOs>(entidad));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearDocenteDTOs crearDto)
        {
            try
            {
                var entidad = _mapper.Map<Docente>(crearDto);
                await _crearDocente.EjecutarAsync(entidad);
                var dtoSalida = _mapper.Map<DocenteDTOs>(entidad);
                return CreatedAtAction(nameof(GetById), new { id = entidad.Id }, dtoSalida);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CrearDocenteDTOs updateDto)
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