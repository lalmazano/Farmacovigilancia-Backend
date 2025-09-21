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
    public class MedicamentoService : ServiceBase<Medicamento, Medicamento>, IMedicamentoService
    {
        private readonly IMedicamentoRepository _repo;

        public MedicamentoService(IMedicamentoRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }

        public override async Task AddAsync(Medicamento dto)
        {
            var ultimo = await _repo.GetLastAsync(u => u.IdMedicamento);
            var nuevoId = (ultimo?.IdMedicamento ?? 0) + 1;

            var entity = new Medicamento
            {
                IdMedicamento = nuevoId,
                Nombre = dto.Nombre,
                Composicion = dto.Composicion,
                Indicaciones= dto.Indicaciones,
                Contraindicaciones = dto.Contraindicaciones,
                FechaRegistro = DateTime.Now
            };

            await _repo.AddAsync(entity);
        }

        public override async Task UpdateAsync(decimal id, Medicamento dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Medicamento no encontrado");
            }

            if (!string.IsNullOrEmpty(dto.Nombre))
            {
                entity.Nombre = dto.Nombre;
            }

            if (!string.IsNullOrEmpty(dto.Composicion))
            {
                entity.Composicion = dto.Composicion;
            }

            if (!string.IsNullOrEmpty(dto.Indicaciones))
            {
                entity.Indicaciones = dto.Indicaciones;
            }

            if (!string.IsNullOrEmpty(dto.Contraindicaciones))
            {
                entity.Contraindicaciones = dto.Contraindicaciones;
            }

            _repo.Update(entity);

        }
    }
}
