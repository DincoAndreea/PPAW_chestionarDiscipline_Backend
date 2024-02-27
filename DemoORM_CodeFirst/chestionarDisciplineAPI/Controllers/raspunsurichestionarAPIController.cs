using LibrarieModele;
using NivelServicii.raspunsurichestionarNS;
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
    public class raspunsurichestionarAPIController : ApiController
    {
        IraspunsurichestionarServicii _raspunsurichestionarServicii;

        public raspunsurichestionarAPIController()
        {

        }

        public raspunsurichestionarAPIController(IraspunsurichestionarServicii raspunsurichestionarServicii)
        {
            _raspunsurichestionarServicii = raspunsurichestionarServicii;
        }

        [Route("api/raspunsurichestionar")]
        [HttpPost]
        public IHttpActionResult GetRaportComplet(raspunsurichestionarDTO raspunsurichestionarDTO)
        {
            var raport = new RaportComplet();
            try
            {
                raport = _raspunsurichestionarServicii.GetRaportComplet(raspunsurichestionarDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Eroare la preluarea raportului.");
            }
            return Ok(raport);
        }
    }
}
