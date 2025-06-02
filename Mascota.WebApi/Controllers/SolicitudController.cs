using Mascota.Entidad;
using Microsoft.AspNetCore.Mvc;

namespace Mascota.WebApi.Controllers
{
    [Route("solicitud")]
    [ApiController]
    public class SolicitudController : Controller
    {
        public SolicitudController()
        {
        }

        [HttpGet]
        [Route("listar")]
        public List<solicitud_inspeccion_expoBE> listar_solicitud(int situacion, string? estado="",string? codigo = "", string? tipo_usuario = "")
        {
            List<solicitud_inspeccion_expoBE> lista = solicitudBL.listar_solicitud(situacion, estado, codigo, tipo_usuario);
            return lista;
        }

        [HttpGet]
        [Route("departamento/listar")]
        public List<departamentoBE> listar_departamento()
        {
            return solicitudBL.listar_departamento();
        }
        [HttpGet]
        [Route("provincia/listar")]
        public List<provinciaBE> listar_provincia(string? codi_depa_dpt)
        {
            return solicitudBL.listar_provincia(codi_depa_dpt);
        }
        [HttpGet]
        [Route("distrito/listar")]
        public List<distritoBE> listar_distrito(string? codi_depa_dpt, string? codi_prov_tpr)
        {
            return solicitudBL.listar_distrito(codi_depa_dpt, codi_prov_tpr);
        }

        [HttpGet]
        [Route("importadores/listar")]
        public List<importadoresBE> listar_importadores(string? nombre = "", string? pais= "00")
        {
            List<importadoresBE> lista = solicitudBL.listar_importadores(nombre, pais);
            return lista;
        }

        [HttpGet]
        [Route("animal/listar")]
        public List<solicitud_insepccion_expo_detBE> listar_animal(int id_solicitud)
        {
            List<solicitud_insepccion_expo_detBE> lista = solicitudBL.listar_animal(id_solicitud);
            return lista;
        }

        [HttpGet]
        [Route("medico/listar")]
        public List<medico_veterinario_padronBE> listar_medico(string? nombre = "", string? id_marca = "", int id_solicitud = 0, string? codi_depa_dpt = "", string? codi_prov_tpr = "", string? codi_dist_tdi = "")
        {
            List<medico_veterinario_padronBE> lista = solicitudBL.listar_medico(nombre, id_marca, id_solicitud, codi_depa_dpt, codi_prov_tpr, codi_dist_tdi);
            return lista;
        }

        [HttpGet]
        [Route("recibo_pago/listar")]
        public List<solicitud_insepccion_expo_recibo_pagoBE> listar_recibo_pago(int id_solicitud)
        {
            List<solicitud_insepccion_expo_recibo_pagoBE> lista = solicitudBL.listar_recibo_pago(id_solicitud);
            return lista;
        }

        [HttpGet]
        [Route("paises_origen/listar")]
        public List<paisesBE> listar_paises_origen()
        {
            List<paisesBE> lista = solicitudBL.listar_paises_origen();
            return lista;
        }

        [HttpGet]
        [Route("paises_destino/listar")]
        public List<paisesBE> listar_paises_destino()
        {
            List<paisesBE> lista = solicitudBL.listar_paises_destino();
            return lista;
        }

        [HttpGet]
        [Route("uso_destino/listar")]
        public List<aplicacion_usoBE> listar_uso_destino()
        {
            List<aplicacion_usoBE> lista = solicitudBL.listar_uso_destino();
            return lista;
        }

        [HttpGet]
        [Route("medio_transporte/listar")]
        public List<medio_transporteBE> listar_medio_transporte()
        {
            List<medio_transporteBE> lista = solicitudBL.listar_medio_transporte();
            return lista;
        }

        [HttpGet]
        [Route("punto_salida/listar")]
        public List<puertoBE> listar_punto_salida(string? medio_transporte)
        {
            List<puertoBE> lista = solicitudBL.listar_punto_salida(medio_transporte);
            return lista;
        }

        [HttpGet]
        [Route("punto_llegada/listar")]
        public List<puertoBE> listar_punto_llegada(string? pais_destino, string? medio_transporte)
        {
            List<puertoBE> lista = solicitudBL.listar_punto_llegada(pais_destino, medio_transporte);
            return lista;
        }

        [HttpGet]
        [Route("lugar_inspeccion/listar")]
        public List<lugar_inspeccionBE> listar_lugar_inspeccion()
        {
            List<lugar_inspeccionBE> lista = solicitudBL.listar_lugar_inspeccion();
            return lista;
        }

        [HttpGet]
        [Route("direccion_ejecutiva/listar")]
        public List<sedeBE> listar_direccion_ejecutiva()
        {
            List<sedeBE> lista = solicitudBL.listar_direccion_ejecutiva();
            return lista;
        }

        [HttpGet]
        [Route("centro_tramite/listar")]
        public List<centro_tramite> listar_centro_tramite(string? codi_sede_sed)
        {
            List<centro_tramite> lista = solicitudBL.listar_centro_tramite(codi_sede_sed);
            return lista;
        }

        [HttpGet]
        [Route("especie/listar")]
        public List<productoBE> listar_especie()
        {
            List<productoBE> lista = solicitudBL.listar_especie();
            return lista;
        }

        [HttpGet]
        [Route("unidad_medida/listar")]
        public List<unidad_medidaBE> listar_unidad_medida()
        {
            List<unidad_medidaBE> lista = solicitudBL.listar_unidad_medida();
            return lista;
        }

        [HttpGet]
        [Route("tipo_envase/listar")]
        public List<tipo_envaseBE> listar_tipo_envase()
        {
            List<tipo_envaseBE> lista = solicitudBL.listar_tipo_envase();
            return lista;
        }

        [HttpGet]
        [Route("clase/listar")]
        public List<claseBE> listar_clase()
        {
            List<claseBE> lista = solicitudBL.listar_clase();
            return lista;
        }

        [HttpGet]
        [Route("area/listar")]
        public List<area_gestionBE> listar_area(string codigo_clase)
        {
            List<area_gestionBE> lista = solicitudBL.listar_area(codigo_clase);
            return lista;
        }

        [HttpGet]
        [Route("procedimiento/listar")]
        public List<procedimiento_tupaBE> listar_procedimiento()
        {
            List<procedimiento_tupaBE> lista = solicitudBL.listar_procedimiento();
            return lista;
        }

        [HttpGet]
        [Route("concepto_pago/listar")]
        public List<concepto_pagoBE> listar_concepto_pago(int id_solicitud, string codigo_area,string id_marca_inspeccion)
        {
            List<concepto_pagoBE> lista = solicitudBL.listar_concepto_pago(id_solicitud, codigo_area, id_marca_inspeccion);
            return lista;
        }

        [HttpGet]
        [Route("info_banco/listar")]
        public List<bancoBE> listar_info_banco()
        {
            List<bancoBE> lista = solicitudBL.listar_info_banco();
            return lista;
        }

        [HttpGet]
        [Route("tipo_pago/listar")]
        public List<tipo_pagoBE> listar_tipo_pago()
        {
            List<tipo_pagoBE> lista = solicitudBL.listar_tipo_pago();
            return lista;
        }

        [HttpGet]
        [Route("banco/listar")]
        public List<bancoBE> listar_banco()
        {
            List<bancoBE> lista = solicitudBL.listar_banco();
            return lista;
        }

        [HttpGet]
        [Route("cuenta_corriente/listar")]
        public List<cuenta_corrienteBE> listar_cuenta_corriente(string codigo_banco)
        {
            List<cuenta_corrienteBE> lista = solicitudBL.listar_cuenta_corriente(codigo_banco);
            return lista;
        }

        [HttpGet]
        [Route("documento/listar")]
        public List<solicitud_inspeccion_relacion_documentoBE> listar_documento(string tipo_documento, int id_solicitud)
        {
            List<solicitud_inspeccion_relacion_documentoBE> lista = solicitudBL.listar_documento(tipo_documento, id_solicitud);
            return lista;
        }


        [HttpGet]
        [Route("documento/listar2")]
        public List<solicitud_inspeccion_relacion_documentoBE> listar_documento2(int id_solicitud)
        {
            List<solicitud_inspeccion_relacion_documentoBE> lista = solicitudBL.listar_documento2(id_solicitud);
            return lista;
        }

        [HttpGet]
        [Route("documento/listar_documento_espec_sen")]
        public List<solicitud_inspeccion_relacion_documentoBE> listar_documento_espec_sen(int id_solicitud)
        {
            List<solicitud_inspeccion_relacion_documentoBE> lista = solicitudBL.listar_documento_espec_sen(id_solicitud);
            return lista;
        }

        [HttpGet]
        [Route("certificado/listar")]
        public List<certificado> listar_certificado_cab(int id_solicitud)
        {
            List<certificado> lista = solicitudBL.listar_certificado_cab(id_solicitud);
            return lista;
        }

        [HttpGet]
        [Route("certificadoDet/listar")]
        public List<certificado_detBE> listar_certificado_det(int id_solicitud)
        {
            List<certificado_detBE> lista = solicitudBL.listar_certificado_det(id_solicitud);
            return lista;
        }

        [HttpPost]
        [Route("exportador/registrar")]
        public respuestaBE registrar_exportador(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_exportador(input);
            return data;
        }

        [HttpPost]
        [Route("importador/registrar")]
        public respuestaBE registrar_importador(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_importador(input);
            return data;
        }

        [HttpPost]
        [Route("envio/registrar")]
        public respuestaBE registrar_envio(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_envio(input);
            return data;
        }

        [HttpPost]
        [Route("animal/registrar")]
        public respuestaBE registrar_animal(solicitud_insepccion_expo_detBE input)
        {
            respuestaBE data = solicitudBL.registrar_animal(input);
            return data;
        }

        [HttpPost]
        [Route("animal/editar")]
        public respuestaBE editar_animal(solicitud_insepccion_expo_detBE input)
        {
            respuestaBE data = solicitudBL.editar_animal(input);
            return data;
        }

        [HttpPost]
        [Route("animal/anular")]
        public respuestaBE anular_animal(solicitud_insepccion_expo_detBE input)
        {
            respuestaBE data = solicitudBL.anular_animal(input);
            return data;
        }

        [HttpPost]
        [Route("animal/registrar2")]
        public respuestaBE registrar_animal2(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_animal2(input);
            return data;
        }

        [HttpPost]
        [Route("medico/registrar")]
        public respuestaBE registrar_medico(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_medico(input);
            return data;
        }

        [HttpPost]
        [Route("recibo/registrar")]
        public respuestaBE registrar_recibo(solicitud_insepccion_expo_recibo_pagoBE input)
        {
            respuestaBE data = solicitudBL.registrar_recibo(input);
            return data;
        }

        [HttpPost]
        [Route("recibo/editar")]
        public respuestaBE editar_recibo(solicitud_insepccion_expo_recibo_pagoBE input)
        {
            respuestaBE data = solicitudBL.editar_recibo(input);
            return data;
        }

        [HttpPost]
        [Route("recibo/anular")]
        public respuestaBE anular_recibo(solicitud_insepccion_expo_recibo_pagoBE input)
        {
            respuestaBE data = solicitudBL.anular_recibo(input);
            return data;
        }

        [HttpPost]
        [Route("recibo/pago")]
        public respuestaBE registrar_pago(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_pago(input);
            return data;
        }

        [HttpPost]
        [Route("documento/registrar2")]
        public respuestaBE registrar_documento2(solicitud_inspeccion_expo_doc_adj_detBE input)
        {
            respuestaBE data = solicitudBL.registrar_documento2(input);
            return data;
        }

        [HttpPost]
        [Route("documento/registrar3")]
        public respuestaBE registrar_documento3(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_documento3(input);
            return data;
        }

        [HttpPost]
        [Route("asignacion_solicitud/registrar")]
        public respuestaBE registrar_asignacion_solicitud(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_asignacion_solicitud(input);
            return data;
        }

        [HttpPost]
        [Route("revision_solicitud/registrar")]
        public respuestaBE registrar_revision_solicitud(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_revision_solicitud(input);
            return data;
        }
        [HttpPost]
        [Route("revision_solicitud/enviar")]
        public respuestaBE enviar_revision_solicitud(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.enviar_revision_solicitud(input);
            return data;
        }
        [HttpPost]
        [Route("revision_senasa/registrar")]
        public respuestaBE registrar_revision_senasa(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_revision_senasa(input);
            return data;
        }
        [HttpPost]
        [Route("certificacion/registrar")]
        public respuestaBE registrar_certificacion(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.registrar_certificacion(input);
            return data;
        }
        [HttpPost]
        [Route("replicar")]
        public respuestaBE replicar_solicitud(solicitud_inspeccion_expo_cabBE input)
        {
            respuestaBE data = solicitudBL.replicar_solicitud(input);
            return data;
        }

        [HttpPost]
        [Route("importador/registrar2")]
        public respuestaBE registrar_importador2(importadoresBE input)
        {
            respuestaBE data = solicitudBL.registrar_importador2(input);
            return data;
        }


        [HttpGet]
        [Route("recuperar")]
        public solicitud_inspeccion_expo_cabBE recuperar_solicitud(int id_solicitud)
        {
            return solicitudBL.recuperar_solicitud(id_solicitud);
        }
        [HttpGet]
        [Route("exportador/recuperar")]
        public personaBE recuperar_exportador(int id_sie_cab)
        {
            return solicitudBL.recuperar_exportador(id_sie_cab);
        }
        [HttpGet]
        [Route("importador/recuperar")]
        public importadoresBE recuperar_importador(int id_sie_cab)
        {
            importadoresBE lista = solicitudBL.recuperar_importador(id_sie_cab);
            return lista;
        }
        [HttpGet]
        [Route("envio/recuperar")]
        public solicitud_inspeccion_expo_cabBE recuperar_envio(int id_sie_cab)
        {
            solicitud_inspeccion_expo_cabBE lista = solicitudBL.recuperar_envio(id_sie_cab);
            return lista;
        }
        [HttpGet]
        [Route("medico/recuperar")]
        public medico_veterinario_padronBE recuperar_medico(int id_sie_cab)
        {
            medico_veterinario_padronBE lista = solicitudBL.recuperar_medico(id_sie_cab);
            return lista;
        }
        [HttpGet]
        [Route("pago/recuperar")]
        public solicitud_inspeccion_expo_cabBE recuperar_pago(int id_sie_cab)
        {
            solicitud_inspeccion_expo_cabBE lista = solicitudBL.recuperar_pago(id_sie_cab);
            return lista;
        }
        [HttpGet]
        [Route("comprobante/recuperar")]
        public comprobante recuperar_comprobante(int id_sie_cab)
        {
            comprobante lista = solicitudBL.recuperar_comprobante(id_sie_cab);
            return lista;
        }

        [HttpPost]
        [Route("asignacion_solicitud/reservar")]
        public respuestaBE reservar_asignacion(solicitud_asignacionBE input)
        {
            respuestaBE data = solicitudBL.reservar_asignacion(input);
            return data;
        }
        [HttpPost]
        [Route("asignacion_solicitud/liberar")]
        public respuestaBE liberar_asignacion(solicitud_asignacionBE input)
        {
            respuestaBE data = solicitudBL.liberar_asignacion(input);
            return data;
        }
        [HttpPost]
        [Route("medico/liberar")]
        public respuestaBE liberar_medico(solicitud_asignacionBE input)
        {
            respuestaBE data = solicitudBL.liberar_medico(input);
            return data;
        }
    }
}
