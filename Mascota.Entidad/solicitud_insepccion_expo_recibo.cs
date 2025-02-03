using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class solicitud_insepccion_expo_reciboBE
    {
        public string cod_soli_recibo { get; set; } = string.Empty;
        public string anno { get; set; } = string.Empty;
        public string fecha_recibo { get; set; } = string.Empty;
        public string codigo_centro_tramite { get; set; } = string.Empty;
        public string monto_total { get; set; } = string.Empty;
        public string monto_pagado { get; set; } = string.Empty;
        public string monto_saldo { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string cod_soli { get; set; } = string.Empty;
        public string nume_regi_arc { get; set; } = string.Empty;
    }
    public class claseBE
    {
        public string codigo_clase { get; set; } = string.Empty;
        public string descripcion_clase { get; set; } = string.Empty;
    }
    public class area_gestionBE
    {
        public string codigo_area_gestion { get; set; } = string.Empty;
        public string descripcion_area_gestion { get; set; } = string.Empty;
    }
    public class procedimiento_tupaBE
    {
        public string codigo_procedimiento_tupa { get; set; } = string.Empty;
        public string descripcion_procedimiento_tupa { get; set; } = string.Empty;
    }
    public class concepto_pagoBE
    {
        public string codigo_servicio { get; set; } = string.Empty;
        public string descripcion_servicio { get; set; } = string.Empty;
        public decimal tarifa { get; set; } = 0;
    }
    public class tipo_pagoBE
    {
        public int codigo_tipo_pago { get; set; } = 0;
        public string descripcion_tipo_pago { get; set; } = string.Empty;
    }
    public class bancoBE
    {
        public string codigo_banco { get; set; } = string.Empty;
        public string nombre_banco { get; set; } = string.Empty;
        public string numero_cuenta { get; set; } = string.Empty;
    }
    public class cuenta_corrienteBE
    {
        public string codigo_cta_cte { get; set; } = string.Empty;
        public string numero_cta { get; set; } = string.Empty;
    }
}
