using Sigame.Models;
using Sigame.Services;
using Sigame.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sigame.Controllers
{
    [OutputCache(NoStore = Sesion.Almacenar, Duration = Sesion.Duracion, VaryByParam = Sesion.VariarPorParametro)]
    public class SolicitanteController : Controller
    {
        // GET: Solicitar
        [HttpGet]
        public ActionResult Mensaje()
        {
            ServicioMensaje servicioMensaje = null;
            try
            {
                if (Sesion.Rol == "Solicitante")
                {
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    ViewData["listaDestinatariosMensaje"] = servicioDestinatario.ListaDestinatariosMensaje(true);
                    ServicioPrioridad servicioPrioridad = new ServicioPrioridad();
                    ViewData["listaPrioridades"] = servicioPrioridad.ListaPrioridades(true);
                    /**/
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    ViewData["UsuarioEnSesion"] = servicioUsuario.UsuarioEnSesion(Sesion.UsuarioId);
                    servicioMensaje = new ServicioMensaje();
                    ViewBag.FolioMensaje = servicioMensaje.NuevoFolio(Sesion.UsuarioId);
                    ServicioEnvio servicioEnvio = new ServicioEnvio();
                    ViewBag.FolioEnvio = servicioEnvio.NuevoFolio(Sesion.UsuarioId);

                    servicioMensaje = new ServicioMensaje();
                    ViewData["listaEstadoMensajesSolicitados"] = servicioMensaje.ListaEstadoMensajesSolicitados(Sesion.UsuarioId);

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
        public ActionResult Historial()
        {
            try
            {
                if (Sesion.Rol == "Solicitante")
                {
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    ViewData["UsuarioEnSesion"] = servicioUsuario.UsuarioEnSesion(Sesion.UsuarioId);
                    ServicioMensaje servicioMensaje = new ServicioMensaje();
                    ViewData["listaHistorial"] = servicioMensaje.ListaHistorial(Sesion.UsuarioId);
                    
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
        public ActionResult ListaDirecciones(int destinatarioid)
        {
            try
            {
                if (Sesion.Rol == "Solicitante")
                {
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    List<MDireccion> lista = servicioDestinatario.ListaDirecciones(destinatarioid);
                    return Json(lista, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult NuevoMensaje(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Solicitante")
                {
                    MMensaje mMensaje = new MMensaje();
                    mMensaje.Folio = formulario["folio"].Trim();
                    mMensaje.Descripcion = formulario["descripcion"].Trim();
                    mMensaje.Observacion = formulario["observacion"].Trim();
                    mMensaje.Fecha = formulario["fecha"].Trim();
                    mMensaje.Hora = formulario["hora"].Trim();
                    mMensaje.EstadoMensaje = false;
                    mMensaje.UsuarioId = Sesion.UsuarioId;
                    mMensaje.PrioridadId = int.Parse(formulario["prioridadid"]);
                    mMensaje.DireccionDestinatarioId = long.Parse(formulario["direcciondestinatarioid"]);
                    mMensaje.DireccionSalida = formulario["direccionsalida"];
                    ServicioMensaje servicioMensaje = new ServicioMensaje();
                    string respuesta = servicioMensaje.NuevoMensaje(mMensaje);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion });
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }
        [HttpPost]
        public ActionResult NuevoEnvio(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Solicitante")
                {
                    MEnvio mEnvio = new MEnvio();
                    mEnvio.Folio = formulario["folio"].Trim();
                    mEnvio.Descripcion = formulario["descripcion"].Trim();
                    mEnvio.Observacion = formulario["observacion"].Trim();
                    mEnvio.FechaSolicitud = formulario["fecha"].Trim();
                    mEnvio.HoraSolicitud = formulario["hora"].Trim();
                    mEnvio.EstadoEnvio = "Pendiente";
                    mEnvio.UsuarioId = Sesion.UsuarioId;
                    mEnvio.PrioridadId = int.Parse(formulario["prioridadid"]);
                    mEnvio.DestinatarioId = int.Parse(formulario["destinatarioid"]);
                    ServicioEnvio servicioEnvio = new ServicioEnvio();
                    string respuesta = servicioEnvio.NuevoEnvio(mEnvio);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion });
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }
    }
}