using Sigame.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sigame.Services
{
    public class ServicioPrioridad
    {
        private Conexion conexion = Conexion.GetInstancia();

        public List<MPrioridad> ListaPrioridades(bool ptEstado)
        {
            List<MPrioridad> lista = new List<MPrioridad>();
            try
            {
                SqlCommand comando = new SqlCommand("stp_lista_prioridades", conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = conexion.GetCommandTimeout
                };
                comando.Parameters.Add("@PtEstado", SqlDbType.Bit).Value = ptEstado;
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    MPrioridad mPrioridad = new MPrioridad();
                    mPrioridad.PrioridadId = int.Parse(datos["PrioridadId"].ToString());
                    mPrioridad.Prioridad = datos["Prioridad"].ToString();
                    mPrioridad.Color = datos["Color"].ToString();
                    lista.Add(mPrioridad);
                }
                datos.Close();
                comando.Dispose();
            }
            catch (SqlException ex)
            {
                MPrioridad mPrioridad = new MPrioridad();
                mPrioridad.PrioridadId = 0;
                mPrioridad.Prioridad = ex.Message;
                mPrioridad.Color = ex.Message;
                lista.Add(mPrioridad);
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
    }
}