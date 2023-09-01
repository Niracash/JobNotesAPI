using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Todos",
                newName: "IsDone");

            migrationBuilder.RenameColumn(
                name: "CompletedDate",
                table: "Todos",
                newName: "DoneDate");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "Todos",
                newName: "IsCompleted");

            migrationBuilder.RenameColumn(
                name: "DoneDate",
                table: "Todos",
                newName: "CompletedDate");
        }
    }
}
