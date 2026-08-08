using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsActiveColumnInTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TaskItems");
        }
    }
}
