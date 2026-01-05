using Aplicaction.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Diplomado, DiplomadoDTOs>();
            CreateMap<CrearDiplomadoDTOs, Diplomado>();

            CreateMap<Docente, DocenteDTOs>();
            CreateMap<CrearDocenteDTOs, Docente>();

            CreateMap<Estudiante, EstudianteDTOs>();
            CreateMap<CrearEstudianteDTO, Estudiante>();

            CreateMap<Modulo, ModulosDTOs>();
            CreateMap<CrearModuloDTO, Modulo>();

            CreateMap<Inscripcion, InscripcionDTOs>();
            CreateMap<CrearInscripcionDTO, Inscripcion>();

            CreateMap<Nota, NotaDTOs>();
            CreateMap<CrearNotaDTO, Nota>();
        }
    }
}