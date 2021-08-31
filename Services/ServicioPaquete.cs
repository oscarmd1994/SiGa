using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioPaquete
    {
        private Conexion conexion = Conexion.GetInstancia();

        public List<MPaquete> ListaPaquetesAsignadosEnProceso()
        {
            List<MPaquete> lista = new List<MPaquete>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_paquetes_asignados_en_proceso", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MPaquete mPaquete = new MPaquete();
                    mPaquete.AsignacionId = int.Parse(datos["AsignacionId"].ToString());
                    mPaquete.Fecha = datos["Fecha"].ToString();
                    mPaquete.Hora = datos["Hora"].ToString();
                    mPaquete.Mensajero = datos["Mensajero"].ToString();
                    mPaquete.Paquetes = datos["Paquetes"].ToString();
                    lista.Add(mPaquete);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MPaquete mPaquete = new MPaquete();
                mPaquete.AsignacionId = 0;
                mPaquete.Fecha = ex.Message;
                mPaquete.Hora = ex.Message;
                mPaquete.Mensajero = ex.Message;
                mPaquete.Paquetes = ex.Message;
                lista.Add(mPaquete);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MPaquete> ListaPaquetesAsignadosEnEspera()
        {
            List<MPaquete> lista = new List<MPaquete>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_paquetes_asignados_en_espera", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MPaquete mPaquete = new MPaquete();
                    mPaquete.Fecha = datos["Fecha"].ToString();
                    mPaquete.Hora = datos["Hora"].ToString();
                    mPaquete.Mensajero = datos["Mensajero"].ToString();
                    mPaquete.Paquetes = datos["Paquetes"].ToString();
                    lista.Add(mPaquete);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MPaquete mPaquete = new MPaquete();
                mPaquete.AsignacionId = 0;
                mPaquete.Fecha = ex.Message;
                mPaquete.Hora = ex.Message;
                mPaquete.Mensajero = ex.Message;
                mPaquete.Paquetes = ex.Message;
                lista.Add(mPaquete);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public string ActualizarEstadoPaquete(long ptPaqueteId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_estado_paquete", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPaqueteId", SqlDbType.BigInt).Value = ptPaqueteId;
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