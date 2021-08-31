using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioItem
    {
        private Conexion conexion = Conexion.GetInstancia();

        public List<MItem> ListaItems(int ptRolId)
        {
            List<MItem> lista = new List<MItem>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_menu_por_rol_usuario", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtRolId", SqlDbType.TinyInt).Value = ptRolId;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MItem mItem = new MItem();
                    mItem.ItemId = int.Parse(datos["ItemId"].ToString());
                    mItem.Item = datos["Item"].ToString();
                    mItem.Icono = datos["Icono"].ToString();
                    mItem.Url = datos["Url"].ToString();
                    mItem.Nivel = int.Parse(datos["Nivel"].ToString());
                    mItem.Parent = int.Parse(datos["Parent"].ToString());
                    lista.Add(mItem);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MItem mItem = new MItem();
                mItem.ItemId = 0;
                mItem.Item = ex.Message;
                mItem.Icono = ex.Message;
                mItem.Url = ex.Message;
                mItem.Nivel = 0;
                mItem.Parent = 0;
                lista.Add(mItem);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}