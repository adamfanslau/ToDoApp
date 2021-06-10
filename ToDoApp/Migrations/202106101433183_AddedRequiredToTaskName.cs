namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToTaskName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyTasks", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.MyTasks", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyTasks", "Description", c => c.String());
            AlterColumn("dbo.MyTasks", "Name", c => c.String());
        }
    }
}
