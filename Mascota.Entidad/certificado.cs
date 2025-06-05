using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota.Entidad
{
    public class certificado
    {
        public string numero_expediente { get; set; } = string.Empty;
        public string nombre_exportador { get; set; } = string.Empty;
        public string direccion_exportador { get; set; } = string.Empty;
        public string nombre_importador { get; set; } = string.Empty;
        public string direccion_importador { get; set; } = string.Empty;
        public string pais_transito { get; set; } = string.Empty;
        public string pais_destino { get; set; } = string.Empty;
        public string medio_transporte { get; set; } = string.Empty;
        public string punto_salida { get; set; } = string.Empty;
        public string fecha_embarque { get; set; } = string.Empty;
        public string punto_llegada { get; set; } = string.Empty;
        public string uso_destino { get; set; } = string.Empty;
        public string fecha_inspeccion { get; set; } = string.Empty;
        public string hora_inspe { get; set; } = string.Empty;
        public string requiere_tratamiento { get; set; } = string.Empty;
        public string requiere_analisis_lab { get; set; } = string.Empty;
        public string medida_sanitaria_cert { get; set; } = string.Empty;
        public string puesto_control_salida { get; set; } = string.Empty;
        public string cumple_req_pais_des { get; set; } = string.Empty;
        public string cumple_exg_senasa { get; set; } = string.Empty;
        public string apto_cert { get; set; } = string.Empty;
        public string total_mercancia {  get; set; } = string.Empty;
        public string desc_certificado_expo { get; set; } = string.Empty;
        public string observacion_certificado_expo { get; set; } = string.Empty;

    }

    public class certificado_detBE
    {
        public string especie { get; set; } = string.Empty;
        public string cantidad { get; set; } = string.Empty;
        public string identificacion { get; set; } = string.Empty;
        public string raza { get; set; } = string.Empty;
        public string sexo { get; set; } = string.Empty;
        public string edad { get; set; } = string.Empty;
        public string pais_origen_animal { get; set; } = string.Empty;
    }
}