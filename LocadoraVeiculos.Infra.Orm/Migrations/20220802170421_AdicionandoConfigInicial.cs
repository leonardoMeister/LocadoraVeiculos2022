using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class AdicionandoConfigInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(20)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(20)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoCliente = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONDUTORES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cnh = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValidadeCnh = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONDUTORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Login = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmicao = table.Column<DateTime>(type: "datetime", nullable: false),
                    TipoPerfil = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_GRUPOVEICULOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GRUPOVEICULOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TAXAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAXAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PLANOCOBRANCA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPlano = table.Column<string>(type: "varchar(100)", nullable: false),
                    ValorDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteKM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorKM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANOCOBRANCA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PLANOCOBRANCA_TB_GRUPOVEICULOS_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TB_GRUPOVEICULOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadeTanque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GrupoVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_VEICULO_TB_GRUPOVEICULOS_GrupoVeiculosId",
                        column: x => x.GrupoVeiculosId,
                        principalTable: "TB_GRUPOVEICULOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    DataRealDaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEstimadaDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuilometragemInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NivelTanqueEnumInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelTanqueEnumDevolucao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDevolucao = table.Column<bool>(type: "bit", nullable: false),
                    QuilometragemFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLocacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_PLANOCOBRANCA_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULO_GrupoVeiculosId",
                table: "TB_VEICULO",
                column: "GrupoVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxas");

            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "TB_LOCACAO");

            migrationBuilder.DropTable(
                name: "TB_TAXAS");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");

            migrationBuilder.DropTable(
                name: "TB_CONDUTORES");

            migrationBuilder.DropTable(
                name: "TB_PLANOCOBRANCA");

            migrationBuilder.DropTable(
                name: "TB_VEICULO");

            migrationBuilder.DropTable(
                name: "TB_GRUPOVEICULOS");
        }
    }
}
