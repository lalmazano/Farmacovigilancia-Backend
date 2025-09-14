using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<RolDto, Rol> ().ReverseMap();
            CreateMap<Recetum, Recetum>().ReverseMap();
            CreateMap<Paciente, Paciente>().ReverseMap();
            CreateMap<Medicamento, Medicamento>().ReverseMap();
            CreateMap<HistorialMedico, HistorialMedico>().ReverseMap();
            CreateMap<EfectoAdverso, EfectoAdverso> ().ReverseMap();
            CreateMap<DetalleRecetum, DetalleRecetum> ().ReverseMap();
            CreateMap<CrearEfectoAdversoDto, EfectoAdverso>().ReverseMap();
            CreateMap<EfectoAdverso, CrearEfectoAdversoDto >().ReverseMap();

        }
    }
}
