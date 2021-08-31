using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sigame.Utilities
{
    public class AES
    {
        private static byte[] Clave = Encoding.ASCII.GetBytes(@"qwr{@^h`h&_`50/ja9!'dcmh3!uw<&=?");
        private static byte[] Vector = Encoding.ASCII.GetBytes(@"9/\~V).A,lY&=t2b");

        public static string Encriptar(string cadena)
        {
            try
            {
                // Instanciamos el algoritmo para asignar las propiedades a sus métodos
                AesCryptoServiceProvider algoritmo = new AesCryptoServiceProvider();
                algoritmo.Key = Clave;
                algoritmo.IV = Vector;
                algoritmo.Mode = CipherMode.CBC;
                algoritmo.Padding = PaddingMode.PKCS7;

                // Creamos el encriptador por medio del algoritmo, clave y vector
                ICryptoTransform transformar = algoritmo.CreateEncryptor(algoritmo.Key, algoritmo.IV);
                MemoryStream stream = new MemoryStream();
                CryptoStream crypto = new CryptoStream(stream, transformar, CryptoStreamMode.Write);
                using (StreamWriter writer = new StreamWriter(crypto))
                {
                    writer.Write(cadena);
                }
                byte[] bytes = stream.ToArray();
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                return "ERROR " + ex.Message;
            }
        }

        public static string Desencriptar(string cadena)
        {
            try
            {
                byte[] cifrado = Convert.FromBase64String(cadena.Replace(' ', '+'));

                // Instanciamos el algoritmo para asignar las propiedades a sus métodos
                AesCryptoServiceProvider algoritmo = new AesCryptoServiceProvider();
                algoritmo.Key = Clave;
                algoritmo.IV = Vector;
                algoritmo.Mode = CipherMode.CBC;
                algoritmo.Padding = PaddingMode.PKCS7;

                // Creamos el desencriptador por medio del algoritmo, clave y vector
                ICryptoTransform transformar = algoritmo.CreateDecryptor(algoritmo.Key, algoritmo.IV);
                MemoryStream stream = new MemoryStream(cifrado);
                CryptoStream crypto = new CryptoStream(stream, transformar, CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(crypto);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                return "ERROR " + ex.Message;
            }
        }
    }
}