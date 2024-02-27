using LibrarieModele;
using NivelServicii.cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.disciplineDAL;

namespace NivelServicii.disciplineNS
{
    public class disciplineServicii : IdisciplineServicii
    {
        IdisciplineAccesor _disciplineAccesor;
        ICache _cache;

        public disciplineServicii(IdisciplineAccesor disciplineAccesor, ICache cache)
        {
            _disciplineAccesor = disciplineAccesor;
            _cache = cache;
        }

        public List<discipline> GetDisciplineByProgramStudiu(int id)
        {
            string key = "discipline_lista_program_studiu";
            List<discipline> discipline;

            if (_cache.IsSet(key))

            {
                discipline = _cache.Get<List<discipline>>(key);
            }
            else
            {
                discipline = _disciplineAccesor.GetDisciplineByProgramStudiu(id);
                _cache.Set(key, discipline);
            }

            return discipline;
        }
    }
}
