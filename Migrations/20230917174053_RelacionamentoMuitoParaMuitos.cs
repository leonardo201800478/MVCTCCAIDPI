using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTCCAIDPI.Migrations
{
    public partial class RelacionamentoMuitoParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicPacient",
                columns: table => new
                {
                    MedicsMedicId = table.Column<int>(type: "int", nullable: false),
                    PacientsPacientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicPacient", x => new { x.MedicsMedicId, x.PacientsPacientId });
                    table.ForeignKey(
                        name: "FK_MedicPacient_Medics_MedicsMedicId",
                        column: x => x.MedicsMedicId,
                        principalTable: "Medics",
                        principalColumn: "MedicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicPacient_Pacients_PacientsPacientId",
                        column: x => x.PacientsPacientId,
                        principalTable: "Pacients",
                        principalColumn: "PacientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicPacient_PacientsPacientId",
                table: "MedicPacient",
                column: "PacientsPacientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicPacient");
        }
    }
}
