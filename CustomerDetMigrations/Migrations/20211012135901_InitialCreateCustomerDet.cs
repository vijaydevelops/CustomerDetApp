using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerDetMigrations.Migrations
{
    public partial class InitialCreateCustomerDet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    countryName = table.Column<string>(type: "TEXT", nullable: true),
                    countryCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    custCode = table.Column<string>(type: "TEXT", nullable: true),
                    custName = table.Column<string>(type: "TEXT", nullable: true),
                    custAddress = table.Column<string>(type: "TEXT", nullable: true),
                    country = table.Column<int>(type: "INTEGER", nullable: false),
                    custEmail = table.Column<string>(type: "TEXT", nullable: true),
                    custContactNo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 1L, "IND", "INDIA" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 18L, "FR", "FRANCE" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 17L, "DSH", "GERMANY" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 16L, "UK", "UNITED KINGDOM" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 15L, "USSR", "RUSSIAN FEDERATION" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 14L, "SKOR", "SOUTH KOREA" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 13L, "JPN", "JAPAN" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 12L, "VTM", "VIETNAM" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 11L, "CMB", "CAMBODIA" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 10L, "THL", "THAILAND" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 9L, "MYN", "MYANMAR" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 8L, "AFG", "AFGHANISTHAN" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 7L, "NPL", "NEPAL" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 6L, "CHN", "CHINA" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 5L, "BHT", "BHUTAN" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 4L, "BNG", "BANGLADESH" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 3L, "SL", "SRI LANKA" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "countryCode", "countryName" },
                values: new object[] { 2L, "PAK", "PAKISTAN" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "country", "custAddress", "custCode", "custContactNo", "custEmail", "custName" },
                values: new object[] { 1L, 1, "69, Jameson street, Nagpur", "C0101", "+919456789456", "jameson@custdemoapi.com", "NAGPUR JAMESON TRADERS" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "country", "custAddress", "custCode", "custContactNo", "custEmail", "custName" },
                values: new object[] { 2L, 1, "12/75, Bahadur Sastri Nagar, Indranagar, Bangalore", "C0102", "+919475645456", "laji.pan@gmail.com", "LALJI PAN MASALA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
