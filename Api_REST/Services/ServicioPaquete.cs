using Sigame.Api_REST.Models;
using Sigame.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sigame.Api_REST.Services
{
    public class ServicioPaquete
    {
        private Conexion conexion = Conexion.GetInstancia();

        public List<MPaqueteAsignado> ListaPaquetesAsignadosEnEspera(int ptMensajeroId)
        {
            List<MPaqueteAsignado> lista = new List<MPaqueteAsignado>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_lista_paquetes_asignados", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = ptMensajeroId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MPaqueteAsignado mPaquete = new MPaqueteAsignado();
                    mPaquete.AsignacionId = long.Parse(datos["AsignacionId"].ToString());
                    mPaquete.TransporteId = int.Parse(datos["TransporteId"].ToString());
                    mPaquete.MensajeroId = int.Parse(datos["MensajeroId"].ToString());
                    mPaquete.PaqueteId = int.Parse(datos["PaqueteId"].ToString());
                    mPaquete.Color = datos["Color"].ToString();
                    mPaquete.Descripcion = datos["Descripcion"].ToString();
                    mPaquete.Origen = datos["Origen"].ToString();
                    mPaquete.Destino = datos["Destino"].ToString();
                    lista.Add(mPaquete);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MPaqueteAsignado mPaquete = new MPaqueteAsignado();
                mPaquete.PaqueteId = 0;
                mPaquete.Color = ex.Message;
                mPaquete.Descripcion = ex.Message;
                mPaquete.Origen = ex.Message;
                mPaquete.Destino = ex.Message;
                lista.Add(mPaquete);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MPaqueteRuta PaqueteEnRuta(int ptMensajeroId)
        {
            MPaqueteRuta mPaquete = new MPaqueteRuta();
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_paquete_en_ruta", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = ptMensajeroId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mPaquete.AsignacionId = long.Parse(datos["AsignacionId"].ToString());
                    mPaquete.PaqueteId = long.Parse(datos["PaqueteId"].ToString());
                    mPaquete.Paquetes = int.Parse(datos["Paquetes"].ToString());
                    mPaquete.MensajeroId = int.Parse(datos["MensajeroId"].ToString());
                    mPaquete.TransporteId = int.Parse(datos["TransporteId"].ToString());
                    mPaquete.Marca = datos["Marca"].ToString();
                    mPaquete.Modelo = datos["Modelo"].ToString();
                    mPaquete.Placa = datos["Placa"].ToString();
                    mPaquete.Descripcion = datos["Descripcion"].ToString();
                    mPaquete.Solicitante = datos["Solicitante"].ToString();
                    mPaquete.Origen = datos["Origen"].ToString();
                    mPaquete.Destino = datos["Destino"].ToString();
                    mPaquete.Destinatario = datos["Destinatario"].ToString();
                    mPaquete.Observacion = datos["Observacion"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mPaquete.AsignacionId = 0;
                mPaquete.PaqueteId = 0;
                mPaquete.Paquetes = 0;
                mPaquete.MensajeroId = 0;
                mPaquete.TransporteId = 0;
                mPaquete.Marca = ex.Message;
                mPaquete.Modelo = ex.Message;
                mPaquete.Placa = ex.Message;
                mPaquete.Descripcion = ex.Message;
                mPaquete.Solicitante = ex.Message;
                mPaquete.Origen = ex.Message;
                mPaquete.Destino = ex.Message;
                mPaquete.Destinatario = ex.Message;
                mPaquete.Observacion = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mPaquete;
        }
        public List<MPaqueteHistorial> ListaPaquetesHistorial(int ptMensajeroId)
        {
            List<MPaqueteHistorial> lista = new List<MPaqueteHistorial>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_historial_paquetes", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = ptMensajeroId;
                SqlDataReader datos = comando.ExecuteReader();
                while(datos.Read())
                {
                    MPaqueteHistorial mPaqueteHistorial = new MPaqueteHistorial();
                    mPaqueteHistorial.Color = datos["Color"].ToString();
                    mPaqueteHistorial.Descripcion = datos["Descripcion"].ToString();
                    mPaqueteHistorial.Origen = datos["Origen"].ToString();
                    mPaqueteHistorial.Destino = datos["Destino"].ToString();
                    lista.Add(mPaqueteHistorial);
                }
                datos.Close();
                comando.Dispose();
            }catch(SqlException ex)
            {
                MPaqueteHistorial mPaqueteHistorial = new MPaqueteHistorial();
                mPaqueteHistorial.Color = ex.Message;
                mPaqueteHistorial.Descripcion = ex.Message;
                mPaqueteHistorial.Origen = ex.Message;
                mPaqueteHistorial.Destino = ex.Message;
                lista.Add(mPaqueteHistorial);
            } finally
            {
                conexion.Close();
            }
            return lista;
        }
        public string EntregarPaquete(MPaquete mPaquete)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_entregar_paquete", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtComentario", SqlDbType.VarChar, 300).Value = mPaquete.Comentario;
                comando.Parameters.Add("@PtFecha", SqlDbType.VarChar, 10).Value = mPaquete.Fecha;
                comando.Parameters.Add("@PtHora", SqlDbType.VarChar, 13).Value = mPaquete.Hora;
                comando.Parameters.Add("@PtLatitud", SqlDbType.VarChar, 25).Value = mPaquete.Latitud;
                comando.Parameters.Add("@PtLongitud", SqlDbType.VarChar, 25).Value = mPaquete.Longitud;
                comando.Parameters.Add("@PtAsignacionId", SqlDbType.BigInt).Value = mPaquete.AsignacionId;
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = mPaquete.MensajeroId;
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = mPaquete.TransporteId;
                comando.Parameters.Add("@PtPaqueteId", SqlDbType.BigInt).Value = mPaquete.PaqueteId;
                comando.Parameters.Add("@PtAcuse", SqlDbType.VarChar).Value = mPaquete.Acuse;
                comando.Parameters.Add("@PtRespuesta", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                comando.Dispose();
                return comando.Parameters["@PtRespuesta"].Value.ToString();
            }
            catch(SqlException ex)
            {
                return "ERROR: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
        public string CancelarPaquete(MPaquete mPaquete)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_cancelar_paquete", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtAsignacionId", SqlDbType.BigInt).Value = mPaquete.AsignacionId;
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = mPaquete.MensajeroId;
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = mPaquete.TransporteId;
                comando.Parameters.Add("@PtPaqueteId", SqlDbType.BigInt).Value = mPaquete.PaqueteId;
                comando.Parameters.Add("@PtRespuesta", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                comando.Dispose();
                return comando.Parameters["@PtRespuesta"].Value.ToString();
            }
            catch (SqlException ex)
            {
                return "ERROR: " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}