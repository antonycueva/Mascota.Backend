using System.IO;

namespace Mascota
{
    public static class Logger
    {
        public static void registrar_linea(string metodo, string error)
        {
            string? base_ruta_log = AppSettingHelper.base_ruta_log;
            if (!string.IsNullOrEmpty(base_ruta_log))
            {
                DateTime fecha = DateTime.Now;
                base_ruta_log = Path.Combine(base_ruta_log, fecha.Year.ToString());
                if (!Directory.Exists(base_ruta_log))
                    Directory.CreateDirectory(base_ruta_log);

                base_ruta_log = Path.Combine(base_ruta_log, fecha.Month.ToString());
                if (!Directory.Exists(base_ruta_log))
                    Directory.CreateDirectory(base_ruta_log);

                base_ruta_log = Path.Combine(base_ruta_log, fecha.ToString("yyyyMMdd"));
                using (FileStream strm = File.Open(base_ruta_log,FileMode.OpenOrCreate))
                {
                    strm.Seek(0, SeekOrigin.End);
                    using (StreamWriter sw = new StreamWriter(strm))
                    {
                        sw.WriteLine(string.Concat(fecha.ToString("HH:mm:ss"), "| ", metodo, "| ", error));
                    }
                       
                }
               

            }
        }
    }
}
