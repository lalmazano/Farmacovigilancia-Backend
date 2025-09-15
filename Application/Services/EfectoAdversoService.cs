using Application.Services.Interface;
using Application.Services.Template;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Repositories.Interface;

namespace Application.Services
{
    public class EfectoAdversoService : ServiceBase<EfectoAdverso, EfectoAdverso>, IEfectoAdversoService
    {
        private readonly IEfectoAdversoRepository _repo;

        public EfectoAdversoService(IEfectoAdversoRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }
        public override async Task AddAsync(EfectoAdverso dto)
        {
            var ultimo = await _repo.GetLastAsync(u => u.IdEfecto);
            var nuevoId = (ultimo?.IdEfecto ?? 0) + 1;

            var entity = new EfectoAdverso
            {
                IdEfecto = nuevoId,
                IdPaciente = dto.IdPaciente,
                IdMedicamento = dto.IdMedicamento,
                FechaReporte = dto.FechaReporte,
                Descripcion = dto.Descripcion,
                Gravedad = dto.Gravedad,
                Lote = dto.Lote,
                Laboratorio = dto.Laboratorio,
                RegistroSanitario = dto.RegistroSanitario,
                FechaVencimiento = dto.FechaVencimiento,
                Dosis = dto.Dosis,
                FechaInicioEfecto = dto.FechaInicioEfecto,
                FechaFinEfecto = dto.FechaFinEfecto,
                ViaAdministracion = dto.ViaAdministracion,
                MedidasTomadas = dto.MedidasTomadas,
                Suspension = dto.Suspension,     
                FechaSuspension = dto.FechaSuspension,
                AjusteDosis = dto.AjusteDosis,    // string
                DosisActual = dto.DosisActual
            };

            await _repo.AddAsync(entity);
        }

    }
}
