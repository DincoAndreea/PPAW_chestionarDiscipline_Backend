using LibrarieModele;
using NivelServicii.activitatiNeevaluate;
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
    public class activitatiNeevaluateAPIController : ApiController
    {
        IactivitatiNeevaluateServicii _activitatiNeevaluateServicii;

        public activitatiNeevaluateAPIController()
        {
        }

        public activitatiNeevaluateAPIController(IactivitatiNeevaluateServicii activitatiNeevaluateServicii)
        {
            _activitatiNeevaluateServicii = activitatiNeevaluateServicii;
        }

        [Route("api/activitatineevaluateAPI")]
        [HttpPost]
        public IHttpActionResult GetActivitatiNeevaluate(activitatineevaluateDTO activitatineevaluateDTO)
        {
            var activitatineevaluate = _activitatiNeevaluateServicii.GetActivitatiNeevaluate(activitatineevaluateDTO);
            if (activitatineevaluate == null) 
            {
                return BadRequest("Eroare la preluarea activitatilor neevaluate.");
            }
            return Ok(activitatineevaluate);
        }
    }
}
