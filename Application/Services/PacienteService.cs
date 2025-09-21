using Application.Services.Interface;
using Application.Services.Template;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PacienteService : ServiceBase<Paciente, Paciente>, IPacienteService
    {
        private readonly IPacienteRepository _repo;

        public PacienteService(IPacienteRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }

        public override async Task AddAsync(Paciente dto)
        {
            var ultimo = await _repo.GetLastAsync(u => u.IdPaciente);
            var nuevoId = (ultimo?.IdPaciente ?? 0) + 1;

            var entity = new Paciente
            {
                IdPaciente= nuevoId,
                Nombre = dto.Nombre,
                FechaNacimiento = dto.FechaNacimiento,
                dpi = dto.dpi,
                Genero = dto.Genero,
                Contacto = dto.Contacto,
                FechaRegistro = DateTime.Now

            };

            await _repo.AddAsync(entity);
        }

        public override async Task UpdateAsync(decimal id, Paciente dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Paciente no encontrado");
            }

            if (!string.IsNullOrEmpty(dto.Nombre))
                entity.Nombre = dto.Nombre;

            // Validar que la fecha no sea nula y no sea la mínima (DateTime.MinValue)
            if (dto.FechaNacimiento != null && dto.FechaNacimiento != DateTime.MinValue)
                entity.FechaNacimiento = dto.FechaNacimiento;

            // Validar que el DPI tenga valor (decimal > 0)
            if (dto.dpi > 0)
                entity.dpi = dto.dpi;

            if (!string.IsNullOrEmpty(dto.Genero))
                entity.Genero = dto.Genero;

            if (!string.IsNullOrEmpty(dto.Contacto))
                entity.Contacto = dto.Contacto;

            _repo.Update(entity);

        }

    }
}
