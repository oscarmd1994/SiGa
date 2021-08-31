using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioUsuario
    {
        private Conexion conexion = Conexion.GetInstancia();

        public MUsuario IniciarSesion(MUsuario ptMUsuario)
        {
            MUsuario mUsuario = new MUsuario();
            try
            {
                SqlCommand comando = new SqlCommand("stp_iniciar_sesion_sistema", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuario", SqlDbType.VarChar, 40).Value = ptMUsuario.Usuario;
                comando.Parameters.Add("@PtContrasenia", SqlDbType.VarChar, 300).Value = ptMUsuario.Contrasenia;
                comando.Parameters.Add("@PtEstadoUsuario", SqlDbType.Bit).Value = ptMUsuario.EstadoUsuario;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mUsuario.UsuarioId = int.Parse(datos["UsuarioId"].ToString());
                    mUsuario.AreaId = int.Parse(datos["AreaId"].ToString());
                    mUsuario.RolId = byte.Parse(datos["RolId"].ToString());
                    mUsuario.Rol = datos["Rol"].ToString();
                    mUsuario.Respuesta = datos["Respuesta"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mUsuario.Respuesta = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mUsuario;
        }
        public MUsuario UsuarioEnSesion(int ptUsuarioId)
        {
            MUsuario mUsuario = new MUsuario();
            try
            {
                SqlCommand comando = new SqlCommand("stp_usuario_sesion", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mUsuario.Usuario = datos["Usuario"].ToString();
                    mUsuario.Foto = datos["Foto"].ToString();
                    mUsuario.Rol = datos["Rol"].ToString();
                    mUsuario.Area = datos["Area"].ToString();
                    mUsuario.Nombre = datos["Nombre"].ToString();
                    mUsuario.ApellidoPaterno = datos["ApellidoPaterno"].ToString();
                    mUsuario. ApellidoMaterno = datos["ApellidoMaterno"].ToString();
                    mUsuario.FechaNacimiento = datos["FechaNacimiento"].ToString();
                    mUsuario.Empresa = datos["Empresa"].ToString();
                }
            }catch(SqlException ex)
            {
                mUsuario.Usuario = ex.Message;
                mUsuario.Foto = ex.Message;
                mUsuario.Rol = ex.Message;
                mUsuario.Area = ex.Message;
                mUsuario.Nombre = ex.Message;
                mUsuario.ApellidoPaterno = ex.Message;
                mUsuario.ApellidoMaterno = ex.Message;
                mUsuario.FechaNacimiento = ex.Message;
                mUsuario.Empresa = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mUsuario;
        }
        public string NuevoUsuario(MUsuario mUsuario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_usuario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFechaNacimiento", SqlDbType.VarChar).Value = mUsuario.FechaNacimiento;
                comando.Parameters.Add("@PtUsuario", SqlDbType.VarChar, 40).Value = mUsuario.Usuario;
                comando.Parameters.Add("@PtContrasenia", SqlDbType.VarChar, 300).Value = mUsuario.Contrasenia;
                comando.Parameters.Add("@PtFoto", SqlDbType.VarChar, 100).Value = mUsuario.Foto;
                comando.Parameters.Add("@PtEstadoUsuario", SqlDbType.Bit).Value = mUsuario.EstadoUsuario;
                comando.Parameters.Add("@PtEmpleadoId", SqlDbType.Int).Value = mUsuario.EmpleadoId;
                comando.Parameters.Add("@PtRolId", SqlDbType.TinyInt).Value = mUsuario.RolId;
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = mUsuario.AreaId;
                comando.Parameters.Add("@PtRespuesta", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                comando.Dispose();
                return comando.Parameters["@PtRespuesta"].Value.ToString();
            }
            catch(SqlException ex)
            {
                return "ERROR " + ex.Message;
            }
            finally
            {
                conexion.Close();
            }
        }
        public List<MUsuario> ListaUsuarios(int ptUsuarioId)
        {
            List<MUsuario> lista = new List<MUsuario>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_usuarios", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MUsuario mUsuario = new MUsuario();
                    mUsuario.UsuarioId = int.Parse(datos["UsuarioId"].ToString());
                    mUsuario.Nombre = datos["Nombre"].ToString();
                    mUsuario.Usuario = datos["Usuario"].ToString();
                    mUsuario.FechaNacimiento = datos["FechaNacimiento"].ToString();
                    mUsuario.Rol = datos["Rol"].ToString();
                    mUsuario.Empresa = datos["Empresa"].ToString();
                    mUsuario.Area = datos["Area"].ToString();
                    mUsuario.EstadoUsuario = bool.Parse(datos["EstadoUsuario"].ToString());
                    lista.Add(mUsuario);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MUsuario mUsuario = new MUsuario();
                mUsuario.UsuarioId = 0;
                mUsuario.Nombre = ex.Message;
                mUsuario.Usuario = ex.Message;
                mUsuario.FechaNacimiento = ex.Message;
                mUsuario.Rol = ex.Message;
                mUsuario.Empresa = ex.Message;
                mUsuario.EstadoUsuario = false;
                lista.Add(mUsuario);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public string ActualizaFotoUsuario(MUsuario mUsuario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_foto_usuario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFoto", SqlDbType.VarChar, 100).Value = mUsuario.Foto;
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mUsuario.UsuarioId;
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
        public MUsuario SeleccionarUsuarioPorId(int ptUsuarioId)
        {
            MUsuario mUsuario = new MUsuario();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_usuario_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mUsuario.Nombre = datos["Nombre"].ToString();
                    mUsuario.UsuarioId = int.Parse(datos["UsuarioId"].ToString());
                    mUsuario.AreaId = int.Parse(datos["AreaId"].ToString());
                    mUsuario.Area = datos["Area"].ToString();
                    mUsuario.EmpresaId = int.Parse(datos["EmpresaId"].ToString());
                    mUsuario.Empresa = datos["Empresa"].ToString();
                    mUsuario.RolId = int.Parse(datos["RolId"].ToString());
                    mUsuario.Rol = datos["Rol"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mUsuario.Nombre = ex.Message;
                mUsuario.UsuarioId = 0;
                mUsuario.AreaId = 0;
                mUsuario.Area = ex.Message;
                mUsuario.EmpresaId = 0;
                mUsuario.Empresa = ex.Message;
                mUsuario.RolId = 0;
                mUsuario.Rol = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mUsuario;
        }
        public string ActualizarPerfil(MUsuario mUsuario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_perfil", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mUsuario.UsuarioId;
                comando.Parameters.Add("@PtFechaNacimiento", SqlDbType.VarChar).Value = mUsuario.FechaNacimiento;
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
        public string ActualizarEstadoUsuario(int ptUsuarioId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_usuario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = ptUsuarioId;
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
        /*public string ActualizarUsuario(MUsuario mUsuario)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_usuario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mUsuario.Usuario;
                comando.Parameters.Add("@PtRolId", SqlDbType.TinyInt).Value = mUsuario.RolId;
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = mUsuario.AreaId;
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
        }*/
    }
}