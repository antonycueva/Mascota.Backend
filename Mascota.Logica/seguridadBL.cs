using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Mascota
{
    public static class seguridadBL
    {
        public static string? conn = AppSettingHelper.conn;
        public static usuarioBE login(app_usuarioBE usuario)
        {
            return new seguridadDA(conn).login(usuario);
        }
        public static List<tipos_documentos_identidadBE> listar_tipo_documento()
        {
            return new seguridadDA(conn).listar_tipo_documento();
        }
        public static personaBE listar_persona(string documento_tipo, string documento_numero, string tipo_usuario)
        {
            return new seguridadDA(conn).listar_persona(documento_tipo, documento_numero, tipo_usuario);
        }
        public static medico_veterinario_padronBE listar_veterinario(string documento_tipo, string documento_numero)
        {
            return new seguridadDA(conn).listar_veterinario(documento_tipo, documento_numero);
        }
        public static List<personaBE> listar_personal_senasa(string codsed, string nombre, string modalidad)
        {
            return new seguridadDA(conn).listar_personal_senasa(codsed, nombre, modalidad);
        }
        public static respuestaBE registrar_usuario(usuarioBE usuario)
        {
            respuestaBE respuesta = new seguridadDA(conn).registrar_usuario(usuario);
            if (string.IsNullOrEmpty(respuesta.mensaje))
            {
                Correo _correo = new Correo()
                {
                    de = AppSettingHelper.usuario,
                    para = usuario.email,
                    asunto = AppSettingHelper.subjectRegistrar,
                    contenido = utilidadBL.contenido_registrar_cuenta(usuario)
                };
                respuesta = utilidadBL.enviar_correo(_correo);
            }
            return respuesta;
        }
        public static respuestaBE registrar_persona(personaBE persona)
        {
            return new seguridadDA(conn).registrar_persona(persona);
        }
        public static respuestaBE recuperar_usuario(usuarioBE usuario)
        {
            respuestaBE respuesta = new respuestaBE();
            new seguridadDA(conn).recuperar_usuario(ref usuario);
            if (!string.IsNullOrEmpty(usuario.email))
            {
                Correo _correo = new Correo()
                {
                    de = AppSettingHelper.usuario,
                    para = usuario.email,
                    asunto = AppSettingHelper.subjectRecuperar,
                    contenido = utilidadBL.contenido_recuperar_cuenta(usuario)
                };
                respuesta = utilidadBL.enviar_correo(_correo);
            }
            return respuesta;
        }

        public static respuestaBE registrar_datos_acceso(usuarioBE usuario)
        {
            return new seguridadDA(conn).registrar_datos_acceso(usuario);
        }
        public static respuestaBE registrar_datos_contacto(usuarioBE usuario)
        {
            return new seguridadDA(conn).registrar_datos_contacto(usuario);
        }

    }
}
