using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gym.Infrastructure.Migrations
{
    public partial class seedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProgress",
                table: "tblProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMyTodo",
                table: "tblMyTodo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblProgress");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblMyTodo");

            migrationBuilder.AlterColumn<string>(
                name: "EdittedBy",
                table: "tblProgress",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblProgress",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "tblProgress",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "EdittedBy",
                table: "tblMyTodo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "tblMyTodo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TodoId",
                table: "tblMyTodo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "tblMyTodo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProgress",
                table: "tblProgress",
                column: "ProgressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMyTodo",
                table: "tblMyTodo",
                column: "TodoId");

            migrationBuilder.InsertData(
                table: "tblMyTodo",
                columns: new[] { "TodoId", "CreatedBy", "CreatedDate", "EdittedBy", "EdittedDate", "EndDate", "Note", "ProgressId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Instructor Malik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2003), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7765), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1933), "finish hard", 0, new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(6417), "task 1" },
                    { 2, "Instructor Malik", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7874), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006), "finish hard", 0, new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7842), "task 2" },
                    { 3, "Instructor Malik", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7883), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7885), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2003), "finish hard", 0, new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7881), "task 3" },
                    { 4, "Instructor Malik", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7890), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7892), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1997), "finish hard", 0, new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7888), "task 4" },
                    { 5, "Instructor Malik", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7897), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1995), "finish hard", 0, new DateTime(2023, 6, 7, 20, 12, 58, 800, DateTimeKind.Local).AddTicks(7894), "task 5" }
                });

            migrationBuilder.InsertData(
                table: "tblProgress",
                columns: new[] { "ProgressId", "Completed", "Confirmed", "ConfirmedBy", "CreatedBy", "CreatedDate", "EdittedBy", "EdittedDate", "Percentage", "Status" },
                values: new object[,]
                {
                    { 1, false, false, "Instructor Malik", "Asap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2003), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 795, DateTimeKind.Local).AddTicks(7055), 0, "pending" },
                    { 2, true, false, "Instructor Malik", "Asap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1992), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 797, DateTimeKind.Local).AddTicks(1926), 100, "done" },
                    { 3, true, true, "Instructor Malik", "Asap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2002), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 797, DateTimeKind.Local).AddTicks(1996), 100, "done" },
                    { 4, false, false, "Instructor Malik", "Asap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2002), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 797, DateTimeKind.Local).AddTicks(2002), 0, "pending" },
                    { 5, false, true, "Instructor Malik", "Asap", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1993), "Asap", new DateTime(2023, 6, 7, 20, 12, 58, 797, DateTimeKind.Local).AddTicks(2006), 50, "progress" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProgress",
                table: "tblProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMyTodo",
                table: "tblMyTodo");

            migrationBuilder.DeleteData(
                table: "tblMyTodo",
                keyColumn: "TodoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblMyTodo",
                keyColumn: "TodoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblMyTodo",
                keyColumn: "TodoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblMyTodo",
                keyColumn: "TodoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblMyTodo",
                keyColumn: "TodoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblProgress",
                keyColumn: "ProgressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblProgress",
                keyColumn: "ProgressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblProgress",
                keyColumn: "ProgressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblProgress",
                keyColumn: "ProgressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblProgress",
                keyColumn: "ProgressId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "tblProgress");

            migrationBuilder.DropColumn(
                name: "TodoId",
                table: "tblMyTodo");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "tblMyTodo");

            migrationBuilder.AlterColumn<int>(
                name: "EdittedBy",
                table: "tblProgress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "tblProgress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblProgress",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "EdittedBy",
                table: "tblMyTodo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "tblMyTodo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblMyTodo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProgress",
                table: "tblProgress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMyTodo",
                table: "tblMyTodo",
                column: "Id");
        }
    }
}
