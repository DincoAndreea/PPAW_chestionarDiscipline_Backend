using LibrarieModele;
using NivelServicii.cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.cicluldestudiiDAL;

namespace NivelServicii.cicluldestudiiNS
{
    public class cicluldestudiiServicii : IcicluldestudiiServicii
    {
        IcicluldestudiiAccesor _cicluldestudiiAccesor;
        ICache _cache;

        public cicluldestudiiServicii(IcicluldestudiiAccesor cicluldestudiiAccesor, ICache cache)
        {
            _cicluldestudiiAccesor = cicluldestudiiAccesor;
            _cache = cache;
        }

        public List<cicluldestudii> GetCicluriDeStudii()
        {
            string key = "cicluldestudii_lista";
            List<cicluldestudii> cicluldestudii;

            if (_cache.IsSet(key))

            {
                cicluldestudii = _cache.Get<List<cicluldestudii>>(key);
            }
            else
            {
                cicluldestudii = _cicluldestudiiAccesor.GetCicluriDeStudii();
                _cache.Set(key, cicluldestudii);
            }

            return cicluldestudii;
        }
    }
}
