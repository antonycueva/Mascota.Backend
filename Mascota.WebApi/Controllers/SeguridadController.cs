using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using wsReniec;
using System;

namespace Mascota.WebApi.Controllers
{
    [Route("seguridad")]
    [ApiController]
    public class SeguridadController : Controller
    {
        public SeguridadController()
        {
        }

        [HttpPost]
        [Route("login")]
        public usuarioBE login(app_usuarioBE usuario)
        {
            usuarioBE data = seguridadBL.login(usuario);
            return data;
        }

        [HttpGet]
        [Route("tipo_documento/listar")]
        public List<tipos_documentos_identidadBE> listar_tipo_documento()
        {
            List<tipos_documentos_identidadBE> lista = seguridadBL.listar_tipo_documento();
            return lista;
        }

        [HttpGet]
        [Route("persona/listar")]
        public personaBE busqueda_integral(string documento_tipo, string documento_numero, string tipo_usuario)
        {
            personaBE persona = seguridadBL.listar_persona(documento_tipo, documento_numero, tipo_usuario);
            if (string.IsNullOrEmpty(persona.persona_id))
            {
                if (tipo_usuario.Equals("A") && documento_tipo.Equals("01"))
                {
                    try
                    {
                        wsReniec.GestionPersonaWSClient ocliente = new wsReniec.GestionPersonaWSClient();
                        wsReniec.obtenerDatosReniecRequest request = new wsReniec.obtenerDatosReniecRequest();
                        wsReniec.obtenerDatosReniecResponse response = new wsReniec.obtenerDatosReniecResponse();
                        request.arg0 = documento_numero;
                        response = ocliente.obtenerDatosReniecAsync(request.arg0).Result;
                        persona.nombre_razon_social = string.IsNullOrEmpty(response.@return.nombreRazonSocial) ? string.Empty : response.@return.nombreRazonSocial;
                        persona.documento_tipo = documento_tipo;
                        persona.documento_numero = string.IsNullOrEmpty(response.@return.documentoNumero) ? string.Empty : response.@return.documentoNumero;
                        persona.apellido_paterno = response.@return.apellidoPaterno;
                        persona.apellido_materno = response.@return.apellidoMaterno;
                        persona.nombres = response.@return.nombres;
                        persona.direccion = response.@return.direccion;
                        persona.departamento_nombre = response.@return.departamento;
                        persona.provincia_nombre = response.@return.provincia;
                        persona.distrito_nombre = response.@return.distrito;
                        persona.referencia_direccion = response.@return.referenciaDireccion;
                        persona.estado_juridico = response.@return.estadoJuridico;
                        persona.estado_natural = response.@return.estadoNatural;
                    }
                    catch (Exception ex)
                    {
                        persona.deResultado = ex.Message.ToString();
                    }
                }
            }
            return persona;
        }
        [HttpGet]
        [Route("veterinario/listar")]
        public medico_veterinario_padronBE listar_veterinario(string documento_tipo, string documento_numero)
        {
            medico_veterinario_padronBE data = seguridadBL.listar_veterinario(documento_tipo, documento_numero);
            return data;
        }
        [HttpGet]
        [Route("senasa/listar")]
        public List<personaBE> listar_personal_senasa(string codsed, string nombre, string modalidad)
        {
            return seguridadBL.listar_personal_senasa(codsed, nombre, modalidad);
        }

        [HttpPost]
        [Route("usuario/registrar")]
        public respuestaBE registrar_usuario(usuarioBE usuario)
        {
            respuestaBE data = seguridadBL.registrar_usuario(usuario);
            return data;
        }

        [HttpPost]
        [Route("persona/registrar")]
        public respuestaBE registrar_persona(personaBE persona)
        {
            return seguridadBL.registrar_persona(persona);
        }

        [HttpPost]
        [Route("usuario/recuperar")]
        public respuestaBE recuperar_usuario(usuarioBE usuario)
        {
            return seguridadBL.recuperar_usuario(usuario);
        }
        [HttpPost]
        [Route("datos/acceso")]
        public respuestaBE registrar_datos_acceso(usuarioBE usuario)
        {
            return seguridadBL.registrar_datos_acceso(usuario);
        }
        [HttpPost]
        [Route("datos/contacto")]
        public respuestaBE registrar_datos_contacto(usuarioBE usuario)
        {
            return seguridadBL.registrar_datos_contacto(usuario);
        }

    }
}
