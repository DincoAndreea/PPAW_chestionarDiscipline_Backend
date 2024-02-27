using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelDataAccess.intrebariDAL
{
    public class intrebariAccesor : IintrebariAccesor
    {
        private IContextDB _db;

        public intrebariAccesor(IContextDB db)
        {
            _db = db;
        }

        public List<intrebari> GetIntrebari()
        {
            return _db.intrebari.ToList();
        }
    }
}
