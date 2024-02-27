using LibrarieModele;
using NivelServicii.cache;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.programestudiuDAL;

namespace NivelServicii.programestudiuNS
{
    public class programestudiuServicii : IprogramestudiuServicii
    {
        IprogramestudiuAccesor _programestudiuAccesor;
        ICache _cache;

        public programestudiuServicii(IprogramestudiuAccesor programestudiuAccesor, ICache cache)
        {
            _programestudiuAccesor = programestudiuAccesor;
            _cache = cache;
        }

        public programedestudiu GetProgramDeStudiu(int id)
        {
            string key = "programedestudiu_" + id;
            programedestudiu programdestudiu;

            if (_cache.IsSet(key))

            {
                programdestudiu = _cache.Get<programedestudiu>(key);
            }
            else
            {
                programdestudiu = _programestudiuAccesor.GetProgramDeStudiu(id);
                _cache.Set(key, programdestudiu);
            }

            return programdestudiu;
        }

        public List<programedestudiu> GetProgrameDeStudiu()
        {
            string key = "programedestudiu_lista";
            List<programedestudiu> programedestudiu;

            if (_cache.IsSet(key))

            {
                programedestudiu = _cache.Get<List<programedestudiu>>(key);
            }
            else
            {
                programedestudiu = _programestudiuAccesor.GetProgrameDeStudiu();
                _cache.Set(key, programedestudiu);
            }

            return programedestudiu;
        }

        public List<programedestudiu> GetProgrameDeStudiuByCicluDeStudii(int id)
        {
            string key = "programedestudiu_lista_ciclu" + id;
            List<programedestudiu> programedestudiu;

            if (_cache.IsSet(key))

            {
                programedestudiu = _cache.Get<List<programedestudiu>>(key);
            }
            else
            {
                programedestudiu = _programestudiuAccesor.GetProgrameDeStudiuByCicluDeStudii(id);
                _cache.Set(key, programedestudiu);
            }

            return programedestudiu;
        }

        public programedestudiu CreateProgramDeStudiu(programedestudiu programedestudiu)
        {
            var programdestudiu = _programestudiuAccesor.CreateProgramDeStudiu(programedestudiu);

            if (programdestudiu != null)
            {
                _cache.RemoveByPattern("programedestudiu_lista");
            }

            return programdestudiu;
        }

        public programedestudiu UpdateProgramDeStudiu(programedestudiu programedestudiu, int id)
        {
            var programdestudiu = _programestudiuAccesor.UpdateProgramDeStudiu(programedestudiu, id);
            if (programdestudiu != null)
            {
                string individual_key = "programedestudiu_" + id;
                string list_key = "programedestudiu_lista";
                _cache.Remove(individual_key);
                _cache.RemoveByPattern(list_key);
            }

            return programdestudiu;
        }

        public List<programedestudiu> DeleteProgramDeStudiu(int id)
        {
            var programedestudiu = _programestudiuAccesor.DeleteProgramDeStudiu(id);

            if (programedestudiu != null)
            {
                string individual_key = "programedestudiu_" + id;
                string list_key = "programedestudiu_lista";
                _cache.Remove(individual_key);
                _cache.RemoveByPattern(list_key);
            }

            return programedestudiu;
        }
    }
}
