using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Movies.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Category_MovieId",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"), "roberto@hireme.com", new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(3991), null, null, "Terror" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CategoryId", "CreatedBy", "CreatedDate", "ImagePoster", "LastModifiedBy", "LastModifiedDate", "Name", "ReleaseDate", "Synopsis" },
                values: new object[] { new Guid("70add475-5bfc-499d-817e-90a301378f22"), new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"), "roberto@hireme.com", new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4088), null, null, null, "Sharks and Ghosts", new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4087), "Sharks that eat people so then becomes ghosts to guide other people to the sharks to continue the killing cycle" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "MovieId", "RateOption", "RateUser" },
                values: new object[] { new Guid("b66bdfdb-f178-434e-bbc5-2d1b06d75b5c"), "roberto@hireme.com", new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4099), null, null, new Guid("70add475-5bfc-499d-817e-90a301378f22"), 5, "roberto@hireme.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Category_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Category_CategoryId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: new Guid("b66bdfdb-f178-434e-bbc5-2d1b06d75b5c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("70add475-5bfc-499d-817e-90a301378f22"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"));

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Category_MovieId",
                table: "Movies",
                column: "MovieId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
