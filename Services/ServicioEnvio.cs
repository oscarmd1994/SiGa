using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioEnvio
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevoFolio(int ptUsuarioId)
        {
            string folio = "F-A0P0S0E0";
            try
            {
                SqlCommand comando = new SqlCommand("stp_nuevo_folio_envio", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    folio = datos["Folio"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                folio = "ERROR " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return folio;
        }
        public string NuevoEnvio(MEnvio mEnvio)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_envio", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFolio", SqlDbType.VarChar, 70).Value = mEnvio.Folio;
                comando.Parameters.Add("@PtDescripcion", SqlDbType.VarChar, 200).Value = mEnvio.Descripcion;
                comando.Parameters.Add("@PtObservacion", SqlDbType.VarChar, 500).Value = mEnvio.Observacion;
                comando.Parameters.Add("@PtFechaSolicitud", SqlDbType.VarChar, 10).Value = mEnvio.FechaSolicitud;
                comando.Parameters.Add("@PtHoraSolicitud", SqlDbType.VarChar, 13).Value = mEnvio.HoraSolicitud;
                comando.Parameters.Add("@PtEstadoEnvio", SqlDbType.VarChar, 25).Value = mEnvio.EstadoEnvio;
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mEnvio.UsuarioId;
                comando.Parameters.Add("@PtPrioridadId", SqlDbType.TinyInt).Value = mEnvio.PrioridadId;
                comando.Parameters.Add("@PtDestinatarioId", SqlDbType.Int).Value = mEnvio.DestinatarioId;
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
        public List<MEnvio> ListaEnviosSinEnviar()
        {
            List<MEnvio> lista = new List<MEnvio>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_envios_sin_entregar", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MEnvio mEnvio = new MEnvio();
                    mEnvio.EnvioId = int.Parse(datos["EnvioId"].ToString());
                    mEnvio.Folio = datos["Folio"].ToString();
                    mEnvio.FechaSolicitud = datos["FechaSolicitud"].ToString();
                    mEnvio.HoraSolicitud = datos["HoraSolicitud"].ToString();
                    mEnvio.Destinatario = datos["Destinatario"].ToString();
                    mEnvio.Descripcion = datos["Descripcion"].ToString();
                    mEnvio.Color = datos["Color"].ToString();
                    mEnvio.EstadoEnvio = datos["EstadoEnvio"].ToString();
                    mEnvio.Paqueteria = datos["Paqueteria"].ToString();
                    lista.Add(mEnvio);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MEnvio mEnvio = new MEnvio();
                mEnvio.EnvioId = 0;
                mEnvio.Folio = ex.Message;
                mEnvio.FechaSolicitud = ex.Message;
                mEnvio.HoraSolicitud = ex.Message;
                mEnvio.Destinatario = ex.Message;
                mEnvio.Descripcion = ex.Message;
                mEnvio.Color = ex.Message;
                mEnvio.EstadoEnvio = ex.Message;
                mEnvio.Paqueteria = ex.Message;
                lista.Add(mEnvio);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public string Enviar(MEnvio mEnvio)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_estado_envio", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEnvioId", SqlDbType.BigInt).Value = mEnvio.EnvioId;
                comando.Parameters.Add("@PtPaqueteriaId", SqlDbType.Int).Value = mEnvio.PaqueteriaId;
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
        public string EntregarEnvio(MEnvio mEnvio)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_enviar_envio", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFechaEntrega", SqlDbType.DateTime).Value = mEnvio.FechaEntrega;
                comando.Parameters.Add("@PtHoraEntrega", SqlDbType.Time).Value = mEnvio.HoraEntrega;
                comando.Parameters.Add("@PtEstadoEnvio", SqlDbType.VarChar, 25).Value = mEnvio.EstadoEnvio;
                comando.Parameters.Add("@PtEnvioId", SqlDbType.BigInt).Value = mEnvio.EnvioId;
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