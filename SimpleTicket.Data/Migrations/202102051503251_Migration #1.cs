namespace SimpleTicket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "CreatorName", c => c.String());
            AddColumn("dbo.Note", "CreateName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "CreateName");
            DropColumn("dbo.Ticket", "CreatorName");
            DropColumn("dbo.Customer", "Status");
        }
    }
}
