using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class solicitud_inspeccion_expoBE
    {
        public int id { get; set; } = 0;

        public string nombre_exportador { get; set; } = string.Empty;
        public string nombre_medico { get; set; } = string.Empty;
        public int situacion { get; set; } = 0;
        public int id_paso { get; set; } = 0;
        public int secuencia_paso { get; set; } = 0;
        public string nombre_paso { get; set; } = string.Empty;
        public string componente_paso { get; set; } = string.Empty;
        public string nombre_situacion { get; set; } = string.Empty;
        public string fech_embarque { get; set; } = string.Empty;
        public string fech_desembarque { get; set; } = string.Empty;
        public string nombre_pais_origen { get; set; } = string.Empty;
        public string nombre_pais_transito { get; set; } = string.Empty;
        public string nombre_pais_destino { get; set; } = string.Empty;
        public string nombre_medio_transporte { get; set; } = string.Empty;
        public string estado_solicitud { get; set; } = string.Empty;
        public string fecha_solicitud { get; set; } = string.Empty;
        public string cmvp_medico { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string codigo_exportador { get; set; } = string.Empty;

        public string codigo_importador { get; set; } = string.Empty;
        public string nombre_importador { get; set; } = string.Empty;


        public string comentario_revision { get; set; } = string.Empty;
        public string id_marca_inspeccion { get; set; } = string.Empty;
        public string fecha_formato { get; set; } = string.Empty;
        public string fech_crea_formato { get; set; } = string.Empty;
        public string fech_modi_formato { get; set; } = string.Empty;
        public string fech_apro_formato { get; set; } = string.Empty;
        public string fech_cert_formato { get; set; } = string.Empty;

        public string nombre_revisor { get; set; } = string.Empty;
        public string nombre_especialista { get; set; } = string.Empty;
        public string usuario_revisor { get; set; } = string.Empty;
        public string usuario_especialista { get; set; } = string.Empty;
        public string codigo_revisor { get; set; } = string.Empty;
        public string codigo_especialista { get; set; } = string.Empty;
        public string numero_expediente { get; set; } = string.Empty;

        public string asignacion { get; set; } = string.Empty;


    }
}
