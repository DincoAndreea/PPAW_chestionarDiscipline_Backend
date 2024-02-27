using LibrarieModele;
using System.Collections.Generic;

namespace NivelDataAccess.disciplineDAL
{
    public interface IdisciplineAccesor
    {
        List<discipline> GetDisciplineByProgramStudiu(int id);
    }
}