using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherDatum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    TemperatureC = table.Column<decimal?>(nullable: false),
                    AirWetness = table.Column<decimal?>(nullable: false),
                    Td = table.Column<decimal?>(nullable: false),
                    Pressure = table.Column<int?>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    windSpeed = table.Column<int?>(nullable: false),
                    cloudness = table.Column<int?>(nullable: false),
                    h = table.Column<int?>(nullable: false),
                    vv = table.Column<int?>(nullable: false),
                    veatherEffects = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDatum", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDatum");
        }
    }
}
