using LibrarieModele;
using NivelServicii.programestudiuNS;
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
    public class programestudiuAPIController : ApiController
    {
        IprogramestudiuServicii _programestudiuServicii;

        public programestudiuAPIController()
        {

        }

        public programestudiuAPIController(IprogramestudiuServicii programestudiuServicii)
        {
            _programestudiuServicii = programestudiuServicii;
        }

        [HttpGet]
        public IHttpActionResult GetProgrameDeStudiuByCicluDeStudii(int id)
        {
            var programe = new List<programedestudiu>();
            try
            {
                programe = _programestudiuServicii.GetProgrameDeStudiuByCicluDeStudii(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(programe);
        }
    }
}
