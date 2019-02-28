namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeRenaming : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SGT_EMPLOYEE", "FIRST_NAME", c => c.String(nullable: false));
            AlterColumn("dbo.SGT_EMPLOYEE", "LAST_NAME", c => c.String(nullable: false));
            AlterColumn("dbo.SGT_EMPLOYEE", "EMAIL", c => c.String(nullable: false));
            AlterColumn("dbo.SGT_EMPLOYEE", "PROJECT", c => c.String(nullable: false));
            AlterColumn("dbo.SGT_EMPLOYEE", "DESIGNATION", c => c.String(nullable: false));
            AlterColumn("dbo.SGT_EMPLOYEE", "EDUCATION", c => c.String(nullable: false));
            AlterColumn("dbo.SGT_EMPLOYEE", "HOBBIES", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SGT_EMPLOYEE", "HOBBIES", c => c.String());
            AlterColumn("dbo.SGT_EMPLOYEE", "EDUCATION", c => c.String());
            AlterColumn("dbo.SGT_EMPLOYEE", "DESIGNATION", c => c.String());
            AlterColumn("dbo.SGT_EMPLOYEE", "PROJECT", c => c.String());
            AlterColumn("dbo.SGT_EMPLOYEE", "EMAIL", c => c.String());
            AlterColumn("dbo.SGT_EMPLOYEE", "LAST_NAME", c => c.String());
            AlterColumn("dbo.SGT_EMPLOYEE", "FIRST_NAME", c => c.String());
        }
    }
}
