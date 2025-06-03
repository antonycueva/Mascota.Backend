using Mascota.Entidad;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using SENASA;

namespace Mascota
{
    public class solicitudDA
    {
        public string? conexion = string.Empty;
        public solicitudDA(string? conn = "")
        {
            conexion = conn;
        }

        public List<departamentoBE> listar_departamento()
        {
            List<departamentoBE> lista = new List<departamentoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_departamento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                departamentoBE item = new departamentoBE();
                                item.codi_depa_dpt = helperDA.GetString(reader, "codi_depa_dpt");
                                item.nomb_dpto_dpt = helperDA.GetString(reader, "nomb_dpto_dpt");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_departamento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<provinciaBE> listar_provincia(string codi_depa_dpt)
        {
            List<provinciaBE> lista = new List<provinciaBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_provincia";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CODI_DEPA_DPT", codi_depa_dpt));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                provinciaBE item = new provinciaBE();
                                item.codi_prov_tpr = helperDA.GetString(reader, "CODI_PROV_TPR");
                                item.nomb_prov_tpr = helperDA.GetString(reader, "NOMB_PROV_TPR");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_provincia", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<distritoBE> listar_distrito(string codi_depa_dpt, string codi_prov_tpr)
        {
            List<distritoBE> lista = new List<distritoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_distrito";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CODI_DEPA_DPT", codi_depa_dpt));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_PROV_TPR", codi_prov_tpr));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                distritoBE item = new distritoBE();
                                item.codi_dist_tdi = helperDA.GetString(reader, "codi_dist_tdi");
                                item.nomb_dist_tdi = helperDA.GetString(reader, "nomb_dist_tdi");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_distrito", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<importadoresBE> listar_importadores(string nombre, string pais)
        {
            List<importadoresBE> lista = new List<importadoresBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_importador";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_NOMBRE_IMPORTADOR", nombre));
                    cmd.Parameters.Add(new OracleParameter("P_PAIS_IMPORTADOR", pais));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                importadoresBE item = new importadoresBE();
                                item.codigo_importador = helperDA.GetString(reader, "codigo_importador");
                                item.nombre_importador = helperDA.GetString(reader, "nombre_importador");
                                item.ciudad_importador = helperDA.GetString(reader, "ciudad_importador");
                                item.direccion_importador = helperDA.GetString(reader, "direccion_importador");
                                item.nomb_pais_tpa = helperDA.GetString(reader, "nomb_pais_tpa");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_importadores", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<paisesBE> listar_paises_origen()
        {
            List<paisesBE> lista = new List<paisesBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_paises_origen";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                paisesBE item = new paisesBE();
                                item.codi_pais_tpa = helperDA.GetString(reader, "codi_pais_tpa");
                                item.nomb_pais_tpa = helperDA.GetString(reader, "nomb_pais_tpa");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_paises_origen", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<paisesBE> listar_paises_destino()
        {
            List<paisesBE> lista = new List<paisesBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_paises_destino";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                paisesBE item = new paisesBE();
                                item.codi_pais_tpa = helperDA.GetString(reader, "codi_pais_tpa");
                                item.nomb_pais_tpa = helperDA.GetString(reader, "nomb_pais_tpa");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_paises_destino", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<aplicacion_usoBE> listar_uso_destino()
        {
            List<aplicacion_usoBE> lista = new List<aplicacion_usoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_uso_destino";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                aplicacion_usoBE item = new aplicacion_usoBE();
                                item.codigo_aplicacion = helperDA.GetString(reader, "codigo_aplicacion");
                                item.descripcion_aplicacion = helperDA.GetString(reader, "descripcion_aplicacion");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_uso_destino", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<medio_transporteBE> listar_medio_transporte()
        {
            List<medio_transporteBE> lista = new List<medio_transporteBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_medio_transporte";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                medio_transporteBE item = new medio_transporteBE();
                                item.codigo_medio_transporte = helperDA.GetString(reader, "codigo_medio_transporte");
                                item.descripcion_medio_transporte = helperDA.GetString(reader, "descripcion_medio_transporte");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_medio_transporte", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<puertoBE> listar_punto_salida(string medio_transporte)
        {
            List<puertoBE> lista = new List<puertoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_punto_salida";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_MEDIO_TRANSPORTE", medio_transporte));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                puertoBE item = new puertoBE();
                                item.codigo_puerto = helperDA.GetString(reader, "codigo_puerto");
                                item.descripcion_puerto = helperDA.GetString(reader, "descripcion_puerto");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_punto_salida", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<puertoBE> listar_punto_llegada(string pais_destino, string medio_transporte)
        {
            List<puertoBE> lista = new List<puertoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_punto_llegada";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_PAIS_DESTINO", pais_destino));
                    cmd.Parameters.Add(new OracleParameter("P_MEDIO_TRANSPORTE", medio_transporte));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                puertoBE item = new puertoBE();
                                item.codigo_puerto = helperDA.GetString(reader, "codigo_puerto");
                                item.descripcion_puerto = helperDA.GetString(reader, "descripcion_puerto");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_punto_llegada", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<lugar_inspeccionBE> listar_lugar_inspeccion()
        {
            List<lugar_inspeccionBE> lista = new List<lugar_inspeccionBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_lugar_inspeccion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lugar_inspeccionBE item = new lugar_inspeccionBE();
                                item.codigo_lugar_inspeccion = helperDA.GetString(reader, "codigo_lugar_inspeccion");
                                item.nombre_lugar_inspeccion = helperDA.GetString(reader, "nombre_lugar_inspeccion");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_lugar_inspeccion", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<sedeBE> listar_direccion_ejecutiva()
        {
            List<sedeBE> lista = new List<sedeBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_direccion_ejecutiva";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sedeBE item = new sedeBE();
                                item.ccodsed = helperDA.GetString(reader, "ccodsed");
                                item.cdessed = helperDA.GetString(reader, "cdessed");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_direccion_ejecutiva", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<centro_tramite> listar_centro_tramite(string codi_sede_sed)
        {
            List<centro_tramite> lista = new List<centro_tramite>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_centro_tramite";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CODI_SEDE_SED", codi_sede_sed));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                centro_tramite item = new centro_tramite();
                                item.codigo_centro_tramite = helperDA.GetString(reader, "codigo_centro_tramite");
                                item.descripcion_centro_tramite = helperDA.GetString(reader, "descripcion_centro_tramite");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_centro_tramite", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<productoBE> listar_especie()
        {
            List<productoBE> lista = new List<productoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_especie";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productoBE item = new productoBE();
                                item.codigo_producto = helperDA.GetString(reader, "codigo_producto");
                                item.nombre_comercial_producto = helperDA.GetString(reader, "nombre_comercial_producto");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_especie", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<unidad_medidaBE> listar_unidad_medida()
        {
            List<unidad_medidaBE> lista = new List<unidad_medidaBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_unidad_medida";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                unidad_medidaBE item = new unidad_medidaBE();
                                item.codi_unid_med = helperDA.GetString(reader, "codi_unid_med");
                                item.desc_unid_med = helperDA.GetString(reader, "desc_unid_med");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_unidad_medida", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<tipo_envaseBE> listar_tipo_envase()
        {
            List<tipo_envaseBE> lista = new List<tipo_envaseBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_tipo_envase";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipo_envaseBE item = new tipo_envaseBE();
                                item.codigo_tipo_envase = helperDA.GetString(reader, "codigo_tipo_envase");
                                item.descripcion_tipo_envase = helperDA.GetString(reader, "descripcion_tipo_envase");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_tipo_envase", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<solicitud_insepccion_expo_detBE> listar_animal(int id_sie_cab)
        {
            List<solicitud_insepccion_expo_detBE> lista = new List<solicitud_insepccion_expo_detBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_animal";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitud_insepccion_expo_detBE item = new solicitud_insepccion_expo_detBE();
                                item.id = helperDA.GetInteger(reader, "id");
                                item.codigo_tipo_envase = helperDA.GetString(reader, "codigo_tipo_envase");
                                item.edad = helperDA.GetInteger(reader, "EDAD");
                                item.raza = helperDA.GetString(reader, "RAZA");
                                item.identificacion = helperDA.GetString(reader, "IDENTIFICACION");
                                item.cantidad = helperDA.GetInteger(reader, "CANTIDAD");
                                item.desc_unid_med = helperDA.GetString(reader, "DESC_UNID_MED");
                                item.descripcion_tipo_envase = helperDA.GetString(reader, "DESCRIPCION_TIPO_ENVASE");
                                item.nombre_comercial_producto = helperDA.GetString(reader, "nombre_comercial_producto");
                                item.nombre_tipo_sexo = helperDA.GetString(reader, "NOMBRE_TIPO_SEXO");
                                item.secuencial = helperDA.GetInteger(reader, "SECUENCIAL");
                                item.codigo_producto = helperDA.GetString(reader, "CODIGO_PRODUCTO");
                                item.especie = helperDA.GetString(reader, "especie");
                                item.id_tipo_sexo = helperDA.GetString(reader, "id_tipo_sexo");
                                item.codi_unid_med = helperDA.GetString(reader, "CODI_UNID_MED");
                                item.microchip = helperDA.GetString(reader, "microchip");
                                item.color = helperDA.GetString(reader, "color");
                                item.pais_destino = helperDA.GetString(reader, "pais_destino");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_animal", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<medico_veterinario_padronBE> listar_medico(string nombre, string id_marca, int id_solicitud, string codi_depa_dpt, string codi_prov_tpr, string codi_dist_tdi)
        {
            List<medico_veterinario_padronBE> lista = new List<medico_veterinario_padronBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_medico";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_NOMBRE_MEDICO", nombre));
                    cmd.Parameters.Add(new OracleParameter("P_ID_SOLICITUD", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_DEPA_DPT", codi_depa_dpt));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_PROV_TPR", codi_prov_tpr));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_DIST_TDI", codi_dist_tdi));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                medico_veterinario_padronBE item = new medico_veterinario_padronBE();
                                item.codi_medi_vet = helperDA.GetString(reader, "CODI_MEDI");
                                item.nomb_cort_vet = helperDA.GetString(reader, "NOMB_CORT");
                                item.dire_medi_vet = helperDA.GetString(reader, "DIRE_MEDI");
                                item.codi_cmvp_vet = helperDA.GetString(reader, "CODI_CMVP");
                                item.nomb_depa_vet = helperDA.GetString(reader, "nomb_depa");
                                item.nomb_prov_vet = helperDA.GetString(reader, "nomb_prov");
                                item.nomb_dist_vet = helperDA.GetString(reader, "nomb_dist");
                                item.email_medi_vet = helperDA.GetString(reader, "email");
                                item.id_marca_inspeccion = id_marca;
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_medico", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<claseBE> listar_clase()
        {
            List<claseBE> lista = new List<claseBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_clase";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                claseBE item = new claseBE();
                                item.codigo_clase = helperDA.GetString(reader, "CODIGO_CLASE");
                                item.descripcion_clase = helperDA.GetString(reader, "DESCRIPCION_CLASE");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_clase", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<area_gestionBE> listar_area(string codigo_clase)
        {
            List<area_gestionBE> lista = new List<area_gestionBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_area";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CLASE", codigo_clase));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                area_gestionBE item = new area_gestionBE();
                                item.codigo_area_gestion = helperDA.GetString(reader, "CODIGO_AREA_GESTION");
                                item.descripcion_area_gestion = helperDA.GetString(reader, "DESCRIPCION_AREA_GESTION");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_area", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<procedimiento_tupaBE> listar_procedimiento()
        {
            List<procedimiento_tupaBE> lista = new List<procedimiento_tupaBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_procedimiento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new OracleParameter("p_parametro", "v_parametro"));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                procedimiento_tupaBE item = new procedimiento_tupaBE();
                                item.codigo_procedimiento_tupa = helperDA.GetString(reader, "CODIGO_PROCEDIMIENTO_TUPA");
                                item.descripcion_procedimiento_tupa = helperDA.GetString(reader, "DESCRIPCION_PROCEDIMIETO_TUPA");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_procedimiento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public List<certificado> listar_certificado_cab(int id_solicitud)
        {
            List<certificado> lista = new List<certificado>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_certificado_cab";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                certificado item = new certificado();
                                item.numero_expediente = helperDA.GetString(reader, "NUMERO_EXPEDIENTE");
                                item.nombre_exportador = helperDA.GetString(reader, "NOMBRE_EXPORTADOR");
                                item.direccion_exportador = helperDA.GetString(reader, "DIRECCION_EXPORTADOR");
                                item.nombre_importador = helperDA.GetString(reader, "NOMBRE_IMPORTADOR");
                                item.direccion_importador = helperDA.GetString(reader, "DIRECCION_IMPORTADOR");
                                item.pais_transito = helperDA.GetString(reader, "PAIS_TRANSITO");
                                item.pais_destino = helperDA.GetString(reader, "PAIS_DESTINO");
                                item.medio_transporte = helperDA.GetString(reader, "MEDIO_TRANSPORTE");
                                item.punto_salida = helperDA.GetString(reader, "PUNTO_SALIDA");
                                item.fecha_embarque = helperDA.GetString(reader, "FECHA_EMBARQUE");
                                item.punto_llegada = helperDA.GetString(reader, "PUNTO_LLEGADA");
                                item.uso_destino = helperDA.GetString(reader, "USO_DESTINO");
                                item.fecha_inspeccion = helperDA.GetString(reader, "FECHA_INSPECCION");
                                item.hora_inspe = helperDA.GetString(reader, "HORA_INSPE");
                                item.requiere_tratamiento = helperDA.GetString(reader, "REQUIERE_TRATAMIENTO");
                                item.requiere_analisis_lab = helperDA.GetString(reader, "REQUIERE_ANALISIS_LAB");
                                item.medida_sanitaria_cert = helperDA.GetString(reader, "MEDIDA_SANITARIA_CERT");
                                item.puesto_control_salida = helperDA.GetString(reader, "PUESTO_CONTROL_SALIDA");
                                item.cumple_req_pais_des = helperDA.GetString(reader, "CUMPLE_REQ_PAIS_DES");
                                item.cumple_exg_senasa = helperDA.GetString(reader, "CUMPLE_EXG_SENASA");
                                item.apto_cert = helperDA.GetString(reader, "APTO_CERT");

                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_documento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public List<certificado_detBE> listar_certificado_det(int id_solicitud)
        {
            List<certificado_detBE> lista = new List<certificado_detBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_certificado_det";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                certificado_detBE item = new certificado_detBE();
                                item.especie = helperDA.GetString(reader, "ESPECIE");
                                item.cantidad = helperDA.GetString(reader, "CANTIDAD");
                                item.identificacion = helperDA.GetString(reader, "IDENTIFICACION");
                                item.raza = helperDA.GetString(reader, "RAZA");
                                item.sexo = helperDA.GetString(reader, "SEXO");
                                item.edad = helperDA.GetString(reader, "EDAD");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_documento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public List<concepto_pagoBE> listar_concepto_pago(int id_solicitud, string codigo_area, string id_marca_inspeccion)
        {
            List<concepto_pagoBE> lista = new List<concepto_pagoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_concepto_pago";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SOLICITUD", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_AREA", codigo_area));
                    cmd.Parameters.Add(new OracleParameter("P_ID_MARCA_INSPECCION", id_marca_inspeccion));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                concepto_pagoBE item = new concepto_pagoBE();
                                item.codigo_servicio = helperDA.GetString(reader, "CODIGO_SERVICIO");
                                item.descripcion_servicio = helperDA.GetString(reader, "DESCRIPCION_SERVICIO");
                                item.tarifa = helperDA.GetDecimal(reader, "TARIFA");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_concepto_pago", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<bancoBE> listar_info_banco()
        {
            List<bancoBE> lista = new List<bancoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_banco_cuenta";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bancoBE item = new bancoBE();
                                item.nombre_banco = helperDA.GetString(reader, "NOMBRE_BANCO");
                                item.numero_cuenta = helperDA.GetString(reader, "NUMERO_CTA");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_info_banco", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<tipo_pagoBE> listar_tipo_pago()
        {
            List<tipo_pagoBE> lista = new List<tipo_pagoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_tipo_pago";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipo_pagoBE item = new tipo_pagoBE();
                                item.codigo_tipo_pago = helperDA.GetInteger(reader, "CODIGO_TIPO_PAGO");
                                item.descripcion_tipo_pago = helperDA.GetString(reader, "DESCRIPCION_TIPO_PAGO");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_tipo_pago", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<bancoBE> listar_banco()
        {
            List<bancoBE> lista = new List<bancoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_banco";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bancoBE item = new bancoBE();
                                item.codigo_banco = helperDA.GetString(reader, "CODIGO_BANCO");
                                item.nombre_banco = helperDA.GetString(reader, "NOMBRE_BANCO");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_banco", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<cuenta_corrienteBE> listar_cuenta_corriente(string codigo_banco)
        {
            List<cuenta_corrienteBE> lista = new List<cuenta_corrienteBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_cuenta_corriente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_BANCO", codigo_banco));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cuenta_corrienteBE item = new cuenta_corrienteBE();
                                item.codigo_cta_cte = helperDA.GetString(reader, "CODIGO_CTA_CTE");
                                item.numero_cta = helperDA.GetString(reader, "NUMERO_CTA");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_cuenta_corriente", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<solicitud_insepccion_expo_recibo_pagoBE> listar_recibo_pago(int id_sie_cab)
        {
            List<solicitud_insepccion_expo_recibo_pagoBE> lista = new List<solicitud_insepccion_expo_recibo_pagoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_recibo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitud_insepccion_expo_recibo_pagoBE item = new solicitud_insepccion_expo_recibo_pagoBE();
                                item.id = helperDA.GetInteger(reader, "id");
                                item.secuencial = helperDA.GetInteger(reader, "secuencial");
                                item.codigo_tipo_pago = helperDA.GetInteger(reader, "codigo_tipo_pago");
                                item.codigo_banco = helperDA.GetString(reader, "codigo_banco");
                                item.codigo_cta_cte = helperDA.GetString(reader, "codigo_cta_cte");
                                item.descripcion_tipo_pago = helperDA.GetString(reader, "DESCRIPCION_TIPO_PAGO");
                                item.nombre_banco = helperDA.GetString(reader, "NOMBRE_BANCO");
                                item.numero_cta_cte = helperDA.GetString(reader, "NUMERO_CTA");
                                item.num_boleta_depo = helperDA.GetString(reader, "NUM_BOLETA_DEPO");
                                item.monto = helperDA.GetDecimal(reader, "MONTO");
                                item.fecha_depo = helperDA.GetString(reader, "FECHA_DEPO");
                                item.fecha_depo2 = helperDA.GetString(reader, "FECHA_DEPO2");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_recibo_pago", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }
        public List<solicitud_inspeccion_relacion_documentoBE> listar_documento(string tipo_documento, int id_solicitud)
        {
            List<solicitud_inspeccion_relacion_documentoBE> lista = new List<solicitud_inspeccion_relacion_documentoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_documento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_DOCUMENTO", tipo_documento));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitud_inspeccion_relacion_documentoBE item = new solicitud_inspeccion_relacion_documentoBE();
                                item.id = helperDA.GetInteger(reader, "id");
                                item.nomb_documento = helperDA.GetString(reader, "NOMB_DOCUMENTO");
                                item.desc_documento = helperDA.GetString(reader, "DESC_DOCUMENTO");
                                item.condicion = helperDA.GetString(reader, "CONDICION");
                                item.info_documento = helperDA.GetString(reader, "INFO_DOCUMENTO");
                                item.estado = helperDA.GetString(reader, "estado");
                                item.fecha = helperDA.GetString(reader, "fecha");
                                item.id_sie_doc_det = helperDA.GetInteger(reader, "id_sie_doc_det");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_documento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public List<solicitud_inspeccion_relacion_documentoBE> listar_documento2(int id_solicitud)
        {
            List<solicitud_inspeccion_relacion_documentoBE> lista = new List<solicitud_inspeccion_relacion_documentoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_documento_inf_cert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitud_inspeccion_relacion_documentoBE item = new solicitud_inspeccion_relacion_documentoBE();
                                item.id = helperDA.GetInteger(reader, "id");
                                item.nomb_documento = helperDA.GetString(reader, "NOMB_DOCUMENTO");
                                item.desc_documento = helperDA.GetString(reader, "DESC_DOCUMENTO");
                                item.condicion = helperDA.GetString(reader, "CONDICION");
                                item.info_documento = helperDA.GetString(reader, "INFO_DOCUMENTO");
                                item.estado = helperDA.GetString(reader, "estado");
                                item.fecha = helperDA.GetString(reader, "fecha");
                                item.id_sie_doc_det = helperDA.GetInteger(reader, "id_sie_doc_det");
                                item.origen = helperDA.GetString(reader, "origen");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_documento2", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public List<solicitud_inspeccion_relacion_documentoBE> listar_documento_espec_sen(int id_solicitud)
        {
            List<solicitud_inspeccion_relacion_documentoBE> lista = new List<solicitud_inspeccion_relacion_documentoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_documento_espec_sen";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_solicitud));
                    //cmd.Parameters.Add(new OracleParameter("P_TIPO_DOCUMENTO", tipo_documento));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitud_inspeccion_relacion_documentoBE item = new solicitud_inspeccion_relacion_documentoBE();
                                item.id = helperDA.GetInteger(reader, "id");
                                item.nomb_documento = helperDA.GetString(reader, "NOMB_DOCUMENTO");
                                item.desc_documento = helperDA.GetString(reader, "DESC_DOCUMENTO");
                                item.condicion = helperDA.GetString(reader, "CONDICION");
                                item.info_documento = helperDA.GetString(reader, "INFO_DOCUMENTO");
                                item.estado = helperDA.GetString(reader, "estado");
                                item.fecha = helperDA.GetString(reader, "fecha");
                                item.id_sie_doc_det = helperDA.GetInteger(reader, "id_sie_doc_det");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_documento_espec_sen", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public List<solicitud_inspeccion_expoBE> listar_solicitud(int situacion, string? estado, string? codigo, string? tipo_usuario)
        {
            List<solicitud_inspeccion_expoBE> lista = new List<solicitud_inspeccion_expoBE>();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_listar_solicitud";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_SITUACION", situacion));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO", codigo));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_USUARIO", tipo_usuario));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitud_inspeccion_expoBE item = new solicitud_inspeccion_expoBE();
                                item.id = helperDA.GetInteger(reader, "ID");
                                item.nombre_importador = helperDA.GetString(reader, "NOMBRE_IMPORTADOR");
                                item.nombre_exportador = helperDA.GetString(reader, "NOMBRE_EXPORTADOR");
                                item.fech_embarque = helperDA.GetString(reader, "FECH_EMBARQUE");
                                item.fech_desembarque = helperDA.GetString(reader, "FECH_DESEMBARQUE");
                                item.nombre_pais_origen = helperDA.GetString(reader, "NOMBRE_PAIS_ORIGEN");
                                item.nombre_pais_destino = helperDA.GetString(reader, "NOMBRE_PAIS_DESTINO");
                                item.nombre_pais_transito = helperDA.GetString(reader, "NOMBRE_PAIS_TRANSITO");
                                item.nombre_situacion = helperDA.GetString(reader, "NOMBRE_SITUACION");
                                item.componente_paso = helperDA.GetString(reader, "COMPONENTE_PASO");
                                item.id_paso = helperDA.GetInteger(reader, "ID_PASO");
                                item.secuencia_paso = helperDA.GetInteger(reader, "SECUENCIA");
                                item.nombre_paso = helperDA.GetString(reader, "NOMBRE_PASO");
                                item.situacion = helperDA.GetInteger(reader, "SITUACION");
                                item.estado_solicitud = helperDA.GetString(reader, "ESTADO_SOLICITUD");
                                item.nombre_medio_transporte = helperDA.GetString(reader, "NOMBRE_MEDIO_TRANSPORTE");
                                item.fecha_solicitud = helperDA.GetString(reader, "FECHA_SOLICITUD");
                                item.nombre_medico = helperDA.GetString(reader, "nombre_medico");
                                item.nombre_revisor = helperDA.GetString(reader, "nomb_empl_rev");
                                item.nombre_especialista = helperDA.GetString(reader, "nomb_empl_esp");
                                item.usuario_revisor = helperDA.GetString(reader, "usu_empl_rev");
                                item.usuario_especialista = helperDA.GetString(reader, "usu_empl_esp");
                                item.codigo_revisor = helperDA.GetString(reader, "CODI_EMPL_REV");
                                item.codigo_especialista = helperDA.GetString(reader, "CODI_EMPL_ESP");
                                item.codigo_exportador = helperDA.GetString(reader, "CODIGO_EXPORTADOR");
                                item.codigo_importador = helperDA.GetString(reader, "CODIGO_IMPORTADOR");
                                item.id_marca_inspeccion = helperDA.GetString(reader, "id_marca_inspeccion");

                                item.comentario_revision = helperDA.GetString(reader, "comentario_revision");
                                item.fech_crea_formato = helperDA.GetString(reader, "fecha_crea");
                                item.fech_modi_formato = helperDA.GetString(reader, "fecha_modi");
                                item.fech_apro_formato = helperDA.GetString(reader, "fecha_apro");
                                item.fech_cert_formato = helperDA.GetString(reader, "fecha_cert");
                                item.numero_expediente = helperDA.GetString(reader, "numero_expediente");
                                lista.Add(item);
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("listar_solicitud", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return lista;
        }

        public respuestaBE registrar_exportador(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_exportador";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_CCODEXP", solicitud.ccodexp));
                    cmd.Parameters.Add(new OracleParameter("P_USER_CREA", solicitud.user_crea));
                    cmd.Parameters.Add(new OracleParameter("P_CORREO_CONTACTO", solicitud.correo_contacto));
                    cmd.Parameters.Add(new OracleParameter("P_TELEFONO_CONTACTO", solicitud.telefono_contacto));
                    cmd.Parameters.Add(new OracleParameter("P_ID_MARCA_INSPECCION", solicitud.id_marca_inspeccion));
                    cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_exportador", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_importador(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_importador";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_IMPORTADOR", solicitud.codigo_importador));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_importador", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public respuestaBE registrar_importador2(importadoresBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_nuevo_importador";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_IMPORTADOR", solicitud.codigo_importador));
                    cmd.Parameters.Add(new OracleParameter("P_NOMBRE_IMPORTADOR", solicitud.nombre_importador));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_PAIS_TPA", solicitud.codi_pais_tpa));
                    cmd.Parameters.Add(new OracleParameter("P_CIUDAD_IMPORTADOR", solicitud.ciudad_importador));
                    cmd.Parameters.Add(new OracleParameter("P_DIRECCION_IMPORTADOR", solicitud.direccion_importador));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_GENERADO", OracleDbType.Varchar2,20,"", ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.codigo = cmd.Parameters["P_CODIGO_GENERADO"].Value.ToString();
                        data.mensaje = (data.codigo.Trim().Length.Equals(0)) ? "No se registro el importador" : "";
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_importador2", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_envio(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_envio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_FECH_PROBL_INSPE", solicitud.fecha_probl_inspe));
                    cmd.Parameters.Add(new OracleParameter("P_HORA_INSPE", solicitud.hora_inspe));
                    cmd.Parameters.Add(new OracleParameter("P_MINUTO_INSPE", solicitud.minuto_inspe));
                    cmd.Parameters.Add(new OracleParameter("P_FECH_EMBARQUE", solicitud.fech_embarque));
                    cmd.Parameters.Add(new OracleParameter("P_FECH_DESEMBARQUE", solicitud.fech_desembarque));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CLASE", solicitud.codigo_clase));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_APLICACION", solicitud.codigo_aplicacion));
                    cmd.Parameters.Add(new OracleParameter("P_PAIS_ORIGEN_CODI_PAIS_TPA", solicitud.pais_origen_codi_pais_tpa));
                    cmd.Parameters.Add(new OracleParameter("P_PAIS_TRANSITO_CODI_PAIS_TPA", solicitud.pais_transito_codi_pais_tpa));
                    cmd.Parameters.Add(new OracleParameter("P_PAIS_DESTINO_CODI_PAIS_TPA", solicitud.pais_destino_codi_pais_tpa));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_MEDIO_TRANSPORTE", solicitud.codigo_medio_transporte));
                    cmd.Parameters.Add(new OracleParameter("P_CCODSED", solicitud.ccodsed));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_PUERTO_SALIDA", solicitud.codigo_puerto_salida));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_PUERTO_LLEGADA", solicitud.codigo_puerto_llegada));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_LUGAR_INSPECCION", solicitud.codigo_lugar_inspeccion));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CENTRO_TRAMITE", solicitud.codigo_centro_tramite));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_envio", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_animal(solicitud_insepccion_expo_detBE detalle)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_animal";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", detalle.id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_PRODUCTO", detalle.codigo_producto));
                    cmd.Parameters.Add(new OracleParameter("P_ID_TIPO_SEXO", detalle.id_tipo_sexo));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_UNID_MED", detalle.codi_unid_med));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_TIPO_ENVASE", detalle.codigo_tipo_envase));
                    cmd.Parameters.Add(new OracleParameter("P_CANTIDAD", detalle.cantidad));
                    cmd.Parameters.Add(new OracleParameter("P_EDAD", detalle.edad));
                    cmd.Parameters.Add(new OracleParameter("P_ESPECIE", detalle.especie));
                    cmd.Parameters.Add(new OracleParameter("P_RAZA", detalle.raza));
                    cmd.Parameters.Add(new OracleParameter("P_IDENTIFICACION", detalle.identificacion));
                    cmd.Parameters.Add(new OracleParameter("P_MICROCHIP", detalle.microchip));
                    cmd.Parameters.Add(new OracleParameter("P_COLOR", detalle.color));
                    cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_animal", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE editar_animal(solicitud_insepccion_expo_detBE detalle)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_editar_animal";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", detalle.id));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_PRODUCTO", detalle.codigo_producto));
                    cmd.Parameters.Add(new OracleParameter("P_ID_TIPO_SEXO", detalle.id_tipo_sexo));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_UNID_MED", detalle.codi_unid_med));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_TIPO_ENVASE", detalle.codigo_tipo_envase));
                    cmd.Parameters.Add(new OracleParameter("P_CANTIDAD", detalle.cantidad));
                    cmd.Parameters.Add(new OracleParameter("P_EDAD", detalle.edad));
                    cmd.Parameters.Add(new OracleParameter("P_ESPECIE", detalle.especie));
                    cmd.Parameters.Add(new OracleParameter("P_RAZA", detalle.raza));
                    cmd.Parameters.Add(new OracleParameter("P_IDENTIFICACION", detalle.identificacion));
                    cmd.Parameters.Add(new OracleParameter("P_MICROCHIP", detalle.microchip));
                    cmd.Parameters.Add(new OracleParameter("P_COLOR", detalle.color));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("editar_animal", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE anular_animal(solicitud_insepccion_expo_detBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_anular_animal";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("anular_animal", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_animal2(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_animal2";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_animal2", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_medico(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_medico";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_CODI_MEDI_VET", solicitud.codi_medi_vet));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_medico", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_recibo(solicitud_insepccion_expo_recibo_pagoBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_recibo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", solicitud.id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_TIPO_PAGO", solicitud.codigo_tipo_pago));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_BANCO", solicitud.codigo_banco));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CTA_CTE", solicitud.codigo_cta_cte));
                    cmd.Parameters.Add(new OracleParameter("P_NUM_BOLETA_DEPO", solicitud.num_boleta_depo));
                    cmd.Parameters.Add(new OracleParameter("P_FECHA_DEPO", solicitud.fecha_depo));
                    cmd.Parameters.Add(new OracleParameter("P_MONTO", solicitud.monto));
                    cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_recibo", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE editar_recibo(solicitud_insepccion_expo_recibo_pagoBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_editar_recibo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", solicitud.id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_TIPO_PAGO", solicitud.codigo_tipo_pago));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_BANCO", solicitud.codigo_banco));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CTA_CTE", solicitud.codigo_cta_cte));
                    cmd.Parameters.Add(new OracleParameter("P_NUM_BOLETA_DEPO", solicitud.num_boleta_depo));
                    cmd.Parameters.Add(new OracleParameter("P_FECHA_DEPO", solicitud.fecha_depo));
                    cmd.Parameters.Add(new OracleParameter("P_MONTO", solicitud.monto));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("editar_recibo", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE anular_recibo(solicitud_insepccion_expo_recibo_pagoBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_anular_recibo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("anular_recibo", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_pago(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_pago";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CLASE", solicitud.codigo_clase));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_PROCEDIMIENTO_TUPA", solicitud.codigo_procedimiento_tupa));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_AREA_GESTION", solicitud.codigo_area_gestion));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_SERVICIO", solicitud.codigo_servicio));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_pago", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_documento(solicitud_inspeccion_expo_doc_adj_detBE documento)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_documento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", documento.id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_DATAOBJECT", OracleDbType.Blob, documento.dataobject, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_documento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_documento_recibo(solicitud_insepccion_expo_recibo_pagoBE documento)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_adjunto";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", documento.id));
                    cmd.Parameters.Add(new OracleParameter("P_DATAOBJECT", OracleDbType.Blob, documento.dataobject, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_documento_recibo", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_documento2(solicitud_inspeccion_expo_doc_adj_detBE documento)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_documento2";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", documento.id));
                    cmd.Parameters.Add(new OracleParameter("P_FILENAME", documento.filename));
                    cmd.Parameters.Add(new OracleParameter("P_FILEEXTENSION", documento.fileextension));
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", documento.id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_ID_REL_DOC", documento.id_rel_doc));
                    cmd.Parameters.Add(new OracleParameter("P_USER_CREA", documento.user_crea));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_documento2", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_documento3(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_documento3";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_documento3", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public respuestaBE registrar_asignacion_solicitud(solicitud_inspeccion_expo_cabBE _data)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_asignacion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", _data.id));
                    cmd.Parameters.Add(new OracleParameter("P_codi_empl_rev", _data.codi_empl_rev));
                    cmd.Parameters.Add(new OracleParameter("P_codi_empl_esp", _data.codi_empl_esp));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", _data.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_asignacion_solicitud", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE reservar_asignacion(solicitud_asignacionBE _data)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_reserva_solicitud";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", _data.id));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_MODI", _data.tipo));
                    cmd.Parameters.Add(new OracleParameter("P_USER_EMPL", _data.codigo));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", _data.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("reservar_asignacion", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE liberar_asignacion(solicitud_asignacionBE _data)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_liberar_solicitud";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", _data.id));
                    cmd.Parameters.Add(new OracleParameter("P_TIPO_MODI", _data.tipo));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", _data.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("liberar_asignacion", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE liberar_medico(solicitud_asignacionBE _data)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_liberar_medico";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", _data.id));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", _data.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("liberar_medico", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public respuestaBE registrar_revision_solicitud(solicitud_inspeccion_expo_cabBE _data)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_revision";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", _data.id));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_vacunacion", _data.w_certificado_vacunacion));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_salud", _data.w_certificado_salud));
                    cmd.Parameters.Add(new OracleParameter("P_w_recibo_pago", _data.w_recibo_pago));
                    cmd.Parameters.Add(new OracleParameter("P_w_constancia_microchip", _data.w_constancia_microchip));
                    cmd.Parameters.Add(new OracleParameter("P_w_documentos_laboratorio", _data.w_documentos_laboratorio));
                    cmd.Parameters.Add(new OracleParameter("P_w_requisito_sanitario", _data.w_requisito_sanitario));
                    cmd.Parameters.Add(new OracleParameter("P_w_temperatura", _data.w_temperatura));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_cardiaca", _data.w_frecuencia_cardiaca));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_respiratoria", _data.w_frecuencia_respiratoria));
                    cmd.Parameters.Add(new OracleParameter("P_w_color_mucosas", _data.w_color_mucosas));
                    cmd.Parameters.Add(new OracleParameter("P_w_heridas", _data.w_heridas));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_externos", _data.w_parasitos_externos));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_internos", _data.w_parasitos_internos));
                    cmd.Parameters.Add(new OracleParameter("P_w_apto_certificacion", _data.w_apto_certificacion));
                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO_REVISION", _data.comentario_revision));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", _data.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_revision_solicitud", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE enviar_revision_solicitud(solicitud_inspeccion_expo_cabBE _data)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_enviar_revision";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", _data.id));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_vacunacion", _data.w_certificado_vacunacion));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_salud", _data.w_certificado_salud));
                    cmd.Parameters.Add(new OracleParameter("P_w_recibo_pago", _data.w_recibo_pago));
                    cmd.Parameters.Add(new OracleParameter("P_w_constancia_microchip", _data.w_constancia_microchip));
                    cmd.Parameters.Add(new OracleParameter("P_w_documentos_laboratorio", _data.w_documentos_laboratorio));
                    cmd.Parameters.Add(new OracleParameter("P_w_requisito_sanitario", _data.w_requisito_sanitario));
                    cmd.Parameters.Add(new OracleParameter("P_w_temperatura", _data.w_temperatura));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_cardiaca", _data.w_frecuencia_cardiaca));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_respiratoria", _data.w_frecuencia_respiratoria));
                    cmd.Parameters.Add(new OracleParameter("P_w_color_mucosas", _data.w_color_mucosas));
                    cmd.Parameters.Add(new OracleParameter("P_w_heridas", _data.w_heridas));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_externos", _data.w_parasitos_externos));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_internos", _data.w_parasitos_internos));
                    cmd.Parameters.Add(new OracleParameter("P_w_apto_certificacion", _data.w_apto_certificacion));
                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO_REVISION", _data.comentario_revision));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", _data.user_modi));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("enviar_revision_solicitud", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public respuestaBE registrar_revision_senasa(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_revision_senasa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_ESTADO", solicitud.estado));
                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO_REVISION", solicitud.comentario_revision));
                    cmd.Parameters.Add(new OracleParameter("P_USER_APR", solicitud.user_apro));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_revision_senasa", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE registrar_certificacion(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_registrar_certificacion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id)); 
                    cmd.Parameters.Add(new OracleParameter("P_ESTADO", solicitud.estado));  
                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO_REVISION", solicitud.comentario_revision));
                    cmd.Parameters.Add(new OracleParameter("P_USER_APR", solicitud.user_apro));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CERTIFICADO", solicitud.codigo_certificado));
                    cmd.Parameters.Add(new OracleParameter("P_DESC_CERTIFICADO_EXPO", solicitud.desc_certificado_expo));
                    cmd.Parameters.Add(new OracleParameter("P_OBSERVACION_CERTIFICADO_EXPO", solicitud.observacion_certificado_expo));
                    cmd.Parameters.Add(new OracleParameter("P_MEDIDA_SANITARIA_CERT", solicitud.medida_sanitaria_cert));
                    cmd.Parameters.Add(new OracleParameter("P_IDIOMA_CERT", solicitud.idioma_cert)); 
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_vacunacion", solicitud.w_certificado_vacunacion));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_salud", solicitud.w_certificado_salud));
                    cmd.Parameters.Add(new OracleParameter("P_w_recibo_pago", solicitud.w_recibo_pago));
                    cmd.Parameters.Add(new OracleParameter("P_w_constancia_microchip", solicitud.w_constancia_microchip));
                    cmd.Parameters.Add(new OracleParameter("P_w_documentos_laboratorio", solicitud.w_documentos_laboratorio));
                    cmd.Parameters.Add(new OracleParameter("P_w_requisito_sanitario", solicitud.w_requisito_sanitario));
                    cmd.Parameters.Add(new OracleParameter("P_w_temperatura", solicitud.w_temperatura));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_cardiaca", solicitud.w_frecuencia_cardiaca));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_respiratoria", solicitud.w_frecuencia_respiratoria));
                    cmd.Parameters.Add(new OracleParameter("P_w_color_mucosas", solicitud.w_color_mucosas));
                    cmd.Parameters.Add(new OracleParameter("P_w_heridas", solicitud.w_heridas));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_externos", solicitud.w_parasitos_externos));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_internos", solicitud.w_parasitos_internos));
                    cmd.Parameters.Add(new OracleParameter("P_w_apto_certificacion", solicitud.w_apto_certificacion));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));
                    cmd.Parameters.Add(new OracleParameter("P_ESTADO_CERT", solicitud.estado_cert));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("registrar_certificacion", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public respuestaBE aprobar_certificacion_esp(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_aprobar_certificacion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_ESTADO", solicitud.estado));
                    cmd.Parameters.Add(new OracleParameter("P_COMENTARIO_REVISION", solicitud.comentario_revision));
                    cmd.Parameters.Add(new OracleParameter("P_USER_APR", solicitud.user_apro));
                    cmd.Parameters.Add(new OracleParameter("P_CODIGO_CERTIFICADO", solicitud.codigo_certificado));
                    cmd.Parameters.Add(new OracleParameter("P_DESC_CERTIFICADO_EXPO", solicitud.desc_certificado_expo));
                    cmd.Parameters.Add(new OracleParameter("P_OBSERVACION_CERTIFICADO_EXPO", solicitud.observacion_certificado_expo));
                    cmd.Parameters.Add(new OracleParameter("P_MEDIDA_SANITARIA_CERT", solicitud.medida_sanitaria_cert));
                    cmd.Parameters.Add(new OracleParameter("P_IDIOMA_CERT", solicitud.idioma_cert));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_vacunacion", solicitud.w_certificado_vacunacion));
                    cmd.Parameters.Add(new OracleParameter("P_w_certificado_salud", solicitud.w_certificado_salud));
                    cmd.Parameters.Add(new OracleParameter("P_w_recibo_pago", solicitud.w_recibo_pago));
                    cmd.Parameters.Add(new OracleParameter("P_w_constancia_microchip", solicitud.w_constancia_microchip));
                    cmd.Parameters.Add(new OracleParameter("P_w_documentos_laboratorio", solicitud.w_documentos_laboratorio));
                    cmd.Parameters.Add(new OracleParameter("P_w_requisito_sanitario", solicitud.w_requisito_sanitario));
                    cmd.Parameters.Add(new OracleParameter("P_w_temperatura", solicitud.w_temperatura));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_cardiaca", solicitud.w_frecuencia_cardiaca));
                    cmd.Parameters.Add(new OracleParameter("P_w_frecuencia_respiratoria", solicitud.w_frecuencia_respiratoria));
                    cmd.Parameters.Add(new OracleParameter("P_w_color_mucosas", solicitud.w_color_mucosas));
                    cmd.Parameters.Add(new OracleParameter("P_w_heridas", solicitud.w_heridas));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_externos", solicitud.w_parasitos_externos));
                    cmd.Parameters.Add(new OracleParameter("P_w_parasitos_internos", solicitud.w_parasitos_internos));
                    cmd.Parameters.Add(new OracleParameter("P_w_apto_certificacion", solicitud.w_apto_certificacion));
                    cmd.Parameters.Add(new OracleParameter("P_USER_MODI", solicitud.user_modi));
                    cmd.Parameters.Add(new OracleParameter("P_ESTADO_CERT", solicitud.estado_cert));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("aprobar_certificacion_esp", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }
        public respuestaBE replicar_solicitud(solicitud_inspeccion_expo_cabBE solicitud)
        {
            respuestaBE data = new respuestaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_replicar_solicitud";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", solicitud.id));
                    cmd.Parameters.Add(new OracleParameter("P_FECH_PROBL_INSPE", solicitud.fecha_probl_inspe));
                    cmd.Parameters.Add(new OracleParameter("P_HORA_INSPE", solicitud.hora_inspe));
                    cmd.Parameters.Add(new OracleParameter("P_MINUTO_INSPE", solicitud.minuto_inspe));
                    cmd.Parameters.Add(new OracleParameter("P_FECH_EMBARQUE", solicitud.fech_embarque));
                    cmd.Parameters.Add(new OracleParameter("P_FECH_DESEMBARQUE", solicitud.fech_desembarque));
                    cmd.Parameters.Add(new OracleParameter("P_ID_MARCA_INSPECCION", solicitud.id_marca_inspeccion));
                    cmd.Parameters.Add(new OracleParameter("P_USER_CREA", solicitud.user_crea));
                    cmd.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int32, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        data.id = Convert.ToInt32(((OracleDecimal)cmd.Parameters["P_ID"].Value).Value);
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        data.mensaje = ex.Message.ToString();
                        Logger.registrar_linea("replicar_solicitud", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return data;
        }

        public solicitud_inspeccion_expo_cabBE recuperar_solicitud(int id_solicitud)
        {
            solicitud_inspeccion_expo_cabBE item = new solicitud_inspeccion_expo_cabBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_solicitud";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SOLICITUD", id_solicitud));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.situacion = helperDA.GetInteger(reader, "situacion");
                                item.estado = helperDA.GetString(reader, "estado");

                                item.nombre_persona = helperDA.GetString(reader, "nombre_persona");
                                item.direccion_persona = helperDA.GetString(reader, "direccion_persona");
                                item.departamento_persona = helperDA.GetString(reader, "nombre_departamento_persona");
                                item.provincia_persona = helperDA.GetString(reader, "nombre_provincia_persona");
                                item.distrito_persona = helperDA.GetString(reader, "nombre_distrito_persona");
                                item.numero_documento_persona = helperDA.GetString(reader, "numero_documento_persona");
                                item.tipo_documento_persona = helperDA.GetString(reader, "nombre_tipo_documento_persona");
                                item.correo_contacto = helperDA.GetString(reader, "correo_contacto");
                                item.telefono_contacto = helperDA.GetString(reader, "telefono_contacto");

                                item.codigo_importador = helperDA.GetString(reader, "codigo_importador");
                                item.nombre_importador = helperDA.GetString(reader, "nombre_importador");
                                item.ciudad_importador = helperDA.GetString(reader, "ciudad_importador");
                                item.direccion_importador = helperDA.GetString(reader, "direccion_importador");
                                item.pais_importador = helperDA.GetString(reader, "nomb_pais_tpa");

                                item.fecha_probl_inspe = helperDA.GetString(reader, "FECH_PROBL_INSPE");
                                item.hora_inspe = helperDA.GetString(reader, "HORA_INSPE");
                                item.minuto_inspe = helperDA.GetString(reader, "MINUTO_INSPE");
                                item.fech_embarque = helperDA.GetString(reader, "FECH_EMBARQUE");
                                item.fech_desembarque = helperDA.GetString(reader, "FECH_DESEMBARQUE");
                                item.codigo_aplicacion = helperDA.GetString(reader, "CODIGO_APLICACION");
                                item.pais_origen_codi_pais_tpa = helperDA.GetString(reader, "PAIS_ORIGEN_CODI_PAIS_TPA");
                                item.pais_transito_codi_pais_tpa = helperDA.GetString(reader, "PAIS_TRANSITO_CODI_PAIS_TPA");
                                item.pais_destino_codi_pais_tpa = helperDA.GetString(reader, "PAIS_DESTINO_CODI_PAIS_TPA");
                                item.codigo_medio_transporte = helperDA.GetString(reader, "CODIGO_MEDIO_TRANSPORTE");
                                item.ccodsed = helperDA.GetString(reader, "CCODSED");
                                item.codigo_puerto_salida = helperDA.GetString(reader, "CODIGO_PUERTO_SALIDA");
                                item.codigo_puerto_llegada = helperDA.GetString(reader, "CODIGO_PUERTO_LLEGADA");
                                item.codigo_lugar_inspeccion = helperDA.GetString(reader, "CODIGO_LUGAR_INSPECCION");
                                item.comentario_revision = helperDA.GetString(reader, "COMENTARIO_REVISION");
                                item.codigo_centro_tramite = helperDA.GetString(reader, "CODIGO_CENTRO_TRAMITE");
                                item.descripcion_centro_tramite = helperDA.GetString(reader, "DESCRIPCION_CENTRO_TRAMITE");

                                item.pais_origen_nomb_pais_tpa = helperDA.GetString(reader, "pais_origen_nomb_pais_tpa");
                                item.pais_destino_nomb_pais_tpa = helperDA.GetString(reader, "pais_destino_nomb_pais_tpa");
                                item.pais_transito_nomb_pais_tpa = helperDA.GetString(reader, "pais_transito_nomb_pais_tpa");
                                item.descripcion_medio_transporte = helperDA.GetString(reader, "descripcion_medio_transporte");
                                item.descripcion_aplicacion = helperDA.GetString(reader, "descripcion_aplicacion");
                                item.descripcion_puerto_salida = helperDA.GetString(reader, "descripcion_puerto_salida");
                                item.descripcion_puerto_llegada = helperDA.GetString(reader, "descripcion_puerto_llegada");
                                item.nombre_lugar_inspeccion = helperDA.GetString(reader, "nombre_lugar_inspeccion");
                                item.desc_sede_sed = helperDA.GetString(reader, "desc_sede_sed");

                                item.id_marca_inspeccion = helperDA.GetString(reader, "ID_MARCA_INSPECCION");
                                item.codi_medi_vet = helperDA.GetString(reader, "CODI_MEDI");
                                item.apel_pate_vet = helperDA.GetString(reader, "APE_PATE");
                                item.apel_mate_vet = helperDA.GetString(reader, "APE_MATE");
                                item.nomb_medi_vet = helperDA.GetString(reader, "NOM_MEDI");
                                item.nomb_cort_vet = helperDA.GetString(reader, "NOMB_CORT");
                                item.dire_medi_vet = helperDA.GetString(reader, "DIRE_MEDI");
                                item.codi_cmvp_vet = helperDA.GetString(reader, "CODI_CMVP");
                                item.numero_documento_medico = helperDA.GetString(reader, "NUME_DOCU_VET");

                                item.w_certificado_vacunacion = helperDA.GetString(reader, "w_certificado_vacunacion");
                                item.w_certificado_salud = helperDA.GetString(reader, "w_certificado_salud");
                                item.w_recibo_pago = helperDA.GetString(reader, "w_recibo_pago");
                                item.w_constancia_microchip = helperDA.GetString(reader, "w_constancia_microchip");
                                item.w_documentos_laboratorio = helperDA.GetString(reader, "w_documentos_laboratorio");
                                item.w_requisito_sanitario = helperDA.GetString(reader, "w_requisito_sanitario");
                                item.w_temperatura = helperDA.GetString(reader, "w_temperatura");
                                item.w_frecuencia_cardiaca = helperDA.GetString(reader, "w_frecuencia_cardiaca");
                                item.w_frecuencia_respiratoria = helperDA.GetString(reader, "w_frecuencia_respiratoria");
                                item.w_color_mucosas = helperDA.GetString(reader, "w_color_mucosas");
                                item.w_heridas = helperDA.GetString(reader, "w_heridas");
                                item.w_parasitos_externos = helperDA.GetString(reader, "w_parasitos_externos");
                                item.w_parasitos_internos = helperDA.GetString(reader, "w_parasitos_internos");
                                item.w_apto_certificacion = helperDA.GetString(reader, "w_apto_certificacion");

                                item.codi_empl_rev = helperDA.GetString(reader, "codi_empl_rev");
                                item.codi_empl_esp = helperDA.GetString(reader, "codi_empl_esp");
                                item.nomb_empl_rev = helperDA.GetString(reader, "nomb_empl_rev");
                                item.nomb_empl_esp = helperDA.GetString(reader, "nomb_empl_esp");
                                item.dni_esp = helperDA.GetString(reader, "dni_esp");
                                item.usu_empl_rev = helperDA.GetString(reader, "usu_empl_rev");
                                item.usu_empl_esp = helperDA.GetString(reader, "usu_empl_esp");

                                item.fecha_revisor = helperDA.GetString(reader, "fecha_revisor");
                                item.fecha_especialista = helperDA.GetString(reader, "fecha_especialista");
                                item.fecha_medico = helperDA.GetString(reader, "fecha_medico");

                                item.codigo_certificado = helperDA.GetString(reader, "CODIGO_CERTIFICADO");
                                item.desc_certificado_expo = helperDA.GetString(reader, "DESC_CERTIFICADO_EXPO");
                                item.observacion_certificado_expo = helperDA.GetString(reader, "OBSERVACION_CERTIFICADO_EXPO");
                                item.medida_sanitaria_cert = helperDA.GetString(reader, "MEDIDA_SANITARIA_CERT");
                                item.idioma_cert = helperDA.GetString(reader, "IDIOMA_CERT");
                                item.estado_cert = helperDA.GetString(reader, "ESTADO_CERT");



                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_solicitud", ex.Message.ToString());
                    }
                    finally
                    {

                        conx.Close();
                    }
                }
            }
            return item;
        }
        public personaBE recuperar_exportador(int id_sie_cab)
        {
            personaBE item = new personaBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_exportador";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.telefono_movil = helperDA.GetString(reader, "telefono_contacto");
                                item.correo_electronico = helperDA.GetString(reader, "correo_contacto");
                                item.nombre_razon_social = helperDA.GetString(reader, "nombre_razon_social");
                                item.persona_tipo = helperDA.GetString(reader, "persona_tipo");
                                item.documento_numero = helperDA.GetString(reader, "documento_numero");
                                item.apellido_paterno = helperDA.GetString(reader, "apellido_paterno");
                                item.apellido_materno = helperDA.GetString(reader, "apellido_materno");
                                item.nombres = helperDA.GetString(reader, "nombres");
                                item.direccion = helperDA.GetString(reader, "direccion");
                                item.persona_id = helperDA.GetString(reader, "persona_id");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_exportador", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
        public importadoresBE recuperar_importador(int id_sie_cab)
        {
            importadoresBE item = new importadoresBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_importador";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {                                
                                item.codigo_importador = helperDA.GetString(reader, "codigo_importador");
                                item.nombre_importador = helperDA.GetString(reader, "nombre_importador");
                                item.ciudad_importador = helperDA.GetString(reader, "ciudad_importador");
                                item.direccion_importador = helperDA.GetString(reader, "direccion_importador");
                                item.codi_pais_tpa = helperDA.GetString(reader, "codi_pais_tpa");
                                item.nomb_pais_tpa = helperDA.GetString(reader, "nomb_pais_tpa");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_importador", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
        public solicitud_inspeccion_expo_cabBE recuperar_envio(int id_sie_cab)
        {
            solicitud_inspeccion_expo_cabBE item = new solicitud_inspeccion_expo_cabBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_envio";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.id = helperDA.GetInteger(reader, "id");
                                item.fecha_probl_inspe = helperDA.GetString(reader, "FECH_PROBL_INSPE");
                                item.hora_inspe = helperDA.GetString(reader, "HORA_INSPE");
                                item.minuto_inspe = helperDA.GetString(reader, "MINUTO_INSPE");
                                item.fech_embarque = helperDA.GetString(reader, "FECH_EMBARQUE");
                                item.fech_desembarque = helperDA.GetString(reader, "FECH_DESEMBARQUE");
                                item.codigo_aplicacion = helperDA.GetString(reader, "CODIGO_APLICACION");
                                item.pais_origen_codi_pais_tpa = helperDA.GetString(reader, "PAIS_ORIGEN_CODI_PAIS_TPA");
                                item.pais_transito_codi_pais_tpa = helperDA.GetString(reader, "PAIS_TRANSITO_CODI_PAIS_TPA");
                                item.pais_destino_codi_pais_tpa = helperDA.GetString(reader, "PAIS_DESTINO_CODI_PAIS_TPA");
                                item.codigo_medio_transporte = helperDA.GetString(reader, "CODIGO_MEDIO_TRANSPORTE");
                                item.ccodsed = helperDA.GetString(reader, "CCODSED");
                                item.codigo_puerto_salida = helperDA.GetString(reader, "CODIGO_PUERTO_SALIDA");
                                item.codigo_puerto_llegada = helperDA.GetString(reader, "CODIGO_PUERTO_LLEGADA");
                                item.codigo_lugar_inspeccion = helperDA.GetString(reader, "CODIGO_LUGAR_INSPECCION");
                                //item.cumplimiento_requisitos = helperDA.GetString(reader, "CUMPLIMIENTO_REQUISITOS");
                                //item.cumplimiento_exigencias = helperDA.GetString(reader, "CUMPLIMIENTO_EXIGENCIAS");
                                //item.resultado_certificacion = helperDA.GetString(reader, "RESULTADO_CERTIFICACION");
                                item.comentario_revision = helperDA.GetString(reader, "COMENTARIO_REVISION");
                                item.codigo_centro_tramite = helperDA.GetString(reader, "CODIGO_CENTRO_TRAMITE");
                                item.descripcion_centro_tramite = helperDA.GetString(reader, "DESCRIPCION_CENTRO_TRAMITE");

                                item.pais_origen_nomb_pais_tpa = helperDA.GetString(reader, "pais_origen_nomb_pais_tpa");
                                item.pais_transito_nomb_pais_tpa = helperDA.GetString(reader, "pais_transito_nomb_pais_tpa");
                                item.pais_destino_nomb_pais_tpa = helperDA.GetString(reader, "pais_destino_nomb_pais_tpa");
                                item.descripcion_medio_transporte = helperDA.GetString(reader, "descripcion_medio_transporte");
                                item.descripcion_aplicacion = helperDA.GetString(reader, "descripcion_aplicacion");
                                item.descripcion_puerto_salida = helperDA.GetString(reader, "descripcion_puerto_salida");
                                item.descripcion_puerto_llegada = helperDA.GetString(reader, "descripcion_puerto_llegada");
                                item.nombre_lugar_inspeccion = helperDA.GetString(reader, "nombre_lugar_inspeccion");
                                item.desc_sede_sed = helperDA.GetString(reader, "desc_sede_sed");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_envio", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
        public medico_veterinario_padronBE recuperar_medico(int id_sie_cab)
        {
            medico_veterinario_padronBE item = new medico_veterinario_padronBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_medico";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_cab));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.id_marca_inspeccion = helperDA.GetString(reader, "ID_MARCA_INSPECCION");
                                item.codi_medi_vet = helperDA.GetString(reader, "CODI_MEDI");
                                item.apel_pate_vet = helperDA.GetString(reader, "APE_PATE");
                                item.apel_mate_vet = helperDA.GetString(reader, "APE_MATE");
                                item.nomb_medi_vet = helperDA.GetString(reader, "NOM_MEDI");
                                item.nomb_cort_vet = helperDA.GetString(reader, "NOMB_CORT");
                                item.dire_medi_vet = helperDA.GetString(reader, "DIRE_MEDI");
                                item.codi_cmvp_vet = helperDA.GetString(reader, "CODI_CMVP");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_medico", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
        public byte[] recuperar_documento(int id_sie_doc_det)
        {
            byte[] byteData = new byte[0];
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_documento";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", id_sie_doc_det));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byteData = (byte[])reader.GetOracleBlob(reader.GetOrdinal("DATAOBJECT")).Value;
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_documento", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return byteData;
        }
        public byte[] recuperar_documento_recibo(int id_sie_rec)
        {
            byte[] byteData = new byte[0];
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_recibo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", id_sie_rec));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byteData = (byte[])reader.GetOracleBlob(reader.GetOrdinal("DATAOBJECT")).Value;
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_documento_recibo", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return byteData;
        }
        public solicitud_inspeccion_expo_cabBE recuperar_pago(int id_sie_doc_det)
        {
            solicitud_inspeccion_expo_cabBE item = new solicitud_inspeccion_expo_cabBE();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_pago";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID", id_sie_doc_det));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.codigo_centro_tramite = helperDA.GetString(reader, "CODIGO_CENTRO_TRAMITE");
                                item.descripcion_centro_tramite = helperDA.GetString(reader, "DESCRIPCION_CENTRO_TRAMITE");
                                item.id_marca_inspeccion = helperDA.GetString(reader, "id_marca_inspeccion");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_pago", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }

        public comprobante recuperar_comprobante(int id_sie_doc)
        {
            comprobante item = new comprobante();
            using (OracleConnection conx = new OracleConnection(conexion))
            {
                helperDA.GetLogonVersionClient(conx);
                using (OracleCommand cmd = conx.CreateCommand())
                {
                    cmd.CommandText = "pkg_mascotaweb.usp_recuperar_comprobante";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("P_ID_SIE_CAB", id_sie_doc));
                    cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output));

                    try
                    {
                        conx.Open();
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                item.recibo = helperDA.GetString(reader, "recibo");
                                item.expediente = helperDA.GetString(reader, "expediente");
                                item.ruc_usuario = helperDA.GetString(reader, "ruc_usuario");
                                item.direccion = helperDA.GetString(reader, "direccion");
                                item.usuario = helperDA.GetString(reader, "usuario");
                                item.total_pagado = helperDA.GetString(reader, "total_pagado");
                                item.aplicativo = helperDA.GetString(reader, "aplicativo");
                                item.fecha_envio = helperDA.GetString(reader, "fecha_envio");
                            }
                        }
                        conx.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.registrar_linea("recuperar_comprobante", ex.Message.ToString());
                    }
                    finally
                    {
                        conx.Close();
                    }
                }
            }
            return item;
        }
    }
}
