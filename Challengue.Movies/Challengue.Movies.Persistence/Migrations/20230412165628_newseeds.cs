using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Movies.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("99b413d5-626c-46c0-a687-6b1cf12dbcad"), "roberto@hireme.com", new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1573), null, null, "Comedy" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("70add475-5bfc-499d-817e-90a301378f22"),
                columns: new[] { "CreatedDate", "Name", "ReleaseDate", "Synopsis" },
                values: new object[] { new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1548), "The Basement", new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1547), "College students trapped in a haunted house with a living serial killer." });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: new Guid("b66bdfdb-f178-434e-bbc5-2d1b06d75b5c"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CategoryId", "CreatedBy", "CreatedDate", "ImagePoster", "LastModifiedBy", "LastModifiedDate", "Name", "ReleaseDate", "Synopsis" },
                values: new object[] { new Guid("2c3220c4-c111-4701-9d04-394bc4e9a2e8"), new Guid("99b413d5-626c-46c0-a687-6b1cf12dbcad"), "roberto@hireme.com", new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1583), null, null, null, "The Wedding Crasher", new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1582), "A wedding crasher falls for a crime boss’s daughter and faces hilarious challenges" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "MovieId", "RateOption", "RateUser" },
                values: new object[] { new Guid("6566622d-a07c-4307-9d57-7fe4eb1d266f"), "roberto@hireme.com", new DateTime(2023, 4, 12, 10, 56, 28, 729, DateTimeKind.Local).AddTicks(1591), null, null, new Guid("2c3220c4-c111-4701-9d04-394bc4e9a2e8"), 5, "roberto@hireme.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: new Guid("6566622d-a07c-4307-9d57-7fe4eb1d266f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("2c3220c4-c111-4701-9d04-394bc4e9a2e8"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("99b413d5-626c-46c0-a687-6b1cf12dbcad"));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("70add475-5bfc-499d-817e-90a301378f22"),
                columns: new[] { "CreatedDate", "Name", "ReleaseDate", "Synopsis" },
                values: new object[] { new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4088), "Sharks and Ghosts", new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4087), "Sharks that eat people so then becomes ghosts to guide other people to the sharks to continue the killing cycle" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: new Guid("b66bdfdb-f178-434e-bbc5-2d1b06d75b5c"),
                column: "CreatedDate",
                value: new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4099));
        }
    }
}
