using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioArea
    {
        private Conexion conexion = Conexion.GetInstancia();

        public string NuevaArea(MArea mArea)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_agregar_area", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtArea", SqlDbType.VarChar, 300).Value = mArea.Area;
                comando.Parameters.Add("@PtEstadoArea", SqlDbType.Bit).Value = mArea.EstadoArea;
                comando.Parameters.Add("@PtEmpresaId", SqlDbType.SmallInt).Value = mArea.EmpresaId;
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
        public List<MArea> ListaAreas(int ptEmpresaId)
        {
            List<MArea> lista = new List<MArea>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_areas", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpresaId", SqlDbType.SmallInt).Value = ptEmpresaId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MArea mArea = new MArea();
                    mArea.AreaId = int.Parse(datos["AreaId"].ToString());
                    mArea.Area = datos["Area"].ToString();
                    lista.Add(mArea);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MArea mArea = new MArea();
                mArea.AreaId = 0;
                mArea.Area = ex.Message;
                lista.Add(mArea);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public List<MArea> ListaAreasTabla(int ptEmpresaId)
        {
            List<MArea> lista = new List<MArea>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_areas_tabla", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEmpresaId", SqlDbType.SmallInt).Value = ptEmpresaId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MArea mArea = new MArea();
                    mArea.AreaId = int.Parse(datos["AreaId"].ToString());
                    mArea.Area = datos["Area"].ToString();
                    mArea.EstadoArea = bool.Parse(datos["EstadoArea"].ToString());
                    lista.Add(mArea);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MArea mArea = new MArea();
                mArea.AreaId = 0;
                mArea.Area = ex.Message;
                mArea.EstadoArea = false;
                lista.Add(mArea);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public MArea SeleccionarAreaPorId(int ptAreaId)
        {
            MArea mArea = new MArea();
            try
            {
                SqlCommand comando = new SqlCommand("stp_seleccionar_area_por_id", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = ptAreaId;
                SqlDataReader datos = comando.ExecuteReader();
                if (datos.Read())
                {
                    mArea.AreaId = int.Parse(datos["AreaId"].ToString());
                    mArea.Area = datos["Area"].ToString();
                }
                datos.Close();
                comando.Dispose();
            }
            catch(SqlException ex)
            {
                mArea.AreaId = 0;
                mArea.Area = ex.Message;
            }
            finally
            {
                conexion.Close();
            }
            return mArea;
        }
        public string ActualizarArea(MArea mArea)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualizar_area", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = mArea.AreaId;
                comando.Parameters.Add("@PtArea", SqlDbType.VarChar, 300).Value = mArea.Area;
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
        public string ActualizarEstadoArea(int ptAreaId)
        {
            try
            {
                SqlCommand comando = new SqlCommand("stp_actualiza_estado_area", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtAreaId", SqlDbType.SmallInt).Value = ptAreaId;
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