namespace angularRef.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFamilyId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kids", "FamilyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Kids", "Name", c => c.String());
            AlterColumn("dbo.Kids", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kids", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Kids", "Name", c => c.String());
            DropColumn("dbo.Kids", "FamilyId");
        }
    }
}
