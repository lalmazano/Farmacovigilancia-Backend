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
    }
}

