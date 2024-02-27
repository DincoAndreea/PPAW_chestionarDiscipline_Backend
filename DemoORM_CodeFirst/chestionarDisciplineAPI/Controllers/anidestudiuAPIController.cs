using Autofac.Core;
using AutoMapper;
using LibrarieModele;
using Microsoft.Extensions.Logging;
using NivelServicii.anidestudiuNS;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Http.Cors;

namespace chestionarDisciplineAPI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class anidestudiuAPIController : ApiController
    {
        private IanidestudiuServicii _anidestudiuServicii;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public anidestudiuAPIController()
        {

        }

        public anidestudiuAPIController(IanidestudiuServicii anidestudiuServicii)
        {
            _anidestudiuServicii = anidestudiuServicii;
        }

        [HttpGet]
        // GET: api/anidestudiuAPI
        public IHttpActionResult GetAniDeStudiu()
        {
            var anidestudiu = _anidestudiuServicii.GetAniDeStudiu();
            if (anidestudiu == null)
            {
                return NotFound();
            }
            var config = new MapperConfiguration(c => c.CreateMap<anidestudiu, anidestudiuDTO>());
            var mapper = new Mapper(config);
            var andestudiu = mapper.Map<IEnumerable<anidestudiu>, IEnumerable<anidestudiuDTO>>(anidestudiu);
            return Ok(andestudiu);
        }

        [HttpGet]
        // GET: api/anidestudiuAPI/5
        public IHttpActionResult GetAnDeStudiu(int id)
        {
            var anidestudiu = new anidestudiu();
            anidestudiu = _anidestudiuServicii.GetAnDeStudiu((int)id); 
            if (anidestudiu == null)
            {
                return NotFound();
            }
            var config = new MapperConfiguration(c => c.CreateMap<anidestudiu, anidestudiuDTO>());
            var mapper = new Mapper(config);
            var andestudiu = mapper.Map<anidestudiu, anidestudiuDTO>(anidestudiu);
            return Ok(andestudiu);
        }

        [Route("api/anidestudiuAPI/ciclu/{id}")]
        [HttpGet]
        public IHttpActionResult GetAnDeStudiuByCiclu(int id)
        {
            var anidestudiu = _anidestudiuServicii.GetAnDeStudiuByCiclu(id);
            if (anidestudiu == null)
            {
                return NotFound();
            }
            return Ok(anidestudiu);
        }

        [HttpPost]
        // POST: api/anidestudiuAPI
        public IHttpActionResult CreateAnDeStudiu([FromBody] anidestudiu anidestudiu)
        {
            var andestudiu = _anidestudiuServicii.CreateAnDeStudiu(anidestudiu);
            if (andestudiu == null)
            {
                return BadRequest("Eroare la crearea anului de studiu.");
            }
            return Ok(andestudiu);
        }

        [HttpPut]
        // PUT: api/anidestudiuAPI/5
        public IHttpActionResult UpdateAnDeStudiu(int id, [FromBody]anidestudiu anidestudiu)
        {
            var andestudiu = _anidestudiuServicii.UpdateAnDeStudiu(anidestudiu, id);
            if (andestudiu == null)
            {
                return BadRequest("Eroare la actualizarea anului de studiu.");
            }
            return Ok(andestudiu);
        }

        [HttpDelete]
        // DELETE: api/anidestudiuAPI/5
        public IHttpActionResult Delete(int id)
        {
            var andestudiu = _anidestudiuServicii.DeleteAnDeStudiu(id);
            if (andestudiu == null)
            {
                return BadRequest("Eroare la stergerea anului de studiu.");
            }
            return Ok(andestudiu);
        }
    }
}
