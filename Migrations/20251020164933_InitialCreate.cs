using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CrudParking.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseValueByHour = table.Column<double>(type: "double precision", nullable: false),
                    BaseValueByFraction = table.Column<double>(type: "double precision", nullable: false),
                    MaxDay = table.Column<decimal>(type: "numeric", nullable: true),
                    TimeHopeMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Plate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Titularname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VehicleMonthlyID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehiclesM_VehiclesM_VehicleMonthlyID",
                        column: x => x.VehicleMonthlyID,
                        principalTable: "VehiclesM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Plate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Closed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Operators_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monthlies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleMonthlyID = table.Column<int>(type: "integer", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthlies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Monthlies_VehiclesM_VehicleMonthlyID",
                        column: x => x.VehicleMonthlyID,
                        principalTable: "VehiclesM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketID = table.Column<int>(type: "integer", nullable: false),
                    OperatorID = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PayMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DatePay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pays_Operators_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Operators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pays_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monthlies_VehicleMonthlyID",
                table: "Monthlies",
                column: "VehicleMonthlyID");

            migrationBuilder.CreateIndex(
                name: "IX_Pays_OperatorID",
                table: "Pays",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Pays_TicketID",
                table: "Pays",
                column: "TicketID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OperatorID",
                table: "Tickets",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesM_VehicleMonthlyID",
                table: "VehiclesM",
                column: "VehicleMonthlyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monthlies");

            migrationBuilder.DropTable(
                name: "Pays");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "VehiclesM");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Operators");
        }
    }
}
