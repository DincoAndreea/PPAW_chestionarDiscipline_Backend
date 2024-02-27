namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.programedestudiu", "sters", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.programedestudiu", "sters");
        }
    }
}
