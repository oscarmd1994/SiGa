using Sigame.Api_REST.Services;
using Sigame.Api_REST.Models;
using Sigame.Utilities;
using System.Web.Http;
using System.Web.Http.Cors;
using System;
using System.Web;

namespace Sigame.Api_REST.Controllers
{
    [AllowAnonymous, RoutePrefix("api/login"), EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpGet, Route("login")]
        public IHttpActionResult Login(string usuario, string contrasenia)
        {
            MMensajero mMensajero = null;
            try
            {
                contrasenia = AES.Encriptar(contrasenia);
                ServicioUsuario servicioUsuario = new ServicioUsuario();
                mMensajero = servicioUsuario.IniciarSesionAplicacion(usuario, contrasenia);
                return Ok(mMensajero);
            }
            catch (Exception)
            {
                return Ok(mMensajero);
            }
        }
        [HttpGet, Route("perfil")]
        public IHttpActionResult Perfil(int mensajeroid)
        {
            MMensajero mMensajero = null;
            try
            {
                ServicioUsuario servicioUsuario = new ServicioUsuario();
                mMensajero = servicioUsuario.Perfil(mensajeroid);
                return Ok(mMensajero);
            }
            catch (Exception ex)
            {
                return Ok(mMensajero);
            }
        }
        [HttpPost, Route("actualizaperfil")]
        public IHttpActionResult ActualizaPerfil(MMensajero mMensajero)
        {
            try
            {
                ServicioUsuario servicioUsuario = new ServicioUsuario();
                string respuesta = servicioUsuario.ActualizarPerfil(mMensajero);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpPost, Route("uploadimage")]
        public IHttpActionResult UploadImage()
        {
            try
            {
                var request = HttpContext.Current.Request;
                if (request.Files.Count > 0)
                {
                    var postedFile = request.Files.Get("file");
                    HttpPostedFileBase foto = new HttpPostedFileWrapper(postedFile);
                    string archivo = Archivo.Imagen(foto, "img_");
                    if (!archivo.Contains("ERROR"))
                    {
                        MMensajero mMensajero = new MMensajero();
                        mMensajero.Foto = archivo;
                        mMensajero.MensajeroId = int.Parse(request.Params["mensajeroId"]);
                        ServicioUsuario servicioUsuario = new ServicioUsuario();
                        string respuesta = servicioUsuario.ActualizaFotoUsuario(mMensajero);
                        return Ok(respuesta);
                    }
                    else
                    {
                        return Ok(archivo);
                    }
                }
                else
                {
                    return Ok("No hay archivos");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
