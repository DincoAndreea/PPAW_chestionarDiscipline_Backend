namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.intrebari", "text_intrebare", c => c.String());
            DropColumn("dbo.intrebari", "camp_nou1");
            DropColumn("dbo.intrebari", "camp_nou2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.intrebari", "camp_nou2", c => c.String());
            AddColumn("dbo.intrebari", "camp_nou1", c => c.String());
            AlterColumn("dbo.intrebari", "text_intrebare", c => c.Double(nullable: false));
        }
    }
}
