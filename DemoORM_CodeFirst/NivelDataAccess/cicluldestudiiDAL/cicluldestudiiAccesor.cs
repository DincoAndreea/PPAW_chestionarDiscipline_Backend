using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelDataAccess.cicluldestudiiDAL
{
    public class cicluldestudiiAccesor : IcicluldestudiiAccesor
    {
        private IContextDB _db;

        public cicluldestudiiAccesor()
        {

        }

        public cicluldestudiiAccesor(IContextDB db)
        {
            _db = db;
        }
        public List<cicluldestudii> GetCicluriDeStudii()
        {
            return _db.cicluldestudii.ToList();
        }
    }
}
