using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioTipoTransporte
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevoTipoTransporte(MTipoTransporte mTipoTransporte)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_tipo_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTipoTransporte", SqlDbType.VarChar, 50).Value = mTipoTransporte.Tipo;
                comando.Parameters.Add("@PtImagen", SqlDbType.VarChar, 100).Value = mTipoTransporte.Imagen;
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
        public List<MTipoTransporte> ListaTablaTiposTransporte()
        {
            List<MTipoTransporte> lista = new List<MTipoTransporte>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_tipos_transporte_tabla", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MTipoTransporte mTipoTransporte = new MTipoTransporte();
                    mTipoTransporte.TipoTransporteId = int.Parse(datos["TipoTransporteId"].ToString());
                    mTipoTransporte.Tipo = datos["Tipo"].ToString();
                    mTipoTransporte.Imagen = datos["Imagen"].ToString();
                    mTipoTransporte.EstadoTipoTransporte =bool.Parse(datos["EstadoTipoTransporte"].ToString());
                    lista.Add(mTipoTransporte);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MTipoTransporte mTipoTransporte = new MTipoTransporte();
                mTipoTransporte.TipoTransporteId = 0;
                mTipoTransporte.Tipo = ex.Message;
                mTipoTransporte.EstadoTipoTransporte = false;
                lista.Add(mTipoTransporte);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public string ActualizarEstadoTipoTransporte(int ptTipoTransporteId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_tipo_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTipoTransporteId", SqlDbType.SmallInt).Value = ptTipoTransporteId;
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
        public MTipoTransporte SeleccionarTipoTransportePorId(int ptTipoTransporteId)
        {
            MTipoTransporte mTipoTransporte = new MTipoTransporte();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_tipo_transporte_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTipoTransporteId", SqlDbType.SmallInt).Value = ptTipoTransporteId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mTipoTransporte.TipoTransporteId = int.Parse(datos["TipoTransporteId"].ToString());
                    mTipoTransporte.Tipo = datos["Tipo"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mTipoTransporte.TipoTransporteId = 0;
                mTipoTransporte.Tipo = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mTipoTransporte;
        }
        public string ActualizarTipoTransporte(MTipoTransporte mTipoTransporte)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_tipo_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTipoTransporte", SqlDbType.VarChar, 50).Value = mTipoTransporte.Tipo;
                comando.Parameters.Add("@PtTipoTransporteId", SqlDbType.SmallInt).Value = mTipoTransporte.TipoTransporteId;
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
        public List<MTipoTransporte> ListaTiposTransporte()
        {
            List<MTipoTransporte> lista = new List<MTipoTransporte>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_tipos_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MTipoTransporte mTipoTransporte = new MTipoTransporte();
                    mTipoTransporte.TipoTransporteId = int.Parse(datos["TipoTransporteId"].ToString());
                    mTipoTransporte.Tipo = datos["Tipo"].ToString();
                    lista.Add(mTipoTransporte);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MTipoTransporte mTipoTransporte = new MTipoTransporte();
                mTipoTransporte.TipoTransporteId = 0;
                mTipoTransporte.Tipo = ex.Message;
                lista.Add(mTipoTransporte);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}