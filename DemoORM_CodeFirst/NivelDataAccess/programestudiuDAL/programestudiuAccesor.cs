using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NivelDataAccess.programestudiuDAL
{
    public class programestudiuAccesor : IprogramestudiuAccesor
    {
        private IContextDB _db;

        public programestudiuAccesor()
        {

        }

        public programestudiuAccesor(IContextDB db)
        {
            _db = db;
        }
        public List<programedestudiu> GetProgrameDeStudiu()
        {

            return _db.programedestudiu.Include(x => x.cicluldestudii).Where(x => x.sters == false).ToList();

        }

        public programedestudiu GetProgramDeStudiu(int id)
        {

            return _db.programedestudiu.Include(x => x.cicluldestudii).Where(x => x.sters == false).FirstOrDefault(x => x.id_programe_de_studiu == id);

        }
        public List<programedestudiu> GetProgrameDeStudiuByCicluDeStudii(int id)
        {

            var cicludestudiu = _db.cicluldestudii.Find(id);

            if (cicludestudiu == null)
            {
                return null;
            }

            return _db.programedestudiu.Where(x => x.id_ciclul_de_studii == id).ToList();

        }

        public programedestudiu CreateProgramDeStudiu(programedestudiu programedestudiu)
        {
            var programdestudiu = new programedestudiu();

            programdestudiu = _db.programedestudiu.Add(programedestudiu);

            _db.SaveChanges();


            return programdestudiu;
        }

        public programedestudiu UpdateProgramDeStudiu(programedestudiu programedestudiu, int id)
        {
            var programdestudiu = new programedestudiu();

            programdestudiu = _db.programedestudiu.Find(id);

            if (programdestudiu != null)
            {
                programdestudiu.nume_programe_de_studiu = programedestudiu.nume_programe_de_studiu;
                programdestudiu.cicluldestudii = programedestudiu.cicluldestudii;
            }

            _db.SaveChanges();


            return programdestudiu;
        }

        public List<programedestudiu> DeleteProgramDeStudiu(int id)
        {
            var programdestudiu = new programedestudiu();
            var lista = new List<programedestudiu>();

            programdestudiu = _db.programedestudiu.Find(id);

            if (programdestudiu != null)
            {
                _db.programedestudiu.Remove(programdestudiu);
            }

            lista = _db.programedestudiu.Include(x => x.cicluldestudii).ToList();

            _db.SaveChanges();


            return lista;
        }
    }
}
