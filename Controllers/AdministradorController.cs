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
    public class AdministradorController : Controller
    {
        // GET: Administrador
        [HttpGet]
        public ActionResult Usuarios()
        {
            ServicioUsuario servicioUsuario = null;
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
                    ViewData["listaEmpleadosUsuarios"] = servicioEmpleado.ListaEmpleadosUsuarios(false);
                    ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
                    ViewData["listaEmpresas"] = servicioEmpresa.ListaEmpresas(true);
                    ServicioRol servicioRol = new ServicioRol();
                    ViewData["listaRoles"] = servicioRol.ListaRoles(true);
                    servicioUsuario = new ServicioUsuario();
                    ViewData["listaUsuarios"] = servicioUsuario.ListaUsuarios(Sesion.UsuarioId);
                    ServicioArea servicioArea = new ServicioArea();
                    /**/
                    servicioUsuario = new ServicioUsuario();
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
                return Redirect("/home/erro");
            }

        }
        [HttpGet]
        public ActionResult Destinatarios()
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
                    ViewData["listaEmpleadosDestinatarios"] = servicioEmpleado.ListaEmpleadosDestinatarios(Sesion.UsuarioId);
                    ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
                    ViewData["listaEmpresas"] = servicioEmpresa.ListaEmpresas(true);
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    ViewData["listaDestinatarios"] = servicioDestinatario.ListaDestinatarios();
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
        public ActionResult Paqueterias()
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {

                    ServicioPaqueteria servicioPaqueteria = new ServicioPaqueteria();
                    ViewData["listaPaqueterias"] = servicioPaqueteria.ListaPaqueterias();
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
        public ActionResult Empleados()
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
                    ViewData["listaEmpleados"] = servicioEmpleado.ListaEmpleados();
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
        public ActionResult Empresas()
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
                    ViewData["listaEmpresas"] = servicioEmpresa.ListaTablaEmpresas();
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
        public ActionResult Areas(int empresaid, string empresa)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioArea servicioArea = new ServicioArea();
                    ViewData["listaAreas"] = servicioArea.ListaAreasTabla(empresaid);
                    ViewBag.empresaid = empresaid;
                    ViewBag.empresa = empresa;
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
        public JsonResult ListaAreas(int empresaid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioArea servicioArea = new ServicioArea();
                    List<MArea> lista = servicioArea.ListaAreas(empresaid);
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
        public ActionResult Transportes()
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioTipoTransporte servicioTipoTransporte = null;
                    servicioTipoTransporte = new ServicioTipoTransporte();
                    ViewData["listaTiposTransporte"] = servicioTipoTransporte.ListaTablaTiposTransporte();
                    ServicioTransporte servicioTransporte = new ServicioTransporte();
                    ViewData["listaTransportes"] = servicioTransporte.ListaTablaTransporte();
                    servicioTipoTransporte = new ServicioTipoTransporte();
                    ViewData["listaTipos"] = servicioTipoTransporte.ListaTiposTransporte();
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
        public ActionResult Area(int idarea)
        {
            ServicioArea servicioArea = new ServicioArea();
            ViewData["AreaPorId"] = servicioArea.SeleccionarAreaPorId(idarea);
            return View("../Dialog/Area");
        }
        [HttpGet]
        public ActionResult Empleado(int idempleado)
        {
            ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
            ViewData["EmpleadoPorId"] = servicioEmpleado.SeleccionarEmpleadoPorId(idempleado);
            return View("../Dialog/Empleado");
        }
        [HttpGet]
        public ActionResult Paqueteria(int idpaqueteria)
        {
            ServicioPaqueteria servicioPaqueteria = new ServicioPaqueteria();
            ViewData["PaqueteriaPorId"] = servicioPaqueteria.SeleccionarPaqueteriaPorId(idpaqueteria);
            return View("../Dialog/Paqueteria");
        }
        [HttpGet]
        public ActionResult Empresa(int empresaid)
        {
            ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
            ViewData["EmpresaPorId"] = servicioEmpresa.SeleccionarEmpresaPorId(empresaid);
            return View("../Dialog/Empresa");
        }
        [HttpGet]
        public ActionResult Destinatario(int destinatarioid)
        {
            ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
            ViewData["DestinatarioPorId"] = servicioDestinatario.SeleccionarDestinatarioPorId(destinatarioid);
            ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
            ViewData["listaEmpresas"] = servicioEmpresa.ListaEmpresas(true);
            return View("../Dialog/Destinatario");
        }
        [HttpGet]
        public ActionResult Usuario(int usuarioid)
        {
            ServicioUsuario servicioUsuario = new ServicioUsuario();
            ViewData["UsuarioPorId"] = servicioUsuario.SeleccionarUsuarioPorId(usuarioid);
            ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
            ViewData["listaEmpresas"] = servicioEmpresa.ListaEmpresas(true);
            ServicioRol servicioRol = new ServicioRol();
            ViewData["listaRoles"] = servicioRol.ListaRoles(true);
            return View("../Dialog/Usuario");
        }
        [HttpGet]
        public ActionResult Tipo(int tipoid)
        {
            ServicioTipoTransporte servicioTipoTransporte = null;
            servicioTipoTransporte = new ServicioTipoTransporte();
            ViewData["TipoTransportePorId"] = servicioTipoTransporte.SeleccionarTipoTransportePorId(tipoid);
            servicioTipoTransporte = new ServicioTipoTransporte();
            ViewData["listaTiposTransporte"] = servicioTipoTransporte.ListaTablaTiposTransporte();
            return View("../Dialog/TipoTransporte");
        }
        [HttpGet]
        public ActionResult Transporte(int transporteid)
        {
            ServicioTransporte servicioTransporte = new ServicioTransporte();
            ViewData["TransportePorId"] = servicioTransporte.SeleccionarTransportePorId(transporteid);
            ServicioTipoTransporte servicioTipoTransporte = new ServicioTipoTransporte();
            ViewData["listaTipos"] = servicioTipoTransporte.ListaTiposTransporte();
            return View("../Dialog/Transporte");
        }
        public ActionResult Confirmar(int lugarid, string accion, string lugar)
        {
            ViewBag.lugarid = lugarid;
            ViewBag.accion = accion;
            ViewBag.lugar = lugar;
            return View("../Dialog/Confirmar");
        }
        [HttpGet]
        public ActionResult EstadoPaqueteria(int paqueteriaid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioPaqueteria servicioPaqueteria = new ServicioPaqueteria();
                    string respuesta = servicioPaqueteria.ActualizarEstadoPaqueteria(paqueteriaid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoEmpresa(int empresaid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
                    string respuesta = servicioEmpresa.ActualizarEstadoEmpresa(empresaid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoArea(int areaid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioArea servicioArea = new ServicioArea();
                    string respuesta = servicioArea.ActualizarEstadoArea(areaid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoDestinatario(int destinatarioid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    string respuesta = servicioDestinatario.ActualizarEstadoDestinatario(destinatarioid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoUsuario(int usuarioid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    string respuesta = servicioUsuario.ActualizarEstadoUsuario(usuarioid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoTipoTransporte(int tipotransporteid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {

                    ServicioTipoTransporte servicioTipoTransporte = new ServicioTipoTransporte();
                    string respuesta = servicioTipoTransporte.ActualizarEstadoTipoTransporte(tipotransporteid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoTransporte(int transporteid)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    ServicioTransporte servicioTransporte = new ServicioTransporte();
                    string respuesta = servicioTransporte.ActualizarEstadoTransporte(transporteid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult EstadoEmpleado(int empleadoid)
        {
            try
            {
                if(Sesion.Rol == "Administrador")
                {
                    ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
                    string respuesta = servicioEmpleado.ActualizarEstadoEmpleado(empleadoid);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" }, JsonRequestBehavior.AllowGet);
                }
            }catch(Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Administrador
        [HttpPost]
        public ActionResult NuevoUsuario(FormCollection formulario, HttpPostedFileBase foto)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    string archivo = "";
                    if (foto != null)
                    {
                        archivo = Archivo.Imagen(foto, "img_");
                    }
                    if (!archivo.Contains("ERROR"))
                    {
                        MUsuario mUsuario = new MUsuario();
                        mUsuario.FechaNacimiento = formulario["fechanacimiento"].Trim();
                        string[] parametro = { formulario["nombre"], formulario["apellidos"] };
                        string usuario = Generador.NombreUsuario(parametro);
                        if (usuario.IndexOf("exception") == -1)
                        {
                            mUsuario.Usuario = usuario;
                            mUsuario.Contrasenia = AES.Encriptar(usuario);
                            mUsuario.Foto = archivo;
                            mUsuario.EstadoUsuario = true;
                            mUsuario.EmpleadoId = int.Parse(formulario["empleadoid"]);
                            mUsuario.RolId = int.Parse(formulario["rolid"]);
                            mUsuario.AreaId = int.Parse(formulario["areaid"]);
                            ServicioUsuario servicioUsuario = new ServicioUsuario();
                            string respuesta = servicioUsuario.NuevoUsuario(mUsuario);
                            string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                            return Json(new { respuesta = respuesta, accion = accion });
                        }
                        else {
                            return Json(new { respuesta = usuario, accion = "Error" });
                        }

                    }
                    else
                    {
                        return Json(new { respuesta = archivo, accion = "Error" });
                    }
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
        public ActionResult NuevoDestinatario(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MDestinatario mDestinatario = new MDestinatario();
                    mDestinatario.EstadoDestinatario = true;
                    mDestinatario.EmpleadoId = int.Parse(formulario["empleadoid"]);
                    mDestinatario.AreaId = int.Parse(formulario["areaid"]);
                    mDestinatario.Direccion = formulario["direcciones"];
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    string respuesta = servicioDestinatario.NuevoDestinatario(mDestinatario);
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
        public ActionResult NuevaPaqueteria(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MPaqueteria mPaqueteria = new MPaqueteria();
                    mPaqueteria.Paqueteria = formulario["paqueteria"].Trim();
                    mPaqueteria.EstadoPaqueteria = true;
                    ServicioPaqueteria servicioPaqueteria = new ServicioPaqueteria();
                    string respuesta = servicioPaqueteria.NuevaPaqueteria(mPaqueteria);
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
        public ActionResult NuevoEmpleado(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MEmpleado mEmpleado = new MEmpleado();
                    mEmpleado.Nombre = formulario["nombre"].Trim();
                    mEmpleado.ApellidoPaterno = formulario["apellidopaterno"].Trim();
                    mEmpleado.ApellidoMaterno = formulario["apellidomaterno"].Trim();
                    mEmpleado.EstadoEmpleado = true;
                    ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
                    string respuesta = servicioEmpleado.NuevoEmpleado(mEmpleado);
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
        public ActionResult NuevaEmpresa(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MEmpresa mEmpresa = new MEmpresa();
                    mEmpresa.Empresa = formulario["empresa"].Trim();
                    mEmpresa.EstadoEmpresa = true;
                    ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
                    string respuesta = servicioEmpresa.NuevaEmpresa(mEmpresa);
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
        public ActionResult NuevaArea(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MArea mArea = new MArea();
                    mArea.EmpresaId = int.Parse(formulario["empresaid"]);
                    mArea.Area = formulario["area"].Trim();
                    mArea.EstadoArea = true;
                    ServicioArea servicioArea = new ServicioArea();
                    string respuesta = servicioArea.NuevaArea(mArea);
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
        public ActionResult ActualizaArea(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MArea mArea = new MArea();
                    mArea.AreaId = int.Parse(formulario["areaid"]);
                    mArea.Area = formulario["area"].Trim();
                    ServicioArea servicioArea = new ServicioArea();
                    string respuesta = servicioArea.ActualizarArea(mArea);
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
        public ActionResult ActualizaEmpleado(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MEmpleado mEmpleado = new MEmpleado();
                    mEmpleado.EmpleadoId = int.Parse(formulario["empleadoid"]);
                    mEmpleado.Nombre = formulario["nombre"].Trim();
                    mEmpleado.ApellidoPaterno = formulario["apellidopaterno"].Trim();
                    mEmpleado.ApellidoMaterno = formulario["apellidomaterno"].Trim();
                    ServicioEmpleado servicioEmpleado = new ServicioEmpleado();
                    string respuesta = servicioEmpleado.ActualizarEmpleado(mEmpleado);
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
        public ActionResult ActualizaPaqueteria(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MPaqueteria mPaqueteria = new MPaqueteria();
                    mPaqueteria.PaqueteriaId = int.Parse(formulario["paqueteriaid"]);
                    mPaqueteria.Paqueteria = formulario["paqueteria"].Trim();
                    ServicioPaqueteria servicioPaqueteria = new ServicioPaqueteria();
                    string respuesta = servicioPaqueteria.ActualizarPaqueteria(mPaqueteria);
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
        public ActionResult ActualizaEmpresa(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MEmpresa mEmpresa = new MEmpresa();
                    mEmpresa.EmpresaId = int.Parse(formulario["empresaid"]);
                    mEmpresa.Empresa = formulario["empresa"];
                    ServicioEmpresa servicioEmpresa = new ServicioEmpresa();
                    string respuesta = servicioEmpresa.ActualizarEmpresa(mEmpresa);
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
        public ActionResult ActualizaDestinatario(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MDestinatario mDestinatario = new MDestinatario();
                    mDestinatario.DestinatarioId = int.Parse(formulario["destinatarioid"]);
                    mDestinatario.AreaId = int.Parse(formulario["areaid"]);
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    string respuesta = servicioDestinatario.ActualizarDestinatario(mDestinatario);
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
        public ActionResult ActualizaPerfil(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol != "")
                {
                    MUsuario mUsuario = new MUsuario();
                    mUsuario.UsuarioId = Sesion.UsuarioId;
                    mUsuario.FechaNacimiento = formulario["fechanacimiento"];
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    string respuesta = servicioUsuario.ActualizarPerfil(mUsuario);
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
        public ActionResult ActualizaTransporte(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MTransporte mTransporte = new MTransporte();
                    mTransporte.TransporteId = int.Parse(formulario["transporteid"]);
                    mTransporte.TipoTransporteId = int.Parse(formulario["tipotransporteid"]);
                    mTransporte.Placa = formulario["placa"];
                    mTransporte.Anio = formulario["anio"];
                    mTransporte.Modelo = formulario["modelo"];
                    mTransporte.Marca = formulario["marca"];
                    mTransporte.Poliza = formulario["poliza"];
                    mTransporte.Vigencia = formulario["vigencia"];
                    ServicioTransporte servicioTransporte = new ServicioTransporte();
                    string respuesta = servicioTransporte.ActualizarTransporte(mTransporte);
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
        public ActionResult NuevoTipoTransporte(FormCollection formulario, HttpPostedFileBase marcador)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    string archivo = Archivo.Imagen(marcador, "marker_");
                    if (!archivo.Contains("ERROR"))
                    {
                        MTipoTransporte mTipoTransporte = new MTipoTransporte();
                        mTipoTransporte.Tipo = formulario["tipo"];
                        mTipoTransporte.Imagen = archivo;
                        ServicioTipoTransporte servicioTipoTransporte = new ServicioTipoTransporte();
                        string respuesta = servicioTipoTransporte.NuevoTipoTransporte(mTipoTransporte);
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
                    return Json(new { respuesta = Sesion.Permiso, accion = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }
        [HttpPost]
        public ActionResult ActualizaTipoTransporte(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MTipoTransporte mTipoTransporte = new MTipoTransporte();
                    mTipoTransporte.Tipo = formulario["tipo"];
                    mTipoTransporte.TipoTransporteId = int.Parse(formulario["tipoid"]);
                    ServicioTipoTransporte servicioTipoTransporte = new ServicioTipoTransporte();
                    string respuesta = servicioTipoTransporte.ActualizarTipoTransporte(mTipoTransporte);
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
        public ActionResult AgregarDireccion(FormCollection formulario)
        {
            try
            {
                if(Sesion.Rol == "Administrador")
                {
                    MDireccionDestinatario mDireccionDestinatario = new MDireccionDestinatario();
                    mDireccionDestinatario.Direccion = formulario["agregardireccion"];
                    mDireccionDestinatario.DestinatarioId = int.Parse(formulario["destinatarioid"]);
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    string respuesta = servicioDestinatario.AgregarDireccion(mDireccionDestinatario);
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
        [HttpPost]
        public ActionResult NuevoTransporte(FormCollection formulario)
        {
            try
            {
                if (Sesion.Rol == "Administrador")
                {
                    MTransporte mTransporte = new MTransporte();
                    mTransporte.TipoTransporteId = int.Parse(formulario["tipotransporteid"]);
                    mTransporte.Placa = formulario["placa"];
                    mTransporte.Marca = formulario["marca"];
                    mTransporte.Anio = formulario["anio"];
                    mTransporte.Modelo = formulario["modelo"];
                    mTransporte.Poliza = formulario["poliza"];
                    mTransporte.Vigencia = formulario["vigencia"];
                    ServicioTransporte servicioTransporte = new ServicioTransporte();
                    string respuesta = servicioTransporte.NuevoTransporte(mTransporte);
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
        public ActionResult ActualizaDireccion(FormCollection formulario)
        {
            try
            {
                if(Sesion.Rol == "Administrador")
                {
                    MDireccionDestinatario mDireccionDestinatario = new MDireccionDestinatario();
                    mDireccionDestinatario.DireccionDestinatarioId = long.Parse(formulario["destinatarioid"]);
                    mDireccionDestinatario.Direccion = formulario["direccion"];
                    ServicioDestinatario servicioDestinatario = new ServicioDestinatario();
                    string respuesta = servicioDestinatario.ActualizaDireccion(mDireccionDestinatario);
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
        /*public ActionResult ActualizaUsuario(FormCollection formulario)
        {
            try
            {
                if(Sesion.Rol == "Administrador")
                {
                    MUsuario mUsuario = new MUsuario();
                    mUsuario.UsuarioId = int.Parse(formulario["usuarioid"]);
                    mUsuario.RolId = int.Parse(formulario["rolid"]);
                    mUsuario.AreaId = int.Parse(formulario["areaid"]);
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    string respuesta = servicioUsuario.ActualizarUsuario(mUsuario);
                    string accion = respuesta.Contains("ERROR") ? "Error" : "Done";
                    return Json(new { respuesta = respuesta, accion = accion });
                } else
                {
                    return Json(new { respuesta = "Estimado usuario usted no tiene persmisos para esta acción", accion = "Error" });
                }
            }catch(Exception ex)
            {
                return Json(new { respuesta = ex.Message, accion = "Error" });
            }
        }*/
    }
}