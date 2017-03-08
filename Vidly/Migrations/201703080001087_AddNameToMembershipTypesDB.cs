namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipTypesDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' where DiscountRate = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where DiscountRate = 10");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' where DiscountRate = 15");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' where DiscountRate = 20");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
