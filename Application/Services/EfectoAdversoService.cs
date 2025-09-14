using Application.Services.Interface;
using Application.Services.Template;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Repositories.Interface;

namespace Application.Services
{
    public class EfectoAdversoService : ServiceBase<CrearEfectoAdversoDto, EfectoAdverso>, IEfectoAdversoService
    {
        private readonly IEfectoAdversoRepository _repo;

        public EfectoAdversoService(IEfectoAdversoRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }
        public override async Task AddAsync(CrearEfectoAdversoDto dto)
        {
            var ultimo = await _repo.GetLastAsync(u => u.IdEfecto);
            var nuevoId = (ultimo?.IdEfecto ?? 0) + 1;

            var entity = new EfectoAdverso
            {
                IdEfecto = nuevoId,
                IdPaciente = dto.idPaciente,
                IdMedicamento = dto.idMedicamento,
                FechaReporte = dto.fechaReporte,
                Descripcion = dto.descripcion,
                Gravedad = dto.gravedad,
                Lote = dto.lote,
                Laboratorio = dto.laboratorio,
                RegistroSanitario = dto.registroSanitario,
                FechaVencimiento = dto.fechaVencimiento,
                Dosis = dto.dosis,
                FechaInicioEfecto = dto.fechaInicioEfecto,
                FechaFinEfecto = dto.fechaFinEfecto,
                ViaAdministracion = dto.viaAdministracion,
                MedidasTomadas = dto.medidasTomadas,
                Suspension = dto.suspension,     
                FechaSuspension = dto.fechaSuspension,
                AjusteDosis = dto.ajusteDosis,    // string
                DosisActual = dto.dosisActual
            };

            await _repo.AddAsync(entity);
        }

    }
}
