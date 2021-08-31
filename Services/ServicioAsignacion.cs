using Sigame.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioAsignacion
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string AsignarPaquetes(MPaquete mPaquete)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_asignacion_paquetes", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = mPaquete.MensajeroId;
                comando.Parameters.Add("@PtFecha", SqlDbType.VarChar, 10).Value = mPaquete.Fecha;
                comando.Parameters.Add("@PtHora", SqlDbType.VarChar, 13).Value = mPaquete.Hora;
                comando.Parameters.Add("@PtAsignadorId", SqlDbType.Int).Value = mPaquete.AsignadorId;
                comando.Parameters.Add("@PtMensajesId", SqlDbType.VarChar, 500).Value = mPaquete.MensajesId;
                comando.Parameters.Add("@PtEstadoPaquete", SqlDbType.VarChar, 25).Value = mPaquete.EstadoPaquete;
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = mPaquete.TransporteId;
                comando.Parameters.Add("@PtRespuesta", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                comando.Dispose();
                return comando.Parameters["@PtRespuesta"].Value.ToString();
            }
            catch (SqlException ex)
            {
                return "ERROR " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}