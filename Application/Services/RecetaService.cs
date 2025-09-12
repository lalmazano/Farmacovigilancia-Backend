using Application.Services.Interface;
using Application.Services.Template;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RecetaService : ServiceBase<Recetum, Recetum>, IRecetaService
    {
        private readonly IRecetaRepository _repo;

        public RecetaService(IRecetaRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }


    }
}


