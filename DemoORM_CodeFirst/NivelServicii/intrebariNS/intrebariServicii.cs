using LibrarieModele;
using NivelServicii.cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.intrebariDAL;

namespace NivelServicii.intrebariNS
{
    public class intrebariServicii : IintrebariServicii
    {
        IintrebariAccesor _intrebariAccesor;
        ICache _cache;

        public intrebariServicii(IintrebariAccesor intrebariAccesor, ICache cache)
        {
            _intrebariAccesor = intrebariAccesor;
            _cache = cache;
        }

        public List<intrebari> GetIntrebari()
        {
            string key = "intrebari_lista";
            List<intrebari> intrebari;

            if (_cache.IsSet(key))

            {
                intrebari = _cache.Get<List<intrebari>>(key);
            }
            else
            {
                intrebari = _intrebariAccesor.GetIntrebari();
                _cache.Set(key, intrebari);
            }

            return intrebari;
        }
    }
}
