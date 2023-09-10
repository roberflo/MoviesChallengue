using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Movies.Identity.Migrations
{
    /// <inheritdoc />
    public partial class seed_more_users_and_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d1a2d232-357e-47ee-834c-ad3c0cd49e12");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4405d273-6c83-4479-9ad3-cff1673349a0", "ff12ffbd-d6db-4fb1-9609-82465479f307", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdd12d1d-fe38-48f3-b6c7-eda7c28496f8", "AQAAAAEAACcQAAAAEEKkIv3jxxf0WIcNwrmsTvl0PiuxccPfQD9awFHpAJpbwOfmBnGpKu7881Kda2q4IQ==", "f028b2e7-3b30-449c-8237-ae6ae5b56699" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0688dfc5-a6fe-4cfe-ab54-9057aa756c7a", 0, "04295a3d-dc74-40a0-8166-46ad25707a18", "ana@user.com", true, "ANA", "FLORES", true, null, "ANA@USER.COM", "ANA", "AQAAAAEAACcQAAAAENHPK1uJSTZSqrxTKEfEOiDsO/sdfurQ5YA38I3C6IkEBIBplMrjTQwWFzYPPzTSMA==", null, false, "00deb7cd-6f80-45be-a598-0c46f1d1aa06", false, "Ana" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4405d273-6c83-4479-9ad3-cff1673349a0", "0688dfc5-a6fe-4cfe-ab54-9057aa756c7a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4405d273-6c83-4479-9ad3-cff1673349a0", "0688dfc5-a6fe-4cfe-ab54-9057aa756c7a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4405d273-6c83-4479-9ad3-cff1673349a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0688dfc5-a6fe-4cfe-ab54-9057aa756c7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bd4dc9a9-c244-420f-ab52-8403dded8bc0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed88516-0deb-410e-b6fc-32c38e8b83e7", "AQAAAAEAACcQAAAAEIRqDVN2VQVCsX27Aw/DwEalI13mKVTHMlUGrMSllqmNjgJheBsMZnHnf8mJ6nrdlw==", "ab135bd5-d86d-4ba7-9477-9df49396404e" });
        }
    }
}
