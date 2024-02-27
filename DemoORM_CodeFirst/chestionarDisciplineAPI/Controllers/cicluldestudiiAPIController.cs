using LibrarieModele;
using NivelServicii.cicluldestudiiNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace chestionarDisciplineAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class cicluldestudiiAPIController : ApiController
    {
        IcicluldestudiiServicii _cicluldestudiiServicii;

        public cicluldestudiiAPIController()
        {

        }

        public cicluldestudiiAPIController(IcicluldestudiiServicii cicluldestudiiServicii)
        {
            _cicluldestudiiServicii = cicluldestudiiServicii;
        }

        [HttpGet]
        public IHttpActionResult GetCicluriDeStudii()
        {
            var cicluridestudii = new List<cicluldestudii>();
            try
            {
                cicluridestudii = _cicluldestudiiServicii.GetCicluriDeStudii();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(cicluridestudii);
        }
    }
}
