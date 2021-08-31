using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioRol
    {
        private Conexion conexion = Conexion.GetInstancia();

        public List<MRol> ListaRoles(bool ptEstado)
        {
            List<MRol> lista = new List<MRol>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_roles", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEstado", SqlDbType.Bit).Value = ptEstado;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MRol mRol = new MRol();
                    mRol.RolId = int.Parse(datos["RolId"].ToString());
                    mRol.Rol = datos["Rol"].ToString();
                    lista.Add(mRol);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MRol mRol = new MRol();
                mRol.RolId = 0;
                mRol.Rol = ex.Message;
                lista.Add(mRol);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}