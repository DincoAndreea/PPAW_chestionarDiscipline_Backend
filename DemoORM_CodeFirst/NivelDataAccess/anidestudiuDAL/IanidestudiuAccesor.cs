using LibrarieModele;
using System.Collections.Generic;

namespace NivelDataAccess.anidestudiuDAL
{
    public interface IanidestudiuAccesor
    {
        anidestudiu CreateAnDeStudiu(anidestudiu anidestudiu);
        List<anidestudiu> DeleteAnDeStudiu(int id);
        anidestudiu GetAnDeStudiu(int id);
        List<anidestudiu> GetAnDeStudiuByCiclu(int id);
        List<anidestudiu> GetAniDeStudiu();
        anidestudiu UpdateAnDeStudiu(anidestudiu anidestudiu, int id);
    }
}