namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailTypeNotMapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SGT_EMPLOYEE", "EMAIL_TYPE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SGT_EMPLOYEE", "EMAIL_TYPE", c => c.Byte(nullable: false));
        }
    }
}
