namespace Repository_CodeFirst.Migrations
{
    
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository_CodeFirst.ContextDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository_CodeFirst.ContextDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //anidestudiu ani = new anidestudiu();
            //ani.anul_de_studiu = "2";
            //ani.ciclul_de_studii = 1;

            //context.anidestudiu.Add(ani);

            /*cicluldestudii cicluldestudii = new cicluldestudii();
            cicluldestudii.nume_ciclu_de_studii = "Masterat";

            context.cicluldestudii.Add(cicluldestudii);

            base.Seed(context);*/
        }
    }
}
