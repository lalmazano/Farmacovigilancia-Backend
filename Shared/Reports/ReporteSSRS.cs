using AspNetCore.Report;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.Security.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shared.Reports
{
    public interface IReporteSSRS
    {
        IActionResult ObtenerReporte(ReporteGenerar reporte);
    }

    public class ReporteSSRS : IReporteSSRS
    {
        private IConfiguration _configuration;
        private string AmbienteReportes;
        ReportSettings _reporteSettings;
        private IDataEncriptada _dataEncriptada;
        public ReporteSSRS(IConfiguration configuration,IDataEncriptada dataEncriptada)
        {
            _configuration = configuration;
            _dataEncriptada = dataEncriptada;

            AmbienteReportes = _dataEncriptada.DesencriptarData(_configuration["Credentials:ReportingService:AmbienteReportes"]);

            var reportServer = _dataEncriptada.DesencriptarData(_configuration["Credentials:ReportingService:ReportServer"]);
            var username = _dataEncriptada.DesencriptarData(_configuration["Credentials:ReportingService:Usuario"]);
            var password = _dataEncriptada.DesencriptarData(_configuration["Credentials:ReportingService:Clave"]);
            var reportServerDomain = "IGSSGT.ORG";

            _reporteSettings = new ReportSettings
            {
                Credential = new NetworkCredential(username, password, reportServerDomain),
                ReportServer = reportServer,
            };

        }

        public IActionResult ObtenerReporte(ReporteGenerar reporte)
        {
            try
            {
                var servicioDeReporte = new ReportViewer(_reporteSettings);
                var peticion = configurarSolicitud(reporte);
                var respuesta = servicioDeReporte.Execute(peticion);

                if (respuesta.Data.Stream == null)
                {
                    throw new Exception("Error al momento de generar el reporte: " + respuesta.Message);
                }

                byte[] reporteBinario = respuesta.Data.Stream.ToArray();

                var reporteGenerado = Convert.ToBase64String(reporteBinario);

                return new ObjectResult(new { reporte = reporteGenerado }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { error = ex.Message }) { StatusCode = 500 };
            }
        }

        private ReportRequest configurarSolicitud(ReporteGenerar reporte)
        {
            string path = AmbienteReportes + reporte.path;

            var reportRequest = new ReportRequest
            {
                ExecuteType = ReportExecuteType.Export,
                RenderType = ReportRenderType.Pdf,
                Path = path
            };

            foreach (ParametrosReporte parametro in reporte.parametros)
            {
                reportRequest.Parameters.Add(parametro.nombre, parametro.valor);
            }

            return reportRequest;
        }
    }

    public partial class ReporteGenerar
    {
        public ReporteGenerar()
        {
            parametros = new HashSet<ParametrosReporte>();
        }
        public string path { get; set; }
        public string? nombre { get; set; }
        public ICollection<ParametrosReporte> parametros { get; set; }

    }

    public partial class ParametrosReporte
    {
        public string nombre { get; set; }
        public string valor { get; set; }
    }
}
