using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HxCore.Migrate.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    DeletelId = table.Column<long>(nullable: true),
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
                name: "BlogType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    DeletelId = table.Column<long>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Order = table.Column<int>(nullable: false),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    DeletelId = table.Column<long>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Order = table.Column<int>(nullable: false),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    DeletelId = table.Column<long>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Position = table.Column<string>(maxLength: 100, nullable: true),
                    Industry = table.Column<string>(maxLength: 100, nullable: true),
                    WorkUnit = table.Column<string>(maxLength: 100, nullable: true),
                    WorkYear = table.Column<int>(nullable: false),
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(maxLength: 40, nullable: false),
                    NickName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    OpenId = table.Column<string>(maxLength: 80, nullable: true),
                    Lock = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    AvatarUrl = table.Column<string>(maxLength: 500, nullable: true),
                    Admin = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    Activate = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: false),
                    Delete = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    UseMdEdit = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    LoginIp = table.Column<string>(maxLength: 100, nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    BasicId = table.Column<long>(nullable: true),
                    JobId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_BasicInfo_BasicId",
                        column: x => x.BasicId,
                        principalTable: "BasicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInfo_JobInfo_JobId",
                        column: x => x.JobId,
                        principalTable: "JobInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Delete = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    DeletelId = table.Column<long>(nullable: true),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    LastModifyTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ContentHtml = table.Column<string>(nullable: true),
                    MarkDown = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    Private = table.Column<string>(nullable: true),
                    Forward = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    Publish = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    Top = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    Essence = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    ForwardUrl = table.Column<string>(maxLength: 255, nullable: true),
                    OldPublishTime = table.Column<DateTime>(nullable: true),
                    BlogTags = table.Column<string>(maxLength: 40, nullable: true),
                    CanCmt = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    ReadCount = table.Column<long>(nullable: false),
                    LikeCount = table.Column<long>(nullable: false),
                    FavCount = table.Column<long>(nullable: false),
                    CmtCount = table.Column<long>(nullable: false),
                    PersonTop = table.Column<string>(type: "char", maxLength: 1, nullable: true),
                    ImgUrl = table.Column<string>(maxLength: 255, nullable: true),
                    ImgName = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    OrderFactor = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<long>(nullable: true),
                    BlogTypeId = table.Column<long>(nullable: true),
                    Carousel = table.Column<string>(type: "char", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_BlogType_BlogTypeId",
                        column: x => x.BlogTypeId,
                        principalTable: "BlogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blog_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicId", "Delete", "DeleteTime", "Email", "JobId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { 1000L, "Y", "N", null, null, "N", null, "stjworkemail@163.com", null, new DateTime(2019, 9, 1, 19, 33, 30, 281, DateTimeKind.Local).AddTicks(3168), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2019, 9, 1, 19, 33, 30, 275, DateTimeKind.Local).AddTicks(3210), "N", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogTypeId",
                table: "Blog",
                column: "BlogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CategoryId",
                table: "Blog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_BasicId",
                table: "UserInfo",
                column: "BasicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_JobId",
                table: "UserInfo",
                column: "JobId");
            migrationBuilder.Sql("alter table blog auto_increment=1000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "BlogType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "BasicInfo");

            migrationBuilder.DropTable(
                name: "JobInfo");
        }
    }
}
