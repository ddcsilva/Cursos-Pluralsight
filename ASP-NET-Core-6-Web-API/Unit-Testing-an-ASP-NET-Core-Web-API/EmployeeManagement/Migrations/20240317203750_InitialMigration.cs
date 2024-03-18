using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EhNovo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Empresa = table.Column<string>(type: "TEXT", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AnosDeServico = table.Column<int>(type: "INTEGER", nullable: false),
                    Salario = table.Column<decimal>(type: "TEXT", nullable: false),
                    AumentoMinimoConcedido = table.Column<bool>(type: "INTEGER", nullable: false),
                    NivelCargo = table.Column<int>(type: "INTEGER", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioInternoCurso",
                columns: table => new
                {
                    CursosParticipadosId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FuncionariosQueParticiparamId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioInternoCurso", x => new { x.CursosParticipadosId, x.FuncionariosQueParticiparamId });
                    table.ForeignKey(
                        name: "FK_FuncionarioInternoCurso_Courses_CursosParticipadosId",
                        column: x => x.CursosParticipadosId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioInternoCurso_InternalEmployees_FuncionariosQueParticiparamId",
                        column: x => x.FuncionariosQueParticiparamId,
                        principalTable: "InternalEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "EhNovo", "Title" },
                values: new object[,]
                {
                    { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), false, "Respeitando Seus Colegas" },
                    { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), false, "Introdução à Empresa" },
                    { new Guid("844e14ce-c055-49e9-9610-855669c9859b"), false, "Atendimento ao Cliente 101" },
                    { new Guid("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"), false, "Gestão de Desastres 101" },
                    { new Guid("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"), false, "Atendimento ao Cliente - Avançado" }
                });

            migrationBuilder.InsertData(
                table: "ExternalEmployees",
                columns: new[] { "Id", "Empresa", "PrimeiroNome", "Sobrenome" },
                values: new object[] { new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb"), "Tecnologia para Todos, Inc", "Amanda", "Smith" });

            migrationBuilder.InsertData(
                table: "InternalEmployees",
                columns: new[] { "Id", "AnosDeServico", "AumentoMinimoConcedido", "NivelCargo", "PrimeiroNome", "Salario", "Sobrenome" },
                values: new object[,]
                {
                    { new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb"), 2, false, 2, "Megan", 3000m, "Jones" },
                    { new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f"), 3, true, 1, "Jaimy", 3400m, "Johnson" }
                });

            migrationBuilder.InsertData(
                table: "FuncionarioInternoCurso",
                columns: new[] { "CursosParticipadosId", "FuncionariosQueParticiparamId" },
                values: new object[,]
                {
                    { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                    { new Guid("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                    { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), new Guid("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
                    { new Guid("37e03ca7-c730-4351-834c-b66f280cdb01"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
                    { new Guid("844e14ce-c055-49e9-9610-855669c9859b"), new Guid("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioInternoCurso_FuncionariosQueParticiparamId",
                table: "FuncionarioInternoCurso",
                column: "FuncionariosQueParticiparamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalEmployees");

            migrationBuilder.DropTable(
                name: "FuncionarioInternoCurso");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "InternalEmployees");
        }
    }
}
