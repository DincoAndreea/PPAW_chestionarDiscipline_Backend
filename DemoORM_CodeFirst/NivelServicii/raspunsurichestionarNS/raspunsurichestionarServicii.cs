using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.raspunsurichestionarDAL;

namespace NivelServicii.raspunsurichestionarNS
{
    public class raspunsurichestionarServicii : IraspunsurichestionarServicii
    {
        IraspunsurichestionarAccesor _raspunsurichestionarAccesor;

        public raspunsurichestionarServicii(IraspunsurichestionarAccesor raspunsurichestionarAccesor)
        {
            _raspunsurichestionarAccesor = raspunsurichestionarAccesor;
        }

        public RaportComplet GetRaportComplet(raspunsurichestionarDTO raspunsurichestionarDTO)
        {
            return _raspunsurichestionarAccesor.GetRaportComplet(raspunsurichestionarDTO);
        }
    }
}
