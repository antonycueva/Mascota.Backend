using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
using Mascota.Entidad;
using static System.Net.Mime.MediaTypeNames;

namespace Mascota
{
    public static class utilidadBL
    {
        public static respuestaBE enviar_correo(Correo correo)
        {
            respuestaBE respuesta = new respuestaBE();
            try
            {
                SmtpClient smtp = new SmtpClient(AppSettingHelper.servidor)
                {
                    Port = int.Parse(AppSettingHelper.puerto),
                    Credentials = new NetworkCredential(AppSettingHelper.usuario, AppSettingHelper.clave),
                    EnableSsl = (AppSettingHelper.SSL.Equals("S")),
                    Timeout = int.Parse(AppSettingHelper.intervalo)
                };

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(correo.de, AppSettingHelper.nombre);
                mailMessage.To.Add(new MailAddress(correo.para));
                mailMessage.Subject = correo.asunto;
                mailMessage.Body = correo.contenido;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.Priority = MailPriority.High;

                smtp.Send(mailMessage);
                respuesta.id = 1;
                respuesta.mensaje = "";
            }
            catch (Exception ex)
            {
                respuesta.id = -1;
                respuesta.mensaje = ex.Message.ToString();
            }
            return respuesta;
        }
        public static string contenido_registrar_cuenta(usuarioBE usuario)
        {
            string query = File.ReadAllText(Path.Combine(@"BodyContent", "zbody_registrar_cuenta.html"));
            query = query.Replace("{usuario}", usuario.usuario);
            query = query.Replace("{clave}", usuario.clave);
            return query.ToString();
        }
        public static string contenido_recuperar_cuenta(usuarioBE usuario)
        {
            string query = File.ReadAllText(Path.Combine(@"BodyContent", "zbody_recuperar_cuenta.html"));
            query = query.Replace("{usuario}", usuario.usuario);
            query = query.Replace("{clave}", usuario.clave);
            return query.ToString();
        }
        public static string contenido_registrar_solicitud(solicitud_inspeccion_expo_cabBE solicitud)
        {
            string query = File.ReadAllText(Path.Combine(@"BodyContent", "zbody_registrar_solicitud.html"));
            query = query.Replace("{numero_solicitud}", solicitud.id.ToString().PadLeft(7,'0'));
            return query.ToString();
        }
        public static string contenido_asignacion_medico(solicitud_inspeccion_expo_cabBE solicitud)
        {
            string query = File.ReadAllText(Path.Combine(@"BodyContent", "zbody_asignacion_medico.html"));
            query = query.Replace("{numero_solicitud}", solicitud.id.ToString().PadLeft(7, '0'));
            return query.ToString();
        }
    }
}
