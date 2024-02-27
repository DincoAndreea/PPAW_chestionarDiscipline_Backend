using LibrarieModele;
using NivelServicii.generareIntrebari;
using NivelServicii.intrebariNS;
using Repository_CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelServicii
{
    public class generareIntrebariServicii : IgenerareIntrebariServicii
    {
        private IintrebariServicii _intrebariServicii;

        public generareIntrebariServicii()
        {

        }
        public generareIntrebariServicii(IintrebariServicii intrebariServicii)
        {
            _intrebariServicii = intrebariServicii;
        }

        public IEnumerable<intrebari> GenerareIntrebariRandom()
        {
           var intrebari = _intrebariServicii.GetIntrebari();                
           Shuffle(intrebari);
           return intrebari;
        }

        public void Shuffle(List<intrebari> intrebari)
        {
            Random random = new Random();
            for (int i = intrebari.Count - 1; i > 0; --i)
            {
                int k = random.Next(i + 1);
                intrebari aux = intrebari[i];
                intrebari[i] = intrebari[k];
                intrebari[k] = aux;
            }
        }
    }
}
