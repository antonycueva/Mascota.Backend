using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class paisBE
    {
        public string codi_pais_tpa { get; set; } = string.Empty;
        public string nomb_pais_tpa { get; set; } = string.Empty;
    }
    public class departamentoBE
    {
        public string codi_depa_dpt { get; set; } = string.Empty;
        public string nomb_dpto_dpt { get; set; } = string.Empty;
    }

    public class provinciaBE
    {
        public string codi_depa_dpt { get; set; } = string.Empty;
        public string codi_prov_tpr { get; set; } = string.Empty;
        public string nomb_prov_tpr { get; set; } = string.Empty;
    }

    public class distritoBE
    {
        public string codi_dist_tdi { get; set; } = string.Empty;
        public string codi_depa_dpt { get; set; } = string.Empty;
        public string codi_prov_tpr { get; set; } = string.Empty;
        public string nomb_dist_tdi { get; set; } = string.Empty;
    }
}
