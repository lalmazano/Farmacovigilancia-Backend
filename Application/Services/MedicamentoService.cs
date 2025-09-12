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
    public class MedicamentoService : ServiceBase<Medicamento, Medicamento>, IMedicamentoService
    {
        private readonly IMedicamentoRepository _repo;

        public MedicamentoService(IMedicamentoRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }
    }
}
