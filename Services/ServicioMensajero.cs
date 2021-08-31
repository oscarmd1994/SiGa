using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioMensajero
    {
        private Conexion conexion = Conexion.GetInstancia();

        public List<MMensajero> ListaMensajerosLibres()
        {
            List<MMensajero> lista = new List<MMensajero>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_mensajeros_libres", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MMensajero mMensajero = new MMensajero();
                    mMensajero.MensajeroId = int.Parse(datos["MensajeroId"].ToString());
                    mMensajero.Nombre = datos["Nombre"].ToString();
                    mMensajero.Foto = datos["Foto"].ToString();
                    lista.Add(mMensajero);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MMensajero mMensajero = new MMensajero();
                mMensajero.MensajeroId = 0;
                mMensajero.Nombre = ex.Message;
                mMensajero.Foto = ex.Message;
                lista.Add(mMensajero);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}