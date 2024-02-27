using LibrarieModele;
using NivelServicii.generareIntrebari;
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
    public class generareintrebariAPIController : ApiController
    {
        IgenerareIntrebariServicii _generareIntrebariServicii;

        public generareintrebariAPIController()
        {

        }

        public generareintrebariAPIController(IgenerareIntrebariServicii generareIntrebariServicii)
        {
            _generareIntrebariServicii = generareIntrebariServicii;
        }

        [HttpGet]
        public IHttpActionResult GenerareIntrebariRandom()
        {
            var intrebari = new List<intrebari>();
            try
            {
                intrebari = (List<intrebari>)_generareIntrebariServicii.GenerareIntrebariRandom();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(intrebari);
        }
    }
}
