using LibrarieModele;
using System.Collections.Generic;

namespace NivelDataAccess.chestionareDAL
{
    public interface IchestionareAccesor
    {
        void AddChestionarComplet(chestionarcompletDTO chestionarcompletDTO);
        void AddChestionarPartial(chestionarpartialDTO chestionarpartialDTO);
        bool ChestionarExists(int id_student, int id_disciplina, int id_tip_activitate, int numar_activitate);
        List<chestionare> GetChestionareByStudentAndTipActivitateAndDisciplina(activitatineevaluateDTO activitatineevaluateDTO);
    }
}