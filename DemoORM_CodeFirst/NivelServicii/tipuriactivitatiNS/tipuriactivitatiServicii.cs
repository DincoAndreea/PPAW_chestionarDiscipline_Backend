using LibrarieModele;
using NivelServicii.cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.tipuriactivitatiDAL;

namespace NivelServicii.tipuriactivitatiNS
{
    public class tipuriactivitatiServicii : ItipuriactivitatiServicii
    {
        ItipuriactivitatiAccesor _tipuriactivitatiAccesor;
        ICache _cache;

        public tipuriactivitatiServicii(ItipuriactivitatiAccesor tipuriactivitatiAccesor, ICache cache)
        {
            _tipuriactivitatiAccesor = tipuriactivitatiAccesor;
            _cache = cache;
        }

        public List<tipuriactivitati> GetTipuriActivitati()
        {
            string key = "tipactivitate_lista";
            List<tipuriactivitati> tipuriactivitati;

            if (_cache.IsSet(key))

            {
                tipuriactivitati = _cache.Get<List<tipuriactivitati>>(key);
            }
            else
            {
                tipuriactivitati = _tipuriactivitatiAccesor.GetTipuriActivitati();
                _cache.Set(key, tipuriactivitati);
            }

            return tipuriactivitati;
        }
    }
}
