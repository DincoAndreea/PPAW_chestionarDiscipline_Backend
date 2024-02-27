using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_CodeFirst
{
    public interface IContextDB
    {
        DbSet<anidestudiu> anidestudiu { get; set; }
        DbSet<chestionare> chestionare { get; set; }
        DbSet<cicluldestudii> cicluldestudii { get; set; }
        DbSet<discipline> discipline { get; set; }
        DbSet<intrebari> intrebari { get; set; }
        DbSet<programedestudiu> programedestudiu { get; set; }
        DbSet<raspunsurichestionar> raspunsurichestionar { get; set; }
        DbSet<tipuriactivitati> tipuriactivitati { get; set; }
        DbSet<studenti> studenti { get; set; }
        DbSet<tabelnou> tabelnou { get; set; }
        int SaveChanges();
        Database Database { get; }
    }
}
