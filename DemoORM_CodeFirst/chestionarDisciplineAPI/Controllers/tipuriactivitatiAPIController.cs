using LibrarieModele;
using NivelServicii.tipuriactivitatiNS;
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
    public class tipuriactivitatiAPIController : ApiController
    {
        ItipuriactivitatiServicii _tipuriactivitatiServicii;

        public tipuriactivitatiAPIController()
        {
        }

        public tipuriactivitatiAPIController(ItipuriactivitatiServicii tipuriactivitatiServicii)
        {
            _tipuriactivitatiServicii = tipuriactivitatiServicii;
        }

        [HttpGet]
        public IHttpActionResult GetTipuriActivitati()
        {
            var tipuri = new List<tipuriactivitati>();
            try
            {
                tipuri = _tipuriactivitatiServicii.GetTipuriActivitati();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(tipuri);
        }
    }
}
