using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class solicitud_insepccion_expo_recibo_detBE
    {
        public string codi_soli_recibo_det { get; set; } = string.Empty;
        public string secuencial { get; set; } = string.Empty;
        public string codi_soli_recibo { get; set; } = string.Empty;
        public string cantidad { get; set; } = string.Empty;
        public string monto { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string anno { get; set; } = string.Empty;
    }

    public class solicitud_inspeccion_relacion_documentoBE
    {
        public int id { get; set; } = 0;
        public string nomb_documento { get; set; } = string.Empty;
        public string desc_documento { get; set; } = string.Empty;
        public string info_documento { get; set; } = string.Empty;
        public string condicion { get; set; } = string.Empty;
        public string tipo_documento { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string fecha { get; set; } = string.Empty;
        public int id_sie_doc_det { get; set; } = 0;

    }
}
