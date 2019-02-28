namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photomaderequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SGT_EMPLOYEE", "PHOTO", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SGT_EMPLOYEE", "PHOTO", c => c.Binary());
        }
    }
}
