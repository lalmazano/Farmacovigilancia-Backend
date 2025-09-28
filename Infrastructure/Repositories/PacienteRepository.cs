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
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public PacienteRepository(QueryContext queryContext, OperationContext operationContext)
            : base(queryContext, operationContext)
        {
        }

        public async Task<Paciente?> GetByDpi(decimal? dpi)
        {
            return await _queryContext.Pacientes
                 .FirstOrDefaultAsync(e => e.dpi == dpi);

        }

    }
}

