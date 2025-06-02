using Mascota.Entidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mascota
{
    public static class solicitudBL
    {
        public static string? conn = AppSettingHelper.conn;
        public static List<importadoresBE> listar_importadores(string nombre, string pais)
        {
            return new solicitudDA(conn).listar_importadores(nombre, pais);
        }
        public static List<solicitud_insepccion_expo_detBE> listar_animal(int id_solicitud)
        {
            return new solicitudDA(conn).listar_animal(id_solicitud);
        }
        public static List<medico_veterinario_padronBE> listar_medico(string nombre, string id_marca, int id_solicitud, string codi_depa_dpt, string codi_prov_tpr, string codi_dist_tdi)
        {
            return new solicitudDA(conn).listar_medico(nombre, id_marca, id_solicitud, codi_depa_dpt, codi_prov_tpr, codi_dist_tdi);
        }
        public static List<solicitud_insepccion_expo_recibo_pagoBE> listar_recibo_pago(int id_solicitud)
        {
            return new solicitudDA(conn).listar_recibo_pago(id_solicitud);
        }

        public static List<certificado> listar_certificado_cab(int id_solicitud)
        {
            return new solicitudDA(conn).listar_certificado_cab(id_solicitud);
        }

        public static List<certificado_detBE> listar_certificado_det(int id_solicitud)
        {
            return new solicitudDA(conn).listar_certificado_det(id_solicitud);
        }

        public static List<paisesBE> listar_paises_origen()
        {
            return new solicitudDA(conn).listar_paises_origen();
        }
        public static List<paisesBE> listar_paises_destino()
        {
            return new solicitudDA(conn).listar_paises_destino();
        }
        public static List<aplicacion_usoBE> listar_uso_destino()
        {
            return new solicitudDA(conn).listar_uso_destino();
        }
        public static List<medio_transporteBE> listar_medio_transporte()
        {
            return new solicitudDA(conn).listar_medio_transporte();
        }
        public static List<puertoBE> listar_punto_salida(string medio_transporte)
        {
            return new solicitudDA(conn).listar_punto_salida(medio_transporte);
        }
        public static List<puertoBE> listar_punto_llegada(string pais_destino, string medio_transporte)
        {
            return new solicitudDA(conn).listar_punto_llegada(pais_destino, medio_transporte);
        }
        public static List<lugar_inspeccionBE> listar_lugar_inspeccion()
        {
            return new solicitudDA(conn).listar_lugar_inspeccion();
        }
        public static List<sedeBE> listar_direccion_ejecutiva()
        {
            return new solicitudDA(conn).listar_direccion_ejecutiva();
        }
        public static List<centro_tramite> listar_centro_tramite(string codi_sede_sed)
        {
            return new solicitudDA(conn).listar_centro_tramite(codi_sede_sed);
        }
        public static List<productoBE> listar_especie()
        {
            return new solicitudDA(conn).listar_especie();
        }
        public static List<unidad_medidaBE> listar_unidad_medida()
        {
            return new solicitudDA(conn).listar_unidad_medida();
        }
        public static List<tipo_envaseBE> listar_tipo_envase()
        {
            return new solicitudDA(conn).listar_tipo_envase();
        }
        public static List<claseBE> listar_clase()
        {
            return new solicitudDA(conn).listar_clase();
        }
        public static List<area_gestionBE> listar_area(string codigo_clase)
        {
            return new solicitudDA(conn).listar_area(codigo_clase);
        }
        public static List<procedimiento_tupaBE> listar_procedimiento()
        {
            return new solicitudDA(conn).listar_procedimiento();
        }
        public static List<concepto_pagoBE> listar_concepto_pago(int id_solicitud, string codigo_area, string id_marca_inspeccion)
        {
            return new solicitudDA(conn).listar_concepto_pago(id_solicitud, codigo_area, id_marca_inspeccion);
        }
        public static List<bancoBE> listar_info_banco()
        {
            return new solicitudDA(conn).listar_info_banco();
        }
        public static List<tipo_pagoBE> listar_tipo_pago()
        {
            return new solicitudDA(conn).listar_tipo_pago();
        }
        public static List<bancoBE> listar_banco()
        {
            return new solicitudDA(conn).listar_banco();
        }
        public static List<cuenta_corrienteBE> listar_cuenta_corriente(string codigo_banco)
        {
            return new solicitudDA(conn).listar_cuenta_corriente(codigo_banco);
        }
        public static List<solicitud_inspeccion_relacion_documentoBE> listar_documento(string tipo_documento, int id_solicitud)
        {
            return new solicitudDA(conn).listar_documento(tipo_documento, id_solicitud);
        }
        public static List<solicitud_inspeccion_relacion_documentoBE> listar_documento2(int id_solicitud)
        {
            return new solicitudDA(conn).listar_documento2(id_solicitud);
        }
        public static List<solicitud_inspeccion_relacion_documentoBE> listar_documento_espec_sen(int id_solicitud)
        {
            return new solicitudDA(conn).listar_documento_espec_sen(id_solicitud);
        }
        public static List<solicitud_inspeccion_expoBE> listar_solicitud(int situacion, string? estado, string? codigo, string? tipo_usuario)
        {
            return new solicitudDA(conn).listar_solicitud(situacion, estado, codigo, tipo_usuario);
        }

        public static respuestaBE registrar_exportador(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_exportador(data);
        }
        public static respuestaBE registrar_importador(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_importador(data);
        }
        public static respuestaBE registrar_importador2(importadoresBE data)
        {
            return new solicitudDA(conn).registrar_importador2(data);
        }
        public static respuestaBE registrar_envio(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_envio(data);
        }
        public static respuestaBE registrar_animal(solicitud_insepccion_expo_detBE data)
        {
            return new solicitudDA(conn).registrar_animal(data);
        }
        public static respuestaBE editar_animal(solicitud_insepccion_expo_detBE data)
        {
            return new solicitudDA(conn).editar_animal(data);
        }
        public static respuestaBE anular_animal(solicitud_insepccion_expo_detBE data)
        {
            return new solicitudDA(conn).anular_animal(data);
        }
        public static respuestaBE registrar_animal2(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_animal2(data);
        }
        public static respuestaBE registrar_medico(solicitud_inspeccion_expo_cabBE data)
        {
            respuestaBE respuesta = new solicitudDA(conn).registrar_medico(data);
            //if (!string.IsNullOrEmpty(data.correo_contacto) && string.IsNullOrEmpty(respuesta.mensaje))
            //{
            //    Correo _correo = new Correo()
            //    {
            //        de = Config.usuario,
            //        para = data.correo_contacto,
            //        asunto = string.Format("Asignación de solicitud de inspección {0} en plataforma de mascota web", data.id.ToString().PadLeft(7, '0')),
            //        contenido = utilidadBL.contenido_asignacion_medico(data)
            //    };
            //    utilidadBL.enviar_correo(_correo);
            //}
            return respuesta;
        }
        public static respuestaBE registrar_recibo(solicitud_insepccion_expo_recibo_pagoBE data)
        {
            return new solicitudDA(conn).registrar_recibo(data);
        }
        public static respuestaBE editar_recibo(solicitud_insepccion_expo_recibo_pagoBE data)
        {
            return new solicitudDA(conn).editar_recibo(data);
        }
        public static respuestaBE anular_recibo(solicitud_insepccion_expo_recibo_pagoBE data)
        {
            return new solicitudDA(conn).anular_recibo(data);
        }
        public static respuestaBE registrar_pago(solicitud_inspeccion_expo_cabBE data)
        {
            respuestaBE respuesta = new solicitudDA(conn).registrar_pago(data);
            if (!string.IsNullOrEmpty(data.correo_contacto) && string.IsNullOrEmpty(respuesta.mensaje))
            {
                Correo _correo = new Correo()
                {
                    de = AppSettingHelper.usuario,
                    para = data.correo_contacto,
                    asunto = string.Format("Registro de solicitud de inspección {0} en plataforma de mascota web", data.id.ToString().PadLeft(7,'0')),
                    contenido = utilidadBL.contenido_registrar_solicitud(data)
                };
                utilidadBL.enviar_correo(_correo);
            }
            return respuesta;
        }
        public static respuestaBE registrar_documento(solicitud_inspeccion_expo_doc_adj_detBE data)
        {
            return new solicitudDA(conn).registrar_documento(data);
        }
        public static respuestaBE registrar_documento_recibo(solicitud_insepccion_expo_recibo_pagoBE data)
        {
            return new solicitudDA(conn).registrar_documento_recibo(data);
        }
        public static respuestaBE registrar_documento2(solicitud_inspeccion_expo_doc_adj_detBE data)
        {
            return new solicitudDA(conn).registrar_documento2(data);
        }
        public static respuestaBE registrar_documento3(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_documento3(data);
        }

        public static respuestaBE registrar_asignacion_solicitud(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_asignacion_solicitud(data);
        }
        public static respuestaBE reservar_asignacion(solicitud_asignacionBE data)
        {
            return new solicitudDA(conn).reservar_asignacion(data);
        }
        public static respuestaBE liberar_asignacion(solicitud_asignacionBE data)
        {
            return new solicitudDA(conn).liberar_asignacion(data);
        }
        public static respuestaBE liberar_medico(solicitud_asignacionBE data)
        {
            return new solicitudDA(conn).liberar_medico(data);
        }
        public static respuestaBE registrar_revision_solicitud(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_revision_solicitud(data);
        }
        public static respuestaBE enviar_revision_solicitud(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).enviar_revision_solicitud(data);
        }
        public static respuestaBE registrar_revision_senasa(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_revision_senasa(data);
        }
        public static respuestaBE registrar_certificacion(solicitud_inspeccion_expo_cabBE data)
        {
            return new solicitudDA(conn).registrar_certificacion(data);
        }

        public static solicitud_inspeccion_expo_cabBE recuperar_solicitud(int id_solicitud)
        {
            return new solicitudDA(conn).recuperar_solicitud(id_solicitud);
        }
        public static personaBE recuperar_exportador(int id_sie_cab)
        {
            return new solicitudDA(conn).recuperar_exportador(id_sie_cab);
        }
        public static importadoresBE recuperar_importador(int id_sie_cab)
        {
            return new solicitudDA(conn).recuperar_importador(id_sie_cab);
        }
        public static solicitud_inspeccion_expo_cabBE recuperar_envio(int id_sie_cab)
        {
            return new solicitudDA(conn).recuperar_envio(id_sie_cab);
        }
        public static medico_veterinario_padronBE recuperar_medico(int id_sie_cab)
        {
            return new solicitudDA(conn).recuperar_medico(id_sie_cab);
        }
        public static byte[] recuperar_documento(int id_sie_doc_det)
        {
            return new solicitudDA(conn).recuperar_documento(id_sie_doc_det);
        }
        public static byte[] recuperar_documento_recibo(int id_sie_rec)
        {
            return new solicitudDA(conn).recuperar_documento_recibo(id_sie_rec);
        }
        public static solicitud_inspeccion_expo_cabBE recuperar_pago(int id_sie_cab)
        {
            return new solicitudDA(conn).recuperar_pago(id_sie_cab);
        }
        public static comprobante recuperar_comprobante(int id_sie)
        {
            return new solicitudDA(conn).recuperar_comprobante(id_sie);
        }


        public static List<departamentoBE> listar_departamento()
        {
            return new solicitudDA(conn).listar_departamento();
        }
        public static List<provinciaBE> listar_provincia(string codi_depa_dpt)
        {
            return new solicitudDA(conn).listar_provincia(codi_depa_dpt);
        }
        public static List<distritoBE> listar_distrito(string codi_depa_dpt, string codi_prov_tpr)
        {
            return new solicitudDA(conn).listar_distrito(codi_depa_dpt, codi_prov_tpr);
        }
        public static respuestaBE replicar_solicitud(solicitud_inspeccion_expo_cabBE solicitud)
        {
            return new solicitudDA(conn).replicar_solicitud(solicitud);
        }
    }
}
