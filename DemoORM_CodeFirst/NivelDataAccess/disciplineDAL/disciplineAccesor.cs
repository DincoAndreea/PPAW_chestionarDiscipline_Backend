using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelDataAccess.disciplineDAL
{
    public class disciplineAccesor : IdisciplineAccesor
    {
        private IContextDB _db;

        public disciplineAccesor()
        {

        }

        public disciplineAccesor(IContextDB db)
        {
            _db = db;
        }

        public List<discipline> GetDisciplineByProgramStudiu(int id)
        {
            var programstudiu = _db.programedestudiu.Find(id);

            if (programstudiu == null)
            {
                return null;
            }

            return _db.discipline.Where(x => x.program_de_studii == id).ToList();

        }
    }
}
