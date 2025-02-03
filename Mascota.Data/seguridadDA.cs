using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using SENASA;

namespace Mascota
{
    public class seguridadDA
    {
        public string? conexion = string.Empty;
        public seguridadDA(string? conn)
        {
            conexion = conn;
        }
        public usuarioBE login(app_usuarioBE usuario)
        {
            usuarioBE item = new usuarioBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete,"usp_login_usuario");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_USUARIO", usuario.usuario));
                    cmd.Parameters.Add(new OracleParameter("P_CLAVE", usuario.clave));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_USUARIO", usuario.grupo));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.usuario = usuario.usuario;
                                item.id = OracleDataHelper.GetInteger(reader, "id");
                                item.email = OracleDataHelper.GetString(reader, "correo_electronico");
                                item.codigo = OracleDataHelper.GetString(reader, "codigo");
                                item.tipo_usuario.id = OracleDataHelper.GetInteger(reader, "ID_TIPO_USUARIO");
                                item.tipo_usuario.nombre = OracleDataHelper.GetString(reader, "NOMBRE_TIPO_USUARIO");
                                item.tipo_usuario.grupo = usuario.grupo;
                                item.persona.persona_tipo = OracleDataHelper.GetString(reader, "persona_tipo");
                                item.persona.persona_id = OracleDataHelper.GetString(reader, "persona_id");
                                item.persona.documento_tipo = OracleDataHelper.GetString(reader, "documento_tipo");
                                item.persona.documento_numero = OracleDataHelper.GetString(reader, "documento_numero");
                                item.persona.apellido_paterno = OracleDataHelper.GetString(reader, "apellido_paterno");
                                item.persona.apellido_materno = OracleDataHelper.GetString(reader, "apellido_materno");
                                item.persona.nombre_razon_social = OracleDataHelper.GetString(reader, "nombre_razon_social");
                                item.persona.nombres = OracleDataHelper.GetString(reader, "nombres");
                                item.persona.ruc = OracleDataHelper.GetString(reader, "ruc");
                                item.persona.direccion = OracleDataHelper.GetString(reader, "direccion");
                                item.persona.telefono = OracleDataHelper.GetString(reader, "telefono");
                                item.persona.correo_electronico = OracleDataHelper.GetString(reader, "correo_electronico");
                                item.persona.departamento_nombre = OracleDataHelper.GetString(reader, "departamento_nombre");
                                item.persona.provincia_nombre = OracleDataHelper.GetString(reader, "provincia_nombre");
                                item.persona.distrito_nombre = OracleDataHelper.GetString(reader, "distrito_nombre");
                                item.persona.nomb_docu_ide = OracleDataHelper.GetString(reader, "nomb_docu_ide");
                                item.persona.telefono_movil = OracleDataHelper.GetString(reader, "telefono_movil");
                                listar_menu(ref item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("login", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }

        public void listar_menu(ref usuarioBE usuario)
        {
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_listar_permiso_pagina");
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.Add(new OracleParameter("P_ID_TIPO_USUARIO", usuario.tipo_usuario.id));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            string nombre_menu = string.Empty;
                            menuBE menu = new menuBE();
                            while (reader.Read())
                            {
                                if (!nombre_menu.Equals(helperDA.GetString(reader, "LABEL_MENU")))
                                {
                                    if (!string.IsNullOrEmpty(nombre_menu))
                                    {
                                        usuario.lista_permiso.Add(menu); 
                                    }

                                    menu = new menuBE();
                                    nombre_menu = helperDA.GetString(reader, "LABEL_MENU");
                                    menu.id = helperDA.GetInteger(reader, "ID_MENU");
                                    menu.label = helperDA.GetString(reader, "LABEL_MENU");
                                    menu.icon = helperDA.GetString(reader, "ICONO");
                                    menu.isTitle = (helperDA.GetString(reader, "TITULO").Equals("S"));

                                    paginaBE item = new paginaBE();
                                    item.id = helperDA.GetInteger(reader, "ID_PAGINA");
                                    item.link = helperDA.GetString(reader, "RUTA");
                                    item.label = helperDA.GetString(reader, "LABEL");
                                    item.parentId = helperDA.GetInteger(reader, "ID_MENU");
                                    item.visible = (helperDA.GetString(reader, "VISIBLE").Equals("S"));
                                    menu.subItems.Add(item);
                                }
                                else
                                {
                                    paginaBE item = new paginaBE();
                                    item.id = helperDA.GetInteger(reader, "ID_PAGINA");
                                    item.link = helperDA.GetString(reader, "RUTA");
                                    item.label = helperDA.GetString(reader, "LABEL");
                                    item.parentId = helperDA.GetInteger(reader, "ID_MENU");
                                    item.visible = (helperDA.GetString(reader, "VISIBLE").Equals("S"));
                                    menu.subItems.Add(item);
                                }
                            }
                            usuario.lista_permiso.Add(menu);
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_menu", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
        }

        public List<tipos_documentos_identidadBE> listar_tipo_documento()
        {
            List<tipos_documentos_identidadBE> lista = new List<tipos_documentos_identidadBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_listar_tipo_documento");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipos_documentos_identidadBE item = new tipos_documentos_identidadBE();
                                item.tipo_docu_ide = helperDA.GetString(reader, "tipo_docu_ide");
                                item.nomb_docu_ide = helperDA.GetString(reader, "nomb_docu_ide");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_tipo_documento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public personaBE listar_persona(string documento_tipo, string documento_numero, string tipo_usuario)
        {
            personaBE item = new personaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_listar_persona");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_DOCUMENTO_TIPO", documento_tipo));
                    cmd.Parameters.Add(new OracleParameter("P_DOCUMENTO_NUMERO", documento_numero));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_USUARIO", tipo_usuario));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {                                
                                item.persona_id = helperDA.GetString(reader, "persona_id");
                                item.nombre_razon_social = helperDA.GetString(reader, "nombre_razon_social");
                                item.documento_tipo = helperDA.GetString(reader, "documento_tipo");
                                item.documento_numero = helperDA.GetString(reader, "documento_numero");
                                item.apellido_paterno = helperDA.GetString(reader, "apellido_paterno");
                                item.apellido_materno = helperDA.GetString(reader, "apellido_materno");
                                item.nombres = helperDA.GetString(reader, "nombres");
                                item.ruc = helperDA.GetString(reader, "ruc");
                                item.direccion = helperDA.GetString(reader, "direccion");
                                item.telefono = helperDA.GetString(reader, "telefono");
                                item.correo_electronico = helperDA.GetString(reader, "correo_electronico");
                                item.documento_numero = helperDA.GetString(reader, "DOCUMENTO_NUMERO");
                                item.documento_tipo = helperDA.GetString(reader, "DOCUMENTO_TIPO");
                                item.telefono_movil = helperDA.GetString(reader, "telefono_movil");
                                item.id_sie_user = helperDA.GetInteger(reader, "ID_SIE_USER");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_persona", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
        public medico_veterinario_padronBE listar_veterinario(string documento_tipo, string documento_numero)
        {
            medico_veterinario_padronBE item = new medico_veterinario_padronBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_listar_veterinario");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_DOCUMENTO_TIPO", documento_tipo));
                    cmd.Parameters.Add(new OracleParameter("P_DOCUMENTO_NUMERO", documento_numero));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.codi_medi_vet = helperDA.GetString(reader, "CODI_MEDI_VET");
                                item.nomb_cort_vet = helperDA.GetString(reader, "NOMB_CORT_VET");
                                item.tipo_docu_ide = helperDA.GetString(reader, "TIPO_DOCU_IDE");
                                item.nume_docu_vet = helperDA.GetString(reader, "NUME_DOCU_VET");
                                item.apel_pate_vet = helperDA.GetString(reader, "APEL_PATE_VET");
                                item.apel_mate_vet = helperDA.GetString(reader, "APEL_MATE_VET");
                                item.nomb_medi_vet = helperDA.GetString(reader, "NOMB_MEDI_VET");
                                item.ruc_medi_vet = helperDA.GetString(reader, "RUC_MEDI_VET");
                                item.dire_medi_vet = helperDA.GetString(reader, "DIRE_MEDI_VET");
                                item.telf_medi_vet = helperDA.GetString(reader, "TELF_MEDI_VET");
                                item.email_medi_vet = helperDA.GetString(reader, "EMAIL_MEDI_VET");
                                item.celu_medi_vet = helperDA.GetString(reader, "CELU_MEDI_VET");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_veterinario", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
        public List<personaBE> listar_personal_senasa(string codsed, string nombre, string modalidad)
        {
            List<personaBE> lista = new List<personaBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_listar_personal_senasa");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CCODSED", codsed));
                    cmd.Parameters.Add(new OracleParameter("P_NOMBRE", nombre));
                    cmd.Parameters.Add(new OracleParameter("P_MODALIDAD", modalidad));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                personaBE item = new personaBE();
                                item.codi_usua_usu = helperDA.GetString(reader, "CODI_USUA_USU");
                                item.persona_id = helperDA.GetString(reader, "CODI_EMPL_PER");
                                item.documento_numero = helperDA.GetString(reader, "LIBR_ELEC_PER");
                                item.apellido_paterno = helperDA.GetString(reader, "APE_PAT_PER");
                                item.apellido_materno = helperDA.GetString(reader, "APE_MAT_PER");
                                item.nombres = helperDA.GetString(reader, "NOM_EMP_PER");
                                item.nombre_comercial = helperDA.GetString(reader, "NOMB_CORT_PER");
                                item.direccion = helperDA.GetString(reader, "DIR_EMP_PER");
                                item.departamento_nombre = helperDA.GetString(reader, "nomb_depa");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_personal_senasa", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public respuestaBE registrar_usuario(usuarioBE usuario)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_registrar_usuario");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_USUARIO", usuario.usuario));
                        cmd.Parameters.Add(new OracleParameter("P_CLAVE", usuario.clave));
                        cmd.Parameters.Add(new OracleParameter("P_EMAIL", usuario.email));
                        cmd.Parameters.Add(new OracleParameter("P_TIPO_USUARIO", usuario.tipo_usuario.id));
                        cmd.Parameters.Add(new OracleParameter("P_CODIGO", usuario.codigo));
                        cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        data.mensaje = (data.id.Equals(0)) ? string.Concat("El usuario ya se encuentra registrado como ", usuario.tipo_usuario) : string.Empty;
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.id = -1;
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_usuario", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public respuestaBE registrar_persona(personaBE persona)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_registrar_persona");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_nombrerazonsocial", persona.nombre_razon_social));
                    cmd.Parameters.Add(new OracleParameter("p_documentotipo", persona.documento_tipo));
                    cmd.Parameters.Add(new OracleParameter("p_documentonumero", persona.documento_numero));
                    cmd.Parameters.Add(new OracleParameter("p_nombres", persona.nombres));
                    cmd.Parameters.Add(new OracleParameter("p_apellidopaterno", persona.apellido_paterno));
                    cmd.Parameters.Add(new OracleParameter("p_apellidomaterno", persona.apellido_materno));
                    cmd.Parameters.Add(new OracleParameter("p_direccion", persona.direccion));
                    cmd.Parameters.Add(new OracleParameter("p_referencia", persona.referencia));
                    cmd.Parameters.Add(new OracleParameter("p_correo_electronico", persona.correo_electronico));
                    cmd.Parameters.Add(new OracleParameter("p_persona_id", OracleDbType.Varchar2, 8, string.Empty, ParameterDirection.Output));
                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.codigo = cmd.Parameters["p_persona_id"].Value.ToString();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_persona", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public void recuperar_usuario(ref usuarioBE usuario)
        {
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_recuperar_cuenta");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_USUARIO", usuario.usuario));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_USUARIO", usuario.tipo_usuario.grupo));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuario.clave = helperDA.GetString(reader, "CLAVE");
                                usuario.email = helperDA.GetString(reader, "EMAIL");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_usuario", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
        }
        public respuestaBE registrar_datos_acceso(usuarioBE usuario)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_datos_acceso");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_usuario_id", usuario.id));
                    cmd.Parameters.Add(new OracleParameter("p_clave", usuario.clave));
                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_datos_contacto(usuarioBE usuario)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = string.Concat(OracleDataHelper.paquete, "usp_datos_contacto");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_usuario_id", usuario.id));
                    cmd.Parameters.Add(new OracleParameter("p_persona_id", usuario.persona.persona_id));
                    cmd.Parameters.Add(new OracleParameter("p_telefono", usuario.persona.telefono));
                    cmd.Parameters.Add(new OracleParameter("p_correo_electronico", usuario.persona.correo_electronico));
                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
    }
}
