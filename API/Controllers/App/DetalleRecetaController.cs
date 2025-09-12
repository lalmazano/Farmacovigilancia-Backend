using Api.Controllers.Template;
using Application.Services.Interface;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.App
{
    [Route("api/[controller]")]
    public class DetalleRecetaController : BaseController<DetalleRecetum>
    {
        public DetalleRecetaController(IDetalleRecetaService service) : base(service) { }
    }
}
