
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
               name: "Tutor",
               columns: table => new
               {
                   TutorId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   UsuarioId = table.Column<int>(type: "int", nullable: false),
                   CertUniDisc = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Tutor", x => x.TutorId);
               });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosticoTEA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_TutorId",
                table: "Paciente",
                column: "TutorId");

            migrationBuilder.InsertData(
               table: "Tutor",
               columns: new[] { "UsuarioId", "CertUniDisc" },
               values: new object[] {  "1",
                                        "/user/doc/cud_user1.docx"});
            migrationBuilder.InsertData(
               table: "Tutor",
               columns: new[] { "UsuarioId", "CertUniDisc" },
               values: new object[] {  "2",
                                        "/user/doc/cud_user2.docx"});

            migrationBuilder.InsertData(
               table: "Tutor",
               columns: new[] { "UsuarioId", "CertUniDisc" },
               values: new object[] {  "3",
                                        "/user/doc/cud_user3.docx"});

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Nombre", "Apellido", "FechaNacimiento", "DiagnosticoTEA", "Sexo", "TutorId" },
                values: new object[] {  "Andrés",
                                        "Zona",
                                        "2013/10/02",
                                        "/user/pac/img/andreszona.jpg" ,
                                        "M" ,
                                        "1"});
            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Nombre", "Apellido", "FechaNacimiento", "DiagnosticoTEA", "Sexo", "TutorId" },
                values: new object[] {  "Mariano",
                                        "Zona",
                                        "2010/12/22",
                                        "/user/pac/img/marianozona.jpg" ,
                                        "M" ,
                                        "1"});

        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompananteEspecialidad");

            migrationBuilder.DropTable(
                name: "AcompananteObraSocial");

            migrationBuilder.DropTable(
                name: "DisponibilidadesSemanales");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Propuesta");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "ObrasSociales");

            migrationBuilder.DropTable(
                name: "Acompanante");

            migrationBuilder.DropTable(
                name: "EstadoPropuestas");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
