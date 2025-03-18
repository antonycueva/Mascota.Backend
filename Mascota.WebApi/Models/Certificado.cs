using Newtonsoft.Json;

namespace Mascota.WebApi.Models
{
    public class Certificado
    {
        [JsonProperty("numero_expediente")]
        public string NumeroExpediente { get; set; }

        [JsonProperty("nombre_exportador")]
        public string NombreExportador { get; set; }

        [JsonProperty("direccion_exportador")]
        public string DireccionExportador { get; set; }

        [JsonProperty("nombre_importador")]
        public string NombreImportador { get; set; }

        [JsonProperty("direccion_importador")]
        public string DireccionImportador { get; set; }

        [JsonProperty("pais_transito")]
        public string PaisTransito { get; set; }

        [JsonProperty("pais_destino")]
        public string PaisDestino { get; set; }

        [JsonProperty("medio_transporte")]
        public string MedioTransporte { get; set; }

        [JsonProperty("punto_salida")]
        public string PuntoSalida { get; set; }

        [JsonProperty("fecha_embarque")]
        public string FechaEmbarque { get; set; }

        [JsonProperty("punto_llegada")]
        public string PuntoLlegada { get; set; }

        [JsonProperty("uso_destino")]
        public string UsoDestino { get; set; }

        [JsonProperty("fecha_inspeccion")]
        public string FechaInspeccion { get; set; }

        [JsonProperty("hora_inspe")]
        public string HoraInspe { get; set; }

        [JsonProperty("requiere_tratamiento")]
        public string RequiereTratamiento { get; set; }

        [JsonProperty("requiere_analisis_lab")]
        public string RequiereAnalisisLab { get; set; }

        [JsonProperty("medida_sanitaria_cert")]
        public string MedidaSanitariaCert { get; set; }

        [JsonProperty("puesto_control_salida")]
        public string PuestoControlSalida { get; set; }

        [JsonProperty("cumple_req_pais_des")]
        public string CumpleReqPaisDes { get; set; }

        [JsonProperty("cumple_exg_senasa")]
        public string CumpleExgSenasa { get; set; }

        [JsonProperty("apto_cert")]
        public string AptoCert { get; set; }
    }
}
