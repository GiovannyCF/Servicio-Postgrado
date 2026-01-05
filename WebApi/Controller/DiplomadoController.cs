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
    public class DiplomadoController : ControllerBase
    {
        private readonly InterfacesDiplomado _repositorio;
        private readonly IMapper _mapper;
        private readonly CrearDiplomado _crearDiplomado;

        public DiplomadoController(InterfacesDiplomado repositorio, IMapper mapper, CrearDiplomado crearDiplomado)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _crearDiplomado = crearDiplomado;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repositorio.GetAll();
            var listaDto = _mapper.Map<IEnumerable<DiplomadoDTOs>>(lista);
            return Ok(listaDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound(new { mensaje = "Diplomado no encontrado" });

            var dto = _mapper.Map<DiplomadoDTOs>(entidad);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearDiplomadoDTOs crearDto)
        {
            try
            {
                var entidad = _mapper.Map<Diplomado>(crearDto);
                await _crearDiplomado.EjecutarAsync(entidad);

                var dtoSalida = _mapper.Map<DiplomadoDTOs>(entidad);
                return CreatedAtAction(nameof(GetById), new { id = entidad.Id }, dtoSalida);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CrearDiplomadoDTOs updateDto)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound(new { mensaje = "Diplomado no encontrado" });

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