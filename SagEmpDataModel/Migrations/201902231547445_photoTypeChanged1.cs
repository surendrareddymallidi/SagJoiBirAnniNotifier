namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoTypeChanged1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SGT_EMPLOYEE", "PHOTO", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SGT_EMPLOYEE", "PHOTO", c => c.String(nullable: false));
        }
    }
}
