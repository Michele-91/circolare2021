using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reti.Circolare.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBW_Edifici",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponibile = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBW_Edifici", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBW_Risorse",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailReti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPersonale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abilitato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBW_Risorse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBW_Sale",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdificioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBW_Sale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBW_Sale_TBW_Edifici_EdificioId",
                        column: x => x.EdificioId,
                        principalTable: "TBW_Edifici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBW_Prenotazioni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RisorsaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBW_Prenotazioni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBW_Prenotazioni_TBW_Risorse_RisorsaId",
                        column: x => x.RisorsaId,
                        principalTable: "TBW_Risorse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBW_Prenotazioni_TBW_Sale_SalaId",
                        column: x => x.SalaId,
                        principalTable: "TBW_Sale",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBW_Prenotazioni_ID",
                table: "TBW_Prenotazioni",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBW_Prenotazioni_RisorsaId",
                table: "TBW_Prenotazioni",
                column: "RisorsaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBW_Prenotazioni_SalaId",
                table: "TBW_Prenotazioni",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBW_Sale_EdificioId",
                table: "TBW_Sale",
                column: "EdificioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBW_Prenotazioni");

            migrationBuilder.DropTable(
                name: "TBW_Risorse");

            migrationBuilder.DropTable(
                name: "TBW_Sale");

            migrationBuilder.DropTable(
                name: "TBW_Edifici");
        }
    }
}
