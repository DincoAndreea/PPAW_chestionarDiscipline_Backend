using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelServicii.generareIntrebari
{
    public interface IgenerareIntrebariServicii
    {
        IEnumerable<intrebari> GenerareIntrebariRandom();
        void Shuffle(List<intrebari> intrebari);
    }
}
