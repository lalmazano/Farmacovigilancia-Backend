using Domain.Entities;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Interface;
using Infrastructure.Repositories.Template;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfectoAdversoRepository: RepositoryBase<EfectoAdverso>, IEfectoAdversoRepository
    {
        public EfectoAdversoRepository(QueryContext queryContext, OperationContext operationContext)
      : base(queryContext, operationContext)
        {
        }

        public override async Task<IEnumerable<EfectoAdverso>> GetAllAsync()
        {
            return await _queryContext.EfectoAdversos
                .Include(m => m.IdMedicamentoNavigation)
                .Include(e => e.IdPacienteNavigation)
                .OrderByDescending(r => r.IdEfecto)
                .ToListAsync();
        }

    }
}


