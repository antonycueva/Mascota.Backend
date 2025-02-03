using Microsoft.Extensions.Configuration;

namespace Mascota
{
    public static class AppSettingHelper
    {
        public static IConfiguration _config;
        public static void AppSettingsConfigure(IConfiguration config) { _config = config; }
        public static string? ambiente { get { return _config.GetSection("Enviroment").Value; } }
        public static string? conn { get { return _config.GetSection(string.Concat("ConnectionStrings:", ambiente)).Value; } }
        public static string? paquete { get { return _config.GetSection(string.Concat("Package:", ambiente)).Value; } }
        public static string? base_ruta_log { get { return _config.GetSection(string.Concat("PathLog:", ambiente)).Value; } }
        public static string? servidor { get { return _config.GetSection("Mailing:Server").Value; } }
        public static string? usuario { get { return _config.GetSection("Mailing:Usuario").Value; } }
        public static string? clave { get { return _config.GetSection("Mailing:Clave").Value; } }
        public static string? nombre { get { return _config.GetSection("Mailing:Nombre").Value; } }
        public static string? puerto { get { return _config.GetSection("Mailing:Port").Value; } }
        public static string? SSL { get { return _config.GetSection("Mailing:EnableSSL").Value; } }
        public static string? intervalo { get { return _config.GetSection("Mailing:Interval").Value; } }
        public static string? subjectRecuperar { get { return _config.GetSection("Subjets:Recuperar").Value; } }
        public static string? subjectRegistrar { get { return _config.GetSection("Subjets:Registrar").Value; } }
        public static string? subjectNotificarAdministrado { get { return _config.GetSection("Subjets:NotificarAdministrado").Value; } }
    }
}
