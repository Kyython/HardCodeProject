using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HCP.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomAttributes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CustomAttributeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomAttributeOptions_CustomAttributes_CustomAttributeId",
                        column: x => x.CustomAttributeId,
                        principalTable: "CustomAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_CustomAttribute_Mappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomAttributeOptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_CustomAttribute_Mappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CustomAttribute_Mappings_CustomAttributeOptions_Cus~",
                        column: x => x.CustomAttributeOptionId,
                        principalTable: "CustomAttributeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_CustomAttribute_Mappings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributeOptions_CustomAttributeId",
                table: "CustomAttributeOptions",
                column: "CustomAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributes_CategoryId",
                table: "CustomAttributes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CustomAttribute_Mappings_CustomAttributeOptionId",
                table: "Product_CustomAttribute_Mappings",
                column: "CustomAttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CustomAttribute_Mappings_ProductId",
                table: "Product_CustomAttribute_Mappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_CustomAttribute_Mappings");

            migrationBuilder.DropTable(
                name: "CustomAttributeOptions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomAttributes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
