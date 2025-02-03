using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class solicitud_insepccion_expo_detBE
    {
        public int id { get; set; } = 0;
        public int secuencial { get; set; } = 0;
        public int id_sie_cab { get; set; } = 0;
        public string especie { get; set; } = string.Empty;
        public string id_tipo_sexo { get; set; } = string.Empty;
        public string nombre_tipo_sexo { get; set; } = string.Empty;
        public int edad { get; set; } = 0;
        public string codi_unid_med { get; set; } = string.Empty;
        public string desc_unid_med { get; set; } = string.Empty;
        public string raza { get; set; } = string.Empty;
        public string identificacion { get; set; } = string.Empty;
        public int cantidad { get; set; } = 0;
        public string codigo_tipo_envase { get; set; } = string.Empty;
        public string codigo_producto { get; set; } = string.Empty;
        public string descripcion_tipo_envase { get; set; } = string.Empty;
        public string nombre_comercial_producto { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string microchip { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public string pais_destino { get; set; } = string.Empty;
    }
}
