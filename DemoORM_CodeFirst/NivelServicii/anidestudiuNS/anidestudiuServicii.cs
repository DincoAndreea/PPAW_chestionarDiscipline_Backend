using LibrarieModele;
using NivelServicii.cache;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.anidestudiuDAL;

namespace NivelServicii.anidestudiuNS
{
    public class anidestudiuServicii : IanidestudiuServicii
    {
        IanidestudiuAccesor _anidestudiuAccesor;
        ICache _cache;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public anidestudiuServicii(IanidestudiuAccesor anidestudiuAccesor, ICache cache)
        {
            _anidestudiuAccesor = anidestudiuAccesor;
            _cache = cache;
        }

        public List<anidestudiu> GetAniDeStudiu()
        {
            string key = "anidestudiu_lista";
            List<anidestudiu> anidestudiu;

            if (_cache.IsSet(key))
            {
                try
                {
                    anidestudiu = _cache.Get<List<anidestudiu>>(key);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Eroare la preluarea anilor de studiu din cache.(Nivel Servicii)");
                    return null;
                }
            }
            else
            {
                try
                {
                    anidestudiu = _anidestudiuAccesor.GetAniDeStudiu();
                    _cache.Set(key, anidestudiu);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Eroare la preluarea anilor de studiu si adaugarea in cache.(Nivel Servicii)");
                    return null;
                }
                
            }

            return anidestudiu;
        }

        public anidestudiu GetAnDeStudiu(int id)
        {
            string key = "anidestudiu_" + id;
            anidestudiu anidestudiu;

            if (_cache.IsSet(key))
            {
                try
                {
                    anidestudiu = _cache.Get<anidestudiu>(key);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Eroare la preluarea anului de studiu si preluarea din cache.(Nivel Servicii)");
                    return null;
                }
            }
            else
            {
                try
                {
                    anidestudiu = _anidestudiuAccesor.GetAnDeStudiu(id);
                    _cache.Set(key, anidestudiu);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Eroare la preluarea anului de studiu si adaugarea in cache.(Nivel Servicii)");
                    return null;
                }
                
            }

            return anidestudiu;
        }

        public List<anidestudiu> GetAnDeStudiuByCiclu(int id)
        {
            string key = "anidestudiu_lista_ciclu_" + id;
            List<anidestudiu> anidestudiu;

            if (_cache.IsSet(key))
            {
                try
                {
                    anidestudiu = _cache.Get<List<anidestudiu>>(key);
                }                
                catch (Exception ex)
                {
                    logger.Error(ex, "Eroare la preluarea anului de studiu dupa ciclu si preluarea din cache.(Nivel Servicii)");
                    return null;
                }
            }
            else
            {
                try
                {
                    anidestudiu = _anidestudiuAccesor.GetAnDeStudiuByCiclu(id);
                    _cache.Set(key, anidestudiu);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Eroare la preluarea anului de studiu dupa ciclu si adaugarea in cache.(Nivel Servicii)");
                    return null;
                }
                
            }

            return anidestudiu;
        }

        public anidestudiu CreateAnDeStudiu(anidestudiu anidestudiu)
        {
            var _anidestudiu = _anidestudiuAccesor.CreateAnDeStudiu(anidestudiu);

            if (_anidestudiu != null)
            {
                _cache.RemoveByPattern("anidestudiu_lista");
            }
            else
            {
                logger.Error("Eroare la adaugarea anului de studiu.(Nivel Servicii)");
                return null;
            }

            return _anidestudiu;
        }

        public anidestudiu UpdateAnDeStudiu(anidestudiu anidestudiu, int id)
        {
            var _anidestudiu = _anidestudiuAccesor.UpdateAnDeStudiu(anidestudiu, id);
            if (_anidestudiu != null)
            {
                string individual_key = "anidestudiu_" + id;
                string list_key = "anidestudiu_lista";
                _cache.Remove(individual_key);
                _cache.RemoveByPattern(list_key);
            }
            else
            {
                logger.Error("Eroare la actualizarea anului de studiu.(Nivel Servicii)");
                return null;
            }

            return _anidestudiu;
        }

        public List<anidestudiu> DeleteAnDeStudiu(int id)
        {
            var anidestudiu = _anidestudiuAccesor.DeleteAnDeStudiu(id);

            if (anidestudiu != null)
            {
                string individual_key = "anidestudiu_" + id;
                string list_key = "anidestudiu_lista";
                _cache.Remove(individual_key);
                _cache.RemoveByPattern(list_key);
            }
            else
            {
                logger.Error("Eroare la stergerea anului de studiu.(Nivel Servicii)");
                return null;
            }

            return anidestudiu;
        }
    }
}
