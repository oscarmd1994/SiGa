using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioDestinatario
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevoDestinatario(MDestinatario mDestinatario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_destinatario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEstadoDestinatario", SqlDbType.Bit).Value = mDestinatario.EstadoDestinatario;
                comando.Parameters.Add("@PtEmpleadoId", SqlDbType.Int).Value = mDestinatario.EmpleadoId;
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = mDestinatario.AreaId;
                comando.Parameters.Add("@PtDireccion", SqlDbType.VarChar).Value = mDestinatario.Direccion;
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
        public string AgregarDireccion(MDireccionDestinatario mDireccionDestinatario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_direccion_destinatario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtDestinatarioId", SqlDbType.Int).Value = mDireccionDestinatario.DestinatarioId;
                comando.Parameters.Add("@PtDireccion", SqlDbType.VarChar, 250).Value = mDireccionDestinatario.Direccion;
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
        public List<MDireccion> ListaDirecciones(int destinatarioid)
        {
            List<MDireccion> lista = new List<MDireccion>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_direcciones_destinatario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtDestinatarioId", SqlDbType.Int).Value = destinatarioid;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MDireccionDestinatario mDireccionDestinatario = new MDireccionDestinatario();
                    mDireccionDestinatario.DireccionDestinatarioId = long.Parse(datos["DireccionDestinatarioId"].ToString());
                    mDireccionDestinatario.Direccion = datos["Direccion"].ToString();
                    lista.Add(mDireccionDestinatario);
                }
                datos.Close();
                comando.Dispose();
            }
            catch(SqlException ex)
            {
                MDireccionDestinatario mDireccionDestinatario = new MDireccionDestinatario();
                mDireccionDestinatario.DireccionDestinatarioId = 0;
                mDireccionDestinatario.Direccion = ex.Message;
                lista.Add(mDireccionDestinatario);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MDestinatario> ListaDestinatarios()
        {
            List<MDestinatario> lista = new List<MDestinatario>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_destinatarios", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MDestinatario mDestinatario = new MDestinatario();
                    mDestinatario.DestinatarioId = int.Parse(datos["DestinatarioId"].ToString());
                    mDestinatario.Nombre = datos["Nombre"].ToString();
                    mDestinatario.Empresa = datos["Empresa"].ToString();
                    mDestinatario.Area = datos["Area"].ToString();
                    mDestinatario.EstadoDestinatario = bool.Parse(datos["EstadoDestinatario"].ToString());
                    lista.Add(mDestinatario);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MDestinatario mDestinatario = new MDestinatario();
                mDestinatario.DestinatarioId = 0;
                mDestinatario.Nombre = ex.Message;
                mDestinatario.Empresa = ex.Message;
                mDestinatario.EstadoDestinatario = false;
                lista.Add(mDestinatario);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MDestinatario> ListaDestinatariosMensaje(bool ptEstado)
        {
            List<MDestinatario> lista = new List<MDestinatario>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_destinatarios_mensaje", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEstado", SqlDbType.Bit).Value = ptEstado;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MDestinatario mDestinatario = new MDestinatario();
                    mDestinatario.DestinatarioId = int.Parse(datos["DestinatarioId"].ToString());
                    mDestinatario.Nombre = datos["Nombre"].ToString();
                    lista.Add(mDestinatario);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MDestinatario mDestinatario = new MDestinatario();
                mDestinatario.DestinatarioId = 0;
                mDestinatario.Nombre = ex.Message;
                lista.Add(mDestinatario);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MDestinatario SeleccionarDestinatarioPorId(int ptDestinatarioId)
        {
            MDestinatario mDestinatario = new MDestinatario();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_destinatario_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtDestinatarioId", SqlDbType.Int).Value = ptDestinatarioId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mDestinatario.DestinatarioId = int.Parse(datos["DestinatarioId"].ToString());
                    mDestinatario.Nombre = datos["Nombre"].ToString();
                    mDestinatario.EmpresaId = int.Parse(datos["EmpresaId"].ToString());
                    mDestinatario.Empresa = datos["Empresa"].ToString();
                    mDestinatario.AreaId = int.Parse(datos["AreaId"].ToString());
                    mDestinatario.Area = datos["Area"].ToString();
                    mDestinatario.Direccion = datos["Direccion"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mDestinatario.DestinatarioId = 0;
                mDestinatario.Nombre = ex.Message;
                mDestinatario.EmpresaId = 0;
                mDestinatario.Empresa = ex.Message;
                mDestinatario.AreaId = 0;
                mDestinatario.Area = ex.Message;
                mDestinatario.Direccion = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mDestinatario;
        }
        public string ActualizarDestinatario(MDestinatario mDestinatario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_destinatario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtDestinatarioId", SqlDbType.Int).Value = mDestinatario.DestinatarioId;
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = mDestinatario.AreaId;
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
        public string ActualizarEstadoDestinatario(int ptDestinatarioId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_destinatario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtDestinatarioId", SqlDbType.Int).Value = ptDestinatarioId;
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
        public string ActualizaDireccion(MDireccionDestinatario mDireccionDestinatario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_direccion_destinatario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtDireccionDestinatarioId", SqlDbType.BigInt).Value = mDireccionDestinatario.DireccionDestinatarioId;
                comando.Parameters.Add("@PtDireccion", SqlDbType.VarChar, 250).Value = mDireccionDestinatario.Direccion;
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