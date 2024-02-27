namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tablenou",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.intrebari", "camp_nou1", c => c.String());
            AddColumn("dbo.intrebari", "camp_nou2", c => c.String());
            AlterColumn("dbo.intrebari", "text_intrebare", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.intrebari", "text_intrebare", c => c.String());
            DropColumn("dbo.intrebari", "camp_nou2");
            DropColumn("dbo.intrebari", "camp_nou1");
            DropTable("dbo.tablenou");
        }
    }
}
