using LibrarieModele;
using System.Collections.Generic;

namespace NivelServicii.programestudiuNS
{
    public interface IprogramestudiuServicii
    {
        programedestudiu CreateProgramDeStudiu(programedestudiu programedestudiu);
        List<programedestudiu> DeleteProgramDeStudiu(int id);
        programedestudiu GetProgramDeStudiu(int id);
        List<programedestudiu> GetProgrameDeStudiu();
        List<programedestudiu> GetProgrameDeStudiuByCicluDeStudii(int id);
        programedestudiu UpdateProgramDeStudiu(programedestudiu programedestudiu, int id);
    }
}