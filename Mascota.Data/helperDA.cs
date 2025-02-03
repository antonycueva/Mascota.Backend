using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace SENASA
{
    class helperDA
    {
        public static void GetLogonVersionClient(OracleConnection conn)
        {
            conn.SqlNetAllowedLogonVersionClient = OracleAllowedLogonVersionClient.Version11;
        }
        public static string GetString(OracleDataReader reader, string name)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(name)))
                return reader.GetString(reader.GetOrdinal(name)).Trim();
            return string.Empty;
        }

        public static int GetInteger(OracleDataReader reader, string name)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(name)))
                return reader.GetInt32(reader.GetOrdinal(name));
            return 0;
        }

        public static bool GetBoolean(OracleDataReader reader, string name)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(name)))
                return reader.GetBoolean(reader.GetOrdinal(name));
            return false;
        }

        public static DateTime GetDateTime(OracleDataReader reader, string name)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(name)))
                return reader.GetDateTime(reader.GetOrdinal(name));
            return DateTime.MinValue;
        }

        public static Decimal GetDecimal(OracleDataReader reader, string name)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(name)))
                return reader.GetDecimal(reader.GetOrdinal(name));
            return 0;
        }
    }
}
