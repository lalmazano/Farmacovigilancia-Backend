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
                IdPaciente= dto.IdPaciente,
                Nombre = dto.Nombre,
                FechaNacimiento = dto.FechaNacimiento,
                Genero = dto.Genero,
                Contacto = dto.Contacto
            };

            await _repo.AddAsync(entity);
        }

    }
}
