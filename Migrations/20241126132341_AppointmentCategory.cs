using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Testare.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppointmentCategory_Appointment_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentCategory_AppointmentID",
                table: "AppointmentCategory",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentCategory_CategoryID",
                table: "AppointmentCategory",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
