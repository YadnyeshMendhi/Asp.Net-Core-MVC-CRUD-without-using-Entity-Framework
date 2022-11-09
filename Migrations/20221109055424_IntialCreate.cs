using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDwithoutEF.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneViewModel",
                columns: table => new
                {
                    PhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneViewModel", x => x.PhoneID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneViewModel");
        }
    }
}
