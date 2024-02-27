using LibrarieModele;
using NLog;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NivelDataAccess.anidestudiuDAL
{
    public class anidestudiuAccesor : IanidestudiuAccesor
    {
        private IContextDB _db;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public anidestudiuAccesor()
        {

        }

        public anidestudiuAccesor(IContextDB db)
        {
            _db = db;
        }
        public List<anidestudiu> GetAniDeStudiu()
        {
            try
            {
                return _db.anidestudiu.Include(x => x.cicluldestudii).ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Eroarea la preluarea anilor de studiu.(Nivel DAL)");
                return null;
            }

        }

        public anidestudiu GetAnDeStudiu(int id)
        {
            var anidestudiu = new anidestudiu();
            try
            {
                anidestudiu = _db.anidestudiu.Include(x => x.cicluldestudii).FirstOrDefault(x => x.id_ani_de_studiu == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Eroarea la preluarea anului de studiu.(Nivel DAL)");
                return null;
            }

            return anidestudiu;
        }

        public List<anidestudiu> GetAnDeStudiuByCiclu(int id)
        {
            var cicludestudiu = _db.cicluldestudii.Find(id);

            if (cicludestudiu == null)
            {
                logger.Error("Eroarea la preluarea anului de studiu dupa ciclu.(Nivel DAL)");
                return null;
            }

            return _db.anidestudiu.Where(x => x.ciclul_de_studii == id).Include(x => x.cicluldestudii).ToList();
        }

        public anidestudiu CreateAnDeStudiu(anidestudiu anidestudiu)
        {
            var andestudiu = new anidestudiu();

            try
            {
                andestudiu = _db.anidestudiu.Add(anidestudiu);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Eroarea la adaugarea anului de studiu.(Nivel DAL)");
                return null;
            }

            return andestudiu;
        }

        public anidestudiu UpdateAnDeStudiu(anidestudiu anidestudiu, int id)
        {
            var andestudiu = new anidestudiu();

            andestudiu = _db.anidestudiu.Find(id);

            if (andestudiu != null)
            {
                andestudiu.anul_de_studiu = anidestudiu.anul_de_studiu;
                andestudiu.cicluldestudii = anidestudiu.cicluldestudii;
            }
            else
            {
                logger.Error("Eroarea la preluarea anului de studiu dupa ciclu.(Nivel DAL)");
            }

            _db.SaveChanges();


            return andestudiu;
        }

        public List<anidestudiu> DeleteAnDeStudiu(int id)
        {
            var andestudiu = new anidestudiu();
            var lista = new List<anidestudiu>();

            andestudiu = _db.anidestudiu.Find(id);

            if (andestudiu != null)
            {
                _db.anidestudiu.Remove(andestudiu);
            }
            else
            {
                logger.Error("Eroarea la stergerea anului de studiu.(Nivel DAL)");
            }

            lista = _db.anidestudiu.Include(x => x.cicluldestudii).ToList();

            _db.SaveChanges();


            return lista;
        }
    }
}
