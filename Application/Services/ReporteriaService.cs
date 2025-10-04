using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Reports;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public interface IReporteriaService
    {
        IActionResult GetReportGitlab();
        IActionResult GetReportEfectoAdversoxPaciente();
        IActionResult GetReportEfectosAdversos();
        IActionResult GetReportFarmacologos();
        IActionResult GetReportMedicos();
        IActionResult GetReportPacientes();
        IActionResult GetReportRecetas();
    }

    public class ReporteriaService : IReporteriaService
    {
        private readonly IReporteSSRS _service;

        public ReporteriaService(IReporteSSRS service)
        {
            _service = service;
        }


        public IActionResult GetReportGitlab()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "/TEST/UsuariosGitlab";
            //reporte.nombre = "UsuariosGitlab";
            List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            parametros.Add(new ParametrosReporte { nombre = "Estado", valor = "active" });
            reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

        public IActionResult GetReportEfectoAdversoxPaciente()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "Efecto_adversoxpaciente";
            //List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            //parametros.Add(new ParametrosReporte { nombre = "Estado", valor = "active" });
            //reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

        public IActionResult GetReportEfectosAdversos()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "efectos_adversos";
            //List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            //parametros.Add(new ParametrosReporte { nombre = "Estado", valor = "active" });
            //reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

        public IActionResult GetReportFarmacologos()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "Farmacologo";
            List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            parametros.Add(new ParametrosReporte { nombre = "Anio", valor = "2025" });
            parametros.Add(new ParametrosReporte { nombre = "Mes", valor = "0" });
            reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

        public IActionResult GetReportMedicos()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "Medicos";
            List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            parametros.Add(new ParametrosReporte { nombre = "Anio", valor = "2025" });
            parametros.Add(new ParametrosReporte { nombre = "Mes", valor = "0" });
            reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

        public IActionResult GetReportPacientes()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "Pacientes";
            List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            parametros.Add(new ParametrosReporte { nombre = "Anio", valor = "2025" });
            parametros.Add(new ParametrosReporte { nombre = "Mes", valor = "0" });
            reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

        public IActionResult GetReportRecetas()
        {
            ReporteGenerar reporte = new ReporteGenerar();

            reporte.path = "Recetas";
            List<ParametrosReporte> parametros = new List<ParametrosReporte>();
            parametros.Add(new ParametrosReporte { nombre = "Anio", valor = "2025" });
            parametros.Add(new ParametrosReporte { nombre = "Mes", valor = "0" });
            reporte.parametros = parametros;
            return _service.ObtenerReporte(reporte);
        }

    }
}
