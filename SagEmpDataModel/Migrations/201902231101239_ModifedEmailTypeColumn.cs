namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifedEmailTypeColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SGT_EMPLOYEE", name: "emailType", newName: "EMAIL_TYPE");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.SGT_EMPLOYEE", name: "EMAIL_TYPE", newName: "emailType");
        }
    }
}
