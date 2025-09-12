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
    public class EfectoAdversoService : ServiceBase<EfectoAdverso, EfectoAdverso>, IEfectoAdversoService
    {
        private readonly IEfectoAdversoRepository _repo;

        public EfectoAdversoService(IEfectoAdversoRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }
    }
}
