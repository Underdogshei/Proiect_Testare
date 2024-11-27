using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Testare.Migrations
{
    /// <inheritdoc />
    public partial class Member : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MemberID",
                table: "Appointment",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Member_MemberID",
                table: "Appointment",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Member_MemberID",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_MemberID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Appointment");
        }
    }
}
