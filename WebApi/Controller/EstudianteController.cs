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
    public class EstudianteController : ControllerBase
    {
        private readonly InterfacesEstudiante _repositorio;
        private readonly IMapper _mapper;
        private readonly CrearEstudiante _crearEstudiante;

        public EstudianteController(InterfacesEstudiante repositorio, IMapper mapper, CrearEstudiante crearEstudiante)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _crearEstudiante = crearEstudiante;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repositorio.GetAll();
            return Ok(_mapper.Map<IEnumerable<EstudianteDTOs>>(lista));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entidad = await _repositorio.GetById(id);
            if (entidad == null) return NotFound(new { mensaje = "Estudiante no encontrado" });
            return Ok(_mapper.Map<EstudianteDTOs>(entidad));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearEstudianteDTO crearDto)
        {
            try
            {
                var entidad = _mapper.Map<Estudiante>(crearDto);
                await _crearEstudiante.EjecutarAsync(entidad);

                var dtoSalida = _mapper.Map<EstudianteDTOs>(entidad);
                return CreatedAtAction(nameof(GetById), new { id = entidad.Id }, dtoSalida);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CrearEstudianteDTO updateDto)
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