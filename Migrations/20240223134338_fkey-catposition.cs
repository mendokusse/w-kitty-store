using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kitty_store.Migrations
{
    /// <inheritdoc />
    public partial class fkeycatposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CatPosition_CatId",
                table: "CatPosition",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatPosition_Cat_CatId",
                table: "CatPosition",
                column: "CatId",
                principalTable: "Cat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatPosition_Cat_CatId",
                table: "CatPosition");

            migrationBuilder.DropIndex(
                name: "IX_CatPosition_CatId",
                table: "CatPosition");
        }
    }
}
