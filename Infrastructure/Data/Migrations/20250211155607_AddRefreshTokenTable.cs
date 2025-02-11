using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopClothing.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4854b33d-301f-4a18-87c6-47ae461e8c41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67cc9c22-4112-4719-8c71-3b9f3f37146d");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("017b0052-cf95-4d50-9363-c5a530a1f1de"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("06ea971c-6feb-4ca3-a0d5-aa09f0cacb20"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("26c2c040-a83d-4742-8838-d606131b3f20"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("4833a2df-0c28-4d2b-844f-88f1c3894655"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("4d150749-a421-4a1a-ae1e-5d67f540ed51"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("96f04fea-d5c2-4b45-9152-6f1991851a21"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("a5a6cc4a-74a0-41f4-b248-675a29bcb06c"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("ae00006f-f073-4940-b930-a379c8703798"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("ae462e07-8976-44ef-9cc5-f9469d4e936f"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("c3e5aa52-1190-4741-9f89-f6bd2eb7811b"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("d9d52d5c-a9db-4e7b-b898-308e8b7ea5d7"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("e3c86f95-e475-4810-bdde-90895c3c3aaa"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("e5c095d3-7fc1-4888-bb5b-3703a41fa6d6"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("06d36083-5e6f-405a-8aba-bcd58c902b94"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("126746a5-e9f5-4556-841e-a7b511cdfa60"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("3dafd5a9-98a4-4451-af0f-844ae6a4bd31"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("55557c5e-93ab-46f8-b988-6a5af528899a"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("9e7c7e76-acca-416a-9689-067ed415c432"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("b3177eb2-8e24-464e-9314-090c15318d84"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("c3ecdf33-88f7-4042-8e3c-834183fef29c"));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19de195b-43f4-4452-8cfa-4814f6879aea", null, "Admin", "ADMIN" },
                    { "e4d2e322-2a9d-4827-9119-623ac66e923b", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "ColorHexCode", "ColorName" },
                values: new object[,]
                {
                    { new Guid("12c2a9f7-bc2f-4d74-92ba-7983512adbd2"), "#FFFFFF", "White" },
                    { new Guid("16697ff4-0197-4fd0-b707-a392bd34ff51"), "#800080", "Purple" },
                    { new Guid("48fac199-74a7-488b-9ff5-dba814846e92"), "#C0C0C0", "Silver" },
                    { new Guid("5b4f33f7-3fe3-44ad-a6a1-0fc0bfa3f935"), "#FFC0CB", "Pink" },
                    { new Guid("60b378f1-5658-4edd-8fc1-884d12e79ee7"), "#FFA500", "Orange" },
                    { new Guid("6ea4301a-f34d-411e-9558-8205f3e04562"), "#008000", "Green" },
                    { new Guid("836a1f80-cf22-4a36-a20a-afa0262dbe51"), "#FFD700", "Gold" },
                    { new Guid("abd44013-2d24-45cf-868b-192126575a11"), "#FF0000", "Red" },
                    { new Guid("bd9964ca-9a77-4af2-aa5f-d19ec75cc16c"), "#000000", "Black" },
                    { new Guid("cc2f2dab-d44b-4f49-86ed-543160f3b3e3"), "#FFFF00", "Yellow" },
                    { new Guid("d4bd7a72-e77e-4f72-899a-5cacb54fa960"), "#0000FF", "Blue" },
                    { new Guid("f78f5292-f6f9-4c19-8350-c5357b9d3f23"), "#808080", "Gray" },
                    { new Guid("f7bf42b8-cb3d-4801-9992-a0bc64b569e9"), "#A52A2A", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "SizeName" },
                values: new object[,]
                {
                    { new Guid("07e7c11d-e1e9-4ed9-a637-c3e15161b351"), "XXXL" },
                    { new Guid("4f590881-ab8e-4f91-8e3e-703f8b1fc82f"), "L" },
                    { new Guid("b59e5706-c57c-49ea-b95f-15b0cdee5e77"), "M" },
                    { new Guid("b9ca1a9d-e253-4751-8fdc-72aa90246cd3"), "XL" },
                    { new Guid("d9baef86-26de-40b5-8ef3-6eb89244a73d"), "XS" },
                    { new Guid("deda18e1-8613-43c2-b22d-87bc5b543f6d"), "S" },
                    { new Guid("df6e60e4-c073-451f-8146-ef2158759489"), "XXL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19de195b-43f4-4452-8cfa-4814f6879aea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d2e322-2a9d-4827-9119-623ac66e923b");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("12c2a9f7-bc2f-4d74-92ba-7983512adbd2"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("16697ff4-0197-4fd0-b707-a392bd34ff51"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("48fac199-74a7-488b-9ff5-dba814846e92"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("5b4f33f7-3fe3-44ad-a6a1-0fc0bfa3f935"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("60b378f1-5658-4edd-8fc1-884d12e79ee7"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("6ea4301a-f34d-411e-9558-8205f3e04562"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("836a1f80-cf22-4a36-a20a-afa0262dbe51"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("abd44013-2d24-45cf-868b-192126575a11"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("bd9964ca-9a77-4af2-aa5f-d19ec75cc16c"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("cc2f2dab-d44b-4f49-86ed-543160f3b3e3"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("d4bd7a72-e77e-4f72-899a-5cacb54fa960"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("f78f5292-f6f9-4c19-8350-c5357b9d3f23"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("f7bf42b8-cb3d-4801-9992-a0bc64b569e9"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("07e7c11d-e1e9-4ed9-a637-c3e15161b351"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("4f590881-ab8e-4f91-8e3e-703f8b1fc82f"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("b59e5706-c57c-49ea-b95f-15b0cdee5e77"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("b9ca1a9d-e253-4751-8fdc-72aa90246cd3"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("d9baef86-26de-40b5-8ef3-6eb89244a73d"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("deda18e1-8613-43c2-b22d-87bc5b543f6d"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("df6e60e4-c073-451f-8146-ef2158759489"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4854b33d-301f-4a18-87c6-47ae461e8c41", null, "Admin", "ADMIN" },
                    { "67cc9c22-4112-4719-8c71-3b9f3f37146d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "ColorHexCode", "ColorName" },
                values: new object[,]
                {
                    { new Guid("017b0052-cf95-4d50-9363-c5a530a1f1de"), "#808080", "Gray" },
                    { new Guid("06ea971c-6feb-4ca3-a0d5-aa09f0cacb20"), "#0000FF", "Blue" },
                    { new Guid("26c2c040-a83d-4742-8838-d606131b3f20"), "#FFA500", "Orange" },
                    { new Guid("4833a2df-0c28-4d2b-844f-88f1c3894655"), "#C0C0C0", "Silver" },
                    { new Guid("4d150749-a421-4a1a-ae1e-5d67f540ed51"), "#FFC0CB", "Pink" },
                    { new Guid("96f04fea-d5c2-4b45-9152-6f1991851a21"), "#800080", "Purple" },
                    { new Guid("a5a6cc4a-74a0-41f4-b248-675a29bcb06c"), "#FFFF00", "Yellow" },
                    { new Guid("ae00006f-f073-4940-b930-a379c8703798"), "#000000", "Black" },
                    { new Guid("ae462e07-8976-44ef-9cc5-f9469d4e936f"), "#008000", "Green" },
                    { new Guid("c3e5aa52-1190-4741-9f89-f6bd2eb7811b"), "#A52A2A", "Brown" },
                    { new Guid("d9d52d5c-a9db-4e7b-b898-308e8b7ea5d7"), "#FFFFFF", "White" },
                    { new Guid("e3c86f95-e475-4810-bdde-90895c3c3aaa"), "#FFD700", "Gold" },
                    { new Guid("e5c095d3-7fc1-4888-bb5b-3703a41fa6d6"), "#FF0000", "Red" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "SizeName" },
                values: new object[,]
                {
                    { new Guid("06d36083-5e6f-405a-8aba-bcd58c902b94"), "M" },
                    { new Guid("126746a5-e9f5-4556-841e-a7b511cdfa60"), "L" },
                    { new Guid("3dafd5a9-98a4-4451-af0f-844ae6a4bd31"), "S" },
                    { new Guid("55557c5e-93ab-46f8-b988-6a5af528899a"), "XXL" },
                    { new Guid("9e7c7e76-acca-416a-9689-067ed415c432"), "XL" },
                    { new Guid("b3177eb2-8e24-464e-9314-090c15318d84"), "XXXL" },
                    { new Guid("c3ecdf33-88f7-4042-8e3c-834183fef29c"), "XS" }
                });
        }
    }
}
