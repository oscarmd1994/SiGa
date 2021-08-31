using Sigame.Api_REST.Models;
using Sigame.Services;
using Sigame.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Api_REST.Services
{
    public class ServicioRecorrido
    {
        private Conexion conexion = Conexion.GetInstancia();

        ~ServicioRecorrido()
        {
        }

        public string IniciaRecorrido(MRecorrido mRecorrido)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_inicia_recorrido", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFecha", SqlDbType.VarChar, 10).Value = mRecorrido.Fecha;
                comando.Parameters.Add("@PtHora", SqlDbType.VarChar, 13).Value = mRecorrido.Hora;
                comando.Parameters.Add("@PtLatitud", SqlDbType.VarChar, 25).Value = mRecorrido.Latitud;
                comando.Parameters.Add("@PtLongitud", SqlDbType.VarChar, 25).Value = mRecorrido.Longitud;
                comando.Parameters.Add("@PtAsignacionId", SqlDbType.BigInt).Value = mRecorrido.AsignacionId;
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = mRecorrido.MensajeroId;
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = mRecorrido.TransporteId;
                comando.Parameters.Add("@PtPaqueteId", SqlDbType.BigInt).Value = mRecorrido.PaqueteId;
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
        public string FinalizaRecorrido(MRecorrido mRecorrido)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_finaliza_recorrido", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFecha", SqlDbType.VarChar, 10).Value = mRecorrido.Fecha;
                comando.Parameters.Add("@PtHora", SqlDbType.VarChar, 13).Value = mRecorrido.Hora;
                comando.Parameters.Add("@PtLatitud", SqlDbType.VarChar, 25).Value = mRecorrido.Latitud;
                comando.Parameters.Add("@PtLongitud", SqlDbType.VarChar, 25).Value = mRecorrido.Longitud;
                comando.Parameters.Add("@PtAsignacionId", SqlDbType.BigInt).Value = mRecorrido.AsignacionId;
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = mRecorrido.MensajeroId;
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = mRecorrido.TransporteId;
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
        public string NuevaUbicacion(MRecorrido mRecorrido)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_agregar_ubicacion", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFecha", SqlDbType.VarChar, 10).Value = mRecorrido.Fecha;
                comando.Parameters.Add("@PtHora", SqlDbType.VarChar, 13).Value = mRecorrido.Hora;
                comando.Parameters.Add("@PtLatitud", SqlDbType.VarChar, 25).Value = mRecorrido.Latitud;
                comando.Parameters.Add("@PtLongitud", SqlDbType.VarChar, 25).Value = mRecorrido.Longitud;
                comando.Parameters.Add("@PtAsignacionId", SqlDbType.BigInt).Value = mRecorrido.AsignacionId;
                comando.Parameters.Add("@PtPaqueteId", SqlDbType.BigInt).Value = mRecorrido.PaqueteId;
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
        public MTransporte Transporte(int ptMensajeroId)
        {
            MTransporte mTransporte = new MTransporte();
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_transporte_recorrido", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = ptMensajeroId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mTransporte.Marca = datos["Marca"].ToString();
                    mTransporte.Placa = datos["Placa"].ToString();
                    mTransporte.Modelo = datos["Modelo"].ToString();
                    mTransporte.Poliza = datos["Poliza"].ToString();
                    mTransporte.Vigencia = datos["Vigencia"].ToString();
                    mTransporte.Anio = datos["Anio"].ToString();
                    mTransporte.Foto = datos["Foto"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mTransporte.Marca = ex.Message;
                mTransporte.Placa = ex.Message;
                mTransporte.Modelo = ex.Message;
                mTransporte.Poliza = ex.Message;
                mTransporte.Vigencia = ex.Message;
                mTransporte.Anio = ex.Message;
                mTransporte.Foto = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mTransporte;
        }
    }
}