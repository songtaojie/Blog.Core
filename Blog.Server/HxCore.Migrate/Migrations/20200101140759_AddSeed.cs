using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HxCore.Migrate.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: "819691921952735232");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Activate", "Admin", "AvatarUrl", "BasicInfoId", "Delete", "DeleteTime", "Email", "JobInfoId", "LastLoginTime", "Lock", "LoginIp", "NickName", "OpenId", "PassWord", "RegisterTime", "UseMdEdit", "UserName" },
                values: new object[] { "819691921952735232", "Y", "N", null, null, "N", null, "stjworkemail@163.com", null, new DateTime(2019, 12, 28, 22, 3, 4, 357, DateTimeKind.Local).AddTicks(1957), "N", null, "超级管理员", null, "F59BD65F7EDAFB087A81D4DCA06C4910", new DateTime(2019, 12, 28, 22, 3, 4, 352, DateTimeKind.Local).AddTicks(7635), "N", "Admin" });
        }
    }
}
