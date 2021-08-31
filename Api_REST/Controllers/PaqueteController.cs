using Sigame.Api_REST.Models;
using Sigame.Api_REST.Services;
using Sigame.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sigame.Api_REST.Controllers
{
    [AllowAnonymous, RoutePrefix("api/paquete"), EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaqueteController : ApiController
    {
        [HttpGet, Route("asignados")] // mid -> MensajeroId
        public IHttpActionResult Asignados(int mid)
        {
            List<MPaqueteAsignado> lista = null;
            try
            {
                ServicioPaquete servicioPaquete = new ServicioPaquete();
                lista = servicioPaquete.ListaPaquetesAsignadosEnEspera(mid);
                return Ok(lista);
            }
            catch (Exception)
            {
                return Ok(lista);
            }
        }
        [HttpGet, Route("enruta")]
        public IHttpActionResult EnRuta(int mid)
        {
            try
            {
                ServicioPaquete servicioPaquete = new ServicioPaquete();
                MPaqueteRuta mPaqueteRuta = servicioPaquete.PaqueteEnRuta(mid);
                return Ok(mPaqueteRuta);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpGet, Route("historial")]
        public IHttpActionResult Historial(int mid)
        {
            List<MPaqueteHistorial> lista = null;
            try
            {
                ServicioPaquete servicioPaquete = new ServicioPaquete();
                lista = servicioPaquete.ListaPaquetesHistorial(mid);
                return Ok(lista);
            }
            catch (Exception)
            {
                return Ok(lista);
            }
        }
        /*[HttpPost, Route("upload")]
        public IHttpActionResult Upload()
        {
            try
            {
                var request = HttpContext.Current.Request;
                if (request.Files.Count > 0)
                {
                    var postedFile = request.Files.Get("file");
                    HttpPostedFileBase foto = new HttpPostedFileWrapper(postedFile);
                    string archivo = Archivo.Imagen(foto, "voucher_");
                    if (!archivo.Contains("ERROR"))
                    {
                        return Ok("Upload successful");
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
        }*/
        [HttpPost, Route("entregar")]
        public IHttpActionResult Entregar()
        {
            try
            {
                var request = HttpContext.Current.Request;
                if (request.Files.Count > 0)
                {
                    var postedFile = request.Files.Get("file");
                    HttpPostedFileBase foto = new HttpPostedFileWrapper(postedFile);
                    string archivo = Archivo.Imagen(foto, "voucher_");
                    if (!archivo.Contains("ERROR"))
                    {
                        MPaquete mPaquete = new MPaquete();
                        mPaquete.Comentario = request.Params["comentario"];
                        mPaquete.Fecha = request.Params["fecha"];
                        mPaquete.Hora = request.Params["hora"];
                        mPaquete.Latitud = request.Params["latitud"];
                        mPaquete.Longitud = request.Params["longitud"];
                        mPaquete.AsignacionId = long.Parse(request.Params["asignacionId"]);
                        mPaquete.MensajeroId = int.Parse(request.Params["mensajeroId"]);
                        mPaquete.TransporteId = int.Parse(request.Params["transporteId"]);
                        mPaquete.PaqueteId = long.Parse(request.Params["paqueteId"]);
                        mPaquete.Acuse = archivo;
                        ServicioPaquete servicioPaquete = new ServicioPaquete();
                        string respuesta = servicioPaquete.EntregarPaquete(mPaquete);
                        return Ok(respuesta);
                    }
                    else
                    {
                        return Ok(archivo);
                    }
                    //var title = request.Params["name"];
                    //string root = HttpContext.Current.Server.MapPath("/Uploads/Vouchers");
                    //root = root + "/" + postedFile.FileName;
                    //postedFile.SaveAs(root);
                    //Save post to DB
                    //return Ok("Success");

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
        /*[HttpPost, Route("entregar")]
        public IHttpActionResult Entregar(MPaquete mPaquete)
        {
            try
            {
                string archivo = Archivo.Upload(mPaquete.Acuse, "voucher_");
                if (!archivo.Contains("ERROR"))
                {
                    mPaquete.Acuse = archivo;
                    ServicioPaquete servicioPaquete = new ServicioPaquete();
                    string respuesta = servicioPaquete.EntregarPaquete(mPaquete);
                    return Ok(respuesta);
                } else
                {
                    return Ok(archivo);
                }
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }*/
        [HttpPost]
        public IHttpActionResult Cancelar(MPaquete mPaquete)
        {
            try
            {
                ServicioPaquete servicioPaquete = new ServicioPaquete();
                string respuesta = servicioPaquete.CancelarPaquete(mPaquete);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
