using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class importadoresBE
    {
        public string codigo_importador { get; set; } = string.Empty;
        public string codi_pais_tpa { get; set; } = string.Empty;
        public string nomb_pais_tpa { get; set; } = string.Empty;
        public string nombre_importador { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string ciudad_importador { get; set; } = string.Empty;
        public string direccion_importador { get; set; } = string.Empty;
        public bool check { get; set; } = false;
    }
}
