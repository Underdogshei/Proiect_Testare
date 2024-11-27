using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Testare.Migrations
{
    /// <inheritdoc />
    public partial class AddOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_OwnerID",
                table: "Appointment",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Owner_OwnerID",
                table: "Appointment",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Owner_OwnerID",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_OwnerID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
