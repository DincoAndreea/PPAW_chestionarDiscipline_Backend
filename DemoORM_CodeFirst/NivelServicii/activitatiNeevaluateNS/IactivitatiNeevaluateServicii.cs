using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelServicii.activitatiNeevaluate
{
    public interface IactivitatiNeevaluateServicii
    {
        IEnumerable<int> GetActivitatiNeevaluate(activitatineevaluateDTO activitatineevaluateDTO);
    }
}
