namespace MvcGroup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconnectionstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Task", c => c.String(maxLength: 20));
            AlterColumn("dbo.Items", "Description", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Description", c => c.String());
            AlterColumn("dbo.Items", "Task", c => c.String());
        }
    }
}
