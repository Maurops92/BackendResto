using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_back.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MENU__C99ED250A5C18D2A", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "ROL",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false),
                    RolName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROL__F92302D1C9FC0871", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "TURNOS",
                columns: table => new
                {
                    TurnoID = table.Column<int>(type: "int", nullable: false),
                    TurnoName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TURNOS__AD3E2EB4CA9AABB7", x => x.TurnoID);
                });

            migrationBuilder.CreateTable(
                name: "CEO",
                columns: table => new
                {
                    CEOID = table.Column<int>(type: "int", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CEO__5D8217436A693392", x => x.CEOID);
                    table.ForeignKey(
                        name: "FK__CEO__RolID__2B3F6F97",
                        column: x => x.RolID,
                        principalTable: "ROL",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "GERENTES",
                columns: table => new
                {
                    GerenteID = table.Column<int>(type: "int", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GERENTES__64E13472F4EF1238", x => x.GerenteID);
                    table.ForeignKey(
                        name: "FK__GERENTES__RolID__276EDEB3",
                        column: x => x.RolID,
                        principalTable: "ROL",
                        principalColumn: "RolID");
                });

            migrationBuilder.CreateTable(
                name: "MOZOS",
                columns: table => new
                {
                    MozoID = table.Column<int>(type: "int", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    TurnoID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MOZOS__A01CDF5C4FC7A688", x => x.MozoID);
                    table.ForeignKey(
                        name: "FK__MOZOS__RolID__33D4B598",
                        column: x => x.RolID,
                        principalTable: "ROL",
                        principalColumn: "RolID");
                    table.ForeignKey(
                        name: "FK__MOZOS__TurnoID__34C8D9D1",
                        column: x => x.TurnoID,
                        principalTable: "TURNOS",
                        principalColumn: "TurnoID");
                });

            migrationBuilder.CreateTable(
                name: "MESAS",
                columns: table => new
                {
                    MesaID = table.Column<int>(type: "int", nullable: false),
                    MozoID = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MESAS__6A4196C82224C6D3", x => x.MesaID);
                    table.ForeignKey(
                        name: "FK__MESAS__MozoID__3C69FB99",
                        column: x => x.MozoID,
                        principalTable: "MOZOS",
                        principalColumn: "MozoID");
                });

            migrationBuilder.CreateTable(
                name: "VENTAS",
                columns: table => new
                {
                    VentaID = table.Column<int>(type: "int", nullable: false),
                    MozoID = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    SaleDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VENTAS__5B41514CAF98D370", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK__VENTAS__MozoID__37A5467C",
                        column: x => x.MozoID,
                        principalTable: "MOZOS",
                        principalColumn: "MozoID");
                });

            migrationBuilder.CreateTable(
                name: "DETALLE_VENTA",
                columns: table => new
                {
                    VentaID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETALLE___47D8BC69A480D92C", x => new { x.VentaID, x.MenuID });
                    table.ForeignKey(
                        name: "FK__DETALLE_V__MenuI__403A8C7D",
                        column: x => x.MenuID,
                        principalTable: "MENU",
                        principalColumn: "MenuID");
                    table.ForeignKey(
                        name: "FK__DETALLE_V__Venta__3F466844",
                        column: x => x.VentaID,
                        principalTable: "VENTAS",
                        principalColumn: "VentaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CEO_RolID",
                table: "CEO",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_DETALLE_VENTA_MenuID",
                table: "DETALLE_VENTA",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_GERENTES_RolID",
                table: "GERENTES",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_MESAS_MozoID",
                table: "MESAS",
                column: "MozoID");

            migrationBuilder.CreateIndex(
                name: "IX_MOZOS_RolID",
                table: "MOZOS",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_MOZOS_TurnoID",
                table: "MOZOS",
                column: "TurnoID");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_MozoID",
                table: "VENTAS",
                column: "MozoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEO");

            migrationBuilder.DropTable(
                name: "DETALLE_VENTA");

            migrationBuilder.DropTable(
                name: "GERENTES");

            migrationBuilder.DropTable(
                name: "MESAS");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "VENTAS");

            migrationBuilder.DropTable(
                name: "MOZOS");

            migrationBuilder.DropTable(
                name: "ROL");

            migrationBuilder.DropTable(
                name: "TURNOS");
        }
    }
}
