using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;
using System.Collections;

namespace Mascota.WebApi.Controllers
{
    [ApiController]
    public class DocumentoController : Controller
    {
        public DocumentoController()
        {
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("documento/upload")]
        public async Task<IActionResult> upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files[0];
                if (file.Length > 0)
                {
                    byte[] fileBytes;
                    solicitud_inspeccion_expo_doc_adj_detBE data = new solicitud_inspeccion_expo_doc_adj_detBE();
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        data.dataobject = ms.ToArray();
                    }
                    respuestaBE respuesta = solicitudBL.registrar_documento(data);
                    return Ok(new { respuesta.id });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("documento/download")]
        public FileStreamResult download(int id_sie_doc_det)
        {
            byte[] byteData = new byte[0];
            //int ArraySize = new int();
            byteData = solicitudBL.recuperar_documento(id_sie_doc_det);
            //ArraySize = byteData.GetUpperBound(0);
            Stream stream = new MemoryStream(byteData);

            //MemoryStream stream = emisionBL.reporte_programacion_competencia(programacion_competencia);
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = string.Format("DOCUMENTO_{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmm"));
            return fileStreamResult;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("recibo/upload")]
        public async Task<IActionResult> upload_recibo()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files[0];
                if (file.Length > 0)
                {
                    byte[] fileBytes;
                    solicitud_insepccion_expo_recibo_pagoBE data = new solicitud_insepccion_expo_recibo_pagoBE();
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        data.dataobject = ms.ToArray();
                    }
                    respuestaBE respuesta = solicitudBL.registrar_documento_recibo(data);
                    return Ok(new { respuesta.id });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("recibo/download")]
        public FileStreamResult download_recibo(int id_sie_rec)
        {
            byte[] byteData = new byte[0];
            //int ArraySize = new int();
            byteData = solicitudBL.recuperar_documento_recibo(id_sie_rec);
            //ArraySize = byteData.GetUpperBound(0);
            Stream stream = new MemoryStream(byteData);

            //MemoryStream stream = emisionBL.reporte_programacion_competencia(programacion_competencia);
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = string.Format("RECIBO_{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmm"));
            return fileStreamResult;
        }

    }
}
