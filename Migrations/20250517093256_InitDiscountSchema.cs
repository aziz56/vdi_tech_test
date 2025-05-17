using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Technical_TestVDI.Migrations
{
    /// <inheritdoc />
    public partial class InitDiscountSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransaksiId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointReward = table.Column<int>(type: "int", nullable: false),
                    TotalBelanja = table.Column<double>(type: "float", nullable: false),
                    Diskon = table.Column<double>(type: "float", nullable: false),
                    TotalBayar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
