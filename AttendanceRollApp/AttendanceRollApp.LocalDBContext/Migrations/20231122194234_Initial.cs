using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceRollApp.LocalDBContext.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationMethod",
                columns: table => new
                {
                    dbId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationMethod", x => x.dbId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    NationalID = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    NfcSerialNumbers = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.NationalID);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    dbId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonNationalID = table.Column<string>(type: "TEXT", nullable: false),
                    AuthMethoddbId = table.Column<int>(type: "INTEGER", nullable: false),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: true),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: true),
                    LastTimeSynced = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsSynced = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.dbId);
                    table.ForeignKey(
                        name: "FK_Attendances_AuthenticationMethod_AuthMethoddbId",
                        column: x => x.AuthMethoddbId,
                        principalTable: "AuthenticationMethod",
                        principalColumn: "dbId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Person_PersonNationalID",
                        column: x => x.PersonNationalID,
                        principalTable: "Person",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AuthMethoddbId",
                table: "Attendances",
                column: "AuthMethoddbId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_PersonNationalID",
                table: "Attendances",
                column: "PersonNationalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AuthenticationMethod");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
