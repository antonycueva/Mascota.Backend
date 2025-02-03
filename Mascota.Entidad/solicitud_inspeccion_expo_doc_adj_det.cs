using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class solicitud_inspeccion_expo_doc_adj_detBE
    {
        public int id { get; set; } = 0;
        public int id_sie_cab { get; set; } = 0;
        public int id_rel_doc { get; set; } = 0;
        public string nume_regi_arc { get; set; } = string.Empty;
        public int secuencial { get; set; } = 0;
        public string fech_carg_arc { get; set; } = string.Empty;
        public string filename { get; set; } = string.Empty;
        public string fileextension { get; set; } = string.Empty;
        public string nombre_objeto { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string fuente { get; set; } = string.Empty;
        public byte[] dataobject { get; set; } = new byte[0];
        public string numerodocumento_ucm { get; set; } = string.Empty;
        public int user_crea { get; set; } = 0;
        public int user_modi { get; set; } = 0;
    }
}
