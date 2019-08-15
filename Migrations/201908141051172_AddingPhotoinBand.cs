namespace BANDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPhotoinBand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bands", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bands", "Photo");
        }
    }
}
