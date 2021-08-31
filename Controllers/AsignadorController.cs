using Sigame.Models;
using Sigame.Services;
using Sigame.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sigame.Controllers
{
    [OutputCache(NoStore = Sesion.Almacenar, Duration = Sesion.Duracion, VaryByParam = Sesion.VariarPorParametro)]
    public class AsignadorController : Controller
    {
        // GET: Asignar
        [HttpGet]
        public ActionResult Asignar()
        {
            try
            {
                if (Sesion.Rol == "Asignador")
                {
                    ServicioMensajero servicioMensajero = new ServicioMensajero();
                    ViewData["listaMensajerosLibre"] = servicioMensajero.ListaMensajerosLibres();
                    ServicioMensaje servicioMensaje = new ServicioMensaje();
                    ViewData["listaMensajesParaAsignar"] = servicioMensaje.ListaMensajesParaAsignar();
                    /**/
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    ViewData["UsuarioEnSesion"] = servicioUsuario.UsuarioEnSesion(Sesion.UsuarioId);

                    ServicioPaquete servicioPaquete = new ServicioPaquete();
                    ViewData["listaPaquetesAsignadosEnProceso"] = servicioPaquete.ListaPaquetesAsignadosEnProceso();
                    ServicioTipoTransporte servicioTipoTransporte = new ServicioTipoTransporte();
                    ViewData["listaTipos"] = servicioTipoTransporte.ListaTiposTransporte();

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
        public ActionResult Mapa()
        {
            try
            {
                if (Sesion.Rol == "Asignador")
                {
                    /**/
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    ViewData["UsuarioEnSesion"] = servicioUsuario.UsuarioEnSesion(Sesion.UsuarioId);
                    ServicioPaquete servicioPaquete = new ServicioPaquete();
                    ViewData["listaPaquetesAsignadosEnEspera"] = servicioPaquete.ListaPaquetesAsignadosEnEspera();

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
        public ActionResult Envios()
        {
            try
            {
                if (Sesion.Rol == "Asignador")
                {
                    ServicioEnvio servicioEnvio = new ServicioEnvio();
                    ViewData["listaEnviosSinEntregar"] = servicioEnvio.ListaEnviosSinEnviar();
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
        public ActionResult Historial()
        {
            try
            {
                if(Sesion.Rol == "Asignador")
                {
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    ViewData["UsuarioEnSesion"] = servicioUsuario.UsuarioEnSesion(Sesion.UsuarioId);
                    ServicioMensaje servicioMensaje = new ServicioMensaje();
                    ViewData["listaHistorial"] = servicioMensaje.ListaHistorial();

                    ServicioItem servicioItem = new ServicioItem();
                    ViewData["menu"] = servicioItem.ListaItems(Sesion.RolId);
                    Sesion.VistaAnterior = Request.RawUrl;
                    return View();
                }
                else
                {
                    return Redirect("/home/inicio");
                }
            }catch(Exception)
            {
                return Redirect("/home/error");
            }
        }
        [HttpGet]
        public ActionResult Envio(int envioid, string accion)
        {
            try
            {
                if (Sesion.Rol == "Asignador")
                {
                    if (accion == "enviar")
                    {
                        ServicioPaqueteria servicioPaqueteria = new ServicioPaqueteria();
                        ViewData["listaPaqueterias"] = servicioPaqueteria.ListaPaqueteriasSelect();
                        ViewBag.EnvioId = envioid;
                        return View("../Dialog/IniciarEnvio");
                    }
                    else
                    {
                        ViewBag.EnvioId = envioid;
                        return View("../Dialog/FinalizarEnvio");
                    }
                }
                else
                {
                    return Redirect("/home/inicio");
                }
            }
            catch (Exception ex)
            {
                return Redirect("/home/error");
            }
        }
        [HttpGet]
        public ActionResult ListaTransportesPorTipo(int tipotransporteid)
        {
            try
            {
                if (Sesion.Rol == "Asignador")
                {
                    ServicioTransporte servicioTransporte = new ServicioTransporte();
                    List<MTransporte> lista = servicioTransporte.ListaTransportesPorTipo(tipotransporteid);
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
        [HttpGet]
        public ActionResult EstadoPaquete(long paqueteid)
        {
            try
            {
                if(Sesion.Rol == "Asignador")
                {
                    ServicioPaquete servicioPaquete = new ServicioPaquete();
                    string respuesta = servicioPaquete.ActualizarEstadoPaquete(paqueteid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                } else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }catch(Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Asignador
        [HttpPost]
        public ActionResult Enrrolar(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Asignador")
                {
                    MPaquete mPaquete = new MPaquete();
                    mPaquete.MensajeroId = int.Parse(formulario["mensajeroid"]);
                    mPaquete.Fecha = formulario["fecha"];
                    mPaquete.Hora = formulario["hora"];
                    mPaquete.AsignadorId = Sesion.UsuarioId;
                    mPaquete.MensajesId = formulario["paquetesid"];
                    mPaquete.EstadoPaquete = "Asignado";
                    mPaquete.TransporteId = int.Parse(formulario["transporteid"]);
                    ServicioAsignacion servicioAsignacion = new ServicioAsignacion();
                    string respuesta = servicioAsignacion.AsignarPaquetes(mPaquete);
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
        public ActionResult EnviarEnvio(FormCollection formulario)
        {
            try
            {
                if(Sesion.Rol == "Asignador")
                {
                    MEnvio mEnvio = new MEnvio();
                    mEnvio.EnvioId = int.Parse(formulario["envioid"]);
                    mEnvio.PaqueteriaId = int.Parse(formulario["paqueteriaid"]);
                    ServicioEnvio servicioEnvio = new ServicioEnvio();
                    string respuesta = servicioEnvio.Enviar(mEnvio);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion });
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" });
                }
            }catch(Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }
        [HttpPost]
        public ActionResult EntregarEnvio(FormCollection formulario)
        {
            try
            {
                if(Sesion.Rol == "Asignador")
                {
                    MEnvio mEnvio = new MEnvio();
                    mEnvio.FechaEntrega = formulario["fechaentrega"];
                    mEnvio.HoraEntrega = formulario["horaentrega"];
                    mEnvio.EstadoEnvio = "Entregado";
                    mEnvio.EnvioId = int.Parse(formulario["envioid"]);
                    ServicioEnvio servicioEnvio = new ServicioEnvio();
                    string respuesta = servicioEnvio.EntregarEnvio(mEnvio);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion });
                } else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" });
                }
            }catch(Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }
    }
}