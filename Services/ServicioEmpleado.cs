using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Sigame.Services
{
    public class ServicioEmpleado
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevoEmpleado(MEmpleado mEmpleado)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_empleado", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtNombre", SqlDbType.VarChar, 70).Value = mEmpleado.Nombre;
                comando.Parameters.Add("@PtApellidoPaterno", SqlDbType.VarChar, 70).Value = mEmpleado.ApellidoPaterno;
                comando.Parameters.Add("@PtApellidoMaterno", SqlDbType.VarChar, 70).Value = mEmpleado.ApellidoMaterno;
                comando.Parameters.Add("@PtEstadoEmpleado", SqlDbType.Bit).Value = mEmpleado.EstadoEmpleado;
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
        public List<MEmpleado> ListaEmpleados()
        {
            List<MEmpleado> lista = new List<MEmpleado>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_empleados", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MEmpleado mEmpleado = new MEmpleado();
                    mEmpleado.EmpleadoId = int.Parse(datos["EmpleadoId"].ToString());
                    mEmpleado.Nombre = datos["Nombre"].ToString();
                    mEmpleado.ApellidoPaterno = datos["ApellidoPaterno"].ToString();
                    mEmpleado.ApellidoMaterno = datos["ApellidoMaterno"].ToString();
                    mEmpleado.EstadoEmpleado = bool.Parse(datos["EstadoEmpleado"].ToString());
                    lista.Add(mEmpleado);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MEmpleado mEmpleado = new MEmpleado();
                mEmpleado.EmpleadoId = 0;
                mEmpleado.Nombre = ex.Message;
                mEmpleado.ApellidoPaterno = ex.Message;
                mEmpleado.ApellidoMaterno = ex.Message;
                mEmpleado.EstadoEmpleado = false;
                lista.Add(mEmpleado);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MEmpleado> ListaEmpleadosUsuarios(bool ptEstadoEmpleado)
        {
            List<MEmpleado> lista = new List<MEmpleado>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_empleados_usuarios", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEstadoEmpleado", SqlDbType.Bit).Value = ptEstadoEmpleado;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MEmpleado mEmpleado = new MEmpleado();
                    mEmpleado.EmpleadoId = int.Parse(datos["EmpleadoId"].ToString());
                    mEmpleado.Nombre = datos["Nombre"].ToString();
                    mEmpleado.ApellidoPaterno = datos["ApellidoPaterno"].ToString();
                    mEmpleado.ApellidoMaterno = datos["ApellidoMaterno"].ToString();
                    lista.Add(mEmpleado);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MEmpleado mEmpleado = new MEmpleado();
                mEmpleado.EmpleadoId = 0;
                mEmpleado.Nombre = ex.Message;
                mEmpleado.ApellidoPaterno = ex.Message;
                mEmpleado.ApellidoMaterno = ex.Message; 
                lista.Add(mEmpleado);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MEmpleado> ListaEmpleadosDestinatarios(int ptUsuarioId)
        {
            List<MEmpleado> lista = new List<MEmpleado>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_empleados_destinatarios", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                comando.Parameters.Add("@PtEstado", SqlDbType.Bit).Value = 1;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MEmpleado mPersona = new MEmpleado();
                    mPersona.EmpleadoId = int.Parse(datos["EmpleadoId"].ToString());
                    mPersona.Nombre = datos["Nombre"].ToString();
                    lista.Add(mPersona);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MEmpleado mEmpleado = new MEmpleado();
                mEmpleado.EmpleadoId = 0;
                mEmpleado.Nombre = ex.Message;
                lista.Add(mEmpleado);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MEmpleado SeleccionarEmpleadoPorId(int empleadoid)
        {
            MEmpleado mEmpleado = new MEmpleado();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_empleado_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpleadoId", SqlDbType.Int).Value = empleadoid;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mEmpleado.EmpleadoId = int.Parse(datos["EmpleadoId"].ToString());
                    mEmpleado.Nombre = datos["Nombre"].ToString();
                    mEmpleado.ApellidoPaterno = datos["ApellidoPaterno"].ToString();
                    mEmpleado.ApellidoMaterno = datos["ApellidoMaterno"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }catch(SqlException ex)
            {
                mEmpleado.EmpleadoId = 0;
                mEmpleado.Nombre = ex.Message;
                mEmpleado.ApellidoPaterno = ex.Message;
                mEmpleado.ApellidoMaterno = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mEmpleado;
        }
        public string ActualizarEmpleado(MEmpleado mEmpleado)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_empleado", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpleadoId", SqlDbType.Int).Value = mEmpleado.EmpleadoId;
                comando.Parameters.Add("@PtNombre", SqlDbType.VarChar, 70).Value = mEmpleado.Nombre;
                comando.Parameters.Add("@PtApellidoPaterno", SqlDbType.VarChar, 70).Value = mEmpleado.ApellidoPaterno;
                comando.Parameters.Add("@PtApellidoMaterno", SqlDbType.VarChar, 70).Value = mEmpleado.ApellidoMaterno;
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
        public string ActualizarEstadoEmpleado(int ptEmpleadoId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_empleado", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpleadoId", SqlDbType.Int).Value = ptEmpleadoId;
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