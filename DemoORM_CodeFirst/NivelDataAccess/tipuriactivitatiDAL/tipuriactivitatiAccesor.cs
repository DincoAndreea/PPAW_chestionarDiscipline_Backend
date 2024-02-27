using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelDataAccess.tipuriactivitatiDAL
{
    public class tipuriactivitatiAccesor : ItipuriactivitatiAccesor
    {
        private IContextDB _db;

        public tipuriactivitatiAccesor()
        {

        }

        public tipuriactivitatiAccesor(IContextDB db)
        {
            _db = db;
        }

        public List<tipuriactivitati> GetTipuriActivitati()
        {
            return _db.tipuriactivitati.ToList();
        }
    }
}
