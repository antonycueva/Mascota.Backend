using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class solicitud_insepccion_expo_recibo_pagoBE
    {
        public int id { get; set; } = 0;
        public int secuencial { get; set; } = 0;
        public int codigo_tipo_pago { get; set; } = 0;
        public string descripcion_tipo_pago { get; set; } = string.Empty;
        public string codigo_banco { get; set; } = string.Empty;
        public string nombre_banco { get; set; } = string.Empty;
        public string codigo_cta_cte { get; set; } = string.Empty;
        public string numero_cta_cte { get; set; } = string.Empty;
        public string num_boleta_depo { get; set; } = string.Empty;
        public string fecha_depo { get; set; } = string.Empty;
        public string fecha_depo2 { get; set; } = string.Empty;
        public decimal monto { get; set; } = 0;
        public int id_sie_cab { get; set; } = 0;
        public byte[] dataobject { get; set; } = new byte[0];
    }
}
