namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MappedEmailTypeToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SGT_EMPLOYEE", "EMAIL_TYPE", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SGT_EMPLOYEE", "EMAIL_TYPE");
        }
    }
}
