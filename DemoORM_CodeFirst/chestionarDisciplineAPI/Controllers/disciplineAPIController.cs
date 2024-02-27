using LibrarieModele;
using NivelServicii.disciplineNS;
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
    public class disciplineAPIController : ApiController
    {
        IdisciplineServicii _disciplineServicii;

        public disciplineAPIController()
        {

        }

        public disciplineAPIController(IdisciplineServicii disciplineServicii)
        {
            _disciplineServicii = disciplineServicii;
        }

        [HttpGet]
        public IHttpActionResult GetDisciplineByProgramStudiu(int id)
        {
            var discipline = new List<discipline>();
            try
            {
                discipline = _disciplineServicii.GetDisciplineByProgramStudiu(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(discipline);
        }
    }
}
