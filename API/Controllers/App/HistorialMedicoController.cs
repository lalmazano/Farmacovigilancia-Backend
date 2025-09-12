using Api.Controllers.Template;
using Application.Services.Interface;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.App
{
    [Route("api/[controller]")]
    public class HistorialMedicoController : BaseController<HistorialMedico>
    {
        public HistorialMedicoController(IHistorialMedicoService service) : base(service)
        {
        }
    }
}

