using LibrarieModele;
using NivelServicii.intrebariNS;
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
    public class intrebariAPIController : ApiController
    {
        IintrebariServicii _intrebariServicii;

        public intrebariAPIController()
        {

        }

        public intrebariAPIController(IintrebariServicii intrebariServicii)
        {
            _intrebariServicii = intrebariServicii;
        }

        [HttpGet]
        public IHttpActionResult GetIntrebari()
        {
            var intrebari = new List<intrebari>();
            try
            {
                intrebari = _intrebariServicii.GetIntrebari();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
            return Ok(intrebari);
        }
    }
}
