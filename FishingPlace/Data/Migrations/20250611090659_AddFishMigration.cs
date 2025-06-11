using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingPlace.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFishMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FishingVesselId",
                table: "Owner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FishId",
                table: "FishingVessel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FishId1",
                table: "FishingVessel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_FishingVesselId",
                table: "Owner",
                column: "FishingVesselId");

            migrationBuilder.CreateIndex(
                name: "IX_FishingVessel_FishId",
                table: "FishingVessel",
                column: "FishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FishingVessel_FishId1",
                table: "FishingVessel",
                column: "FishId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FishingVessel_Fish_FishId",
                table: "FishingVessel",
                column: "FishId",
                principalTable: "Fish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FishingVessel_Fish_FishId1",
                table: "FishingVessel",
                column: "FishId1",
                principalTable: "Fish",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_FishingVessel_FishingVesselId",
                table: "Owner",
                column: "FishingVesselId",
                principalTable: "FishingVessel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishingVessel_Fish_FishId",
                table: "FishingVessel");

            migrationBuilder.DropForeignKey(
                name: "FK_FishingVessel_Fish_FishId1",
                table: "FishingVessel");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_FishingVessel_FishingVesselId",
                table: "Owner");

            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropIndex(
                name: "IX_Owner_FishingVesselId",
                table: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_FishingVessel_FishId",
                table: "FishingVessel");

            migrationBuilder.DropIndex(
                name: "IX_FishingVessel_FishId1",
                table: "FishingVessel");

            migrationBuilder.DropColumn(
                name: "FishingVesselId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "FishId",
                table: "FishingVessel");

            migrationBuilder.DropColumn(
                name: "FishId1",
                table: "FishingVessel");
        }
    }
}
