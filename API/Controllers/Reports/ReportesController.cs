using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Srv_inventory.Controllers.Reportes
{
    [Route("api/[controller]")]
    public class ReportesController :  ControllerBase
    {

        private readonly IReporteriaService _service;

        public ReportesController(IReporteriaService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("GetReportGitlab")]
        public IActionResult GetReportGitlab()
        {
            return _service.GetReportGitlab();
        }

        [AllowAnonymous]
        [HttpGet("GetReportEfectoAdversoxMedicamento")]
        public IActionResult GetReport()
        {
            return _service.GetReportEfectoAdversoxPaciente();
        }

        [AllowAnonymous]
        [HttpGet("GetReportEfectosAdversos")]
        public IActionResult GetReportEfectosAdversos()
        {
            return _service.GetReportEfectosAdversos();
        }

        [AllowAnonymous]
        [HttpGet("GetReportFarmacologos")]
        public IActionResult GetReportFarmacologos()
        {
            return _service.GetReportFarmacologos();
        }

        [AllowAnonymous]
        [HttpGet("GetReportMedicos")]
        public IActionResult GetReportMedicos()
        {
            return _service.GetReportMedicos();
        }

        [AllowAnonymous]
        [HttpGet("GetReportPacientes")]
        public IActionResult GetReportPacientes()
        {
            return _service.GetReportPacientes();
        }

        [AllowAnonymous]
        [HttpGet("GetReportRecetas")]
        public IActionResult GetReportRecetas()
        {
            return _service.GetReportRecetas();
        }

    }
}
