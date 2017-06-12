namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingConstraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoomReservations_RoomReservationsId", "dbo.RoomReservations");
            DropForeignKey("dbo.RoomReservations", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.Users", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Accommodation_AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Comments", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.Accommodations", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RoomReservations", "Room_RoomId1", "dbo.Rooms");
            DropForeignKey("dbo.RoomReservations", "User_UserId", "dbo.Users");
            DropIndex("dbo.Accommodations", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "User_UserId1" });
            DropIndex("dbo.Comments", new[] { "Accommodation_AccommodationId" });
            DropIndex("dbo.Users", new[] { "RoomReservations_RoomReservationsId" });
            DropIndex("dbo.Users", new[] { "Comment_CommentId" });
            DropIndex("dbo.RoomReservations", new[] { "Room_RoomId1" });
            DropIndex("dbo.RoomReservations", new[] { "User_UserId" });
            DropIndex("dbo.RoomReservations", new[] { "User_UserId1" });
            DropColumn("dbo.Comments", "UserId");
            DropColumn("dbo.RoomReservations", "RoomId");
            DropColumn("dbo.RoomReservations", "UserId");
            RenameColumn(table: "dbo.Comments", name: "Accommodation_AccommodationId", newName: "AccommodationId");
            RenameColumn(table: "dbo.Comments", name: "User_UserId1", newName: "UserId");
            RenameColumn(table: "dbo.Accommodations", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.RoomReservations", name: "Room_RoomId1", newName: "RoomId");
            RenameColumn(table: "dbo.RoomReservations", name: "User_UserId", newName: "UserId");
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Comment_CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Comment_CommentId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Comment_CommentId);
            
            CreateTable(
                "dbo.RoomReservationsUsers",
                c => new
                    {
                        RoomReservations_RoomReservationsId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoomReservations_RoomReservationsId, t.User_UserId })
                .ForeignKey("dbo.RoomReservations", t => t.RoomReservations_RoomReservationsId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.RoomReservations_RoomReservationsId)
                .Index(t => t.User_UserId);
            
            AddColumn("dbo.RoomReservations", "timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "AppUser_Id", c => c.Int());
            AddColumn("dbo.Countries", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accommodations", "address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Accommodations", "description", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Accommodations", "imageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Accommodations", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accommodations", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccommodationTypes", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "text", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "AccommodationId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoomReservations", "endDate", c => c.String(nullable: false));
            AlterColumn("dbo.RoomReservations", "startDate", c => c.String(nullable: false));
            AlterColumn("dbo.RoomReservations", "RoomId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoomReservations", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Places", "name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Regions", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Countries", "code", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.AppUsers", "FullName", c => c.String(nullable: false, maxLength: 25));
            CreateIndex("dbo.Accommodations", "UserId");
            CreateIndex("dbo.AccommodationTypes", "name", unique: true);
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "AccommodationId");
            CreateIndex("dbo.RoomReservations", "RoomId");
            CreateIndex("dbo.RoomReservations", "UserId");
            CreateIndex("dbo.Rooms", "AppUser_Id");
            CreateIndex("dbo.AppUsers", "FullName", unique: true);
            CreateIndex("dbo.Places", "name", unique: true);
            CreateIndex("dbo.Regions", "name", unique: true);
            CreateIndex("dbo.Countries", "name", unique: true);
            AddForeignKey("dbo.Rooms", "AppUser_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.Accommodations", "UserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "AccommodationId", "dbo.Accommodations", "AccommodationId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Accommodations", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.RoomReservations", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.RoomReservations", "UserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "User_UserId");
            DropColumn("dbo.Users", "RoomReservations_RoomReservationsId");
            DropColumn("dbo.Users", "Comment_CommentId");
            DropColumn("dbo.RoomReservations", "timestamp_AutoReset");
            DropColumn("dbo.RoomReservations", "timestamp_Enabled");
            DropColumn("dbo.RoomReservations", "timestamp_Interval");
            DropColumn("dbo.RoomReservations", "User_UserId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomReservations", "User_UserId1", c => c.Int());
            AddColumn("dbo.RoomReservations", "timestamp_Interval", c => c.Double(nullable: false));
            AddColumn("dbo.RoomReservations", "timestamp_Enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.RoomReservations", "timestamp_AutoReset", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Comment_CommentId", c => c.Int());
            AddColumn("dbo.Users", "RoomReservations_RoomReservationsId", c => c.Int());
            AddColumn("dbo.Comments", "User_UserId", c => c.Int());
            DropForeignKey("dbo.RoomReservations", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.RoomReservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Accommodations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "AccommodationId", "dbo.Accommodations");
            DropForeignKey("dbo.Accommodations", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Rooms", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.RoomReservationsUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RoomReservationsUsers", "RoomReservations_RoomReservationsId", "dbo.RoomReservations");
            DropForeignKey("dbo.UserComments", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.UserComments", "User_UserId", "dbo.Users");
            DropIndex("dbo.RoomReservationsUsers", new[] { "User_UserId" });
            DropIndex("dbo.RoomReservationsUsers", new[] { "RoomReservations_RoomReservationsId" });
            DropIndex("dbo.UserComments", new[] { "Comment_CommentId" });
            DropIndex("dbo.UserComments", new[] { "User_UserId" });
            DropIndex("dbo.Countries", new[] { "name" });
            DropIndex("dbo.Regions", new[] { "name" });
            DropIndex("dbo.Places", new[] { "name" });
            DropIndex("dbo.AppUsers", new[] { "FullName" });
            DropIndex("dbo.Rooms", new[] { "AppUser_Id" });
            DropIndex("dbo.RoomReservations", new[] { "UserId" });
            DropIndex("dbo.RoomReservations", new[] { "RoomId" });
            DropIndex("dbo.Comments", new[] { "AccommodationId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.AccommodationTypes", new[] { "name" });
            DropIndex("dbo.Accommodations", new[] { "UserId" });
            AlterColumn("dbo.AppUsers", "FullName", c => c.String());
            AlterColumn("dbo.Countries", "code", c => c.Int(nullable: false));
            AlterColumn("dbo.Regions", "name", c => c.String());
            AlterColumn("dbo.Places", "name", c => c.String());
            AlterColumn("dbo.Rooms", "description", c => c.String());
            AlterColumn("dbo.RoomReservations", "UserId", c => c.Int());
            AlterColumn("dbo.RoomReservations", "RoomId", c => c.Int());
            AlterColumn("dbo.RoomReservations", "startDate", c => c.String());
            AlterColumn("dbo.RoomReservations", "endDate", c => c.String());
            AlterColumn("dbo.Comments", "AccommodationId", c => c.Int());
            AlterColumn("dbo.Comments", "UserId", c => c.Int());
            AlterColumn("dbo.Comments", "text", c => c.String());
            AlterColumn("dbo.AccommodationTypes", "name", c => c.String());
            AlterColumn("dbo.Accommodations", "UserId", c => c.Int());
            AlterColumn("dbo.Accommodations", "name", c => c.String());
            AlterColumn("dbo.Accommodations", "imageURL", c => c.String());
            AlterColumn("dbo.Accommodations", "description", c => c.String());
            AlterColumn("dbo.Accommodations", "address", c => c.String());
            DropColumn("dbo.Countries", "name");
            DropColumn("dbo.Rooms", "AppUser_Id");
            DropColumn("dbo.RoomReservations", "timestamp");
            DropTable("dbo.RoomReservationsUsers");
            DropTable("dbo.UserComments");
            RenameColumn(table: "dbo.RoomReservations", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.RoomReservations", name: "RoomId", newName: "Room_RoomId1");
            RenameColumn(table: "dbo.Accommodations", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "User_UserId1");
            RenameColumn(table: "dbo.Comments", name: "AccommodationId", newName: "Accommodation_AccommodationId");
            AddColumn("dbo.RoomReservations", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.RoomReservations", "RoomId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoomReservations", "User_UserId1");
            CreateIndex("dbo.RoomReservations", "User_UserId");
            CreateIndex("dbo.RoomReservations", "Room_RoomId1");
            CreateIndex("dbo.Users", "Comment_CommentId");
            CreateIndex("dbo.Users", "RoomReservations_RoomReservationsId");
            CreateIndex("dbo.Comments", "Accommodation_AccommodationId");
            CreateIndex("dbo.Comments", "User_UserId1");
            CreateIndex("dbo.Comments", "User_UserId");
            CreateIndex("dbo.Accommodations", "User_UserId");
            AddForeignKey("dbo.RoomReservations", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.RoomReservations", "Room_RoomId1", "dbo.Rooms", "RoomId");
            AddForeignKey("dbo.Accommodations", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Comments", "User_UserId1", "dbo.Users", "UserId");
            AddForeignKey("dbo.Comments", "Accommodation_AccommodationId", "dbo.Accommodations", "AccommodationId");
            AddForeignKey("dbo.Users", "Comment_CommentId", "dbo.Comments", "CommentId");
            AddForeignKey("dbo.RoomReservations", "User_UserId1", "dbo.Users", "UserId");
            AddForeignKey("dbo.Users", "RoomReservations_RoomReservationsId", "dbo.RoomReservations", "RoomReservationsId");
            AddForeignKey("dbo.Comments", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
