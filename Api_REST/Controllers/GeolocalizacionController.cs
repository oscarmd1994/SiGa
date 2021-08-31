using Sigame.Api_REST.Models;
using Sigame.Api_REST.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sigame.Api_REST.Controllers
{
    [AllowAnonymous, RoutePrefix("api/geolocalizacion"), EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GeolocalizacionController : ApiController
    {
        [HttpPost, Route("ubicacion")]
        public IHttpActionResult Ubicacion(MRecorrido mRecorrido)
        {
            ServicioRecorrido servicioRecorrido = null;
            try
            {
                servicioRecorrido = new ServicioRecorrido();
                string respuesta = servicioRecorrido.NuevaUbicacion(mRecorrido);
                return Ok(respuesta);
            } catch(Exception ex)
            {
                return Ok(ex.Message);
            }
   
        }
    }
}
