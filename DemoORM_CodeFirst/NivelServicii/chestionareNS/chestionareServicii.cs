using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelDataAccess.chestionareDAL;

namespace NivelServicii.chestionareNS
{
    public class chestionareServicii : IchestionareServicii
    {
        IchestionareAccesor _chestionareAccesor;

        public chestionareServicii(IchestionareAccesor chestionareAccesor)
        {
            _chestionareAccesor = chestionareAccesor;
        }

        public void AddChestionarComplet(chestionarcompletDTO chestionarcompletDTO)
        {
            _chestionareAccesor.AddChestionarComplet(chestionarcompletDTO);
        }

        public void AddChestionarPartial(chestionarpartialDTO chestionarpartialDTO)
        {
            _chestionareAccesor.AddChestionarPartial(chestionarpartialDTO);
        }

        public bool ChestionarExists(int id_student, int id_disciplina, int id_tip_activitate, int numar_activitate)
        {
            return _chestionareAccesor.ChestionarExists(id_student, id_disciplina, id_tip_activitate, numar_activitate);
        }
    }
}
