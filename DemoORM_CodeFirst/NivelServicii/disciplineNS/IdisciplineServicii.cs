using LibrarieModele;
using System.Collections.Generic;

namespace NivelServicii.disciplineNS
{
    public interface IdisciplineServicii
    {
        List<discipline> GetDisciplineByProgramStudiu(int id);
    }
}