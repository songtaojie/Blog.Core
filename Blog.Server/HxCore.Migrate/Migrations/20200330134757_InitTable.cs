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
                    { 853390187210735616L, new DateTime(2020, 3, 30, 21, 47, 56, 875, DateTimeKind.Local).AddTicks(351), "N", null, null, null, null, "原创", null, "e3763d67-e30a-4370-af53-2d90bbc761b1", "Admin" },
                    { 853390187214929920L, new DateTime(2020, 3, 30, 21, 47, 56, 875, DateTimeKind.Local).AddTicks(963), "N", null, null, null, null, "转载", null, "e3763d67-e30a-4370-af53-2d90bbc761b1", "Admin" },
                    { 853390187214929921L, new DateTime(2020, 3, 30, 21, 47, 56, 875, DateTimeKind.Local).AddTicks(970), "N", null, null, null, null, "翻译", null, "e3763d67-e30a-4370-af53-2d90bbc761b1", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "T_Category",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { 853390187214929922L, new DateTime(2020, 3, 30, 21, 47, 56, 875, DateTimeKind.Local).AddTicks(2208), "N", null, null, null, null, "前端", null, "e3763d67-e30a-4370-af53-2d90bbc761b1", "Admin" },
                    { 853390187214929923L, new DateTime(2020, 3, 30, 21, 47, 56, 875, DateTimeKind.Local).AddTicks(2238), "N", null, null, null, null, "后端", null, "e3763d67-e30a-4370-af53-2d90bbc761b1", "Admin" },
                    { 853390187214929924L, new DateTime(2020, 3, 30, 21, 47, 56, 875, DateTimeKind.Local).AddTicks(2242), "N", null, null, null, null, "编程语言", null, "e3763d67-e30a-4370-af53-2d90bbc761b1", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "T_UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicInfoId", "Delete", "DeleteTime", "Email", "JobInfoId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { "e3763d67-e30a-4370-af53-2d90bbc761b1", "Y", "N", null, 0L, "N", null, "stjworkemail@163.com", 0L, new DateTime(2020, 3, 30, 21, 47, 56, 871, DateTimeKind.Local).AddTicks(8406), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2020, 3, 30, 21, 47, 56, 868, DateTimeKind.Local).AddTicks(9017), "N", "Admin" });
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
