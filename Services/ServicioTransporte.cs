using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioTransporte
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevoTransporte(MTransporte mTransporte)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPlaca", SqlDbType.VarChar, 30).Value = mTransporte.Placa;
                comando.Parameters.Add("@PtMarca", SqlDbType.VarChar, 100).Value = mTransporte.Marca;
                comando.Parameters.Add("@PtModelo", SqlDbType.VarChar, 100).Value = mTransporte.Modelo;
                comando.Parameters.Add("@PtAnio", SqlDbType.VarChar, 4).Value = mTransporte.Anio;
                comando.Parameters.Add("@PtTipoTransporteId", SqlDbType.SmallInt).Value = mTransporte.TipoTransporteId;
                comando.Parameters.Add("@PtPoliza", SqlDbType.VarChar, 20).Value = mTransporte.Poliza;
                comando.Parameters.Add("@PtVigencia", SqlDbType.VarChar, 10).Value = mTransporte.Vigencia;
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
        public List<MTransporte> ListaTablaTransporte()
        {
            List<MTransporte> lista = new List<MTransporte>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_transporte_tabla", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MTransporte mTransporte = new MTransporte();
                    mTransporte.TransporteId = int.Parse(datos["TransporteId"].ToString());
                    mTransporte.Tipo = datos["Tipo"].ToString();
                    mTransporte.Marca = datos["Marca"].ToString();
                    mTransporte.Placa = datos["Placa"].ToString();
                    mTransporte.Modelo = datos["Modelo"].ToString();
                    mTransporte.Anio = datos["Anio"].ToString();
                    mTransporte.Fecha = datos["Fecha"].ToString();
                    mTransporte.Poliza = datos["Poliza"].ToString();
                    mTransporte.Vigencia = datos["Vigencia"].ToString();
                    mTransporte.Disponibilidad = datos["Disponibilidad"].ToString();
                    mTransporte.EstadoTransporte = bool.Parse(datos["EstadoTransporte"].ToString());
                    lista.Add(mTransporte);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MTransporte mTransporte = new MTransporte();
                mTransporte.TransporteId = 0;
                mTransporte.Tipo = ex.Message;
                mTransporte.Marca = ex.Message;
                mTransporte.Placa = ex.Message;
                mTransporte.Modelo = ex.Message;
                mTransporte.Anio = ex.Message;
                mTransporte.Fecha = ex.Message;
                mTransporte.Poliza = ex.Message;
                mTransporte.Vigencia = ex.Message;
                mTransporte.Disponibilidad = ex.Message;
                mTransporte.EstadoTransporte = false;
                lista.Add(mTransporte);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MTransporte SeleccionarTransportePorId(int ptTransporteId)
        {
            MTransporte mTransporte = new MTransporte();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_transporte_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = ptTransporteId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mTransporte.TransporteId = int.Parse(datos["TransporteId"].ToString());
                    mTransporte.TipoTransporteId = int.Parse(datos["TipoTransporteId"].ToString());
                    mTransporte.Placa = datos["Placa"].ToString();
                    mTransporte.Modelo = datos["Modelo"].ToString();
                    mTransporte.Anio = datos["Anio"].ToString();
                    mTransporte.Fecha = datos["Fecha"].ToString();
                    mTransporte.Marca = datos["Marca"].ToString();
                    mTransporte.Poliza = datos["Poliza"].ToString();
                    mTransporte.Vigencia = datos["Vigencia"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mTransporte.TransporteId = 0;
                mTransporte.TipoTransporteId = 0;
                mTransporte.Placa = ex.Message;
                mTransporte.Modelo = ex.Message;
                mTransporte.Anio = ex.Message;
                mTransporte.Fecha = ex.Message;
                mTransporte.Marca = ex.Message;
                mTransporte.Poliza = ex.Message;
                mTransporte.Vigencia = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mTransporte;
        }
        public string ActualizarTransporte(MTransporte mTransporte)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtPlaca", SqlDbType.VarChar, 30).Value = mTransporte.Placa;
                comando.Parameters.Add("@PtModelo", SqlDbType.VarChar, 100).Value = mTransporte.Modelo;
                comando.Parameters.Add("@PtAnio", SqlDbType.VarChar, 4).Value = mTransporte.Anio;
                comando.Parameters.Add("@PtMarca", SqlDbType.VarChar, 100).Value = mTransporte.Marca;
                comando.Parameters.Add("@PtPoliza", SqlDbType.VarChar, 20).Value = mTransporte.Poliza;
                comando.Parameters.Add("@PtVigencia", SqlDbType.VarChar, 10).Value = mTransporte.Vigencia;
                comando.Parameters.Add("@PtTipoTransporteId", SqlDbType.SmallInt).Value = mTransporte.TipoTransporteId;
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = mTransporte.TransporteId;
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
        public string ActualizarEstadoTransporte(int ptTransporteId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_transporte", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTransporteId", SqlDbType.Int).Value = ptTransporteId;
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
        public List<MTransporte> ListaTransportesPorTipo(int ptTipoTransporteId)
        {
            List<MTransporte> lista = new List<MTransporte>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_transporte_por_tipo", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtTipoTransporteId", SqlDbType.Int).Value = ptTipoTransporteId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MTransporte mTransporte = new MTransporte();
                    mTransporte.TransporteId = int.Parse(datos["TransporteId"].ToString());
                    mTransporte.Placa = datos["Placa"].ToString();
                    mTransporte.Modelo = datos["Modelo"].ToString();
                    mTransporte.Anio = datos["Anio"].ToString();
                    lista.Add(mTransporte);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MTransporte mTransporte = new MTransporte();
                mTransporte.TransporteId = 0;
                mTransporte.Placa = ex.Message;
                mTransporte.Modelo = ex.Message;
                mTransporte.Anio = ex.Message;
                lista.Add(mTransporte);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}