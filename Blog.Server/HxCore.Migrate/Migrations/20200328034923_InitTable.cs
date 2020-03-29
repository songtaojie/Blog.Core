using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HxCore.Migrate.Migrations
{
    public partial class InitTable : Migration
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
                name: "Blog",
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
                    CategoryId = table.Column<string>(maxLength: 100, nullable: true),
                    BlogTypeId = table.Column<string>(maxLength: 100, nullable: true),
                    Carousel = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogTag",
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
                    table.PrimaryKey("PK_BlogTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogType",
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
                    table.PrimaryKey("PK_BlogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
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
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobInfo",
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
                    table.PrimaryKey("PK_JobInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
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
                    BasicInfoId = table.Column<string>(maxLength: 100, nullable: true),
                    JobInfoId = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlogType",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { 852514776905940992L, new DateTime(2020, 3, 28, 11, 49, 22, 794, DateTimeKind.Local).AddTicks(377), "N", null, null, null, null, "原创", null, "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Admin" },
                    { 852514776910135296L, new DateTime(2020, 3, 28, 11, 49, 22, 794, DateTimeKind.Local).AddTicks(1019), "N", null, null, null, null, "转载", null, "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Admin" },
                    { 852514776910135297L, new DateTime(2020, 3, 28, 11, 49, 22, 794, DateTimeKind.Local).AddTicks(1026), "N", null, null, null, null, "翻译", null, "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { 852514776910135298L, new DateTime(2020, 3, 28, 11, 49, 22, 794, DateTimeKind.Local).AddTicks(2359), "N", null, null, null, null, "前端", null, "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Admin" },
                    { 852514776910135299L, new DateTime(2020, 3, 28, 11, 49, 22, 794, DateTimeKind.Local).AddTicks(2388), "N", null, null, null, null, "后端", null, "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Admin" },
                    { 852514776910135300L, new DateTime(2020, 3, 28, 11, 49, 22, 794, DateTimeKind.Local).AddTicks(2392), "N", null, null, null, null, "编程语言", null, "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicInfoId", "Delete", "DeleteTime", "Email", "JobInfoId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { "d0b4df42-ba26-4fae-9848-dc0d3520754e", "Y", "N", null, null, "N", null, "stjworkemail@163.com", null, new DateTime(2020, 3, 28, 11, 49, 22, 790, DateTimeKind.Local).AddTicks(8535), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2020, 3, 28, 11, 49, 22, 787, DateTimeKind.Local).AddTicks(9248), "N", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicInfo");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "BlogTag");

            migrationBuilder.DropTable(
                name: "BlogType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "JobInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
