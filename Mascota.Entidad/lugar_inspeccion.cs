using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class lugar_inspeccionBE
    {
        public string codigo_lugar_inspeccion { get; set; } = string.Empty;
        public string nombre_lugar_inspeccion { get; set; } = string.Empty;
        public string direccion_lugar_inspeccion { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string persona_id { get; set; } = string.Empty;
        public string persona_sucursal_id { get; set; } = string.Empty;
        public string codigo_centro_tramite { get; set; } = string.Empty;
        public string indicador_insp_adicional { get; set; } = string.Empty;
        public string ccodsed { get; set; } = string.Empty;
    }
}
