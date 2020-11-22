using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HxCore.Migrate.Migrations
{
    public partial class InitTableMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeletelUserId = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    RealName = table.Column<string>(maxLength: 100, nullable: true),
                    CardId = table.Column<string>(maxLength: 40, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(maxLength: 8, nullable: true),
                    QQ = table.Column<string>(maxLength: 40, nullable: true),
                    WeChat = table.Column<string>(maxLength: 40, nullable: true),
                    Telephone = table.Column<string>(maxLength: 40, nullable: true),
                    Mobile = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    School = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Blog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeletelUserId = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ContentHtml = table.Column<string>(nullable: true),
                    MarkDown = table.Column<string>(type: "char(1)", nullable: true),
                    Private = table.Column<string>(nullable: true),
                    Forward = table.Column<string>(type: "char(1)", nullable: true),
                    Publish = table.Column<string>(type: "char(1)", nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    Top = table.Column<string>(type: "char(1)", nullable: true),
                    Essence = table.Column<string>(type: "char(1)", nullable: true),
                    ForwardUrl = table.Column<string>(maxLength: 255, nullable: true),
                    OldPublishTime = table.Column<DateTime>(nullable: true),
                    BlogTags = table.Column<string>(maxLength: 40, nullable: true),
                    CanCmt = table.Column<string>(type: "char(1)", nullable: true),
                    ReadCount = table.Column<long>(nullable: false),
                    LikeCount = table.Column<long>(nullable: false),
                    FavCount = table.Column<long>(nullable: false),
                    CmtCount = table.Column<long>(nullable: false),
                    PersonTop = table.Column<string>(type: "char(1)", nullable: true),
                    ImgUrl = table.Column<string>(maxLength: 255, nullable: true),
                    ImgName = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    OrderFactor = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    BlogTypeId = table.Column<long>(nullable: false),
                    Carousel = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_BlogTag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeletelUserId = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BlogTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_BlogType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeletelUserId = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_BlogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeletelUserId = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_JobInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeletelUserId = table.Column<string>(maxLength: 100, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Position = table.Column<string>(maxLength: 100, nullable: true),
                    Industry = table.Column<string>(maxLength: 100, nullable: true),
                    WorkUnit = table.Column<string>(maxLength: 100, nullable: true),
                    WorkYear = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    Skills = table.Column<string>(maxLength: 1000, nullable: true),
                    GoodAreas = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_JobInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_UserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(maxLength: 40, nullable: false),
                    NickName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    OpenId = table.Column<string>(maxLength: 80, nullable: true),
                    Lock = table.Column<string>(type: "char(1)", nullable: true),
                    AvatarUrl = table.Column<string>(maxLength: 500, nullable: true),
                    Admin = table.Column<string>(type: "char(1)", nullable: true),
                    Activate = table.Column<string>(type: "char(1)", nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    Delete = table.Column<string>(type: "char(1)", nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    UseMdEdit = table.Column<string>(type: "char(1)", nullable: true),
                    LoginIp = table.Column<string>(maxLength: 100, nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    BasicInfoId = table.Column<long>(nullable: false),
                    JobInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "T_BlogType",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { 938893818701283328L, new DateTime(2020, 11, 21, 20, 28, 51, 203, DateTimeKind.Local).AddTicks(2376), "N", null, null, null, null, "原创", null, "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Admin" },
                    { 938893818705477632L, new DateTime(2020, 11, 21, 20, 28, 51, 203, DateTimeKind.Local).AddTicks(2923), "N", null, null, null, null, "转载", null, "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Admin" },
                    { 938893818705477633L, new DateTime(2020, 11, 21, 20, 28, 51, 203, DateTimeKind.Local).AddTicks(2929), "N", null, null, null, null, "翻译", null, "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "T_Category",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { 938893818705477634L, new DateTime(2020, 11, 21, 20, 28, 51, 203, DateTimeKind.Local).AddTicks(4084), "N", null, null, null, null, "前端", null, "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Admin" },
                    { 938893818705477635L, new DateTime(2020, 11, 21, 20, 28, 51, 203, DateTimeKind.Local).AddTicks(4109), "N", null, null, null, null, "后端", null, "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Admin" },
                    { 938893818705477636L, new DateTime(2020, 11, 21, 20, 28, 51, 203, DateTimeKind.Local).AddTicks(4113), "N", null, null, null, null, "编程语言", null, "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "T_UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicInfoId", "Delete", "DeleteTime", "Email", "JobInfoId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { "6a9e4884-dce8-4400-94c3-a29a2b56a735", "Y", "N", null, 0L, "N", null, "stjworkemail@163.com", 0L, new DateTime(2020, 11, 21, 20, 28, 51, 200, DateTimeKind.Local).AddTicks(5651), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2020, 11, 21, 20, 28, 51, 198, DateTimeKind.Local).AddTicks(126), "N", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicInfo");

            migrationBuilder.DropTable(
                name: "T_Blog");

            migrationBuilder.DropTable(
                name: "T_BlogTag");

            migrationBuilder.DropTable(
                name: "T_BlogType");

            migrationBuilder.DropTable(
                name: "T_Category");

            migrationBuilder.DropTable(
                name: "T_JobInfo");

            migrationBuilder.DropTable(
                name: "T_UserInfo");
        }
    }
}
