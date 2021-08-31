using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioEmpresa
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevaEmpresa(MEmpresa mEmpresa)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_empresa", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpresa", SqlDbType.VarChar, 100).Value = mEmpresa.Empresa;
                comando.Parameters.Add("@PtEstadoEmpresa", SqlDbType.Bit).Value = mEmpresa.EstadoEmpresa;
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
        public List<MEmpresa> ListaEmpresas(bool ptEstado)
        {
            List<MEmpresa> lista = new List<MEmpresa>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_empresas", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEstado", SqlDbType.Bit).Value = ptEstado;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MEmpresa mEmpresa = new MEmpresa();
                    mEmpresa.EmpresaId = int.Parse(datos["EmpresaId"].ToString());
                    mEmpresa.Empresa = datos["Empresa"].ToString();
                    lista.Add(mEmpresa);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MEmpresa mEmpresa = new MEmpresa();
                mEmpresa.EmpresaId = 0;
                mEmpresa.Empresa = ex.Message;
                lista.Add(mEmpresa);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MEmpresa> ListaTablaEmpresas()
        {
            List<MEmpresa> lista = new List<MEmpresa>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_tabla_empresas", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MEmpresa mEmpresa = new MEmpresa();
                    mEmpresa.EmpresaId = int.Parse(datos["EmpresaId"].ToString());
                    mEmpresa.Empresa = datos["Empresa"].ToString();
                    mEmpresa.EstadoEmpresa = bool.Parse(datos["EstadoEmpresa"].ToString());
                    lista.Add(mEmpresa);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MEmpresa mEmpresa = new MEmpresa();
                mEmpresa.EmpresaId = 0;
                mEmpresa.Empresa = ex.Message;
                mEmpresa.EstadoEmpresa = false;
                lista.Add(mEmpresa);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MEmpresa SeleccionarEmpresaPorId(int ptEmpresaId)
        {
            MEmpresa mEmpresa = new MEmpresa();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_empresa_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpresaId", SqlDbType.SmallInt).Value = ptEmpresaId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mEmpresa.EmpresaId = int.Parse(datos["EmpresaId"].ToString());
                    mEmpresa.Empresa = datos["Empresa"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                mEmpresa.EmpresaId = 0;
                mEmpresa.Empresa = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mEmpresa;
        }
        public string ActualizarEmpresa(MEmpresa mEmpresa)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_empresa", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpresaId", SqlDbType.SmallInt).Value = mEmpresa.EmpresaId;
                comando.Parameters.Add("@PtEmpresa", SqlDbType.VarChar, 100).Value = mEmpresa.Empresa;
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
        public string ActualizarEstadoEmpresa(int ptEmpresaId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_empresa", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpresaId", SqlDbType.SmallInt).Value = ptEmpresaId;
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