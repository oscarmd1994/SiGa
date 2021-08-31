using Sigame.Api_REST.Models;
using Sigame.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Api_REST.Services
{
    public class ServicioUsuario
    {
        private Conexion conexion = Conexion.GetInstancia();
        public MMensajero IniciarSesionAplicacion(string ptUsuario, string ptContrasenia)
        {
            MMensajero mMensajero = new MMensajero();
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_iniciar_sesion", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuario", SqlDbType.VarChar, 40).Value = ptUsuario;
                comando.Parameters.Add("@PtContrasenia", SqlDbType.VarChar, 300).Value = ptContrasenia;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mMensajero.MensajeroId = int.Parse(datos["MensajeroId"].ToString());
                    mMensajero.Area = datos["Area"].ToString();
                    mMensajero.Empresa = datos["Empresa"].ToString();
                    mMensajero.Rol = datos["Rol"].ToString();
                    mMensajero.Respuesta = datos["Respuesta"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mMensajero.Respuesta = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mMensajero;
        }
        public MMensajero Perfil(int mensajeroId)
        {
            MMensajero mMensajero = new MMensajero();
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_usuario_sesion", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mensajeroId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mMensajero.Usuario = datos["Usuario"].ToString();
                    mMensajero.Foto = datos["Foto"].ToString();
                    mMensajero.Rol = datos["Rol"].ToString();
                    mMensajero.Area = datos["Area"].ToString();
                    mMensajero.Nombre = datos["Nombre"].ToString();
                    mMensajero.ApellidoPaterno = datos["ApellidoPaterno"].ToString();
                    mMensajero.ApellidoMaterno = datos["ApellidoMaterno"].ToString();
                    mMensajero.FechaNacimiento = datos["FechaNacimiento"].ToString();
                    mMensajero.Empresa = datos["Empresa"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch(SqlException ex)
            {
                mMensajero.Usuario = ex.Message;
                mMensajero.Foto = ex.Message;
                mMensajero.Rol = ex.Message;
                mMensajero.Area = ex.Message;
                mMensajero.Nombre = ex.Message;
                mMensajero.ApellidoPaterno = ex.Message;
                mMensajero.ApellidoMaterno = ex.Message;
                mMensajero.FechaNacimiento = ex.Message;
                mMensajero.Empresa = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mMensajero;
        }
        public string ActualizarPerfil(MMensajero mMensajero)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_actualizar_perfil", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtUsuarioId", SqlDbType.Int).Value = mMensajero.MensajeroId;
                comando.Parameters.Add("@PtFechaNacimiento", SqlDbType.Date).Value = mMensajero.FechaNacimiento;
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
        public string ActualizaFotoUsuario(MMensajero mMensajero)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_aplicacion_actualizar_foto_usuario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtFoto", SqlDbType.VarChar, 100).Value = mMensajero.Foto;
                comando.Parameters.Add("@PtMensajeroId", SqlDbType.Int).Value = mMensajero.MensajeroId;
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