using Sigame.Api_REST.Models;
using Sigame.Api_REST.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sigame.Api_REST.Controllers
{
    [AllowAnonymous, RoutePrefix("api/recorrido"), EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RecorridoController : ApiController
    {
        [HttpPost, Route("iniciar")]
        public IHttpActionResult Iniciar(MRecorrido mRecorrido)
        {
            try
            {
                ServicioRecorrido servicioRecorrido = new ServicioRecorrido();
                string respuesta = servicioRecorrido.IniciaRecorrido(mRecorrido);
                return Ok(respuesta);
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpPost, Route("finalizar")]
        public IHttpActionResult Finalizar(MRecorrido mRecorrido)
        {
            try
            {
                ServicioRecorrido servicioRecorrido = new ServicioRecorrido();
                string respuesta = servicioRecorrido.FinalizaRecorrido(mRecorrido);
            return Ok(respuesta);
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpGet, Route("transporte")]
        public IHttpActionResult Transporte(int mensajeroid)
        {
            MTransporte mTransporte = null;
            try
            {
                ServicioRecorrido servicioRecorrido = new ServicioRecorrido();
                mTransporte = servicioRecorrido.Transporte(mensajeroid);
                return Ok(mTransporte);
            }catch(Exception ex)
            {
                return Ok(mTransporte);
            }
        }
    }
}
