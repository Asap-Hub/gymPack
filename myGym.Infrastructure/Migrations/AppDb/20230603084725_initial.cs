using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gym.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMyTodo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    EdittedDate = table.Column<DateTime>(nullable: false),
                    EdittedBy = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMyTodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProgress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    EdittedDate = table.Column<DateTime>(nullable: false),
                    EdittedBy = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Percentage = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    Reviewed = table.Column<bool>(nullable: false),
                    ReviewBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProgress", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMyTodo");

            migrationBuilder.DropTable(
                name: "tblProgress");
        }
    }
}
