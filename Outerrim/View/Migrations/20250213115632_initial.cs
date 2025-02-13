using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace View.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftSpecifications",
                columns: table => new
                {
                    SpecificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StructureId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelTankCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    MinSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAltitude = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecificationCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftSpecifications", x => x.SpecificationId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeSyndicates",
                columns: table => new
                {
                    SyndicateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeSyndicates", x => x.SyndicateId);
                });

            migrationBuilder.CreateTable(
                name: "Mercenaries",
                columns: table => new
                {
                    MercenaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    BodySkills = table.Column<int>(type: "INTEGER", nullable: false),
                    CombatSkill = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercenaries", x => x.MercenaryId);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fuel = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    Altitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SpecificationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AircraftSpecifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "AircraftSpecifications",
                        principalColumn: "SpecificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MercenaryReputations",
                columns: table => new
                {
                    MercenaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SyndicateId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReputationChange = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MercenaryReputations", x => new { x.MercenaryId, x.SyndicateId });
                    table.ForeignKey(
                        name: "FK_MercenaryReputations_CrimeSyndicates_SyndicateId",
                        column: x => x.SyndicateId,
                        principalTable: "CrimeSyndicates",
                        principalColumn: "SyndicateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MercenaryReputations_Mercenaries_MercenaryId",
                        column: x => x.MercenaryId,
                        principalTable: "Mercenaries",
                        principalColumn: "MercenaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AircraftCrewsJT",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "INTEGER", nullable: false),
                    MercenaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftCrewsJT", x => new { x.AircraftId, x.MercenaryId });
                    table.ForeignKey(
                        name: "FK_AircraftCrewsJT_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AircraftCrewsJT_Mercenaries_MercenaryId",
                        column: x => x.MercenaryId,
                        principalTable: "Mercenaries",
                        principalColumn: "MercenaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compartments",
                columns: table => new
                {
                    CompartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AircraftId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compartments", x => x.CompartmentId);
                    table.ForeignKey(
                        name: "FK_Compartments_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machineries",
                columns: table => new
                {
                    MachineryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Function = table.Column<string>(type: "TEXT", nullable: false),
                    CompartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machineries", x => x.MachineryId);
                    table.ForeignKey(
                        name: "FK_Machineries_Compartments_CompartmentId",
                        column: x => x.CompartmentId,
                        principalTable: "Compartments",
                        principalColumn: "CompartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AircraftCrewsJT_MercenaryId",
                table: "AircraftCrewsJT",
                column: "MercenaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_SpecificationId",
                table: "Aircrafts",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Compartments_AircraftId",
                table: "Compartments",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Machineries_CompartmentId",
                table: "Machineries",
                column: "CompartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MercenaryReputations_SyndicateId",
                table: "MercenaryReputations",
                column: "SyndicateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftCrewsJT");

            migrationBuilder.DropTable(
                name: "EnergySystems");

            migrationBuilder.DropTable(
                name: "EnvironmentalSystems");

            migrationBuilder.DropTable(
                name: "MercenaryReputations");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "CrimeSyndicates");

            migrationBuilder.DropTable(
                name: "Mercenaries");

            migrationBuilder.DropTable(
                name: "Machineries");

            migrationBuilder.DropTable(
                name: "Compartments");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "AircraftSpecifications");
        }
    }
}
