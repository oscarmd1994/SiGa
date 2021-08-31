using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioMensaje
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevoFolio(int ptUsuarioId)
        {
            string folio = "F-A0P0S0M0";
            try
            {
                SqlCommand comando = new SqlCommand("stp_nuevo_folio_mensaje", conexion.GetConexion())
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
        public string NuevoMensaje(MMensaje mMensaje)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_mensaje", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFolio", SqlDbType.VarChar, 70).Value = mMensaje.Folio;
                comando.Parameters.Add("@PtDescripcion", SqlDbType.VarChar, 200).Value = mMensaje.Descripcion;
                comando.Parameters.Add("@PtObservacion", SqlDbType.VarChar, 500).Value = mMensaje.Observacion;
                comando.Parameters.Add("@PtFecha", SqlDbType.VarChar, 10).Value = mMensaje.Fecha;
                comando.Parameters.Add("@PtHora", SqlDbType.VarChar, 13).Value = mMensaje.Hora;
                comando.Parameters.Add("@PtEstadoMensaje", SqlDbType.Bit).Value = mMensaje.EstadoMensaje;
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mMensaje.UsuarioId;
                comando.Parameters.Add("@PtPrioridadId", SqlDbType.TinyInt).Value = mMensaje.PrioridadId;
                comando.Parameters.Add("@PtDireccionDestinatarioId", SqlDbType.BigInt).Value = mMensaje.DireccionDestinatarioId;
                comando.Parameters.Add("@PtDireccionSalida", SqlDbType.VarChar, 250).Value = mMensaje.DireccionSalida;
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
        public List<MMensaje> ListaEstadoMensajesSolicitados(int ptUsuarioId)
        {
            List<MMensaje> lista = new List<MMensaje>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_estado_mensajes_solicitados", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MMensaje mMensaje = new MMensaje();
                    mMensaje.MensajeId = int.Parse(datos["MensajeId"].ToString());
                    mMensaje.Folio = datos["Folio"].ToString();
                    mMensaje.Fecha = datos["Fecha"].ToString();
                    mMensaje.Hora = datos["Hora"].ToString();
                    mMensaje.Destinatario = datos["Destinatario"].ToString();
                    mMensaje.Descripcion = datos["Descripcion"].ToString();
                    mMensaje.Color = datos["Color"].ToString();
                    mMensaje.EstadoPaquete = datos["EstadoPaquete"].ToString();
                    lista.Add(mMensaje);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MMensaje mMensaje = new MMensaje();
                mMensaje.MensajeId = 0;
                mMensaje.Folio = ex.Message;
                mMensaje.Fecha = ex.Message;
                mMensaje.Hora = ex.Message;
                mMensaje.Destinatario = ex.Message;
                mMensaje.Descripcion = ex.Message;
                mMensaje.Color = ex.Message;
                mMensaje.EstadoPaquete = ex.Message;
                lista.Add(mMensaje);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MMensaje> ListaMensajesParaAsignar()
        {
            List<MMensaje> lista = new List<MMensaje>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_mensajes_para_asignar", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MMensaje mMensaje = new MMensaje();
                    mMensaje.MensajeId = int.Parse(datos["MensajeId"].ToString());
                    mMensaje.Nombre = datos["Nombre"].ToString();
                    mMensaje.Foto = datos["Foto"].ToString();
                    mMensaje.Descripcion = datos["Descripcion"].ToString();
                    mMensaje.DireccionDestinatario = datos["DireccionDestinatario"].ToString();
                    mMensaje.Destinatario = datos["Destinatario"].ToString();
                    mMensaje.Color = datos["Color"].ToString();
                    mMensaje.DireccionSalida = datos["DireccionSalida"].ToString();
                    lista.Add(mMensaje);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MMensaje mMensaje = new MMensaje();
                mMensaje.MensajeId = 0;
                mMensaje.Nombre = ex.Message;
                mMensaje.Foto = ex.Message;
                mMensaje.Descripcion = ex.Message;
                mMensaje.DireccionDestinatario = ex.Message;
                mMensaje.Destinatario = ex.Message;
                mMensaje.Color = ex.Message;
                mMensaje.DireccionSalida = ex.Message;
                lista.Add(mMensaje);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MMensaje> ListaHistorial(int ptUsuarioId)
        {
            List<MMensaje> lista = new List<MMensaje>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_historial_mensajes_solicitados", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MMensaje mMensaje = new MMensaje();
                    mMensaje.MensajeId = int.Parse(datos["MensajeId"].ToString());
                    mMensaje.Folio = datos["Folio"].ToString();
                    mMensaje.Fecha = datos["Fecha"].ToString();
                    mMensaje.Hora = datos["Hora"].ToString();
                    mMensaje.Destinatario = datos["Destinatario"].ToString();
                    mMensaje.Descripcion = datos["Descripcion"].ToString();
                    mMensaje.Color = datos["Color"].ToString();
                    mMensaje.EstadoPaquete = datos["EstadoPaquete"].ToString();
                    lista.Add(mMensaje);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MMensaje mMensaje = new MMensaje();
                mMensaje.MensajeId = 0;
                mMensaje.Folio = ex.Message;
                mMensaje.Fecha = ex.Message;
                mMensaje.Hora = ex.Message;
                mMensaje.Destinatario = ex.Message;
                mMensaje.Descripcion = ex.Message;
                mMensaje.Color = ex.Message;
                mMensaje.EstadoPaquete = ex.Message;
                lista.Add(mMensaje);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MMensaje> ListaHistorial()
        {
            List<MMensaje> lista = new List<MMensaje>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_historial_mensajes_solicitados", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MMensaje mMensaje = new MMensaje();
                    mMensaje.MensajeId = int.Parse(datos["MensajeId"].ToString());
                    mMensaje.Folio = datos["Folio"].ToString();
                    mMensaje.Fecha = datos["Fecha"].ToString();
                    mMensaje.Hora = datos["Hora"].ToString();
                    mMensaje.Destinatario = datos["Destinatario"].ToString();
                    mMensaje.Descripcion = datos["Descripcion"].ToString();
                    mMensaje.Color = datos["Color"].ToString();
                    mMensaje.EstadoPaquete = datos["EstadoPaquete"].ToString();
                    mMensaje.Acuse = datos["Acuse"].ToString();
                    lista.Add(mMensaje);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MMensaje mMensaje = new MMensaje();
                mMensaje.MensajeId = 0;
                mMensaje.Folio = ex.Message;
                mMensaje.Fecha = ex.Message;
                mMensaje.Hora = ex.Message;
                mMensaje.Destinatario = ex.Message;
                mMensaje.Descripcion = ex.Message;
                mMensaje.Color = ex.Message;
                mMensaje.EstadoPaquete = ex.Message;
                lista.Add(mMensaje);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}