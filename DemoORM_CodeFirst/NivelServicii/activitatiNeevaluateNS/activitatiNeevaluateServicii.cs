using LibrarieModele;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;
using NivelServicii.activitatiNeevaluate;
using NivelDataAccess.chestionareDAL;

namespace NivelServicii
{
    public class activitatiNeevaluateServicii : IactivitatiNeevaluateServicii
    {
        private IchestionareAccesor _chestionareAccesor;

        public activitatiNeevaluateServicii()
        {

        }

        public activitatiNeevaluateServicii(IchestionareAccesor chestionareAccesor)
        {
            _chestionareAccesor = chestionareAccesor;
        }
        public IEnumerable<int> GetActivitatiNeevaluate(activitatineevaluateDTO activitatineevaluateDTO)
        {
            var chestionare = _chestionareAccesor.GetChestionareByStudentAndTipActivitateAndDisciplina(activitatineevaluateDTO);
            var activitatiNeevaluate = new List<int>();
            if (chestionare.Count() > 0)
            {
                var _disciplina = chestionare[0].discipline;
                int numar = activitatineevaluateDTO.tipactivitate.id_tip_activitate == 1 ? _disciplina.nr_seminare 
                    : activitatineevaluateDTO.tipactivitate.id_tip_activitate == 2 ? _disciplina.nr_laboratoare 
                    : activitatineevaluateDTO.tipactivitate.id_tip_activitate == 3 ? _disciplina.nr_cursuri 
                    : activitatineevaluateDTO.tipactivitate.id_tip_activitate == 4 ? _disciplina.nr_intalniri_proiect : 0;
                if (numar == 0)
                {
                    return Enumerable.Empty<int>();
                }
                else
                {
                    activitatiNeevaluate = Enumerable.Range(1, numar).ToList();
                    for (int i = 0; i < chestionare.Count; i++)
                    {
                        activitatiNeevaluate.Remove(chestionare[i].numar_activitate);
                    }
                }
            }

            return activitatiNeevaluate;
        }
    }
}
