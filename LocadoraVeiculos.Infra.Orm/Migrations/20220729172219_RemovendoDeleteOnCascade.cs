using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class RemovendoDeleteOnCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PLANOCOBRANCA_TB_GRUPOVEICULOS_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA");

            migrationBuilder.CreateTable(
                name: "TB_LOCACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEstimadaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuilometragemInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NivelTanqueEnumInicio = table.Column<int>(type: "int", nullable: false),
                    StatusDevolucao = table.Column<bool>(type: "bit", nullable: false),
                    QuilometragemFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataRealDaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelTanqueEnumDevolucao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOCACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_LOCACAO_TB_CLIENTE_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_LOCACAO_TB_CONDUTORES_CondutoresId",
                        column: x => x.CondutoresId,
                        principalTable: "TB_CONDUTORES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_LOCACAO_TB_GRUPOVEICULOS_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TB_GRUPOVEICULOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_LOCACAO_TB_PLANOCOBRANCA_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TB_PLANOCOBRANCA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_LOCACAO_TB_VEICULO_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TB_VEICULO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxas",
                columns: table => new
                {
                    ListaTaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxas", x => new { x.ListaTaxasId, x.LocacoesId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxas_TB_LOCACAO_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TB_LOCACAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxas_TB_TAXAS_ListaTaxasId",
                        column: x => x.ListaTaxasId,
                        principalTable: "TB_TAXAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxas_LocacoesId",
                table: "LocacaoTaxas",
                column: "LocacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LOCACAO_ClienteId",
                table: "TB_LOCACAO",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LOCACAO_CondutoresId",
                table: "TB_LOCACAO",
                column: "CondutoresId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LOCACAO_GrupoVeiculosId",
                table: "TB_LOCACAO",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LOCACAO_PlanoCobrancaId",
                table: "TB_LOCACAO",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LOCACAO_VeiculoId",
                table: "TB_LOCACAO",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PLANOCOBRANCA_TB_GRUPOVEICULOS_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA",
                column: "GrupoVeiculosId",
                principalTable: "TB_GRUPOVEICULOS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PLANOCOBRANCA_TB_GRUPOVEICULOS_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA");

            migrationBuilder.DropTable(
                name: "LocacaoTaxas");

            migrationBuilder.DropTable(
                name: "TB_LOCACAO");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PLANOCOBRANCA_TB_GRUPOVEICULOS_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA",
                column: "GrupoVeiculosId",
                principalTable: "TB_GRUPOVEICULOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
