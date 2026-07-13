using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Migrations
{
    /// <inheritdoc />
    public partial class addNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Appintments");

            migrationBuilder.RenameColumn(
                name: "DoctrId",
                table: "Appintments",
                newName: "DoctorId");

            migrationBuilder.AddColumn<int>(
                name: "BshinId",
                table: "Appintments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appintmentid = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitNote_Appintments_Appintmentid",
                        column: x => x.Appintmentid,
                        principalTable: "Appintments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appintments_BshinId",
                table: "Appintments",
                column: "BshinId");

            migrationBuilder.CreateIndex(
                name: "IX_Appintments_DoctorId",
                table: "Appintments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitNote_Appintmentid",
                table: "VisitNote",
                column: "Appintmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Appintments_Bshins_BshinId",
                table: "Appintments",
                column: "BshinId",
                principalTable: "Bshins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appintments_Doctor_DoctorId",
                table: "Appintments",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appintments_Bshins_BshinId",
                table: "Appintments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appintments_Doctor_DoctorId",
                table: "Appintments");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "VisitNote");

            migrationBuilder.DropIndex(
                name: "IX_Appintments_BshinId",
                table: "Appintments");

            migrationBuilder.DropIndex(
                name: "IX_Appintments_DoctorId",
                table: "Appintments");

            migrationBuilder.DropColumn(
                name: "BshinId",
                table: "Appintments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appintments",
                newName: "DoctrId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Appintments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
