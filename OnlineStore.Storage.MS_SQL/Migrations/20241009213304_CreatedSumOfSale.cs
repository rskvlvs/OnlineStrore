using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSumOfSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TotalSum",
                table: "Sales",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSum",
                table: "Sales");
        }
    }
}
