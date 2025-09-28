using Application.Services.Interface;
using Application.Services.Template;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interface;

namespace Application.Services
{
    public class EfectoAdversoService
        : ServiceBase<EfectoAdverso, EfectoAdverso>, IEfectoAdversoService
    {
        private readonly IEfectoAdversoRepository _repo;
        private readonly IPacienteRepository _prepo;

        public EfectoAdversoService(
            IEfectoAdversoRepository repo,
            IPacienteRepository prepo,      // <-- agrégalo
            IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _prepo = prepo ?? throw new ArgumentNullException(nameof(prepo));  // <-- así evitas NRE
        }

        public override async Task AddAsync(EfectoAdverso dto)
        {
            var ultimo = await _repo.GetLastAsync(u => u.IdEfecto);
            var nuevoId = (ultimo?.IdEfecto ?? 0) + 1;

            var paciente = await _prepo.GetByDpi(dto.dpi);

            if (paciente == null)
                throw new KeyNotFoundException($"Paciente con DPI {dto.dpi} no encontrado.");

            var entity = new EfectoAdverso
            {
                IdEfecto = nuevoId,
                IdPaciente = paciente.IdPaciente,
                IdMedicamento = dto.IdMedicamento,
                dpi = dto.dpi,
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
                AjusteDosis = dto.AjusteDosis,
                DosisActual = dto.DosisActual
            };

            await _repo.AddAsync(entity);
        }
    }
}
