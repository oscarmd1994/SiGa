using Sigame.Models;
using Sigame.Services;
using Sigame.Utilities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Sigame.Controllers
{
    [OutputCache(NoStore = Sesion.Almacenar, Duration = Sesion.Duracion, VaryByParam = Sesion.VariarPorParametro)]
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Inicio()
        {
            if (Sesion.Rol == "")
            {
                return View();
            } else
            {
                return Redirect(Sesion.VistaAnterior);
            }
        }
        [HttpGet]
        public ActionResult Principal()
        {
            return Redirect("/home/inicio");
        }
        [HttpGet]
        public ActionResult Salir()
        {
            try
            {
                if (Sesion.Rol != "")
                {
                    Sesion.Abandonar();
                    return Redirect("/home/inicio");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpGet]
        public ActionResult Perfil()
        {
            try
            {
                if (Sesion.Rol != "")
                {
                    /**/
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    ViewData["UsuarioEnSesion"] = servicioUsuario.UsuarioEnSesion(Sesion.UsuarioId);

                    ServicioItem servicioItem = new ServicioItem();
                    ViewData["menu"] = servicioItem.ListaItems(Sesion.RolId);

                    Sesion.VistaAnterior = Request.RawUrl;
                    return View();
                }
                else
                {
                    return Redirect("/home/inicio");
                }
            }
            catch (Exception)
            {
                return Redirect("/home/error");
            }
        }
        [HttpGet]
        public ActionResult Recorridos()
        {
            try
            {
                if(Sesion.Rol != "")
                {
                    ServicioRecorrido servicioRecorrido = new ServicioRecorrido();
                    List<MRecorrido> lista = servicioRecorrido.ListaMensajeros();
                    return Json(lista, JsonRequestBehavior.AllowGet);
                } else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Iniciar(FormCollection formulario)
        {
            try
            {
                MUsuario mUsuario = null;
                string contrasenia = AES.Encriptar(formulario["contrasenia"]);
                if (!contrasenia.Contains("ERROR"))
                {
                    mUsuario = new MUsuario();
                    mUsuario.Usuario = formulario["usuario"].Trim();
                    mUsuario.Contrasenia = contrasenia;
                    mUsuario.EstadoUsuario = true;
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    mUsuario = servicioUsuario.IniciarSesion(mUsuario);
                    if (mUsuario.Respuesta == "login")
                    {
                        Sesion.UsuarioId = mUsuario.UsuarioId;
                        Sesion.AreaId = mUsuario.AreaId;
                        Sesion.RolId = mUsuario.RolId;
                        Sesion.Rol = mUsuario.Rol;
                        string url = "";
                        switch (mUsuario.Rol)
                        {
                            case "Administrador":
                                url = "/administrador/usuarios";
                                break;
                            case "Asignador":
                                url = "/asignador/asignar";
                                break;
                            case "Solicitante":
                                url = "/solicitante/mensaje";
                                break;
                        }
                        return Json(new { respuesta = "login", url = url });
                    }
                    else
                    {
                        return Json(new { respuesta = mUsuario.Respuesta, url = "" });
                    }
                }
                else
                {
                    return Json(new { respuesta = contrasenia, url = "" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, url = "" });
            }
        }
        [HttpPost]
        public ActionResult Foto(HttpPostedFileBase foto)
        {
            try
            {
                if (foto != null)
                {
                    string archivo = Archivo.Imagen(foto, "img_");
                    if (!archivo.Contains("ERROR"))
                    {
                        MUsuario mUsuario = new MUsuario();
                        mUsuario.Foto = archivo;
                        mUsuario.UsuarioId = Sesion.UsuarioId;
                        ServicioUsuario servicioUsuario = new ServicioUsuario();
                        string respuesta = servicioUsuario.ActualizaFotoUsuario(mUsuario);
                        string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                        return Json(new { respuesta = respuesta, accion = accion });
                    }
                    else
                    {
                        return Json(new { respuesta = archivo, accion = "Error" });
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }
    }
}