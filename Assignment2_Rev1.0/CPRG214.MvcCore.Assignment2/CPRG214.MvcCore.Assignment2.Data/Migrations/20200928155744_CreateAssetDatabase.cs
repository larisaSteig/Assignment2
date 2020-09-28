using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.MvcCore.Assignment2.Data.Migrations
{
    public partial class CreateAssetDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<string>(nullable: false),
                    AssetTypeID = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeID",
                        column: x => x.AssetTypeID,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 100, "Computers by Dell" });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 200, "Monitor by LG" });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 300, "Phones by Cisco" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeID", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[] { 1, 100, "The most powerful computer you have ever owned", "Dell", "SX-10", "100123963", "abc123" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeID", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[] { 2, 200, "The best monitor for developer", "LG", "LG-X3", "200123963", "def456" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeID", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[] { 3, 300, "The most stylish phone for the ladies", "Cisco", "Cisco-100", "300123963", "ghi789" });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeID",
                table: "Assets",
                column: "AssetTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");
        }
    }
}
