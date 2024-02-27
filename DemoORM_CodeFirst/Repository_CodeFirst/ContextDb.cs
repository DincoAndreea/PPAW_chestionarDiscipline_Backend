using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_CodeFirst
{
    public class ContextDb : DbContext, IContextDB
    {
        public ContextDb() : base("name=chestionarDisciplineCS")
        {
            
        }

        public virtual DbSet<anidestudiu> anidestudiu { get; set; }
        public virtual DbSet<chestionare> chestionare { get; set; }
        public virtual DbSet<cicluldestudii> cicluldestudii { get; set; }
        public virtual DbSet<discipline> discipline { get; set; }
        public virtual DbSet<intrebari> intrebari { get; set; }
        public virtual DbSet<programedestudiu> programedestudiu { get; set; }
        public virtual DbSet<raspunsurichestionar> raspunsurichestionar { get; set; }
        public virtual DbSet<tipuriactivitati> tipuriactivitati { get; set; }
        public virtual DbSet<studenti> studenti { get; set; }
        public virtual DbSet<tabelnou> tabelnou { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}
