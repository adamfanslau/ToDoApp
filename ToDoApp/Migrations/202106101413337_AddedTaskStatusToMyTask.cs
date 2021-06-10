namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskStatusToMyTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MyTasks", "TaskStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.MyTasks", "TaskStatusId");
            AddForeignKey("dbo.MyTasks", "TaskStatusId", "dbo.TaskStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyTasks", "TaskStatusId", "dbo.TaskStatus");
            DropIndex("dbo.MyTasks", new[] { "TaskStatusId" });
            DropColumn("dbo.MyTasks", "TaskStatusId");
            DropTable("dbo.TaskStatus");
        }
    }
}
