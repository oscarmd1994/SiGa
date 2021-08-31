using System;
using System.Drawing;
using System.IO;
using System.Web;

namespace Sigame.Utilities
{
    public static class Archivo
    {
        public static string Imagen(HttpPostedFileBase imagen, string prefijo)
        {
            string[] extensiones = new string[] { ".png", ".jpg", ".jpeg" };
            string[] directorios = new string[] { "/Uploads/Profiles", "/Uploads/Markers", "/Uploads/Vouchers" };
            string ruta = "";
            try
            {
                foreach (var directorio in directorios)
                {
                    bool existe = Directory.Exists(HttpContext.Current.Server.MapPath(directorio));
                    if (!existe)
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(directorio));
                    }
                }
                string extension = Path.GetExtension(imagen.FileName);
                if (Array.IndexOf(extensiones, extension) != -1)
                {
                    if (imagen.ContentLength > 0 && (imagen.ContentLength / 1024) < 10240)
                    {
                        string tiempo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        string archivo = prefijo + tiempo + extension;
                        switch (prefijo)
                        {
                            case "img_":
                                ruta = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads/Profiles"), archivo);
                                break;
                            case "marker_":
                                ruta = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads/Markers"), archivo);
                                break;
                            case "voucher_":
                                ruta = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads/Vouchers"), archivo);
                                break;
                        }
                        imagen.SaveAs(ruta);
                        return archivo;
                    }
                    else
                    {
                        return "ERROR: El tamaño de la imagen no puede ser mayor a 10MB";
                    }

                }
                else
                {
                    return "ERROR: No se permiten archivos " + extension;
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        /*
        public static string Upload(string imagen, string prefijo)
        {
            try
            {
                string directorio = "/Uploads/Vouchers";
                bool existe = Directory.Exists(HttpContext.Current.Server.MapPath(directorio));
                if (!existe)
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(directorio));
                }
                string tiempo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string archivo = prefijo + tiempo + ".png";
                string ruta = Path.Combine(HttpContext.Current.Server.MapPath(directorio), archivo);
                var bytess = Convert.FromBase64String(imagen);
                var imageFile = new FileStream(ruta, FileMode.Create);
                imageFile.Write(bytess, 0, bytess.Length);
                imageFile.Flush();
                if (imageFile.Length > 0 && (imageFile.Length / 1024) < 3072)
                {
                    return archivo;

                }
                else
                {
                    File.Delete(ruta);
                    return "ERROR: El tamaño de la imagen no puede ser mayor a 3MB";
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        */
    }
}