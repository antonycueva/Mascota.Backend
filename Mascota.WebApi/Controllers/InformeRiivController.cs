using Microsoft.AspNetCore.Mvc;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using System.Runtime.Loader;
using System.Reflection;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;  // <-- Añadido
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Mascota.WebApi.Models;  // <-- Añadido

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IConverter _converter;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<ReportController> _logger;

    public ReportController(IConverter converter, IHttpClientFactory httpClientFactory, ILogger<ReportController> logger)
    {
        _converter = converter;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        var context = new CustomAssemblyLoadContext();
        context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "wkhtmltox", "libwkhtmltox.dll"));
    }

    [HttpGet("generate")]
    public async Task<IActionResult> GeneratePdf(int id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5193/solicitud/certificado/listar?id_solicitud={id}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error fetching data from certificado/listar: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, "Error fetching data from certificado/listar");
            }

            var data = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"Response data: {data}");

            List<Certificado> certificados;
            try
            {
                certificados = JsonConvert.DeserializeObject<List<Certificado>>(data);
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError($"Error deserializing data: {jsonEx.Message}");
                return BadRequest("Error deserializing data from certificado/listar");
            }

            if (certificados == null || certificados.Count == 0)
            {
                _logger.LogError("Deserialized data is null or empty");
                return BadRequest("Error deserializing data from certificado/listar");
            }

            var certificado = certificados[0];  // <-- Tomar el primer elemento de la lista

            _logger.LogInformation($"Deserialized data: {JsonConvert.SerializeObject(certificado)}");

            string htmlContent = System.IO.File.ReadAllText("reporte.html");
            htmlContent = htmlContent.Replace("{{NumeroExpediente}}", certificado.NumeroExpediente)
                                     .Replace("{{NombreExportador}}", certificado.NombreExportador)
                                     .Replace("{{DireccionExportador}}", certificado.DireccionExportador)
                                     .Replace("{{NombreImportador}}", certificado.NombreImportador)
                                     .Replace("{{DireccionImportador}}", certificado.DireccionImportador)
                                     .Replace("{{PaisTransito}}", certificado.PaisTransito)
                                     .Replace("{{PaisDestino}}", certificado.PaisDestino)
                                     .Replace("{{MedioTransporte}}", certificado.MedioTransporte)
                                     .Replace("{{PuntoSalida}}", certificado.PuntoSalida)
                                     .Replace("{{FechaEmbarque}}", certificado.FechaEmbarque)
                                     .Replace("{{PuntoLlegada}}", certificado.PuntoLlegada)
                                     .Replace("{{UsoDestino}}", certificado.UsoDestino)
                                     .Replace("{{FechaInspeccion}}", certificado.FechaInspeccion)
                                     .Replace("{{HoraInspe}}", certificado.HoraInspe)
                                     .Replace("{{RequiereTratamiento}}", certificado.RequiereTratamiento)
                                     .Replace("{{RequiereAnalisisLab}}", certificado.RequiereAnalisisLab)
                                     .Replace("{{MedidaSanitariaCert}}", certificado.MedidaSanitariaCert)
                                     .Replace("{{PuestoControlSalida}}", certificado.PuestoControlSalida)
                                     .Replace("{{CumpleReqPaisDes}}", certificado.CumpleReqPaisDes)
                                     .Replace("{{CumpleExgSenasa}}", certificado.CumpleExgSenasa)
                                     .Replace("{{AptoCert}}", certificado.AptoCert);

            _logger.LogInformation($"Generated HTML content: {htmlContent}");

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 }
                },
                Objects = {
                    new ObjectSettings {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        // HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]", Line = true },
                        // FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Este es el pie de página." }
                    }
                }
            };

            byte[] pdf = _converter.Convert(doc);
            return File(pdf, "application/pdf", "reporte.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Internal server error: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        return LoadUnmanagedDll(absolutePath);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        return LoadUnmanagedDllFromPath(unmanagedDllName);
    }

    protected override Assembly Load(AssemblyName assemblyName)
    {
        throw new NotImplementedException();
    }
}