namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.anidestudiu",
                c => new
                    {
                        id_ani_de_studiu = c.Int(nullable: false, identity: true),
                        anul_de_studiu = c.String(),
                        ciclul_de_studii = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_ani_de_studiu)
                .ForeignKey("dbo.cicluldestudii", t => t.ciclul_de_studii, cascadeDelete: false)
                .Index(t => t.ciclul_de_studii);
            
            CreateTable(
                "dbo.cicluldestudii",
                c => new
                    {
                        id_ciclu_de_studii = c.Int(nullable: false, identity: true),
                        nume_ciclu_de_studii = c.String(),
                    })
                .PrimaryKey(t => t.id_ciclu_de_studii);
            
            CreateTable(
                "dbo.chestionare",
                c => new
                    {
                        id_chestionar = c.Int(nullable: false, identity: true),
                        id_student = c.Int(nullable: false),
                        id_disciplina = c.Int(nullable: false),
                        id_an_de_studiu = c.Int(nullable: false),
                        id_program_de_studiu = c.Int(nullable: false),
                        id_tip_activitate = c.Int(nullable: false),
                        numar_activitate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_chestionar)
                .ForeignKey("dbo.anidestudiu", t => t.id_an_de_studiu, cascadeDelete: false)
                .ForeignKey("dbo.discipline", t => t.id_disciplina, cascadeDelete: false)
                .ForeignKey("dbo.programedestudiu", t => t.id_program_de_studiu, cascadeDelete: false)
                .ForeignKey("dbo.studenti", t => t.id_student, cascadeDelete: false)
                .ForeignKey("dbo.tipuriactivitati", t => t.id_tip_activitate, cascadeDelete: false)
                .Index(t => t.id_student)
                .Index(t => t.id_disciplina)
                .Index(t => t.id_an_de_studiu)
                .Index(t => t.id_program_de_studiu)
                .Index(t => t.id_tip_activitate);
            
            CreateTable(
                "dbo.discipline",
                c => new
                    {
                        id_disciplina = c.Int(nullable: false, identity: true),
                        nume_disciplina = c.String(),
                        ciclul_de_studii = c.Int(nullable: false),
                        program_de_studii = c.Int(nullable: false),
                        anul_de_studiu = c.Int(nullable: false),
                        semestrul = c.Int(nullable: false),
                        nr_cursuri = c.Int(nullable: false),
                        nr_laboratoare = c.Int(nullable: false),
                        nr_seminare = c.Int(nullable: false),
                        nr_intalniri_proiect = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_disciplina)
                .ForeignKey("dbo.anidestudiu", t => t.anul_de_studiu, cascadeDelete: false)
                .ForeignKey("dbo.cicluldestudii", t => t.ciclul_de_studii, cascadeDelete: false)
                .ForeignKey("dbo.programedestudiu", t => t.program_de_studii, cascadeDelete: false)
                .Index(t => t.ciclul_de_studii)
                .Index(t => t.program_de_studii)
                .Index(t => t.anul_de_studiu);
            
            CreateTable(
                "dbo.programedestudiu",
                c => new
                    {
                        id_programe_de_studiu = c.Int(nullable: false, identity: true),
                        nume_programe_de_studiu = c.String(),
                        id_ciclul_de_studii = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_programe_de_studiu)
                .ForeignKey("dbo.cicluldestudii", t => t.id_ciclul_de_studii, cascadeDelete: false)
                .Index(t => t.id_ciclul_de_studii);
            
            CreateTable(
                "dbo.studenti",
                c => new
                    {
                        id_student = c.Int(nullable: false, identity: true),
                        nume = c.String(),
                        prenume = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id_student);
            
            CreateTable(
                "dbo.tipuriactivitati",
                c => new
                    {
                        id_tip_activitate = c.Int(nullable: false, identity: true),
                        nume_activitate = c.String(),
                    })
                .PrimaryKey(t => t.id_tip_activitate);
            
            CreateTable(
                "dbo.intrebari",
                c => new
                    {
                        id_intrebare = c.Int(nullable: false, identity: true),
                        text_intrebare = c.String(),
                    })
                .PrimaryKey(t => t.id_intrebare);
            
            CreateTable(
                "dbo.raspunsurichestionar",
                c => new
                    {
                        id_raspuns = c.Int(nullable: false, identity: true),
                        id_chestionar = c.Int(nullable: false),
                        id_intrebare = c.Int(nullable: false),
                        text_raspuns = c.String(),
                    })
                .PrimaryKey(t => t.id_raspuns)
                .ForeignKey("dbo.chestionare", t => t.id_chestionar, cascadeDelete: false)
                .ForeignKey("dbo.intrebari", t => t.id_intrebare, cascadeDelete: false)
                .Index(t => t.id_chestionar)
                .Index(t => t.id_intrebare);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.raspunsurichestionar", "id_intrebare", "dbo.intrebari");
            DropForeignKey("dbo.raspunsurichestionar", "id_chestionar", "dbo.chestionare");
            DropForeignKey("dbo.chestionare", "id_tip_activitate", "dbo.tipuriactivitati");
            DropForeignKey("dbo.chestionare", "id_student", "dbo.studenti");
            DropForeignKey("dbo.chestionare", "id_program_de_studiu", "dbo.programedestudiu");
            DropForeignKey("dbo.chestionare", "id_disciplina", "dbo.discipline");
            DropForeignKey("dbo.discipline", "program_de_studii", "dbo.programedestudiu");
            DropForeignKey("dbo.programedestudiu", "id_ciclul_de_studii", "dbo.cicluldestudii");
            DropForeignKey("dbo.discipline", "ciclul_de_studii", "dbo.cicluldestudii");
            DropForeignKey("dbo.discipline", "anul_de_studiu", "dbo.anidestudiu");
            DropForeignKey("dbo.chestionare", "id_an_de_studiu", "dbo.anidestudiu");
            DropForeignKey("dbo.anidestudiu", "ciclul_de_studii", "dbo.cicluldestudii");
            DropIndex("dbo.raspunsurichestionar", new[] { "id_intrebare" });
            DropIndex("dbo.raspunsurichestionar", new[] { "id_chestionar" });
            DropIndex("dbo.programedestudiu", new[] { "id_ciclul_de_studii" });
            DropIndex("dbo.discipline", new[] { "anul_de_studiu" });
            DropIndex("dbo.discipline", new[] { "program_de_studii" });
            DropIndex("dbo.discipline", new[] { "ciclul_de_studii" });
            DropIndex("dbo.chestionare", new[] { "id_tip_activitate" });
            DropIndex("dbo.chestionare", new[] { "id_program_de_studiu" });
            DropIndex("dbo.chestionare", new[] { "id_an_de_studiu" });
            DropIndex("dbo.chestionare", new[] { "id_disciplina" });
            DropIndex("dbo.chestionare", new[] { "id_student" });
            DropIndex("dbo.anidestudiu", new[] { "ciclul_de_studii" });
            DropTable("dbo.raspunsurichestionar");
            DropTable("dbo.intrebari");
            DropTable("dbo.tipuriactivitati");
            DropTable("dbo.studenti");
            DropTable("dbo.programedestudiu");
            DropTable("dbo.discipline");
            DropTable("dbo.chestionare");
            DropTable("dbo.cicluldestudii");
            DropTable("dbo.anidestudiu");
        }
    }
}
