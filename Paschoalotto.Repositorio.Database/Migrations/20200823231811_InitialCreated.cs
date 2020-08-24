using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paschoalotto.Repositorio.Database.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "provedordados");

            migrationBuilder.CreateTable(
                name: "DividaCliente",
                schema: "provedordados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DividaCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoJuros",
                schema: "provedordados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    TipoJuros = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Criacao = table.Column<DateTime>(nullable: false),
                    Alteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoJuros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propostas",
                schema: "provedordados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    JurosId = table.Column<int>(nullable: false),
                    DividaId = table.Column<int>(nullable: false),
                    DataProposta = table.Column<DateTime>(nullable: false),
                    QtdMaximaParcelas = table.Column<int>(nullable: false),
                    ContatoColaborador = table.Column<string>(nullable: true),
                    PorcentagemComissao = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propostas_DividaCliente_DividaId",
                        column: x => x.DividaId,
                        principalSchema: "provedordados",
                        principalTable: "DividaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propostas_TipoJuros_JurosId",
                        column: x => x.JurosId,
                        principalSchema: "provedordados",
                        principalTable: "TipoJuros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcordoCliente",
                schema: "provedordados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    DataAcordo = table.Column<DateTime>(nullable: false),
                    PropostaId = table.Column<int>(nullable: false),
                    Comissao = table.Column<double>(nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    TaxaJuros = table.Column<double>(nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    VencimentoParcelas = table.Column<string>(nullable: true),
                    TipoJuros = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcordoCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcordoCliente_Propostas_PropostaId",
                        column: x => x.PropostaId,
                        principalSchema: "provedordados",
                        principalTable: "Propostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcordoCliente_PropostaId",
                schema: "provedordados",
                table: "AcordoCliente",
                column: "PropostaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Propostas_DividaId",
                schema: "provedordados",
                table: "Propostas",
                column: "DividaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Propostas_JurosId",
                schema: "provedordados",
                table: "Propostas",
                column: "JurosId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcordoCliente",
                schema: "provedordados");

            migrationBuilder.DropTable(
                name: "Propostas",
                schema: "provedordados");

            migrationBuilder.DropTable(
                name: "DividaCliente",
                schema: "provedordados");

            migrationBuilder.DropTable(
                name: "TipoJuros",
                schema: "provedordados");
        }
    }
}
