using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeteriaMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeItem = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item__727E83EB21E04C67", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    Senha = table.Column<byte[]>(type: "varbinary(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__2B3DE798BC46B99B", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Inter_ItemUsuario",
                columns: table => new
                {
                    Inter_ItemUsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inter_It__5172E7B6EF58EE29", x => x.Inter_ItemUsuarioID);
                    table.ForeignKey(
                        name: "FK_Inter_Item",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_Inter_Usuario",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inter_ItemUsuario_ItemID",
                table: "Inter_ItemUsuario",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Inter_ItemUsuario_UsuarioID",
                table: "Inter_ItemUsuario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__A9D10534C7A82BC2",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inter_ItemUsuario");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
