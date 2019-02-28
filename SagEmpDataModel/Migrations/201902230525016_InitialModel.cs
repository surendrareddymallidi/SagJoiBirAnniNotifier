namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SGT_EMPLOYEE",
                c => new
                    {
                        SAG_ID = c.Int(nullable: false, identity: true),
                        FIRST_NAME = c.String(maxLength:50),
                        MIDDLE_NAME = c.String(maxLength: 50),
                        LAST_NAME = c.String(maxLength: 50),
                        EMAIL = c.String(maxLength: 50),
                        DATE_OF_BIRTH = c.DateTime(nullable: false),
                        DATE_OF_JOINING = c.DateTime(nullable: false),
                        PROJECT = c.String(maxLength: 100),
                        DESIGNATION = c.String(maxLength: 100),
                        LOCATIONID = c.Byte(nullable: false),
                        EDUCATION = c.String(maxLength: 100),
                        PREVIOUS_COMPANY = c.String(maxLength: 100),
                        PREVIOUS_COMPANY_DESIGNATION = c.String(maxLength: 75),
                        HOBBIES = c.String(maxLength: 150),
                        PHOTO = c.Binary(),
                        JOININGMAILSENT = c.Boolean(nullable: false, defaultValue: false),
                        BIRTHDAYS = c.Byte(nullable: false, defaultValue: 0),
                        ANNIVERSARIES = c.Byte(nullable: false, defaultValue: 0),
                        IS_TERMINATED = c.Boolean(nullable: false, defaultValue:false),
                    })
                .PrimaryKey(t => t.SAG_ID)
                .ForeignKey("dbo.bussaglocations", t => t.LOCATIONID, cascadeDelete: true)
                .Index(t => t.LOCATIONID);
            
            CreateTable(
                "dbo.bussaglocations",
                c => new
                    {
                        locationId = c.Byte(nullable: false),
                        locationName = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.locationId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SGT_EMPLOYEE", "LOCATIONID", "dbo.bussaglocations");
            DropIndex("dbo.SGT_EMPLOYEE", new[] { "LOCATIONID" });
            DropTable("dbo.bussaglocations");
            DropTable("dbo.SGT_EMPLOYEE");
        }
    }
}
