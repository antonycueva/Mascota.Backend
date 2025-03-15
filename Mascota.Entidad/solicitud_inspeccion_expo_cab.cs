namespace Mascota.Entidad
{
    public class solicitud_asignacionBE
    {
        public int id { get; set; } = 0;
        public string tipo { get; set; } = string.Empty;
        public string codigo { get; set; } = string.Empty;
        public int user_modi { get; set; } = 0;
    }
    public class solicitud_inspeccion_expo_cabBE
    {
        public int id { get; set; } = 0;
        public string anno { get; set; } = string.Empty;
        public string ccodexp { get; set; } = string.Empty;
        public string codigo_importador { get; set; } = string.Empty;
        public string fecha_probl_inspe { get; set; } = string.Empty;
        public string hora_inspe { get; set; } = string.Empty;
        public string minuto_inspe { get; set; } = string.Empty;
        public string fech_embarque { get; set; } = string.Empty;
        public string fech_desembarque { get; set; } = string.Empty;
        public string codigo_clase { get; set; } = string.Empty;
        public string cod_usuario { get; set; } = string.Empty;
        public string codigo_aplicacion { get; set; } = string.Empty;
        public string pais_origen_codi_pais_tpa { get; set; } = string.Empty;
        public string pais_transito_codi_pais_tpa { get; set; } = string.Empty;
        public string pais_destino_codi_pais_tpa { get; set; } = string.Empty;
        public string codigo_medio_transporte { get; set; } = string.Empty;
        public string ccodsed { get; set; } = string.Empty;
        public string codigo_puerto_salida { get; set; } = string.Empty;
        public string codigo_lugar_inspeccion { get; set; } = string.Empty;
        public string codigo_procedimiento_tupa { get; set; } = string.Empty;
        public string codigo_area_gestion { get; set; } = string.Empty;
        
        public string numero_expediente { get; set; } = string.Empty;
        public string nombre_importador { get; set; } = string.Empty;
        public string ciudad_importador { get; set; } = string.Empty;
        public string direccion_importador { get; set; } = string.Empty;
        public string pais_importador { get; set; } = string.Empty;
        public string nume_regi_arc_veter { get; set; } = string.Empty;
        public string nume_regi_arc_senasa { get; set; } = string.Empty;
        public string nume_regi_arc { get; set; } = string.Empty;
        public string codigo_puerto_llegada { get; set; } = string.Empty;
        public string codi_medi_vet { get; set; } = string.Empty;
        public string codigo_servicio { get; set; } = string.Empty;
        public string codigo_centro_tramite { get; set; } = string.Empty;
        public int user_crea { get; set; } = 0;
        public int user_modi { get; set; } = 0;
        public int user_apro { get; set; } = 0;
        public string estado { get; set; } = "S";
        public string comentario_revision { get; set; } = string.Empty;
        public string id_marca_inspeccion { get; set; } = string.Empty;
        public int situacion { get; set; } = 0;

        public string w_certificado_vacunacion { get; set; } = string.Empty;
        public string w_certificado_salud { get; set; } = string.Empty;
        public string w_recibo_pago { get; set; } = string.Empty;
        public string w_constancia_microchip { get; set; } = string.Empty;
        public string w_documentos_laboratorio { get; set; } = string.Empty;
        public string w_requisito_sanitario { get; set; } = string.Empty;
        public string w_temperatura { get; set; } = string.Empty;
        public string w_frecuencia_cardiaca { get; set; } = string.Empty;
        public string w_frecuencia_respiratoria { get; set; } = string.Empty;
        public string w_color_mucosas { get; set; } = string.Empty;
        public string w_heridas { get; set; } = string.Empty;
        public string w_parasitos_externos { get; set; } = string.Empty;
        public string w_parasitos_internos { get; set; } = string.Empty;
        public string w_apto_certificacion { get; set; } = string.Empty;

        public string pais_origen_nomb_pais_tpa { get; set; } = string.Empty;
        public string pais_transito_nomb_pais_tpa { get; set; } = string.Empty;
        public string pais_destino_nomb_pais_tpa { get; set; } = string.Empty;
        public string descripcion_medio_transporte { get; set; } = string.Empty;
        public string descripcion_aplicacion { get; set; } = string.Empty;
        public string descripcion_puerto_salida { get; set; } = string.Empty;
        public string descripcion_puerto_llegada { get; set; } = string.Empty;
        public string nombre_lugar_inspeccion { get; set; } = string.Empty;
        public string desc_sede_sed { get; set; } = string.Empty;
        public string descripcion_centro_tramite { get; set; } = string.Empty;

        public string nombre_persona { get; set; } = string.Empty;
        public string direccion_persona { get; set; } = string.Empty;
        public string departamento_persona { get; set; } = string.Empty;
        public string provincia_persona { get; set; } = string.Empty;
        public string distrito_persona { get; set; } = string.Empty;
        public string numero_documento_persona { get; set; } = string.Empty;
        public string tipo_documento_persona { get; set; } = string.Empty;
        public string correo_contacto { get; set; } = string.Empty;
        public string telefono_contacto { get; set; } = string.Empty;

        public string apel_pate_vet { get; set; } = string.Empty;
        public string apel_mate_vet { get; set; } = string.Empty;
        public string nomb_medi_vet { get; set; } = string.Empty;
        public string seud_medi_vet { get; set; } = string.Empty;
        public string dire_medi_vet { get; set; } = string.Empty;
        public string nomb_cort_vet { get; set; } = string.Empty;
        public string codi_cmvp_vet { get; set; } = string.Empty;
        public string numero_documento_medico { get; set; } = string.Empty;

        public string codi_empl_ctd { get; set; } = string.Empty;
        public string codi_empl_rev { get; set; } = string.Empty;
        public string codi_empl_esp { get; set; } = string.Empty;
        public string nomb_empl_ctd { get; set; } = string.Empty;
        public string nomb_empl_rev { get; set; } = string.Empty;
        public string nomb_empl_esp { get; set; } = string.Empty;
        public string usu_empl_ctd { get; set; } = string.Empty;
        public string usu_empl_rev { get; set; } = string.Empty;
        public string usu_empl_esp { get; set; } = string.Empty;

        public string fecha_revisor { get; set; } = string.Empty;
        public string fecha_especialista { get; set; } = string.Empty;
        public string fecha_medico { get; set; } = string.Empty;

        public string codigo_certificado { get; set; } = string.Empty;
        public string documento_tipo_expo { get; set; } = string.Empty;
        public string nombre_exportador { get; set; } = string.Empty;
        public string direccion_exportador { get; set; } = string.Empty;
        public string num_doc_exportador { get; set; } = string.Empty;
        public string desc_certificado_expo { get; set; } = string.Empty;
        public string observacion_certificado_expo { get; set; } = string.Empty;
        public string medida_sanitaria_cert { get; set; } = string.Empty;
        public string idioma_cert { get; set; } = string.Empty;



    }
}
