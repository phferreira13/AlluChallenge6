using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allu.Challenge6.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_Tutor_AddExtraFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Tutores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Tutores",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobre",
                table: "Tutores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Tutores",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "Sobre",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Tutores");
        }
    }
}
