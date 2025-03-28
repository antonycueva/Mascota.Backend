using Newtonsoft.Json;

namespace Mascota.WebApi.Models
{
    public class CertificadoDetalle
    {
        [JsonProperty("especie")]
        public string Especie { get; set; }

        [JsonProperty("cantidad")]
        public string Cantidad { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("raza")]
        public string Raza { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("edad")]
        public string Edad { get; set; }
    }
}
