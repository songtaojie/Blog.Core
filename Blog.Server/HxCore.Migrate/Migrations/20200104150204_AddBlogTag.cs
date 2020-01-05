using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HxCore.Migrate.Migrations
{
    public partial class AddBlogTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogType",
                keyColumn: "Id",
                keyValue: "821142707052216320");

            migrationBuilder.DeleteData(
                table: "BlogType",
                keyColumn: "Id",
                keyValue: "821142707056410624");

            migrationBuilder.DeleteData(
                table: "BlogType",
                keyColumn: "Id",
                keyValue: "821142707056410625");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "821142707056410626");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "821142707056410627");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "821142707056410628");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: "821142707031244800");

            migrationBuilder.CreateTable(
                name: "BlogTag",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 100, nullable: false),
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

            migrationBuilder.InsertData(
                table: "BlogType",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { "822243480372772864", new DateTime(2020, 1, 4, 23, 2, 3, 287, DateTimeKind.Local).AddTicks(1784), "N", null, null, null, null, "原创", null, "822243480343412736", "Admin" },
                    { "822243480376967168", new DateTime(2020, 1, 4, 23, 2, 3, 287, DateTimeKind.Local).AddTicks(2469), "N", null, null, null, null, "转载", null, "822243480343412736", "Admin" },
                    { "822243480376967169", new DateTime(2020, 1, 4, 23, 2, 3, 287, DateTimeKind.Local).AddTicks(2477), "N", null, null, null, null, "翻译", null, "822243480343412736", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { "822243480376967170", new DateTime(2020, 1, 4, 23, 2, 3, 287, DateTimeKind.Local).AddTicks(4082), "N", null, null, null, null, "前端", null, "822243480343412736", "Admin" },
                    { "822243480376967171", new DateTime(2020, 1, 4, 23, 2, 3, 287, DateTimeKind.Local).AddTicks(4108), "N", null, null, null, null, "后端", null, "822243480343412736", "Admin" },
                    { "822243480376967172", new DateTime(2020, 1, 4, 23, 2, 3, 287, DateTimeKind.Local).AddTicks(4115), "N", null, null, null, null, "编程语言", null, "822243480343412736", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicInfoId", "Delete", "DeleteTime", "Email", "JobInfoId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { "822243480343412736", "Y", "N", null, null, "N", null, "stjworkemail@163.com", null, new DateTime(2020, 1, 4, 23, 2, 3, 283, DateTimeKind.Local).AddTicks(8830), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2020, 1, 4, 23, 2, 3, 278, DateTimeKind.Local).AddTicks(6321), "N", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTag");

            migrationBuilder.DeleteData(
                table: "BlogType",
                keyColumn: "Id",
                keyValue: "822243480372772864");

            migrationBuilder.DeleteData(
                table: "BlogType",
                keyColumn: "Id",
                keyValue: "822243480376967168");

            migrationBuilder.DeleteData(
                table: "BlogType",
                keyColumn: "Id",
                keyValue: "822243480376967169");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "822243480376967170");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "822243480376967171");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "822243480376967172");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: "822243480343412736");

            migrationBuilder.InsertData(
                table: "BlogType",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { "821142707052216320", new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(1010), "N", null, null, null, null, "原创", null, "821142707031244800", "Admin" },
                    { "821142707056410624", new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(1586), "N", null, null, null, null, "转载", null, "821142707031244800", "Admin" },
                    { "821142707056410625", new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(1593), "N", null, null, null, null, "翻译", null, "821142707031244800", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateTime", "Delete", "DeleteTime", "DeletelUserId", "Description", "LastModifyTime", "Name", "Order", "UserId", "UserName" },
                values: new object[,]
                {
                    { "821142707056410626", new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(2788), "N", null, null, null, null, "前端", null, "821142707031244800", "Admin" },
                    { "821142707056410627", new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(2828), "N", null, null, null, null, "后端", null, "821142707031244800", "Admin" },
                    { "821142707056410628", new DateTime(2020, 1, 1, 22, 7, 58, 476, DateTimeKind.Local).AddTicks(2832), "N", null, null, null, null, "编程语言", null, "821142707031244800", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicInfoId", "Delete", "DeleteTime", "Email", "JobInfoId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { "821142707031244800", "Y", "N", null, null, "N", null, "stjworkemail@163.com", null, new DateTime(2020, 1, 1, 22, 7, 58, 473, DateTimeKind.Local).AddTicks(7568), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2020, 1, 1, 22, 7, 58, 469, DateTimeKind.Local).AddTicks(7140), "N", "Admin" });
        }
    }
}
