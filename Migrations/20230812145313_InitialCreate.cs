using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace customerapi.Migrations
{
    /// Initial migration
    public partial class InitialCreate : Migration
    {
        /// Create the customer table
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("PrimaryKey", "true")
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "varchar", nullable: true),
                    last_name = table.Column<string>(type: "varchar", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                }
            );
        }

        /// Drop the customer table
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer"
            );
        }
    }
}
