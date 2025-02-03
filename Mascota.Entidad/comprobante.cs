using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota.Entidad
{
    public class comprobante
    {
        public string recibo { get; set; } = string.Empty;
        public string expediente { get; set; } = string.Empty;
        public string ruc_usuario { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
        public string fecha_envio { get; set; } = string.Empty;
        public string total_monto { get; set; } = string.Empty;
        public string total_pagado { get; set; } = string.Empty;
        public string aplicativo { get; set; } = string.Empty;
    }
}
