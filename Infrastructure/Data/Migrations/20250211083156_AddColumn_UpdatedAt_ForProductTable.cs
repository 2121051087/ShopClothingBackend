using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopClothing.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_UpdatedAt_ForProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "423e7460-f072-4e4c-806a-dbb6317c4965");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d4a09de-3fa4-4f2f-a96a-f7672bfe83ca");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("1b49af0a-e6d3-46f7-b818-1c3acbec255a"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("48e46b6b-da55-45d3-9d0c-bed95bbc5af1"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("529b94b9-a559-44c0-8d7e-caa0a4401ce9"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("68459d1a-563f-4a6b-9a45-c55189b0370b"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("68f35fdf-6f00-4ffa-bbdb-fb7cc784b278"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("735610df-47c3-4255-a33a-393a5859e773"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("7e0c9b16-f491-42fe-bcb8-7f5e38533ceb"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("8fc31980-3ac5-45db-bebc-3dfffbfa666b"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("933c00b5-5142-4f62-b29e-70dd45392e95"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("9c0d1a31-0f07-4bfd-8422-5fb67fa521bf"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("a7b4d363-b39f-476c-8124-d3226d098d0b"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("be646020-e240-45c6-9bf5-f57e182908b1"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "ColorID",
                keyValue: new Guid("ed984d84-31fe-4dce-9e09-82b9ee832655"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("23dd0bda-acd5-4299-883e-66878e598a22"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("37719386-2a51-4aa5-952b-59e28e6fb0e9"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("5d596bfa-dab9-42d4-af9b-aaec14e668b4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("72013087-3c06-45d6-a07a-407acd13c885"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("8124b5fe-fcf2-412b-9c19-c678ffcb8310"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("855ab87e-df37-42cf-a986-4c0a61f2e363"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeID",
                keyValue: new Guid("edb7a952-68cc-49a9-8379-769d1a205793"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "423e7460-f072-4e4c-806a-dbb6317c4965", null, "User", "USER" },
                    { "7d4a09de-3fa4-4f2f-a96a-f7672bfe83ca", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "ColorHexCode", "ColorName" },
                values: new object[,]
                {
                    { new Guid("1b49af0a-e6d3-46f7-b818-1c3acbec255a"), "#A52A2A", "Brown" },
                    { new Guid("48e46b6b-da55-45d3-9d0c-bed95bbc5af1"), "#800080", "Purple" },
                    { new Guid("529b94b9-a559-44c0-8d7e-caa0a4401ce9"), "#808080", "Gray" },
                    { new Guid("68459d1a-563f-4a6b-9a45-c55189b0370b"), "#FFFFFF", "White" },
                    { new Guid("68f35fdf-6f00-4ffa-bbdb-fb7cc784b278"), "#0000FF", "Blue" },
                    { new Guid("735610df-47c3-4255-a33a-393a5859e773"), "#FF0000", "Red" },
                    { new Guid("7e0c9b16-f491-42fe-bcb8-7f5e38533ceb"), "#FFA500", "Orange" },
                    { new Guid("8fc31980-3ac5-45db-bebc-3dfffbfa666b"), "#008000", "Green" },
                    { new Guid("933c00b5-5142-4f62-b29e-70dd45392e95"), "#C0C0C0", "Silver" },
                    { new Guid("9c0d1a31-0f07-4bfd-8422-5fb67fa521bf"), "#FFC0CB", "Pink" },
                    { new Guid("a7b4d363-b39f-476c-8124-d3226d098d0b"), "#000000", "Black" },
                    { new Guid("be646020-e240-45c6-9bf5-f57e182908b1"), "#FFD700", "Gold" },
                    { new Guid("ed984d84-31fe-4dce-9e09-82b9ee832655"), "#FFFF00", "Yellow" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "SizeName" },
                values: new object[,]
                {
                    { new Guid("23dd0bda-acd5-4299-883e-66878e598a22"), "XXXL" },
                    { new Guid("37719386-2a51-4aa5-952b-59e28e6fb0e9"), "XXL" },
                    { new Guid("5d596bfa-dab9-42d4-af9b-aaec14e668b4"), "L" },
                    { new Guid("72013087-3c06-45d6-a07a-407acd13c885"), "M" },
                    { new Guid("8124b5fe-fcf2-412b-9c19-c678ffcb8310"), "XL" },
                    { new Guid("855ab87e-df37-42cf-a986-4c0a61f2e363"), "XS" },
                    { new Guid("edb7a952-68cc-49a9-8379-769d1a205793"), "S" }
                });
        }
    }
}
