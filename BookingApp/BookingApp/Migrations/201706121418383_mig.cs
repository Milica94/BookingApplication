namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        AccommodationId = c.Int(nullable: false, identity: true),
                        address = c.String(),
                        approved = c.Boolean(nullable: false),
                        averageGrade = c.Single(nullable: false),
                        description = c.String(),
                        imageURL = c.String(),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        name = c.String(),
                        PlaceId = c.Int(nullable: false),
                        AccommodationTypeId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.AccommodationId)
                .ForeignKey("dbo.AccommodationTypes", t => t.AccommodationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.AccommodationTypeId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.AccommodationTypes",
                c => new
                    {
                        AccommodationTypeId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.AccommodationTypeId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        grade = c.Int(nullable: false),
                        text = c.String(),
                        UserId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        User_UserId1 = c.Int(),
                        Accommodation_AccommodationId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .ForeignKey("dbo.Accommodations", t => t.Accommodation_AccommodationId)
                .Index(t => t.User_UserId)
                .Index(t => t.User_UserId1)
                .Index(t => t.Accommodation_AccommodationId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                        RoomReservations_RoomReservationsId = c.Int(),
                        Comment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.RoomReservations", t => t.RoomReservations_RoomReservationsId)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentId)
                .Index(t => t.RoomReservations_RoomReservationsId)
                .Index(t => t.Comment_CommentId);
            
            CreateTable(
                "dbo.RoomReservations",
                c => new
                    {
                        RoomReservationsId = c.Int(nullable: false, identity: true),
                        endDate = c.String(),
                        startDate = c.String(),
                        timestamp_AutoReset = c.Boolean(nullable: false),
                        timestamp_Enabled = c.Boolean(nullable: false),
                        timestamp_Interval = c.Double(nullable: false),
                        RoomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Room_RoomId = c.Int(),
                        Room_RoomId1 = c.Int(),
                        User_UserId = c.Int(),
                        User_UserId1 = c.Int(),
                    })
                .PrimaryKey(t => t.RoomReservationsId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId1)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .Index(t => t.Room_RoomId)
                .Index(t => t.Room_RoomId1)
                .Index(t => t.User_UserId)
                .Index(t => t.User_UserId1);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        bedCount = c.Int(nullable: false),
                        description = c.String(),
                        pricePerNight = c.Int(nullable: false),
                        roomNumber = c.Int(nullable: false),
                        AccommodationId = c.Int(nullable: false),
                        RoomReservations_RoomReservationsId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Accommodations", t => t.AccommodationId, cascadeDelete: true)
                .ForeignKey("dbo.RoomReservations", t => t.RoomReservations_RoomReservationsId)
                .Index(t => t.AccommodationId)
                .Index(t => t.RoomReservations_RoomReservationsId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceId)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Regions", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Accommodations", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Comments", "Accommodation_AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Comments", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.Users", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.RoomReservations", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.RoomReservations", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RoomReservations", "Room_RoomId1", "dbo.Rooms");
            DropForeignKey("dbo.Users", "RoomReservations_RoomReservationsId", "dbo.RoomReservations");
            DropForeignKey("dbo.Rooms", "RoomReservations_RoomReservationsId", "dbo.RoomReservations");
            DropForeignKey("dbo.RoomReservations", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Accommodations", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Accommodations", "AccommodationTypeId", "dbo.AccommodationTypes");
            DropIndex("dbo.Regions", new[] { "CountryId" });
            DropIndex("dbo.Places", new[] { "RegionId" });
            DropIndex("dbo.Rooms", new[] { "RoomReservations_RoomReservationsId" });
            DropIndex("dbo.Rooms", new[] { "AccommodationId" });
            DropIndex("dbo.RoomReservations", new[] { "User_UserId1" });
            DropIndex("dbo.RoomReservations", new[] { "User_UserId" });
            DropIndex("dbo.RoomReservations", new[] { "Room_RoomId1" });
            DropIndex("dbo.RoomReservations", new[] { "Room_RoomId" });
            DropIndex("dbo.Users", new[] { "Comment_CommentId" });
            DropIndex("dbo.Users", new[] { "RoomReservations_RoomReservationsId" });
            DropIndex("dbo.Comments", new[] { "Accommodation_AccommodationId" });
            DropIndex("dbo.Comments", new[] { "User_UserId1" });
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropIndex("dbo.Accommodations", new[] { "User_UserId" });
            DropIndex("dbo.Accommodations", new[] { "AccommodationTypeId" });
            DropIndex("dbo.Accommodations", new[] { "PlaceId" });
            DropTable("dbo.AppUsers");
            DropTable("dbo.Countries");
            DropTable("dbo.Regions");
            DropTable("dbo.Places");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomReservations");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.AccommodationTypes");
            DropTable("dbo.Accommodations");
        }
    }
}
