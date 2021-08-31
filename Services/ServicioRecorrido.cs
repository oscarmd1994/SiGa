using Sigame.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sigame.Services
{
    public class ServicioRecorrido
    {
        private Conexion conexion = Conexion.GetInstancia();
        public List<MRecorrido> ListaMensajeros()
        {
            List<MRecorrido> lista = new List<MRecorrido>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_mensajeros_en_recorrido_ver_mapa", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MRecorrido mRecorrido = new MRecorrido();
                    mRecorrido.Mensajero = datos["Mensajero"].ToString();
                    mRecorrido.Foto = datos["Foto"].ToString();
                    mRecorrido.Latitud = datos["Latitud"].ToString();
                    mRecorrido.Longitud = datos["Longitud"].ToString();
                    mRecorrido.Imagen = datos["Imagen"].ToString();
                    mRecorrido.Placa = datos["Placa"].ToString();
                    mRecorrido.Modelo = datos["Modelo"].ToString();
                    mRecorrido.Anio = datos["Anio"].ToString();
                    lista.Add(mRecorrido);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MRecorrido mRecorrido = new MRecorrido();
                mRecorrido.Mensajero = ex.Message;
                mRecorrido.Foto = ex.Message;
                mRecorrido.LugarOrigen = ex.Message;
                mRecorrido.LugarDestino = ex.Message;
                mRecorrido.Destinatario = ex.Message;
                mRecorrido.Latitud = ex.Message;
                mRecorrido.Longitud = ex.Message;
                mRecorrido.Placa = ex.Message;
                mRecorrido.Modelo = ex.Message;
                mRecorrido.Anio = ex.Message;
                lista.Add(mRecorrido);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}