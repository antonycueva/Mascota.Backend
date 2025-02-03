using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class usuarioBE
    {
        public int id { get; set; } = 0;
        public string codigo { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
        public string clave { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public tipo_usuarioBE tipo_usuario { get; set; } = new tipo_usuarioBE();
        public DateTime? fecha_crea { get; set; } = null;
        public DateTime? fecha_modi { get; set; } = null;
        public app_personaBE persona { get; set; } = new app_personaBE();
        public List<menuBE> lista_permiso { get; set; } = new List<menuBE>();
    }
    public class tipo_usuarioBE
    {
        public int id { get; set; } = 0;
        public string nombre { get; set; } = string.Empty;
        public string grupo { get; set; } = string.Empty;
    }
    public class app_usuarioBE
    {
        public string usuario { get; set; } = string.Empty;
        public string clave { get; set; } = string.Empty;
        public string grupo { get; set; } = string.Empty;
    }

    public class respuestaBE
    {
        public int id { get; set; } = 0;
        public string codigo { get; set; } = string.Empty;
        public string mensaje { get; set; } = string.Empty;
    }

    public class menuBE
    {
        public int id { get; set; } = 0;
        public string label { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public bool isTitle { get; set; } = false;
        public List<paginaBE> subItems { get; set; } = new List<paginaBE>();
    }

    public class paginaBE
    {
        public int id { get; set; } = 0;
        public string label { get; set; } = string.Empty;
        public string link { get; set; } = string.Empty;
        public int parentId { get; set; } = 0;
        public bool visible { get; set; } = false;
    }
}
