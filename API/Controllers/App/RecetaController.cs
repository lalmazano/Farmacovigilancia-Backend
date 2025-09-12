using Microsoft.AspNetCore.Mvc;
using Api.Controllers.Template;
using Application.Services.Interface;
using Domain.DTOs;
using Domain.Entities;

namespace API.Controllers.App
{
    [Route("api/[controller]")]
    public class RecetaController : BaseController<Recetum>
    {
        public RecetaController(IRecetaService service) : base(service) { }
    }
}