namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomizedColumnNameJoiningMailSent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SGT_EMPLOYEE", name: "JOININGMAILSENT", newName: "JOINING_MAIL_SENT");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.SGT_EMPLOYEE", name: "JOINING_MAIL_SENT", newName: "JOININGMAILSENT");
        }
    }
}
