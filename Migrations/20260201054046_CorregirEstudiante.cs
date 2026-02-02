using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAcademico.Migrations
{
    /// <inheritdoc />
    public partial class CorregirEstudiante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Matriculas_MatriculaId",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Calificaciones");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Estudiantes",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Estudiantes",
                newName: "EstudianteId");

            migrationBuilder.RenameColumn(
                name: "FechaRegistro",
                table: "Calificaciones",
                newName: "Fecha");

            migrationBuilder.AlterColumn<int>(
                name: "MatriculaId",
                table: "Calificaciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EstudianteId",
                table: "Matriculas",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId",
                table: "Calificaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_EstudianteId",
                table: "Calificaciones",
                column: "EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Cursos_CursoId",
                table: "Calificaciones",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_EstudianteId",
                table: "Calificaciones",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "EstudianteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Matriculas_MatriculaId",
                table: "Calificaciones",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "MatriculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Estudiantes_EstudianteId",
                table: "Matriculas",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "EstudianteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_CursoId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_EstudianteId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Matriculas_MatriculaId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Estudiantes_EstudianteId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_EstudianteId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_CursoId",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_EstudianteId",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "Calificaciones");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Estudiantes",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Estudiantes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Calificaciones",
                newName: "FechaRegistro");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MatriculaId",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Calificaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Matriculas_MatriculaId",
                table: "Calificaciones",
                column: "MatriculaId",
                principalTable: "Matriculas",
                principalColumn: "MatriculaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
