using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.Orm.Migrations
{
    public partial class addDeleteOnCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_VEICULO_GrupoVeiculosId",
                table: "TB_VEICULO");

            migrationBuilder.DropIndex(
                name: "IX_TB_PLANOCOBRANCA_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA");

            migrationBuilder.AlterColumn<string>(
                name: "NomeGrupo",
                table: "TB_GRUPOVEICULOS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULO_GrupoVeiculosId",
                table: "TB_VEICULO",
                column: "GrupoVeiculosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PLANOCOBRANCA_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA",
                column: "GrupoVeiculosId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_VEICULO_GrupoVeiculosId",
                table: "TB_VEICULO");

            migrationBuilder.DropIndex(
                name: "IX_TB_PLANOCOBRANCA_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA");

            migrationBuilder.AlterColumn<string>(
                name: "NomeGrupo",
                table: "TB_GRUPOVEICULOS",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VEICULO_GrupoVeiculosId",
                table: "TB_VEICULO",
                column: "GrupoVeiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PLANOCOBRANCA_GrupoVeiculosId",
                table: "TB_PLANOCOBRANCA",
                column: "GrupoVeiculosId");
        }
    }
}
