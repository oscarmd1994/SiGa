using System.Configuration;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class Conexion
    {
        private static object objeto = new object();
        private static Conexion instancia = null;
        private SqlConnection conexion = null;
        private int commandTimeout = 0;
        private Conexion()
        {
            try
            {
                AppSettingsReader configuracion = new AppSettingsReader();
                string valor = (string)configuracion.GetValue("conexion", typeof(string));
                commandTimeout = (int)configuracion.GetValue("commandtimeout", typeof(int));
                conexion = new SqlConnection(valor);
                conexion.Open();
            }
            catch (SqlException)
            {
            }
        }
        public static Conexion GetInstancia()
        {
            lock (objeto)
            {
                if (instancia == null)
                {
                    instancia = new Conexion();
                }
                return instancia;
            }
        }
        public SqlConnection GetConexion()
        {
            return conexion;
        }
        public int GetCommandTimeout
        {
            get { return commandTimeout; }
        }
        public void Close()
        {
            if (conexion != null)
            {
                conexion.Close();
                instancia = null;
            }
        }
    }
}