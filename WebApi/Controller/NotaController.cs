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
    public class NotaController : ControllerBase
    {
        private readonly InterfacesNota _repositorio;
        private readonly IMapper _mapper;
        private readonly CrearNota _crearNota;

        public NotaController(InterfacesNota repositorio, IMapper mapper, CrearNota crearNota)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _crearNota = crearNota;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return Ok(_mapper.Map<IEnumerable<NotaDTOs>>(lista));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound();
            return Ok(_mapper.Map<NotaDTOs>(entidad));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearNotaDTO crearDto)
        {
            try
            {
                var entidad = _mapper.Map<Nota>(crearDto);
                await _crearNota.EjecutarAsync(entidad);
                var dtoSalida = _mapper.Map<NotaDTOs>(entidad);
                return CreatedAtAction(nameof(GetById), new { id = entidad.Id }, dtoSalida);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CrearNotaDTO updateDto)
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