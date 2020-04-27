using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    hospital_name = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    hospital_overall_rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalInfo");
        }
    }
}
