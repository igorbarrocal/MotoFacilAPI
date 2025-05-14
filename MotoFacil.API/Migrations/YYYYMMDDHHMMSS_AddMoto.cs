using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoFacil.Migrations
{
    public partial class AddMoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOTOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", Oracle.EntityFrameworkCore.Metadata.OracleValueGenerationStrategy.IdentityColumn),
                    PLACA = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    COR = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    CATEGORIA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTOS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MOTOS");
        }
    }
}

