using Api.Controllers.Template;
using Application.Services.Interface;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.App
{
    [Route("api/[controller]")]
    public class EfectoAdversoController : BaseController<EfectoAdverso>
    {
        public EfectoAdversoController(IEfectoAdversoService service) : base(service) { }
    }
}