using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergySystems");

            migrationBuilder.DropTable(
                name: "EnvironmentalSystems");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Machineries",
                type: "TEXT",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Machineries");

            migrationBuilder.CreateTable(
                name: "EnergySystems",
                columns: table => new
                {
                    MachineryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergySystems", x => x.MachineryId);
                    table.ForeignKey(
                        name: "FK_EnergySystems_Machineries_MachineryId",
                        column: x => x.MachineryId,
                        principalTable: "Machineries",
                        principalColumn: "MachineryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalSystems",
                columns: table => new
                {
                    MachineryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalSystems", x => x.MachineryId);
                    table.ForeignKey(
                        name: "FK_EnvironmentalSystems_Machineries_MachineryId",
                        column: x => x.MachineryId,
                        principalTable: "Machineries",
                        principalColumn: "MachineryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    MachineryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.MachineryId);
                    table.ForeignKey(
                        name: "FK_Weapons_Machineries_MachineryId",
                        column: x => x.MachineryId,
                        principalTable: "Machineries",
                        principalColumn: "MachineryId",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
