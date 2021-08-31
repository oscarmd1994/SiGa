using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioPaqueteria
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevaPaqueteria(MPaqueteria mPaqueteria)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_paqueteria", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPaqueteria", SqlDbType.VarChar, 30).Value = mPaqueteria.Paqueteria;
                comando.Parameters.Add("@PtEstadoPaqueteria", SqlDbType.Bit).Value = mPaqueteria.EstadoPaqueteria;
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
        public List<MPaqueteria> ListaPaqueterias()
        {
            List<MPaqueteria> lista = new List<MPaqueteria>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_paqueterias", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MPaqueteria mPaqueteria = new MPaqueteria();
                    mPaqueteria.PaqueteriaId = int.Parse(datos["PaqueteriaId"].ToString());
                    mPaqueteria.Paqueteria = datos["Paqueteria"].ToString();
                    mPaqueteria.EstadoPaqueteria = bool.Parse(datos["EstadoPaqueteria"].ToString());
                    lista.Add(mPaqueteria);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MPaqueteria mPaqueteria = new MPaqueteria();
                mPaqueteria.PaqueteriaId = 0;
                mPaqueteria.Paqueteria = ex.Message;
                mPaqueteria.EstadoPaqueteria = false;
                lista.Add(mPaqueteria);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MPaqueteria SeleccionarPaqueteriaPorId(int ptPaqueteriaId)
        {
            MPaqueteria mPaqueteria = new MPaqueteria();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_paqueteria_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPaqueteriaId", SqlDbType.Int).Value = ptPaqueteriaId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mPaqueteria.PaqueteriaId = int.Parse(datos["PaqueteriaId"].ToString());
                    mPaqueteria.Paqueteria = datos["Paqueteria"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mPaqueteria.PaqueteriaId = 0;
                mPaqueteria.Paqueteria = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mPaqueteria;
        }
        public string ActualizarPaqueteria(MPaqueteria mPaqueteria)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_paqueteria", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPaqueteriaId", SqlDbType.Int).Value = mPaqueteria.PaqueteriaId;
                comando.Parameters.Add("@PtPaqueteria", SqlDbType.VarChar, 30).Value = mPaqueteria.Paqueteria;
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
        public string ActualizarEstadoPaqueteria(int ptPaqueteriaId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_paqueteria", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPaqueteriaId", SqlDbType.Int).Value = ptPaqueteriaId;
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
        public List<MPaqueteria> ListaPaqueteriasSelect()
        {
            List<MPaqueteria> lista = new List<MPaqueteria>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_paqueterias_select", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MPaqueteria mPaqueteria = new MPaqueteria();
                    mPaqueteria.PaqueteriaId = int.Parse(datos["PaqueteriaId"].ToString());
                    mPaqueteria.Paqueteria = datos["Paqueteria"].ToString();
                    lista.Add(mPaqueteria);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MPaqueteria mPaqueteria = new MPaqueteria();
                mPaqueteria.PaqueteriaId = 0;
                mPaqueteria.Paqueteria = ex.Message;
                lista.Add(mPaqueteria);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}