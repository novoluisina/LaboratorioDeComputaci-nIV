using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todo_item.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "Todo_items",
                columns: table => new
                {
                    Id_item = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo_items", x => x.Id_item);
                    table.ForeignKey(
                        name: "FK_Todo_items_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Todo_items",
                columns: new[] { "Id_item", "Description", "Title", "UserId" },
                values: new object[] { 1, "La tarea consta de realizar el backend para una todo list. Se debe entregar el 17/4", "Completar tarea Laboratorio", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_user", "Address", "Email", "Name", "State", "UserType" },
                values: new object[,]
                {
                    { 1, "Rivadavia 111", "ngomez@gmail.com", "Nicolas", true, null },
                    { 2, "Colon 212", "juanperez@gmail.com", "Juan", true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_items_UserId",
                table: "Todo_items",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo_items");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
