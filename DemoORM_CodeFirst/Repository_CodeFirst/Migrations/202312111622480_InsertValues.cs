namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValues : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.cicluldestudii(nume_ciclu_de_studii) VALUES ('Licenta');");
            //Sql("INSERT INTO anidestudiu(anul_de_studiu, ciclul_de_studii) VALUES ('1',1);");
        }

        public override void Down()
        {

        }
    }
}
