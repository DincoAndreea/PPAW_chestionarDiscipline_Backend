using LibrarieModele;

namespace NivelServicii.chestionareNS
{
    public interface IchestionareServicii
    {
        void AddChestionarComplet(chestionarcompletDTO chestionarcompletDTO);
        void AddChestionarPartial(chestionarpartialDTO chestionarpartialDTO);
        bool ChestionarExists(int id_student, int id_disciplina, int id_tip_activitate, int numar_activitate);
    }
}