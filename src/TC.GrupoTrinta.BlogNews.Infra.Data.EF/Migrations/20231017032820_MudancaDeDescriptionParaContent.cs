using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TC.GrupoTrinta.BlogNews.Infra.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class MudancaDeDescriptionParaContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "News",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "News",
                newName: "Description");
        }
    }
}
