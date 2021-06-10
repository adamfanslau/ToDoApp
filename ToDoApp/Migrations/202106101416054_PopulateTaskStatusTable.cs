namespace ToDoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTaskStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TaskStatus (Name) Values ('To Do')");
            Sql("INSERT INTO TaskStatus (Name) Values ('In Progress')");
            Sql("INSERT INTO TaskStatus (Name) Values ('Suspended')");
            Sql("INSERT INTO TaskStatus (Name) Values ('Completed')");
            Sql("INSERT INTO TaskStatus (Name) Values ('Abandoned')");
        }
        
        public override void Down()
        {
        }
    }
}
