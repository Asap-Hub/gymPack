using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gym.Infrastructure.Migrations
{
    public partial class seeddat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4187), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4200), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(2634) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4305), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4307), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4271) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4312), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4314), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4320), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4322), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4326), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4328), new DateTime(2023, 6, 6, 0, 35, 29, 792, DateTimeKind.Local).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 785, DateTimeKind.Local).AddTicks(3339), new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(5666) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6649), new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6719), new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6725), new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6730), new DateTime(2023, 6, 6, 0, 35, 29, 787, DateTimeKind.Local).AddTicks(6733) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3329), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3340), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(1929) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3621), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3624), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3634), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3636), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3642), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3644), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "tblMyTodo",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EdittedDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3650), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3653), new DateTime(2023, 6, 6, 0, 30, 31, 982, DateTimeKind.Local).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 977, DateTimeKind.Local).AddTicks(4622), new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1290), new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1334) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1369), new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1377), new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "tblProgress",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EdittedDate" },
                values: new object[] { new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1385), new DateTime(2023, 6, 6, 0, 30, 31, 979, DateTimeKind.Local).AddTicks(1388) });
        }
    }
}
