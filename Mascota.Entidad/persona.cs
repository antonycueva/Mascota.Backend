using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascota
{
    public class app_personaBE
    {
        public string persona_tipo { get; set; } = string.Empty;
        public string persona_id { get; set; } = string.Empty;
        public string nombre_razon_social { get; set; } = string.Empty;
        public string documento_tipo { get; set; } = string.Empty;
        public string documento_numero { get; set; } = string.Empty;
        public string apellido_paterno { get; set; } = string.Empty;
        public string apellido_materno { get; set; } = string.Empty;
        public string nombres { get; set; } = string.Empty;
        public string ruc { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string correo_electronico { get; set; } = string.Empty;
        public string departamento_nombre { get; set; } = string.Empty;
        public string provincia_nombre { get; set; } = string.Empty;
        public string distrito_nombre { get; set; } = string.Empty;
        public string nomb_docu_ide { get; set; } = string.Empty;
        public string telefono_movil { get; set; } = string.Empty;
    }
    public class personaBE
    {
        public string codi_usua_usu { get; set; } = string.Empty;
        public string persona_id { get; set; } = string.Empty;
        public string nombre_razon_social { get; set; } = string.Empty;
        public string persona_tipo { get; set; } = string.Empty;
        public string documento_tipo { get; set; } = string.Empty;
        public string documento_numero { get; set; } = string.Empty;
        public string nomb_docu_ide { get; set; } = string.Empty;
        public string apellido_paterno { get; set; } = string.Empty;
        public string apellido_materno { get; set; } = string.Empty;
        public string ruc { get; set; } = string.Empty;
        public string nombres { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string departamento_id { get; set; } = string.Empty;
        public string provincia_id { get; set; } = string.Empty;
        public string distrito_id { get; set; } = string.Empty;
        public string departamento_nombre { get; set; } = string.Empty;
        public string provincia_nombre { get; set; } = string.Empty;
        public string distrito_nombre { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string centro_poblado_id { get; set; } = string.Empty;
        public string telefono_movil { get; set; } = string.Empty;
        public string correo_electronico { get; set; } = string.Empty;
        public string referencia { get; set; } = string.Empty;
        public string estado { get; set; } = string.Empty;
        public string pais_id { get; set; } = string.Empty;
        public string fecha_nacimiento { get; set; } = string.Empty;
        public string nombre_razsoc_comp { get; set; } = string.Empty;
        public string nombre_comercial { get; set; } = string.Empty;
        public string referencia_direccion { get; set; } = string.Empty;
        public string estado_natural { get; set; } = string.Empty;
        public string estado_juridico { get; set; } = string.Empty;
        public string sexo { get; set; } = string.Empty;
        public string deResultado { get; set; } = string.Empty;
        public int id_sie_user { get; set; } = 0;
    }
    public class tipos_documentos_identidadBE
    {
        public string tipo_docu_ide { get; set; } = string.Empty;
        public string nomb_docu_ide { get; set; } = string.Empty;
    }

}
