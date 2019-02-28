namespace SagEmpDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customedtableColumnNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.bussaglocations", newName: "SGT_LOCATION");
            RenameColumn(table: "dbo.SGT_LOCATION", name: "locationId", newName: "LOCATION_ID");
            RenameColumn(table: "dbo.SGT_LOCATION", name: "locationName", newName: "LOCATION_NAME");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.SGT_LOCATION", name: "LOCATION_NAME", newName: "locationName");
            RenameColumn(table: "dbo.SGT_LOCATION", name: "LOCATION_ID", newName: "locationId");
            RenameTable(name: "dbo.SGT_LOCATION", newName: "bussaglocations");
        }
    }
}
