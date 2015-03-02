namespace BarterService.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Ammount = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Consumer_Id = c.Long(nullable: false),
                        Seller_Id = c.Long(nullable: false),
                        Weal_Id = c.Long(nullable: false),
                        ScoreTransaction_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Consumer_Id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Seller_Id, cascadeDelete: false)
                .ForeignKey("dbo.Weals", t => t.Weal_Id, cascadeDelete: true)
                .ForeignKey("dbo.ScoreTransactions", t => t.ScoreTransaction_Id, cascadeDelete: true)
                .Index(t => t.Consumer_Id)
                .Index(t => t.Seller_Id)
                .Index(t => t.Weal_Id)
                .Index(t => t.ScoreTransaction_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScoreAccounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ScoreAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(nullable: false, maxLength: 300),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Owner_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Author_Id = c.Long(nullable: false),
                        Weal_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id, cascadeDelete: false)
                .ForeignKey("dbo.Weals", t => t.Weal_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Weal_Id);
            
            CreateTable(
                "dbo.ScoreTransactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        FromAccount_Id = c.Long(nullable: false),
                        ToAccount_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScoreAccounts", t => t.FromAccount_Id, cascadeDelete: false)
                .ForeignKey("dbo.ScoreAccounts", t => t.ToAccount_Id, cascadeDelete: false)
                .Index(t => t.FromAccount_Id)
                .Index(t => t.ToAccount_Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        Rating = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Deal_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.Deal_Id, cascadeDelete: true)
                .Index(t => t.Deal_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        DealsCount = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        User_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: false)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "Deal_Id", "dbo.Deals");
            DropForeignKey("dbo.Deals", "ScoreTransaction_Id", "dbo.ScoreTransactions");
            DropForeignKey("dbo.ScoreTransactions", "ToAccount_Id", "dbo.ScoreAccounts");
            DropForeignKey("dbo.ScoreTransactions", "FromAccount_Id", "dbo.ScoreAccounts");
            DropForeignKey("dbo.Deals", "Weal_Id", "dbo.Weals");
            DropForeignKey("dbo.Deals", "Seller_Id", "dbo.Users");
            DropForeignKey("dbo.Deals", "Consumer_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Weal_Id", "dbo.Weals");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Weals", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Id", "dbo.ScoreAccounts");
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.Feedbacks", new[] { "Deal_Id" });
            DropIndex("dbo.ScoreTransactions", new[] { "ToAccount_Id" });
            DropIndex("dbo.ScoreTransactions", new[] { "FromAccount_Id" });
            DropIndex("dbo.Comments", new[] { "Weal_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Weals", new[] { "Owner_Id" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Deals", new[] { "ScoreTransaction_Id" });
            DropIndex("dbo.Deals", new[] { "Weal_Id" });
            DropIndex("dbo.Deals", new[] { "Seller_Id" });
            DropIndex("dbo.Deals", new[] { "Consumer_Id" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.ScoreTransactions");
            DropTable("dbo.Comments");
            DropTable("dbo.Weals");
            DropTable("dbo.ScoreAccounts");
            DropTable("dbo.Users");
            DropTable("dbo.Deals");
        }
    }
}
