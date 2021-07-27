namespace test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genner",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NameGenner = c.String(maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.userName",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30, fixedLength: true),
                        Password = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Phone = c.String(nullable: false, maxLength: 15, fixedLength: true),
                        OldMail = c.String(maxLength: 128, fixedLength: true),
                        Date = c.DateTime(storeType: "date"),
                        IDGenner = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genner", t => t.IDGenner)
                .Index(t => t.IDGenner);
            
            CreateTable(
                "dbo.loginModels",
                c => new
                    {
                        userMail = c.String(nullable: false, maxLength: 128),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.userMail);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userName", "IDGenner", "dbo.Genner");
            DropIndex("dbo.userName", new[] { "IDGenner" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.loginModels");
            DropTable("dbo.userName");
            DropTable("dbo.Genner");
        }
    }
}
