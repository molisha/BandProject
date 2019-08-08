namespace BANDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBandId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Band_Id", "dbo.Bands");
            DropIndex("dbo.Members", new[] { "Band_Id" });
            RenameColumn(table: "dbo.Members", name: "Band_Id", newName: "BandId");
            AlterColumn("dbo.Bands", "EstDAte", c => c.DateTime());
            AlterColumn("dbo.Members", "BandId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Members", "BandId");
            AddForeignKey("dbo.Members", "BandId", "dbo.Bands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "BandId", "dbo.Bands");
            DropIndex("dbo.Members", new[] { "BandId" });
            AlterColumn("dbo.Members", "BandId", c => c.Byte());
            AlterColumn("dbo.Bands", "EstDAte", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Members", name: "BandId", newName: "Band_Id");
            CreateIndex("dbo.Members", "Band_Id");
            AddForeignKey("dbo.Members", "Band_Id", "dbo.Bands", "Id");
        }
    }
}
