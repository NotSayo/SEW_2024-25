using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations
{
    /// <inheritdoc />
    public partial class namefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StructureId",
                table: "AircraftSpecifications",
                newName: "Structure");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Structure",
                table: "AircraftSpecifications",
                newName: "StructureId");
        }
    }
}
