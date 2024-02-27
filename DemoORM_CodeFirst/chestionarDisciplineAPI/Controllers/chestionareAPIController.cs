using LibrarieModele;
using NivelServicii.chestionareNS;
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
    public class chestionareAPIController : ApiController
    {
        private IchestionareServicii _chestionareServicii;

        public chestionareAPIController()
        {

        }

        public chestionareAPIController(IchestionareServicii chestionareServicii)
        {
            _chestionareServicii = chestionareServicii;
        }

        [Route("api/chestionarpartial")]
        [HttpPost]
        public void AddChestionarPartial(chestionarpartialDTO chestionarpartialDTO)
        {
            _chestionareServicii.AddChestionarPartial(chestionarpartialDTO);
        }

        [Route("api/chestionarcomplet")]
        [HttpPost]
        public void AddChestionarComplet(chestionarcompletDTO chestionarcompletDTO)
        {
            _chestionareServicii.AddChestionarComplet(chestionarcompletDTO);
        }
    }
}
