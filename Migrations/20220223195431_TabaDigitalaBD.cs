using Microsoft.EntityFrameworkCore.Migrations;

namespace Taba_Digital.Migrations
{
    public partial class TabaDigitalaBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aldeias",
                columns: table => new
                {
                    Id_Aldeia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aldeias", x => x.Id_Aldeia);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "Necessidades",
                columns: table => new
                {
                    Id_Necessidades = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Necessidades", x => x.Id_Necessidades);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id_Pessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id_Pessoa);
                });

            migrationBuilder.CreateTable(
                name: "Solicita",
                columns: table => new
                {
                    Id_Solicita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AldeiaId_Aldeia = table.Column<int>(type: "int", nullable: false),
                    NecessidadesId_necessidades = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicita", x => x.Id_Solicita);
                    table.ForeignKey(
                        name: "FK_Solicita_Aldeias_AldeiaId_Aldeia",
                        column: x => x.AldeiaId_Aldeia,
                        principalTable: "Aldeias",
                        principalColumn: "Id_Aldeia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicita_Necessidades_NecessidadesId_necessidades",
                        column: x => x.NecessidadesId_necessidades,
                        principalTable: "Necessidades",
                        principalColumn: "Id_Necessidades",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doacoes",
                columns: table => new
                {
                    Id_Doacoes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_contribuicoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PessoaId_Pessoa = table.Column<int>(type: "int", nullable: false),
                    AldeiaId_Aldeia = table.Column<int>(type: "int", nullable: false),
                    EmpresaId_Empresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacoes", x => x.Id_Doacoes);
                    table.ForeignKey(
                        name: "FK_Doacoes_Aldeias_AldeiaId_Aldeia",
                        column: x => x.AldeiaId_Aldeia,
                        principalTable: "Aldeias",
                        principalColumn: "Id_Aldeia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacoes_Empresas_EmpresaId_Empresa",
                        column: x => x.EmpresaId_Empresa,
                        principalTable: "Empresas",
                        principalColumn: "Id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacoes_Pessoa_PessoaId_Pessoa",
                        column: x => x.PessoaId_Pessoa,
                        principalTable: "Pessoa",
                        principalColumn: "Id_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_AldeiaId_Aldeia",
                table: "Doacoes",
                column: "AldeiaId_Aldeia");

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_EmpresaId_Empresa",
                table: "Doacoes",
                column: "EmpresaId_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_PessoaId_Pessoa",
                table: "Doacoes",
                column: "PessoaId_Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Solicita_AldeiaId_Aldeia",
                table: "Solicita",
                column: "AldeiaId_Aldeia");

            migrationBuilder.CreateIndex(
                name: "IX_Solicita_NecessidadesId_necessidades",
                table: "Solicita",
                column: "NecessidadesId_necessidades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacoes");

            migrationBuilder.DropTable(
                name: "Solicita");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Aldeias");

            migrationBuilder.DropTable(
                name: "Necessidades");
        }
    }
}
