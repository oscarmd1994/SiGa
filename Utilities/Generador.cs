using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Sigame.Utilities
{
    public class Generador
    {
        private const string consignos = "áàäéèëíìïóòöúùuÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇñÑ";
        private const string sinsignos = "aaaeeeiiiooouuuAAAEEEIIIOOOUUUcCnN";
        public static string NombreUsuario(string[] parametros)
        {
            try
            {
                string nombre = Regex.Replace(parametros[0], @"\s", "");
                nombre = nombre.Remove(1).ToUpper() + nombre.Substring(1).ToLower();
                string apellidos = Regex.Replace(parametros[1], @"\s", "");
                apellidos = apellidos.Remove(1).ToUpper() + apellidos.Substring(1).ToLower();
                Random random = new Random();
                string numero = random.Next(0, 1000).ToString();
                string usuario = apellidos.Substring(0, 1) + nombre.Substring(0, 1) + apellidos.Substring(0, 7) + "_" + numero;
                StringBuilder builder = new StringBuilder(usuario.Length);
                int index;
                foreach (char caracter in usuario)
                {
                    index = consignos.IndexOf(caracter);
                    if (index > -1)
                    {
                        builder.Append(sinsignos.Substring(index, 1));
                    }
                    else
                    {
                        builder.Append(caracter);
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                return "Caught exception: " + ex.Message;
            }
        }
    }
}